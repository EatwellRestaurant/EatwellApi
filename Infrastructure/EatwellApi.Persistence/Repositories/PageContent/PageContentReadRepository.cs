using EatwellApi.Application.Abstractions.Repositories.PageContent;
using EatwellApi.Persistence.Context;
using DomainPageContent = EatwellApi.Domain.Entities.PageContent;

namespace EatwellApi.Persistence.Repositories.PageContent
{
    public class PageContentReadRepository : ReadRepository<DomainPageContent>, IPageContentReadRepository
    {
        public PageContentReadRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
