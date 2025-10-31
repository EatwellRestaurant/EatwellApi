using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos
{
    public class LookupDto<TType> : IDto
    {
        public TType Id { get; set; }
        public string Name { get; set; }
    }

}
