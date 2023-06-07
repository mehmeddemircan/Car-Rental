
using CarRental.Business.Abstract;
using CarRental.Core.Entities.Concrete.Auth;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.DTOs.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  CarRental.Business.Concrete
{
    public class UserManager : IUserService
    {

        IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaims(user);
        }

        public void Add(User user)
        {
          
            _userRepository.AddAsync(user);
        }

        public User GetByMail(string email)
        {
            return _userRepository.Get(u => u.Email == email);
        }

        public async Task<IEnumerable<UserDetailDto>> GetListAsync()
        {

            List<UserDetailDto> userDetailDtos = new List<UserDetailDto>();

              var response = await _userRepository.GetListAsync();
            foreach (var item in response.ToList())
            {

                userDetailDtos.Add(new UserDetailDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    Status = item.Status
                });

            }
            return userDetailDtos; 
                
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
           var user = await _userRepository.GetAsync(x => x.Id == id);
            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Status = user.Status
            };
            return userDto; 
        }

        public Task<bool> DeleteAsync(int id)
        {
<<<<<<< Updated upstream
            throw new NotImplementedException();
=======
            var getUser = await _userRepository.GetAsync(x => x.Id == userUpdateDto.Id);


            User user = new User()
            {
                Id = userUpdateDto.Id,
                FirstName = userUpdateDto.FirstName,
                LastName = userUpdateDto.LastName,
                Email = userUpdateDto.Email,
                Gender = userUpdateDto.Gender,
                Status = userUpdateDto.Status,
                //todo: Şifre Güncellemede eklenecek
                PasswordHash = getUser.PasswordHash,
                PasswordSalt = getUser.PasswordSalt,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Address = userUpdateDto.Address,
                CreatedDate = getUser.CreatedDate,
                CreatedBy = getUser.CreatedBy,
                UpdatedDate = DateTime.Now,
                UpdatedBy = 1


            };

            var userUpdate = await _userRepository.UpdateAsync(user);
            UserUpdateDto newUserUpdateDto = new UserUpdateDto()
            {
                Id = userUpdateDto.Id,
                FirstName = userUpdateDto.FirstName,
                LastName = userUpdateDto.LastName,
                Email = userUpdateDto.Email,
                Gender = userUpdateDto.Gender,
                Status = userUpdateDto.Status,
                DateOfBirth = userUpdateDto.DateOfBirth,
                Address = userUpdateDto.Address,

            };
            return newUserUpdateDto;

>>>>>>> Stashed changes
        }
    }
}
