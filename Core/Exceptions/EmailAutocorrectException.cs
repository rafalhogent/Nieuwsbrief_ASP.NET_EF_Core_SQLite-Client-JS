using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class EmailAutocorrectException : Exception
    {
        public EmailAutocorrectException(string autocorrect, string typedEmail) : base()
        {
            Autocorrect = autocorrect;
            TypedEmail = typedEmail;
        }

        public string TypedEmail { get; set; }
        public string Autocorrect { get; init; }
    }
}
