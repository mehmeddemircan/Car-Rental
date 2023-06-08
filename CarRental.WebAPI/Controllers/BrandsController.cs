using CarRental.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {

        IBrandService _brandService; 
        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetBrands()
        {
            var result = await _brandService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{brandId:int}")]
        public async Task<IActionResult> GetBrandById(int brandId)
        {
            var result = await _brandService.GetByIdAsync(brandId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
