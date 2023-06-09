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

            CreateMap<CarAddDto, Car>();
            CreateMap<Car, CarAddDto>();

            CreateMap<CarUpdateDto, Car>();
            CreateMap<Car, CarUpdateDto>();

            CreateMap<CarDetailDto, Car>();
            CreateMap<Car, CarDetailDto>();

        }
    }
}
