using EatwellApi.Application.Abstractions.Repositories.MealCategory;
using EatwellApi.Application.Abstractions.Services.MealCategory;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using DomainMealCategory = EatwellApi.Domain.Entities.MealCategory;

namespace EatwellApi.Persistence.Services.MealCategory
{
    public class MealCategoryManager(IMealCategoryReadRepository readRepository) : IMealCategoryService
    {
        readonly IMealCategoryReadRepository _readRepository = readRepository;


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
