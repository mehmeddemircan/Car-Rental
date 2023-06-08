using AutoMapper;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Mappings
{
    public class ModelProfile : Profile
    {

        public ModelProfile()
        {

            CreateMap<ModelAddDto, Model>();
            CreateMap<Model, ModelAddDto>();

            CreateMap<ModelUpdateDto, Model>();
            CreateMap<Model, ModelUpdateDto>();

            CreateMap<ModelDetailDto, Model>();
            CreateMap<Model, ModelDetailDto>();


            CreateMap<ModelListDto, Model>();
            CreateMap<Model, ModelListDto>();
        }
    }
}
