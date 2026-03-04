using EatwellApi.Application.Abstractions.Repositories.MealCategory;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DomainMealCategory = EatwellApi.Domain.Entities.MealCategory;

namespace EatwellApi.Application.Features.Queries.MealCategories.GetOverview
{
    public class GetMealCategoryOverviewQueryHandler(IMealCategoryReadRepository readRepository) : IRequestHandler<GetMealCategoryOverviewQueryRequest, DataResponse<MealCategoriesOverviewDto>>
    {
        readonly IMealCategoryReadRepository _readRepository = readRepository;



        public async Task<DataResponse<MealCategoriesOverviewDto>> Handle(GetMealCategoryOverviewQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<DomainMealCategory> query = _readRepository
                .Where(m => !m.IsDeleted)
                .AsNoTracking();


            DateTime now = DateTime.UtcNow;

            MealCategoriesOverviewStatistics statistics = await query
            .GroupBy(_ => 1)
            .Select(g => new MealCategoriesOverviewStatistics(
                g.Count(),
                g.Count(m => m.IsActive == true),
                g.Count(m => m.IsActive != true),
                g.Count(m =>
                    m.CreateDate.Month == now.Month &&
                    m.CreateDate.Year == now.Year)
            ))
            .SingleAsync(cancellationToken);


            List<MealCategoryListDto> mealCategories = await query
                .OrderByDescending(m => m.CreateDate)
                .ApplyPagination(request)
                .Select(m => new MealCategoryListDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    IsActive = m.IsActive,
                    CreateDate = m.CreateDate,
                    ProductCount = m.Products.Count(p => !p.IsDeleted)
                })
                .ToListAsync(cancellationToken);


            return new(new()
            {
                TotalMealCategories = statistics.TotalMealCategories,
                ActiveMealCategories = statistics.ActiveMealCategories,
                InactiveMealCategories = statistics.InactiveMealCategories,
                ThisMonthAddedMealCategories = statistics.ThisMonthAddedMealCategories,
                MealCategories = new(mealCategories, request, statistics.TotalMealCategories)
            },
            CommonMessages.StatisticsFetched);
        }
    }
}
