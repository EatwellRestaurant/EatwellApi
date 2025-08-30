using AutoMapper;
using Business.Abstract;
using Business.Constants.Messages;
using Core.ResponseModels;
using DataAccess.Abstract;
using Entities.Dtos.HeadOffice;

namespace Business.Concrete
{
    public class HeadOfficeManager : IHeadOfficeService
    {
        readonly IHeadOfficeDal _headOfficeDal;
        readonly IMapper _mapper;


        public HeadOfficeManager(IHeadOfficeDal headOfficeDal, IMapper mapper)
        {
            _headOfficeDal = headOfficeDal;
            _mapper = mapper;
        }




        public async Task<DataResponse<HeadOfficeDto>> GetAsync()
            => new(_mapper.Map<HeadOfficeDto>
                (await _headOfficeDal
                .GetAsNoTrackingAsync(h => h.Id == 1)), 
                CommonMessages.EntityFetch);
    }
}
