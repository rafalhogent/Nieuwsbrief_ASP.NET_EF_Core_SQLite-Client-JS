﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public class EmailExistsException : Exception
    {
        public EmailExistsException(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
