using AutoMapper;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.BrandDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Mappings
{
    public class BrandProfile : Profile
    {

        public BrandProfile()
        {

            CreateMap<BrandAddDto, Brand>();
            CreateMap<Brand, BrandAddDto>();

            CreateMap<BrandUpdateDto, Brand>();
            CreateMap<Brand, BrandUpdateDto>();

            CreateMap<BrandDetailDto, Brand>();
            CreateMap<Brand,BrandDetailDto>();

        }
    }
}
