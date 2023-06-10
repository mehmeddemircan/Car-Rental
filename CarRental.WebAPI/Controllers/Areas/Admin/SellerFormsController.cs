using CarRental.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers.Areas.Admin
{
    [Area("Admin")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class SellerFormsController : ControllerBase
    {

        ISellerFormService _sellerFormService;

        public SellerFormsController(ISellerFormService sellerFormService)
        {
            _sellerFormService = sellerFormService; 
        }
    }
}
