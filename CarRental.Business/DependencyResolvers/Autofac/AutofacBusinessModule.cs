﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.Core.Utilities.Interceptors;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.DataAccess.Abstract;
using CarRental.DataAccess.Concrete.EntityFramework;
using Castle.DynamicProxy;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();


            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<BrandRepository>().As<IBrandRepository>();

            builder.RegisterType<ModelManager>().As<IModelService>();
            builder.RegisterType<ModelRepository>().As<IModelRepository>();

            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<ColorRepository>().As<IColorRepository>();

            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<CarRepository>().As<ICarRepository>();

            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<RentalRepository>().As<IRentalRepository>();


            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<CommentRepository>().As<ICommentRepository>();

            builder.RegisterType<PackageManager>().As<IPackageService>();
            builder.RegisterType<PackageRepository>().As<IPackageRepository>();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<UserOperationClaimRepository>().As<IUserOperationClaimRepository>();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<OperationClaimRepository>().As<IOperationClaimRepository>();

            builder.RegisterType<SellerFormManager>().As<ISellerFormService>();
            builder.RegisterType<SellerFormRepository>().As<ISellerFormRepository>();

            builder.RegisterType<CloudinaryManager>().As<ICloudinaryService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
