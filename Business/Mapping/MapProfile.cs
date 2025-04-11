using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.MealCategory;
using Entities.Dtos.User;

namespace Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<User, UserListDto>();


            CreateMap<User, UserDetailDto>();


            CreateMap<MealCategory, MealCategoryListDto>();


            CreateMap<MealCategory, MealCategoryDetailDto>();
        }
    }
}
