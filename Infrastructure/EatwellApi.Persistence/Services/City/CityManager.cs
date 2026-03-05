using EatwellApi.Application.Abstractions.Repositories.City;
using EatwellApi.Application.Abstractions.Services.City;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Dtos.City;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using Microsoft.EntityFrameworkCore;
using DomainCity = EatwellApi.Domain.Entities.City;

namespace EatwellApi.Persistence.Services.City
{
    public class CityManager(ICityReadRepository readRepository) : ICityService
    {
        readonly ICityReadRepository _readRepository = readRepository;


        public async Task<DataResponse<List<CityLookupDto>>> GetLookupAsync()
           => new(await _readRepository
               .GetAllQueryable()
               .Select(c => new CityLookupDto
               {
                   Id = c.Id,
                   Name = c.Name,
               })
               .ToListAsync(),
               CommonMessages.EntityListed);



        public async Task<PaginationResponse<CityListDto>> GetAllAsync(PaginationRequest request)
        {
            IQueryable<DomainCity> query = _readRepository
                .GetAllQueryable();


            return new(await query
                .ApplyPagination(request)
                .Select(c => new CityListDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    BranchCount = c.Branches.Count(b => !b.IsDeleted),
                })
                .ToListAsync(),
                request,
                await query.CountAsync());
        }
    }
}
