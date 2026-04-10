using EatwellApi.Application.Abstractions.Repositories.MealCategory;
using EatwellApi.Application.Abstractions.Services.MealCategory;
using EatwellApi.Application.Abstractions.Services.Product;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Exceptions.General;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DomainMealCategory = EatwellApi.Domain.Entities.MealCategory;

namespace EatwellApi.Persistence.Services.MealCategory
{
    public class MealCategoryManager(IMealCategoryReadRepository readRepository, IProductService productService) : IMealCategoryService
    {
        readonly IMealCategoryReadRepository _readRepository = readRepository;
        readonly IProductService _productService = productService;

        public async Task<DataResponse<List<MealCategoryLookupDto>>> GetLookupAsync()
           => new(await _readRepository
               .Where(m => !m.IsDeleted)
               .OrderByDescending(m => m.CreateDate)
               .AsNoTracking()
               .Select(m => new MealCategoryLookupDto
               {
                   Id = m.Id,
                   Name = m.Name,
               })
               .ToListAsync(),
               CommonMessages.EntityListed);




        public async Task<MealCategoryProductDto> GetByIdForUserAsync(PaginationRequest request, int id)
        {
             MealCategoryProductDto mealCategoryProductDto = await _readRepository
                .Where(m => m.Id == id && !m.IsDeleted && m.IsActive)
                .AsNoTracking()
                .Select(m => new MealCategoryProductDto
                {
                    Name = m.Name,
                    IconPath = m.IconPath,
                    ImagePath = m.ImagePath
                })
                .SingleOrDefaultAsync()
                ??
                throw new EntityNotFoundException("Menü");


            mealCategoryProductDto.Products = await _productService.GetAllByMealCategoryIdAsync(request, id);


            return mealCategoryProductDto;
        }




        public async Task<PaginationResponse<MealCategoryListDto>> GetAllAsync(PaginationRequest request)
            => await GetMealCategoriesByConditionAsync(
                request,
                m => true,
                m => new MealCategoryListDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    IsActive = m.IsActive,
                    CreateDate = m.CreateDate,
                    ProductCount = m.Products.Count(p => !p.IsDeleted),
                });




        public async Task<PaginationResponse<MealCategoryDisplayDto>> GetActiveForUserAsync(PaginationRequest request)
            => await GetMealCategoriesByConditionAsync(
                request,
                m => m.IsActive && !m.IsDeleted,
                m => new MealCategoryDisplayDto
                {
                    Id = m.Id,
                    Name = m.Name,
                    ImagePath = m.ImagePath,
                });




        public async Task<PaginationResponse<MealCategoryLookupDto>> GetActiveAsync(PaginationRequest request)
            => await GetMealCategoriesByConditionAsync(
                request,
                m => m.IsActive,
                m => new MealCategoryLookupDto
                {
                    Id = m.Id,
                    Name = m.Name,
                });





        #region Private Methods

        private async Task<PaginationResponse<TDto>> GetMealCategoriesByConditionAsync<TDto>(
            PaginationRequest request,
            Expression<Func<DomainMealCategory, bool>> condition,
            Expression<Func<DomainMealCategory, TDto>> selector)
        {
            IQueryable<DomainMealCategory> query = _readRepository
              .Where(condition)
              .Where(m => !m.IsDeleted);


            List<TDto> mealCategoryListDtos = await query
                .OrderByDescending(m => m.CreateDate)
                .AsNoTracking()
                .ApplyPagination(request)
                .Select(selector)
                .ToListAsync();


            return new(mealCategoryListDtos, request, await query.CountAsync());
        }

        #endregion
    }
}
