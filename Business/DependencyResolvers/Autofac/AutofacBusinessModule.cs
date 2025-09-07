using Autofac;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Mapping;
using Business.Security;
using Business.Security.JWT;
using Castle.DynamicProxy;
using Core.Utilities.Email;
using Core.Utilities.Email.Sendinblue;
using Core.Utilities.FileHelper;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FileHelper>().As<IFileHelper>().InstancePerLifetimeScope();
            builder.RegisterType<SendinblueService>().As<IEmailService>().SingleInstance();
            
            builder.RegisterType<DashboardManager>().As<IDashboardService>().InstancePerLifetimeScope();
            builder.RegisterType<BranchStatisticsManager>().As<IBranchStatisticsService>().InstancePerLifetimeScope();
            builder.RegisterType<EmployeeStatisticsManager>().As<IEmployeeStatisticsService>().InstancePerLifetimeScope();

            builder.RegisterType<BranchManager>().As<IBranchService>().InstancePerLifetimeScope();
            builder.RegisterType<EfBranchDal>().As<IBranchDal>().InstancePerLifetimeScope();

            builder.RegisterType<BranchImageManager>().As<IBranchImageService>().InstancePerLifetimeScope();
            builder.RegisterType<EfBranchImageDal>().As<IBranchImageDal>().InstancePerLifetimeScope();

            builder.RegisterType<BranchEmployeeManager>().As<IBranchEmployeeService>().InstancePerLifetimeScope();
            builder.RegisterType<EfBranchEmployeeDal>().As<IBranchEmployeeDal>().InstancePerLifetimeScope();

            builder.RegisterType<EvaluationManager>().As<IEvaluationService>().InstancePerLifetimeScope();
            builder.RegisterType<EfEvaluationDal>().As<IEvaluationDal>().InstancePerLifetimeScope();

            builder.RegisterType<MealCategoryManager>().As<IMealCategoryService>().InstancePerLifetimeScope();
            builder.RegisterType<EfMealCategoryDal>().As<IMealCategoryDal>().InstancePerLifetimeScope();

            builder.RegisterType<ProductManager>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<EfProductDal>().As<IProductDal>().InstancePerLifetimeScope();

            builder.RegisterType<ReservationManager>().As<IReservationService>().InstancePerLifetimeScope();
            builder.RegisterType<EfReservationDal>().As<IReservationDal>().InstancePerLifetimeScope();

            builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerLifetimeScope();

            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserDal>().As<IUserDal>().InstancePerLifetimeScope();
            
            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().InstancePerLifetimeScope();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().InstancePerLifetimeScope();

            builder.RegisterType<CityManager>().As<ICityService>().InstancePerLifetimeScope();
            builder.RegisterType<EfCityDal>().As<ICityDal>().InstancePerLifetimeScope();

            builder.RegisterType<TableManager>().As<ITableService>().InstancePerLifetimeScope();
            builder.RegisterType<EfTableDal>().As<ITableDal>().InstancePerLifetimeScope();
            
            builder.RegisterType<PageContentManager>().As<IPageContentService>().InstancePerLifetimeScope();
            builder.RegisterType<EfPageContentDal>().As<IPageContentDal>().InstancePerLifetimeScope();

            builder.RegisterType<OrderManager>().As<IOrderService>().InstancePerLifetimeScope();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>().InstancePerLifetimeScope();

            builder.RegisterType<HeadOfficeManager>().As<IHeadOfficeService>().InstancePerLifetimeScope();
            builder.RegisterType<EfHeadOfficeDal>().As<IHeadOfficeDal>().InstancePerLifetimeScope();
            
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().InstancePerLifetimeScope();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>().InstancePerLifetimeScope();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                });
        }
    }
}
