using Application.Features.Appointments.Constants;
using Application.Features.Companies.Dtos;
using Domain.Entities;

namespace Application.Features.Appointments.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public int CompanyId { get; set; }
        public GetCompanyDto Company { get; set; }
    }
}
