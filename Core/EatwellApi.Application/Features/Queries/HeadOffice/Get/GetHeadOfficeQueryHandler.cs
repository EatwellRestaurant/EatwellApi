using AutoMapper;
using EatwellApi.Application.Abstractions.Repositories.HeadOffice;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Dtos.HeadOffice;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.HeadOffice.Get
{
    public class GetHeadOfficeQueryHandler : IRequestHandler<GetHeadOfficeQueryRequest, DataResponse<HeadOfficeDto>>
    {
        readonly IHeadOfficeReadRepository _readRepository;
        readonly IMapper _mapper;

        public GetHeadOfficeQueryHandler(IHeadOfficeReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }


        public async Task<DataResponse<HeadOfficeDto>> Handle(GetHeadOfficeQueryRequest request, CancellationToken cancellationToken)
            => new(
                _mapper.Map<HeadOfficeDto>
                (await _readRepository
                .GetAsNoTrackingAsync(h => h.Id == 1)),
                CommonMessages.EntityFetch);
        
    }
}
