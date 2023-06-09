using CarRental.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService; 
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetRentals()
        {
            var result = await _rentalService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{rentalId:int}")]
        public async Task<IActionResult> GetRentalById(int rentalId)
        {
            var result = await _rentalService.GetByIdAsync(rentalId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
