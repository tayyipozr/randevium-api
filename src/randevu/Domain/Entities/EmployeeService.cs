using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class EmployeeService : Entity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public EmployeeService()
        {
        }
        public EmployeeService(int id, int employeeId, int serviceId, int appointmentId) : this()
        {
            Id = id;
            EmployeeId = employeeId; 
            AppointmentId = appointmentId;
            ServiceId = serviceId;
        }
    }
}
