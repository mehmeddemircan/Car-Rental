using CarRental.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> MakePayment(int totalAmount)
        {
       
        
                try
                {
                    var clientSecret = await _paymentService.CreatePaymentIntentAsync(totalAmount);
                    return Ok(clientSecret);
                }
                catch (StripeException ex)
                {
                    return BadRequest(ex.Message);
                }
            
        }
    }
}
