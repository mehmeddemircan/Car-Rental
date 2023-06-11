using CarRental.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        IPackageService _packageService; 

        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        [Route("[action]/{modelId:int}")]

        public async Task<IActionResult> GetPackagesByModel(int modelId )
        {
            var result = await _packageService.GetListAsync(x => x.ModelId == modelId);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }
    }
}
