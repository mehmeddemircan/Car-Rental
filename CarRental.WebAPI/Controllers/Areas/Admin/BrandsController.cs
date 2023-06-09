using CarRental.Business.Abstract;
using CarRental.Entities.DTOs.BrandDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers.Areas.Admin
{
    [Area("Admin")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {

        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddNewbrand([FromForm] BrandAddDto brandAddDto)
        {
            var result = await _brandService.AddAsync(brandAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{brandId:int}")]
        public async Task<IActionResult> DeleteBrand(int brandId)
        {
            var result = await _brandService.DeleteAsync(brandId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateBrand([FromForm] BrandUpdateDto brandUpdateDto)
        {
            var result = await _brandService.UpdateAsync(brandUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
