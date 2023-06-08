using CarRental.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers.Areas.Admin
{
    [Area("Admin")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService; 
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _userService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }
    }
}
