namespace Application.Features.AppointmentDetails.Dtos
{
    public class AddAppointmentDto
    {
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
