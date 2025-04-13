using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.General;
using Core.ResponseModels;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete
{
    public class BranchManager : IBranchService
    {
        readonly IBranchDal _branchDal;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        readonly ICityService _cityService;

        public BranchManager(IBranchDal branchDal, IMapper mapper, IUnitOfWork unitOfWork, ICityService cityService)
        {
            _branchDal = branchDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cityService = cityService;
        }



        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(BranchUpsertDtoValidator), Priority = 2)]
        public async Task<CreateSuccessResponse> Add(BranchUpsertDto upsertDto)
        {
            await CheckIfCityIdExists(upsertDto.CityId);

            await CheckIfBranchNameExists(upsertDto.Name);

            await CheckIfBranchAddressExists(upsertDto.Address);

            
            await _branchDal.AddAsync(_mapper.Map<Branch>(upsertDto));
            await _unitOfWork.SaveChangesAsync();
            
            return new CreateSuccessResponse(CommonMessages.EntityAdded);
        }


        [SecuredOperation("admin")]
        public IResult Delete(Branch branch)
        {
            _branchDal.Remove(branch);
            return new SuccessResult(BranchMessages.BranchDeleted);
        }


        [SecuredOperation("admin")]
        public async Task<IDataResult<Branch?>> Get(int id)
        {
            return new SuccessDataResult<Branch?>(await _branchDal.GetAsync(b => b.Id == id), BranchMessages.BranchWasBrought);
        }


        [SecuredOperation("admin")]
        public async Task<DataResponse<List<AdminBranchListDto>>> GetAllForAdmin()
        => new DataResponse<List<AdminBranchListDto>>(_mapper.Map<List<AdminBranchListDto>>
                (await _branchDal
                .GetAllQueryable()
                .Include(b => b.City)
                .OrderByDescending(m => m.CreateDate)
                .ToListAsync()),
                CommonMessages.EntityListed);


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BranchUpsertDtoValidator))]
        public IResult Update(Branch branch)
        {
            _branchDal.Update(branch);
            return new SuccessResult(BranchMessages.BranchUpdated);
        }





        #region BusinessRules

        private async Task CheckIfCityIdExists(int cityId)
        {
            if (!await _cityService.AnyAsync(c => c.Id == cityId))
                throw new EntityNotFoundException("Şube");
        }
        
        
        private async Task CheckIfBranchNameExists(string branchName)
        {
            if (await _branchDal.AnyAsync(b => b.Name == branchName && !b.IsDeleted))
                throw new EntityAlreadyExistsException("şube ismi");
        }


        private async Task CheckIfBranchAddressExists(string branchAddress)
        {
            if (await _branchDal.AnyAsync(b => b.Address == branchAddress && !b.IsDeleted))
                throw new EntityAlreadyExistsException("adres");
        }

        #endregion
    }
}
