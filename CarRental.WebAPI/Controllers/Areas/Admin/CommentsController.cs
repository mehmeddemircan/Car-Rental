using CarRental.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers.Areas.Admin
{

    [Area("Admin")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {

        ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetComments()
        {
            var result = await _commentService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{commentId:int}")]
        public async Task<IActionResult> GetCommentById(int commentId)
        {
            var result = await _commentService.GetByIdAsync(commentId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("[action]/{carId:int}")]

        public async Task<IActionResult> GetCommentsByCarId (int carId)
        {
            var result = await _commentService.GetListAsync(x => x.CarId == carId);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet]
        [Route("[action]/{userId:int}")]

        public async Task<IActionResult> GetUserComments(int userId)
        {
            var result = await _commentService.GetListAsync(x => x.UserId == userId);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
