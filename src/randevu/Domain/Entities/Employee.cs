using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Employee : Entity
    {
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual Company? Company { get; set; }
        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; }
        public virtual ICollection<AppointmentTimeSlot> AppointmentTimeSlots { get; set; }

        public Employee() 
        {
            AppointmentDetails = new HashSet<AppointmentDetail>();
            AppointmentTimeSlots = new HashSet<AppointmentTimeSlot>();
        }

        public Employee(int id, string description, int companyId, int userId) : this()
        {
            Id = id;
            Description = description;
            CompanyId = companyId;
            UserId = userId;
        }
    }
}
