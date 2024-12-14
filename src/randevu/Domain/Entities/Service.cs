using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Service : Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public int CompanyId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual ICollection<AppointmentDetail> AppointmentDetails { get; set; }
        public virtual ICollection<AppointmentTimeSlot> AppointmentTimeSlots { get; set; }
        public Service()
        {
            AppointmentDetails = new HashSet<AppointmentDetail>();
            AppointmentTimeSlots = new HashSet<AppointmentTimeSlot>();
        }

        public Service(int id, string name, string description, decimal cost, int companyId) : this()
        {
            Id = id;
            Name = name;
            Description = description;
            Cost = cost;
            CompanyId = companyId;
        } 
    }
}
