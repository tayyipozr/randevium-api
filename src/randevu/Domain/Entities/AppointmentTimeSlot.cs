using Application.Features.Appointments.Constants;
using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class AppointmentTimeSlot : Entity
    {
        public int ServiceId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentTimeSlotStatus AppointmentTimeSlotStatus { get; set; }

        public virtual Service? Service { get; set; }
        public virtual Employee? Employee { get; set; }

        public AppointmentTimeSlot()
        {
            AppointmentTimeSlotStatus = AppointmentTimeSlotStatus.Available;
        }

        public AppointmentTimeSlot(int id, int serviceId, int employeeId, DateTime startTime, DateTime endTime, 
            AppointmentTimeSlotStatus appointmentTimeSlotStatus)
        {
            Id = id;
            ServiceId = serviceId;
            EmployeeId = employeeId;
            StartTime = startTime;
            EndTime = endTime;
            AppointmentTimeSlotStatus = appointmentTimeSlotStatus;
        }
    }
}
