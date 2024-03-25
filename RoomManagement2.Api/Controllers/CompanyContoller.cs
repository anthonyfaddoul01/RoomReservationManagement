using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RoomManagement2.Api.Resources;
using RoomManagement2.Api.Validators;
using RoomManagement2.Core.Models;
using RoomManagement2.Core.Services;
using RoomManagement2.Services;

namespace RoomManagement2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyContoller : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyContoller(ICompanyService companyService, IMapper mapper)
        {
            this._mapper = mapper;
            this._companyService = companyService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<CompanyResource>>> GetAllCompanies()
        {
            var companies = await _companyService.GetAllCompanies();
            var companyResources = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyResource>>(companies);

            return Ok(companyResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyResource>> GetCompanyById(int id)
        {
            var company = await _companyService.GetCompanyById(id);
            var companyResource = _mapper.Map<Company, CompanyResource>(company);

            return Ok(companyResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<CompanyResource>> CreateCompany([FromBody] SaveCompanyResource saveCompanyResource)
        {
            var validator = new SaveCompanyResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCompanyResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var companyToCreate = _mapper.Map<SaveCompanyResource, Company>(saveCompanyResource);

            var newCompany = await _companyService.CreateCompany(companyToCreate);

            var company = await _companyService.GetCompanyById(newCompany.Id);

            var companyResource = _mapper.Map<Company, CompanyResource>(company);

            return Ok(companyResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyResource>> UpdateCompany(int id, [FromBody] SaveCompanyResource saveCompanyResource)
        {
            var validator = new SaveCompanyResourceValidator();
            var validationResult = await validator.ValidateAsync(saveCompanyResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); // this needs refining, but for demo it is ok

            var companyToBeUpdated = await _companyService.GetCompanyById(id);

            if (companyToBeUpdated == null)
                return NotFound();

            var company = _mapper.Map<SaveCompanyResource, Company>(saveCompanyResource);

            await _companyService.UpdateCompany(companyToBeUpdated, company);

            var updatedCompany = await _companyService.GetCompanyById(id);

            var updatedCompanyResource = _mapper.Map<Company, CompanyResource>(updatedCompany);

            return Ok(updatedCompanyResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _companyService.GetCompanyById(id);

            await _companyService.DeleteCompany(company);

            return NoContent();
        }
    }
}
