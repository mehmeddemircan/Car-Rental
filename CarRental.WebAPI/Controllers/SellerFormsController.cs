using CarRental.Business.Abstract;
using CarRental.Entities.DTOs.SellerFormDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerFormsController : ControllerBase
    {

        ISellerFormService _sellerFormService;

        public SellerFormsController(ISellerFormService sellerFormService)
        {
            _sellerFormService = sellerFormService;
        }

        [HttpGet]
        [Route("[action]/{userId:int}")]
        public async Task<IActionResult> GetUserSellerForms(int userId)
        {
            var result = await _sellerFormService.GetListAsync(x => x.UserId == userId);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> SendSellerForm(SellerFormAddDto sellerFormAddDto)
        {
            var result = await _sellerFormService.AddAsync(sellerFormAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{sellerFormId:int}")]
        public async Task<IActionResult> DeleteSellerForm(int sellerFormId)
        {
            var result = await _sellerFormService.DeleteAsync(sellerFormId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateSellerForm(SellerFormUpdateDto sellerFormUpdateDto)
        {
            var result = await _sellerFormService.UpdateAsync(sellerFormUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
