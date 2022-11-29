using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class EmailingServiceConfig
    {
        public string EMAIL_FROM { get; set; }
        public string SMTP_SERVER { get; set; }
        public string SMTP_USERNAME { get; set; }
        public string SMTP_PASSWORD { get; set; }
        public int SMTP_PORT { get; set; }


    }
}
