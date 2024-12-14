using Application.Features.Employees.Command.CreateEmployee;
using Application.Features.Employees.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        [HttpPost("Add")]

        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto EmployeeDto)
        {
            CreateEmployeeCommand createEmployeeCommand = new()
            {
                CompanyId = EmployeeDto.CompanyId,
                Description = EmployeeDto.Description,
                UserId = GetUserId()
            };

            EmployeeDto result = await Mediator.Send(createEmployeeCommand);
            return Created("", result);
        }
    }
}
