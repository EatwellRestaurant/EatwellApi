using EatwellApi.Application.Abstractions.Repositories.Branch;
using EatwellApi.Application.Abstractions.Services.Branch;
using EatwellApi.Application.Dtos.Branch;
using Microsoft.EntityFrameworkCore;

namespace EatwellApi.Persistence.Services.Branch
{
    public class BranchManager(IBranchReadRepository readRepository) : IBranchService
    {
        readonly IBranchReadRepository _readRepository = readRepository;



        public async Task<List<BaseBranchDto>> GetLookupAsync()
            => await _readRepository
            .GetAllQueryable(b => !b.IsDeleted)
            .Select(b => new BaseBranchDto()
            {
                Id = b.Id,
                Name = b.Name
            })
            .ToListAsync();
    }
}
