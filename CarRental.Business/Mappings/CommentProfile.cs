using AutoMapper;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs.CommentDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Mappings
{
    public class CommentProfile : Profile
    {

        public CommentProfile()
        {
            CreateMap<CommentAddDto, Comment>();
            CreateMap<Comment, CommentAddDto>();

            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Comment, CommentUpdateDto>();

            CreateMap<CommentDetailDto, Comment>();
            CreateMap<Comment, CommentDetailDto>()
                   .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.User.LastName));
              

            
        }
    }
}
