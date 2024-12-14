using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Company : Entity
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Phone { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }

        public virtual AppUser? User { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

        public Company() { 
            Services = new HashSet<Service>();
            Employees = new HashSet<Employee>();
            Appointments = new HashSet<Appointment>();
        }

        public Company(int id, string name, string address, string city, string region, string phone, string description, int userId) : this()
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            Region = region;
            Phone = phone;
            Description = description;
            UserId = userId;
        }
    }
}
