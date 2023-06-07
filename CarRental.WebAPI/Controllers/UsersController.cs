using CarRental.Business.Abstract;
using CarRental.Entities.DTOs.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        IUserService _userService; 
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-users")]

        public  async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpGet("users/{userId}")]

        public async Task<IActionResult> GetUserById(int userId)
        {
            var result = await _userService.GetByIdAsync(userId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete("delete-user")]

        public async Task<IActionResult> DeletePerson(int userId)
        {
            var result = await _userService.DeleteAsync(userId);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPut("update-user")]

        public async Task<IActionResult> UpdatePerson(UserUpdateDto userUpdateDto)
        {
            var result = await _userService.UpdateAsync(userUpdateDto);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
