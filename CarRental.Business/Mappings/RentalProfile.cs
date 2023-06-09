using AutoMapper;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.RentalDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Mappings
{
    public class RentalProfile : Profile
    {

        public RentalProfile()
        {
            CreateMap<RentalAddDto, Rental>();
            CreateMap<Rental, RentalAddDto>();

            CreateMap<RentalUpdateDto, Rental>();
            CreateMap<Rental, RentalUpdateDto>();

            CreateMap<RentalDetailDto, Rental>();
            CreateMap<Rental, RentalDetailDto>()
                      //.ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Car.Brand.BrandName))
                .ForMember(dest => dest.DailyPrice, opt => opt.MapFrom(src => src.Car.DailyPrice))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Car.Description))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));

           
        }

    }
}
