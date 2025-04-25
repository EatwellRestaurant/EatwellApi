using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.Constants.Messages.Entity;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.Branch;
using Core.Exceptions.General;
using Core.ResponseModels;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Entities.Dtos.MealCategory;
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
        public async Task<DeleteSuccessResponse> Delete(int branchId)
        {
            // Oluşturduğumuz sorguda rezervasyonların saat dilimini de dikkate alıyoruz ve
            // DateTime.Now, runtime değeri olduğu için doğrudan sorguya dahil edilirse,
            // EF Core tarafından doğru bir şekilde SQL sorgusuna dönüştürülemez. Çünkü değeri sürekli değişiyor.
            // Bunun yerine DateTime.Now değerini bir değişkene atayıp, 
            // sorguya sabit bir değer olarak dahil ettik. Ve bu, sorgunun doğru çalışmasını sağladı.

            var now = DateTime.Now; 

            Branch? branch = await _branchDal
                .Where(b => b.Id == branchId)
                .Include(b => b.Reservations
                    .Where(r => r.ReservationDate >= now && !r.IsDeleted))
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Şube");


            if (branch.Reservations.Any())
                throw new BranchHasReservationsException();

            branch.DeleteDate = DateTime.Now;
            branch.IsDeleted = true;

            _branchDal.Update(branch);
            await _unitOfWork.SaveChangesAsync();

            return new DeleteSuccessResponse(CommonMessages.EntityDeleted);
        }



        [SecuredOperation("admin")]
        public async Task<DataResponse<BranchDetailDto>> GetForAdmin(int branchId)
        {
            Branch? branch = await _branchDal
                .Where(b => b.Id == branchId)
                .Include(b => b.City)
                .AsNoTracking()
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Şube");


            return new DataResponse<BranchDetailDto>
                           (_mapper.Map<BranchDetailDto>(branch),
                           CommonMessages.EntityFetch);
        }



        [SecuredOperation("admin")]
        public async Task<DataResponse<List<AdminBranchListDto>>> GetAllForAdmin()
        => new DataResponse<List<AdminBranchListDto>>(_mapper.Map<List<AdminBranchListDto>>
                (await _branchDal
                .GetAllQueryable()
                .Include(b => b.City)
                .AsNoTracking()
                .OrderByDescending(b => b.CreateDate)
                .ToListAsync()),
                CommonMessages.EntityListed);



        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(BranchUpsertDtoValidator), Priority = 2)]
        public async Task<UpdateSuccessResponse> Update(int branchId, BranchUpsertDto upsertDto)
        {
            Branch? branch = await _branchDal
                .Where(b => b.Id == branchId)
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Şube");


            if (branch.CityId != upsertDto.CityId)
                await CheckIfCityIdExists(upsertDto.CityId);


            if (branch.Name != upsertDto.Name) 
                await CheckIfBranchNameExists(upsertDto.Name, branchId);


            if (branch.Address != upsertDto.Address) 
                await CheckIfBranchAddressExists(upsertDto.Address, branchId);


            _mapper.Map(upsertDto, branch);
            branch.UpdateDate = DateTime.Now;

            _branchDal.Update(branch);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateSuccessResponse(BranchMessages.BranchUpdated);
        }





        #region BusinessRules

        private async Task CheckIfCityIdExists(int cityId)
        {
            if (!await _cityService.AnyAsync(c => c.Id == cityId))
                throw new EntityNotFoundException("Şehir");
        }
        
        
        private async Task CheckIfBranchNameExists(string branchName, int? branchId = null)
        {
            if (await _branchDal.AnyAsync(b => b.Name == branchName && !b.IsDeleted && branchId.HasValue && b.Id != branchId))
                throw new EntityAlreadyExistsException("şube ismi");
        }


        private async Task CheckIfBranchAddressExists(string branchAddress, int? branchId = null)
        {
            if (await _branchDal.AnyAsync(b => b.Address == branchAddress && !b.IsDeleted && branchId.HasValue && b.Id != branchId))
                throw new EntityAlreadyExistsException("adres");
        }

        #endregion
    }
}
