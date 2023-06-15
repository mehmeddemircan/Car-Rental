using AutoMapper;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.CompanyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Mappings
{
    public class CompanyProfile : Profile
    {

        public CompanyProfile()
        {

            CreateMap<CompanyAddDto, Company>();
            CreateMap<Company, CompanyAddDto>();

            CreateMap<CompanyUpdateDto, Company>();
            CreateMap<Company, CompanyUpdateDto>();

            CreateMap<CompanyDetailDto, Company>();
            CreateMap<Company, CompanyDetailDto>();

        }
    }
}
