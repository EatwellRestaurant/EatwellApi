using EatwellApi.Application.Abstractions.Repositories.Branch;
using EatwellApi.Application.Abstractions.Services.Branch;
using EatwellApi.Application.Dtos.Branch;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using Microsoft.EntityFrameworkCore;
using DomainBranch = EatwellApi.Domain.Entities.Branch;

namespace EatwellApi.Persistence.Services.Branch
{
    public class BranchManager(IBranchReadRepository readRepository) : IBranchService
    {
        readonly IBranchReadRepository _readRepository = readRepository;



        public async Task<List<BranchLookupDto>> GetLookupAsync()
            => await _readRepository
            .GetAllQueryable(b => !b.IsDeleted)
            .Select(b => new BranchLookupDto()
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToListAsync();



        public async Task<PaginationResponse<BranchListWithCityDto>> GetAllAsync(PaginationRequest request)
        {
            IQueryable<DomainBranch> query = _readRepository
                .GetAllQueryable(b => !b.IsDeleted);


            return new(await query
                .OrderByDescending(b => b.CreateDate)
                .ApplyPagination(request)
                .Select(b => new BranchListWithCityDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    Email = b.Email,
                    Address = b.Address,
                    CityId = b.CityId,
                    CityName = b.City.Name,
                })
                .ToListAsync(),
                request,
                await query.CountAsync());
        }
    }
}
