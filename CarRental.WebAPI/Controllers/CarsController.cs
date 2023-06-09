using CarRental.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetCars()
        {
            var result = await _carService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{carId:int}")]
        public async Task<IActionResult> GetCarById(int carId)
        {
            var result = await _carService.GetByIdAsync(carId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
