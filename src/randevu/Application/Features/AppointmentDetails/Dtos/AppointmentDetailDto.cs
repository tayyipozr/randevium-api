using Application.Features.Appointments.Dtos;
using Application.Features.Employees.Dtos;
using Application.Features.Services.Dtos;

namespace Application.Features.AppointmentDetails.Dtos
{
    public class AppointmentDetailDto
    {
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }

        public AppointmentDto? Appointment { get; set; }
        public ServiceDto? Service { get; set; }
        public EmployeeDto? Employee { get; set; }
    }
}
