using AutoMapper;
using EatwellApi.Application.Abstractions.Repositories.Product;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Dtos.Product;
using EatwellApi.Application.Wrappers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DomainProduct = EatwellApi.Domain.Entities.Product;

namespace EatwellApi.Application.Features.Queries.Product.GetBySelection
{
    public class GetBySelectionStatusQueryHandler : IRequestHandler<GetBySelectionStatusQueryRequest, DataResponse<List<ProductDisplayDto>>>
    {
        readonly IProductReadRepository _readRepository;
        readonly IMapper _mapper;

        public GetBySelectionStatusQueryHandler(IProductReadRepository readRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _mapper = mapper;
        }



        public async Task<DataResponse<List<ProductDisplayDto>>> Handle(GetBySelectionStatusQueryRequest request, CancellationToken cancellationToken)
        {
            List<DomainProduct> products = await _readRepository
                .GetAllQueryable(p => !p.IsDeleted && p.IsActive && p.IsSelected == request.IsSelected)
                .OrderBy(p => p.Order)
                .ThenByDescending(p => p.CreateDate)
                .ToListAsync();


            return new DataResponse<List<ProductDisplayDto>>
                (_mapper.Map<List<ProductDisplayDto>>(products), CommonMessages.EntityListed);
        }
    }
}
