using AutoMapper;
using EatwellApi.Application.Abstractions.Repositories.PageContent;
using EatwellApi.Application.Dtos.PageContent;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Exceptions.General;
using MediatR;
using DomainPageContent = EatwellApi.Domain.Entities.PageContent;

namespace EatwellApi.Application.Features.Queries.PageContent.GetByPage
{
    public class GetPageContentByPageQueryHandler : IRequestHandler<GetPageContentByPageQueryRequest, DataResponse<List<PageContentListDto>>>
    {
        readonly IPageContentReadRepository _readRepository;
        readonly IMapper _mapper;

        public GetPageContentByPageQueryHandler(IPageContentReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }


        public async Task<DataResponse<List<PageContentListDto>>> Handle(GetPageContentByPageQueryRequest request, CancellationToken cancellationToken)
        {
            List<DomainPageContent> pageContents = await _readRepository
                .GetAllAsync(p => p.Page == request.PageEnum);


            if (pageContents.Count <= 0)
                throw new EntityNotFoundException("Sayfa");


            return new DataResponse<List<PageContentListDto>>
                (_mapper.Map<List<PageContentListDto>>(pageContents));
        }
    }
}
