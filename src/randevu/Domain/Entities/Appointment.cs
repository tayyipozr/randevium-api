using Application.Features.Appointments.Constants;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Appointment : Entity
    {
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<EmployeeService> EmployeeServices { get; set; }
        public Appointment()
        {
            AppointmentStatus = AppointmentStatus.Pending;
            EmployeeServices = new HashSet<EmployeeService>();
        }
        public Appointment(int id, DateTime createdTime, DateTime updatedTime, int userId) : this()
        {
            Id = id;
            CreatedTime = createdTime;
            UpdatedTime = updatedTime;
            UserId = userId;
        }
    }
}
