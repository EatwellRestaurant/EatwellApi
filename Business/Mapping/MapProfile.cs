using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Entities.Dtos.City;
using Entities.Dtos.Country;
using Entities.Dtos.MealCategory;
using Entities.Dtos.User;

namespace Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.Now));


            CreateMap<User, UserListDto>();


            CreateMap<User, UserDetailDto>();


            CreateMap<MealCategory, MealCategoryListDto>();


            CreateMap<MealCategory, MealCategoryDetailDto>();


            CreateMap<Country, AdminCountryListDto>();


            CreateMap<Country, CountryDto>();

            
            CreateMap<City, CityDto>();


            CreateMap<City, CityWithBranchesDto>();


            CreateMap<City, CityWithBranchCountDto>()
                .ForMember(dest => dest.BranchCount, opt => opt.MapFrom(src => src.Branches.Count));


            CreateMap<Branch, BranchDto>();


            CreateMap<Branch, AdminBranchListDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));
            
            
            CreateMap<BranchUpsertDto, Branch>();


            CreateMap<Branch, BranchDetailDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));
        }
    }
}
