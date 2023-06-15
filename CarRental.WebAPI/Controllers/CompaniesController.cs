using CarRental.Business.Abstract;
using CarRental.Entities.DTOs.CompanyDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {

        ICompanyService _companyService;
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("[action]")]

        public async Task<IActionResult> GetCompanies()
        {
            var result = await _companyService.GetListAsync();
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }


        [HttpGet]
        [Route("[action]/{companyId:int}")]
        public async Task<IActionResult> GetCompaniesById(int companyId)
        {
            var result = await _companyService.GetByIdAsync(companyId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("[action]")]

        public async Task<IActionResult> CreateCompany( CompanyAddDto companyAddDto)
        {
            var result = await _companyService.AddAsync(companyAddDto);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();

        }

        [HttpDelete]
        [Route("[action]/{companyId:int}")]
        public async Task<IActionResult> DeleteCompany(int companyId)
        {
            var result = await _companyService.DeleteAsync(companyId);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest();
        }


        [HttpPut]
        [Route("[action]")]

        public async Task<IActionResult> UpdateCompany(CompanyUpdateDto companyUpdateDto)
        {
            var result = await _companyService.UpdateAsync(companyUpdateDto);

            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }



    }
}
