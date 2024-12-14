using Application.Features.Appointments.Dtos;
using Application.Features.Appointments.Queries;
using Application.Features.Services.Command.CreateService;
using Application.Features.Services.Dtos;
using Application.Features.Services.Models;
using Application.Features.Services.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : BaseController
    {
        [HttpPost("Add")]

        public async Task<IActionResult> AddService([FromBody] ServiceDto ServiceDto)
        {
            CreateServiceCommand createServiceCommand = new()
            {
                CompanyId = ServiceDto.CompanyId,
                Description = ServiceDto.Description,
                Name = ServiceDto.Name,
                Cost = ServiceDto.Cost,
            };

            ServiceDto result = await Mediator.Send(createServiceCommand);
            return Created("", result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetServices([FromQuery] int companyId)
        {
            GetServiceQuery getServiceQuery = new GetServiceQuery
            {
                CompanyId = companyId
            };

            ServiceModel result = await Mediator.Send(getServiceQuery);
            return Ok(result);
        }
    }
}
