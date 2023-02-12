using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public Company() { 
            Services = new HashSet<Service>();
            Employees = new HashSet<Employee>();
        }

        public Company(int id, string name, string description, int userId) : this()
        {
            Id = id;
            Name = name;
            Description = description;
            UserId = userId;
        }
    }
}
