using EatwellApi.Application.Abstractions.Repositories.Product;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Dtos.Product;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DomainProduct = EatwellApi.Domain.Entities.Product;

namespace EatwellApi.Application.Features.Queries.Product.GetOverview
{
    public class GetProductOverviewQueryHandler(IProductReadRepository readRepository) : IRequestHandler<GetProductOverviewQueryRequest, DataResponse<ProductsOverviewDto>>
    {
        readonly IProductReadRepository _readRepository = readRepository;



        public async Task<DataResponse<ProductsOverviewDto>> Handle(GetProductOverviewQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<DomainProduct> query = _readRepository
                .Where(p => !p.IsDeleted)
                .AsNoTracking();


            DateTime now = DateTime.UtcNow;

            ProductsOverviewStatistics statistics = await query
            .GroupBy(_ => 1)
            .Select(g => new ProductsOverviewStatistics(
                g.Count(),
                g.Count(p => p.IsActive == true),
                g.Count(p => p.IsActive != true),
                g.Count(p =>
                    p.CreateDate.Month == now.Month &&
                    p.CreateDate.Year == now.Year)
            ))
            .SingleAsync(cancellationToken);


            List<ProductListWithMealCategoryDto> products = await query
                .OrderByDescending(p => p.CreateDate)
                .ApplyPagination(request)
                .Select(p => new ProductListWithMealCategoryDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    MealCategoryId = p.MealCategoryId,
                    MealCategoryName = p.MealCategory.Name,
                    IsActive = p.IsActive,
                    CreateDate = p.CreateDate,
                })
                .ToListAsync(cancellationToken);


            return new(new()
            {
                TotalProducts = statistics.TotalProducts,
                ActiveProducts = statistics.ActiveProducts,
                InactiveProducts = statistics.InactiveProducts,
                ThisMonthAddedProducts = statistics.ThisMonthAddedProducts,
                Products = new(products, request, statistics.TotalProducts)
            },
            CommonMessages.StatisticsFetched);
        }
    }
}
