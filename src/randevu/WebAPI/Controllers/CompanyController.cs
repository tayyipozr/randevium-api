using Application.Features.Auths.Command.Login;
using Application.Features.Auths.Command.Register;
using Application.Features.Auths.Dtos;
using Application.Features.Auths.Queries;
using Application.Features.Companies.Command.CreateCompany;
using Application.Features.Companies.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : BaseController
    {
        [HttpPost("Company")]

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
