using Core.Security.Entities;
using Core.Security.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AppUser : User
    {
        public virtual Company Company { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public AppUser() { 

        }

        public AppUser(int id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash,
                bool status, AuthenticatorType authenticatorType)
            : this()
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
            AuthenticatorType = authenticatorType;
           
        }
    }
}
