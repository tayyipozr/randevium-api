using Application.Features.Appointments.Constants;
using Application.Features.Companies.Dtos;
using Domain.Entities;

namespace Application.Features.Appointments.Dtos
{
    public class CreateAppointmentDto
    {
        public DateTime AppointmentDateTime { get; set; }
        public int CompanyId { get; set; }
    }
}
