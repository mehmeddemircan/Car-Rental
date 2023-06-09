using CarRental.Business.Abstract;
using CarRental.Entities.DTOs.ColorDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers.Areas.Admin
{

    [Area("Admin")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        IColorService _colorService; 
        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddNewColor(ColorAddDto colorAddDto)
        {
            var result = await _colorService.AddAsync(colorAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{colorId:int}")]
        public async Task<IActionResult> DeleteColor(int colorId)
        {
            var result = await _colorService.DeleteAsync(colorId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateColor(ColorUpdateDto colorUpdateDto)
        {
            var result = await _colorService.UpdateAsync(colorUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
