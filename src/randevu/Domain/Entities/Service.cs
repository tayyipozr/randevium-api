using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Service : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<EmployeeService> EmployeeServices { get; set; }
        public Service()
        {

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
