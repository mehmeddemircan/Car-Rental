using CarRental.Business.Abstract;
using CarRental.Entities.DTOs.CommentDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentService _commentService; 
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddNewComment(CommentAddDto commentAddDto)
        {
            var result = await _commentService.AddAsync(commentAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{commentId:int}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var result = await _commentService.DeleteAsync(commentId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateComment( CommentUpdateDto commentUpdateDto)
        {
            var result = await _commentService.UpdateAsync(commentUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
