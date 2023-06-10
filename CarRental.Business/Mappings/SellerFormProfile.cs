using AutoMapper;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.SellerFormDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Mappings
{
    public class SellerFormProfile : Profile
    {

        public SellerFormProfile()
        {
            CreateMap<SellerFormAddDto, SellerForm>();
            CreateMap<SellerForm, SellerFormAddDto>();

            CreateMap<SellerFormUpdateDto, SellerForm>();
            CreateMap<SellerForm, SellerFormUpdateDto>();

            CreateMap<SellerFormDetailDto, SellerForm>();
            CreateMap<SellerForm, SellerFormDetailDto>();
        }
    }
}
