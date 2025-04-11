using AutoMapper;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserListDto>();


            CreateMap<MealCategory, MealCategoryListDto>();
        }
    }
}
