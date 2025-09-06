using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation.HeadOffice;
using Core.Aspects.Autofac.Validation;
using Core.ResponseModels;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.HeadOffice;
using Entities.Enums.OperationClaim;

namespace Business.Concrete
{
    public class HeadOfficeManager : IHeadOfficeService
    {
        readonly IHeadOfficeDal _headOfficeDal;
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;


        public HeadOfficeManager(IHeadOfficeDal headOfficeDal, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _headOfficeDal = headOfficeDal;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }




        public async Task<DataResponse<HeadOfficeDto>> GetAsync()
            => new(_mapper.Map<HeadOfficeDto>
                (await _headOfficeDal
                .GetAsNoTrackingAsync(h => h.Id == 1)), 
                CommonMessages.EntityFetch);



        [SecuredOperation(OperationClaimEnum.Admin, Priority = 1)]
        [ValidationAspect(typeof(HeadOfficeDtoValidator), Priority = 2)]
        public async Task<UpdateSuccessResponse> UpdateAsync(HeadOfficeDto headOfficeDto)
        {
            HeadOffice? headOffice = await _headOfficeDal
                .GetAsync(h => h.Id == 1);


            _mapper.Map(headOfficeDto, headOffice);
            await _unitOfWork.SaveChangesAsync();

            return new(CommonMessages.EntityUpdated);
        }
    }
}
