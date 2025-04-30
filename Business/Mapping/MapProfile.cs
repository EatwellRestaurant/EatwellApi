using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Entities.Dtos.City;
using Entities.Dtos.MealCategory;
using Entities.Dtos.Product;
using Entities.Dtos.Reservation;
using Entities.Dtos.User;

namespace Business.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            #region User

            CreateMap<UserUpdateDto, User>()
                .ForMember(dest => dest.Password, opt => opt.Ignore())
                .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => DateTime.Now));


            CreateMap<User, UserListDto>();


            CreateMap<User, UserDetailDto>();

            #endregion



            #region MealCategory

            CreateMap<MealCategory, MealCategoryListDto>();


            CreateMap<MealCategory, MealCategoryDetailDto>();

            #endregion



            #region City

            CreateMap<City, CityDto>();


            CreateMap<City, CityWithBranchesDto>();


            CreateMap<City, CityWithBranchCountDto>()
                .ForMember(dest => dest.BranchCount, opt => opt.MapFrom(src => src.Branches.Count));

            #endregion



            #region Branch

            CreateMap<Branch, BranchDto>();


            CreateMap<Branch, AdminBranchListDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));
            
            
            CreateMap<BranchUpsertDto, Branch>();


            CreateMap<Branch, BranchDetailDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));

            #endregion



            #region Reservation

            CreateMap<ReservationUpsertDto, Reservation>();

            #endregion



            #region Product

            CreateMap<Product, ProductListDto>();


            CreateMap<Product, ProductListWithMealCategoryDto>()
                .ForMember(dest => dest.MealCategoryName, opt => opt.MapFrom(src => src.MealCategory.Name));


            CreateMap<Product, ProductDetailDto>();

            #endregion

        }
    }
}
