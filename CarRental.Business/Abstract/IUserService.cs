﻿using CarRental.Core.Entities.Concrete.Auth;
using CarRental.Core.Utilities.Results;
using CarRental.Entities.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);

        Task<IDataResult<IEnumerable<UserDetailDto>>> GetListAsync();

        Task<IDataResult<UserDto>> GetByIdAsync(int id);

        Task<IDataResult<UserUpdateDto>> UpdateAsync(UserUpdateDto userUpdateDto);

        Task<IDataResult<bool>> DeleteAsync(int id);

    }
}
