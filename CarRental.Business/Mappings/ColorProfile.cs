using AutoMapper;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.ColorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Mappings
{
    public class ColorProfile : Profile
    {

        public ColorProfile()
        {

            CreateMap<ColorAddDto, Color>();
            CreateMap<Color, ColorAddDto>();

            CreateMap<ColorUpdateDto, Color>();
            CreateMap<Color, ColorUpdateDto>();

            CreateMap<ColorDetailDto, Color>();
            CreateMap<Color, ColorDetailDto>();

        }
    }
}
