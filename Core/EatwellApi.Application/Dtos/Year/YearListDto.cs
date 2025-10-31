using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Year
{
    public class YearListDto : IDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

    }
}
