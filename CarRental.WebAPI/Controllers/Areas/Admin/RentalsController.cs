using CarRental.Business.Abstract;
using CarRental.Entities.DTOs.RentalDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers.Areas.Admin
{
    [Area("Admin")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {

        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddNewRental(RentalAddDto rentalAddDto)
        {
            var result = await _rentalService.AddAsync(rentalAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{rentalId:int}")]
        public async Task<IActionResult> DeleteRental(int rentalId)
        {
            var result = await _rentalService.DeleteAsync(rentalId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateRental(RentalUpdateDto rentalUpdateDto)
        {
            var result = await _rentalService.UpdateAsync(rentalUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
