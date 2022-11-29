using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class InvalidEmailFormatException : Exception
    {
        public InvalidEmailFormatException(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
