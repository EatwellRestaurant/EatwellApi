using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Exceptions.General;
using DataAccess.Abstract;
using Entities.Dtos.OperationClaim;
using Entities.Enums.OperationClaim;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal, IMapper mapper)
        {
            _operationClaimDal = operationClaimDal;
        }



        public async Task<string> GetClaim(int operationClaimId)
        {
            string? operationClaimName = await _operationClaimDal
               .Where(o => o.Id == operationClaimId)
               .Select(o => o.Name)
               .SingleOrDefaultAsync()
               ??
               throw new EntityNotFoundException("Yetki");


            return operationClaimName;
        }



        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task CheckIfOperationClaimIdExists(int operationClaimId)
        {
            if (!await _operationClaimDal.AnyAsync(o => o.Id == operationClaimId))
                throw new EntityNotFoundException("Rol");
        }




        [SecuredOperation(OperationClaimEnum.Admin)]
        public async Task<List<OperationClaimListDto>> GetAllAsync()
            => await _operationClaimDal
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
