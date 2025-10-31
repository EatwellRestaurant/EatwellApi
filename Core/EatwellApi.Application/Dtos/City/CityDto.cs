using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.City
{
    public class CityDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
