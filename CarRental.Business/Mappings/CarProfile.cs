using AutoMapper;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.CarDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Mappings
{
    public class CarProfile : Profile
    {

        public CarProfile()
        {

            CreateMap<CarAddDto, Car>()
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(imageFile => new CarImage { Url = imageFile.FileName }).ToList()));
            CreateMap<Car, CarAddDto>();

            CreateMap<CarUpdateDto, Car>();
            CreateMap<Car, CarUpdateDto>();

            CreateMap<CarImageDto, Car>();
            CreateMap<Car, CarImageDto>();
            CreateMap<CarImage, string>().ConvertUsing(src => src.Url);

            CreateMap<CarDetailDto, Car>();
            CreateMap<Car, CarDetailDto>()

                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName))
                .ForMember(dest => dest.ColorName, opt => opt.MapFrom(src => src.Color.ColorName))
                .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model.ModelName))
                .ForMember(dest => dest.PackageName, opt => opt.MapFrom(src => src.Package.PackageName))

           .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(image => image.Url).ToList()));



            //.ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Brand.Id))
            //                                .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.BrandName));


        }
    }
}
