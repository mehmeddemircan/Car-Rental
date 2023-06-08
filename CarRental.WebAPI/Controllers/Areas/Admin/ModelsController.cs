using CarRental.Business.Abstract;
using CarRental.Entities.DTOs.ModelDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers.Areas.Admin
{
    [Area("Admin")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {

        IModelService _modelService; 

        public ModelsController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddNewModel(ModelAddDto modelAddDto)
        {
            var result = await _modelService.AddAsync(modelAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{modelId:int}")]
        public async Task<IActionResult> DeleteModel(int modelId)
        {
            var result = await _modelService.DeleteAsync(modelId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateModel(ModelUpdateDto modelUpdateDto)
        {
            var result = await _modelService.UpdateAsync(modelUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
