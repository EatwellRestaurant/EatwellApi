using AutoMapper;
using Entities.Concrete;
using Entities.Dtos.Branch;
using Entities.Dtos.City;
using Entities.Dtos.MealCategory;
using Entities.Dtos.Order;
using Entities.Dtos.PageContent;
using Entities.Dtos.Product;
using Entities.Dtos.Reservation;
using Entities.Dtos.Table;
using Entities.Dtos.User;
using Entities.Enums;
using Microsoft.EntityFrameworkCore.SqlServer.Internal;

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


            CreateMap<Branch, BranchListDto>();


            CreateMap<Branch, BranchListWithCityDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));


            CreateMap<BranchInsertDto, Branch>();
            
            
            CreateMap<BranchUpdateDto, Branch>();


            CreateMap<Branch, BranchDetailDto>()
                .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));

            #endregion



            #region Reservation

            CreateMap<ReservationUpsertDto, Reservation>();


            CreateMap<Reservation, ReservationListDto>()
                .ForMember(dest => dest.TableNo, opt => opt.MapFrom(src => src.Table.No));


            CreateMap<Reservation, ReservationDetailDto>()
                .IncludeBase<Reservation,ReservationListDto>();


            #endregion



            #region Table

            CreateMap<TableInsertDto, Table>();


            CreateMap<TableUpdateDto, Table>();

            
            CreateMap<Table, TableListDto>();

            #endregion



            #region Product

            CreateMap<Product, ProductAdminListDto>();


            CreateMap<Product, ProductListWithMealCategoryDto>()
                .ForMember(dest => dest.MealCategoryName, opt => opt.MapFrom(src => src.MealCategory.Name));


            CreateMap<Product, ProductDetailDto>();


            CreateMap<Product, ProductDisplayDto>();

            #endregion



            #region PageContent

            CreateMap<PageContent, PageContentListDto>()
                .ForMember(dest => dest.SectionId, opt => opt.MapFrom(src => src.Section))
                .ForMember(dest => dest.SectionName, opt => opt.MapFrom(src => ((SectionEnum)src.Section).ToString()));

            #endregion




            #region Order

            CreateMap<OrderInsertDto, Order>();

            #endregion


        }
    }
}
