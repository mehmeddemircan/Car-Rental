using CarRental.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {

        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }


        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetColors()
        {
            var result = await _colorService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetColorswithPage(int pageNumber,int pageSize)
        {
            var result = await _colorService.GetListAsyncPagination(pageNumber,pageSize);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }



        [HttpGet]
        [Route("[action]/{colorId:int}")]
        public async Task<IActionResult> GetColorById(int colorId)
        {
            var result = await _colorService.GetByIdAsync(colorId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
