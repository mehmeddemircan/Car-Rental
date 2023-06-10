using AutoMapper;
using CarRental.Core.Entities.Concrete.Auth;
using CarRental.Entities.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Mappings
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<UserDetailDto, User>();
            CreateMap<User, UserDetailDto>().ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.OperationClaim.Name));

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>().ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.OperationClaim.Name));

            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserUpdateDto>();

        }
        
    }
}
