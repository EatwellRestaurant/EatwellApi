using EatwellApi.Application.Dtos.PageContent;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums;
using MediatR;

namespace EatwellApi.Application.Features.Queries.PageContent.GetByPage
{
    public class GetPageContentByPageQueryRequest : IRequest<DataResponse<List<PageContentListDto>>>
    {
        public PageEnum PageEnum { get; set; }

        public GetPageContentByPageQueryRequest(PageEnum page)
        {
            PageEnum = page;
        }
    }
}
