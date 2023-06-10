using CarRental.Business.Abstract;
using CarRental.Core.Entities.Concrete.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers.Areas.Admin
{
    [Area("Admin")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class OperationClaimsController : ControllerBase
    {

        IOperationClaimService _operationClaimService; 
        public OperationClaimsController(IOperationClaimService operationClaimService)
        {
            _operationClaimService = operationClaimService;
        }
        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddNewRole(OperationClaim operationClaim)
        {
            var result = await _operationClaimService.AddAsync(operationClaim);

            if (result != null)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetRoles()
        {
            var result = await _operationClaimService.GetAllAsync();

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{userId:int}")]
        public async Task<IActionResult> GetSingleRole(int id)
        {
            var result = await _operationClaimService.GetSingleAsync(x => x.Id == id);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpDelete]
        [Route("[action]/{id:int}")]

        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _operationClaimService.DeleteAsync(id);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateRole(OperationClaim operationClaim)
        {

            var result = await _operationClaimService.UpdateAsync(operationClaim);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
