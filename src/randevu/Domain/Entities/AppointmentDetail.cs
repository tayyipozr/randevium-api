using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class AppointmentDetail : Entity
    {
        public int AppointmentId { get; set; }
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }

        public virtual Appointment? Appointment { get; set; }
        public virtual Service? Service { get; set; }
        public virtual Employee? Employee { get; set; }

        public AppointmentDetail()
        {

        }
        public AppointmentDetail(int id, int appointmentId, int serviceId, int employeeId, decimal price, int duration) : this()
        {
            Id = id;
            AppointmentId = appointmentId;
            ServiceId = serviceId;
            EmployeeId = employeeId;
            Price = price;
            Duration = duration;
        }
    }
}
