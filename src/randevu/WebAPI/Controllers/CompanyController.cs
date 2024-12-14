using Application.Features.Companies.Command.CreateCompany;
using Application.Features.Companies.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : BaseController
    {
        [HttpPost("Add")]

        public async Task<IActionResult> AddCompany([FromBody] CompanyDto companyDto)
        {
            CreateCompanyCommand createCompanyCommand = new()
            {
                Name = companyDto.Name,
                Description = companyDto.Description,
                UserId = GetUserId()
            };

            CompanyDto result = await Mediator.Send(createCompanyCommand);
            return Created("", result);
        }
    }
}
