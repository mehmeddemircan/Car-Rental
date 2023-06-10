using CarRental.Business.Abstract;
using CarRental.Entities.DTOs.PackageDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers.Areas.Admin
{
    [Area("Admin")]
    [Route("api/[Area]/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {

        IPackageService _packageService;

        public PackagesController(IPackageService packageService)
        {
            _packageService = packageService;
        }


        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetPackages()
        {
            var result = await _packageService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{packageId:int}")]
        public async Task<IActionResult> GetPackageById(int packageId)
        {
            var result = await _packageService.GetByIdAsync(packageId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> AddNewPackage(PackageAddDto packageAddDto)
        {
            var result = await _packageService.AddAsync(packageAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{packageId:int}")]
        public async Task<IActionResult> DeletePackage(int packageId)
        {
            var result = await _packageService.DeleteAsync(packageId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdatePackage( PackageUpdateDto packageUpdateDto)
        {
            var result = await _packageService.UpdateAsync(packageUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
