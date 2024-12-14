using Application.Features.Appointments.Constants;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Appointment : Entity
    {
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; }
        public Appointment()
        {
            AppointmentStatus = AppointmentStatus.Pending;
            AppointmentDetails = new HashSet<AppointmentDetail>();
        }
        public Appointment(int id, DateTime createdTime, DateTime updatedTime, DateTime appointmentDateTime, 
            AppointmentStatus appointmentStatus, int userId, int companyId) : this()
        {
            Id = id;
            CreatedTime = createdTime;
            UpdatedTime = updatedTime;
            AppointmentDateTime = appointmentDateTime;
            AppointmentStatus = appointmentStatus;
            UserId = userId;
            CompanyId = companyId;
        }
    }
}
