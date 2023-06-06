
using CarRental.Core.Entities.Concrete.Auth;
using CarRental.Core.Utilities.Results;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.Entities.DTOs.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IAuthService
    {

        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
