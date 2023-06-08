using CarRental.Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {

        IModelService _modelService;
        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetModels()
        {
            var result = await _modelService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{modelId:int}")]
        public async Task<IActionResult> GetModelById(int modelId)
        {
            var result = await _modelService.GetByIdAsync(modelId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
