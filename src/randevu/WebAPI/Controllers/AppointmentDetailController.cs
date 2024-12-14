using Application.Features.AppointmentDetails.Command.CreateAppointmentDetail;
using Application.Features.AppointmentDetails.Dtos;
using Application.Features.AppointmentDetails.Queries;
using Application.Features.Appointments.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentDetailController : BaseController
    {
        [HttpPost("Add")]

        public async Task<IActionResult> AddAppointmentDetail([FromBody] AppointmentDetailDto appointmentDetailDto)
        {
            CreateAppointmentDetailCommand createAppointmentDetailCommand = new()
            {
                AppointmentId = appointmentDetailDto.AppointmentId,
                EmployeeId = appointmentDetailDto.EmployeeId,
                ServiceId = appointmentDetailDto.ServiceId,
                Price = appointmentDetailDto.Price,
                Duration = appointmentDetailDto.Duration
            };

            AppointmentDetailDto result = await Mediator.Send(createAppointmentDetailCommand);
            return Created("", result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAppointmentDetail([FromQuery] int id)
        {
            GetAppointmentDetailQuery getAppointmentDetailQuery = new GetAppointmentDetailQuery
            {
                AppointmentId = id
            };

            AppointmentDetailModel result = await Mediator.Send(getAppointmentDetailQuery);
            return Ok(result);
        }
    }
}
