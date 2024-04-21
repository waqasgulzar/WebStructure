using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Common.Email
{
    public class EmailSettings
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string FromEmail { get; set; }

        public string Password { get; set; }

        public bool EnableSSL { get; set; }
    }
}
