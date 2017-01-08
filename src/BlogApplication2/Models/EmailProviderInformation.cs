using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogApplication2.Data
{
    public class EmailProviderInformation
    {
        //public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string SmtpDomain { get; set; }
        public int SmtpPortNumber { get; set; }
        public string ToEmail { get; set; }
        public string ToName { get; set; }

        public void GetEmailData(InfoServiceDBContext _context)
        {
            foreach (var e in (from c in _context.EmailProviderInformation select c))
            {
                UserName = e.UserName;
                Password = e.Password;
                SmtpDomain = e.SmtpDomain;
                SmtpPortNumber = e.SmtpPortNumber;
                ToEmail = e.ToEmail;
                ToName = e.ToName;
            }
        }
    }
}
