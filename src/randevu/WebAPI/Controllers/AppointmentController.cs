using Application.Features.Appointments.Command.CreateAppointment;
using Application.Features.Appointments.Constants;
using Application.Features.Appointments.Dtos;
using Application.Features.Appointments.Models;
using Application.Features.Appointments.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentController : BaseController
    {
        [HttpPost("Add")]

        public async Task<IActionResult> AddAppointment([FromBody] CreateAppointmentDto createAppointmentDto)
        {
            CreateAppointmentCommand createAppointmentCommand = new()
            {
                AppointmentDateTime = createAppointmentDto.AppointmentDateTime.ToUniversalTime(),
                CompanyId = createAppointmentDto.CompanyId,
                UserId = GetUserId()
            };

            AppointmentDto result = await Mediator.Send(createAppointmentCommand);
            return Created("", result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetUserAppointments()
        {
            GetAppointmentsQuery getAppointmentQuery = new GetAppointmentsQuery
            {
                UserId = GetUserId(),
            };

            AppointmentModel result = await Mediator.Send(getAppointmentQuery);
            return Ok(result);
        }

    }
}
