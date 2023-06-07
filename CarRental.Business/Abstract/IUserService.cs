using CarRental.Core.Entities.Concrete.Auth;
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

        Task<IEnumerable<UserDetailDto>> GetListAsync();

        Task<UserDto> GetByIdAsync(int id);

        Task<UserUpdateDto> UpdateAsync(UserUpdateDto userUpdateDto);
        Task<bool> DeleteAsync(int id);

    }
}
