using EatwellApi.Application.Abstractions.Repositories.OperationClaim;
using EatwellApi.Application.Abstractions.Services.OperationClaim;
using EatwellApi.Application.Dtos.OperationClaim;
using EatwellApi.Domain.Enums.OperationClaim;
using Microsoft.EntityFrameworkCore;

namespace EatwellApi.Persistence.Services.OperationClaim
{
    public class OperationClaimManager(IOperationClaimReadRepository readRepository) : IOperationClaimService
    {
        readonly IOperationClaimReadRepository _readRepository = readRepository;


        public async Task<List<OperationClaimListDto>> GetAllAsync()
            => await _readRepository
            .GetAllQueryable(o =>
            o.Id != (int)OperationClaimEnum.Admin
            && o.Id != (int)OperationClaimEnum.User)
            .Select(o => new OperationClaimListDto()
            {
                Id = o.Id,
                Name = o.DisplayName,
            })
            .ToListAsync();
    }
}
