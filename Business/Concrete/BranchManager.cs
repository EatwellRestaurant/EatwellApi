using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.Branch;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions.Branch;
using Core.Exceptions.General;
using Core.ResponseModels;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Entities.Dtos.Product;
using Microsoft.EntityFrameworkCore;
using Service.Concrete;

namespace Business.Concrete
{
    public class BranchManager : Manager<Branch>, IBranchService
    {
        readonly IBranchDal _branchDal;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        readonly ICityService _cityService;

        public BranchManager(IBranchDal branchDal, IMapper mapper, IUnitOfWork unitOfWork, ICityService cityService) : base(branchDal)
        {
            _branchDal = branchDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _cityService = cityService;
        }



        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(BranchInsertDtoValidator), Priority = 2)]
        public async Task<CreateSuccessResponse> Add(BranchInsertDto insertDto)
        {
            await CheckIfCityIdExists(insertDto.CityId);

            await CheckIfBranchNameExists(insertDto.Name);

            await CheckIfBranchAddressExists(insertDto.Address);

            
            await _branchDal.AddAsync(_mapper.Map<Branch>(insertDto));
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

            DateTime now = DateTime.Now; 

            Branch? branch = await _branchDal
                .Where(b => b.Id == branchId && !b.IsDeleted)
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
                .Where(b => b.Id == branchId && !b.IsDeleted)
                .Include(b => b.City)
                .AsNoTracking()
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Şube");


            return new DataResponse<BranchDetailDto>
                           (_mapper.Map<BranchDetailDto>(branch),
                           CommonMessages.EntityFetch);
        }



        [SecuredOperation("admin")]
        public async Task<DataResponse<List<BranchListWithCityDto>>> GetAllForAdmin()
        => new DataResponse<List<BranchListWithCityDto>>(_mapper.Map<List<BranchListWithCityDto>>
                (await _branchDal
                .GetAllQueryable(b => !b.IsDeleted)
                .Include(b => b.City)
                .AsNoTracking()
                .OrderByDescending(b => b.CreateDate)
                .ToListAsync()),
                CommonMessages.EntityListed);



        [SecuredOperation("admin", Priority = 1)]
        public async Task<DataResponse<List<BranchListDto>>> GetAllForAdminByCityId(int cityId)
        {
            if (!await _cityService.AnyAsync(c => c.Id == cityId))
                throw new EntityNotFoundException("Şehir");


            return new DataResponse<List<BranchListDto>>(_mapper.Map<List<BranchListDto>>
                    (await _branchDal
                    .GetAllQueryable(b => b.CityId == cityId && !b.IsDeleted)
                    .OrderByDescending(b => b.CreateDate)
                    .ToListAsync()),
                    CommonMessages.EntityListed);
        }



        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(BranchUpdateDtoValidator), Priority = 2)]
        public async Task<UpdateSuccessResponse> Update(int branchId, BranchUpdateDto updateDto)
        {
            Branch? branch = await _branchDal
                .Where(b => b.Id == branchId && !b.IsDeleted)
                .SingleOrDefaultAsync()
                ?? throw new EntityNotFoundException("Şube");

            if (branch.Name != updateDto.Name) 
                await CheckIfBranchNameExists(updateDto.Name, branchId);


            if (branch.Address != updateDto.Address) 
                await CheckIfBranchAddressExists(updateDto.Address, branchId);


            _mapper.Map(updateDto, branch);
            branch.UpdateDate = DateTime.Now;

            _branchDal.Update(branch);
            await _unitOfWork.SaveChangesAsync();

            return new UpdateSuccessResponse(CommonMessages.EntityUpdated);
        }





        #region BusinessRules

        private async Task CheckIfCityIdExists(int cityId)
        {
            if (!await _cityService.AnyAsync(c => c.Id == cityId))
                throw new EntityNotFoundException("Şehir");
        }
        
        
        private async Task CheckIfBranchNameExists(string branchName, int? branchId = null)
        {
            if (await _branchDal.AnyAsync(b => b.Name == branchName && !b.IsDeleted && (branchId.HasValue ? b.Id != branchId : true)))
                throw new EntityAlreadyExistsException("şube ismi");
        }


        private async Task CheckIfBranchAddressExists(string branchAddress, int? branchId = null)
        {
            if (await _branchDal.AnyAsync(b => b.Address == branchAddress && !b.IsDeleted && (branchId.HasValue ? b.Id != branchId : true)))
                throw new EntityAlreadyExistsException("adres");
        }

        #endregion
    }
}
