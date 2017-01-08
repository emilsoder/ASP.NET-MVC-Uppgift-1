using System;
using System.Collections.Generic;

namespace BlogApplication2.Data
{
    public class EmailProviderInformation
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SmtpDomain { get; set; }
        public int SmtpPortNumber { get; set; }
        public string ToEmail { get; set; }
        public string ToName { get; set; }
    }
}
