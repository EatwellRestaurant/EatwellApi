using EatwellApi.Application.Dtos.HeadOffice;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.HeadOffice.Get
{
    public class GetHeadOfficeQueryRequest : IRequest<DataResponse<HeadOfficeDto>>
    {
    }
}
