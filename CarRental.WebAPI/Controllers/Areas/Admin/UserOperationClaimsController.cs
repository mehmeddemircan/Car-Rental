using CarRental.Business.Abstract;
using CarRental.Core.Entities.Concrete.Auth;
using CarRental.Entities.DTOs.UserOperationClaimDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers.Areas.Admin
{
    [Area("Admin")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        IUserOperationClaimService _userOperationClaimService;

        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddRoleToUser(UserOperationClaimAddDto userOperationClaimAddDto)
        {
            var result = await _userOperationClaimService.AddAsync(userOperationClaimAddDto);

            if (result != null)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetRolesOfUsers()
        {
            var result = await _userOperationClaimService.GetListAsync();

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{userId:int}")]
        public async Task<IActionResult> GetRolesOfSingleUser(int userId)
        {
            var result = await _userOperationClaimService.GetAsync(x => x.UserId == userId);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete]
        [Route("[action]/{id:int}")]

        public async Task<IActionResult> RemoveUserRole(int id)
        {
            var result = await _userOperationClaimService.DeleteAsync(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateRoleOfUser(UserOperationClaimUpdateDto userOperationClaimUpdateDto)
        {

            var result = await _userOperationClaimService.UpdateAsync(userOperationClaimUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
