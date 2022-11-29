using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Subscriber : BaseEntity
    {
        public Subscriber(string email, string? firstName = null, string? lastName = null) : base()
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Joined { get; set; } = DateTime.Now;
        public string Email { get; set; }
        public bool Active { get; set; } = true;
    }
}
