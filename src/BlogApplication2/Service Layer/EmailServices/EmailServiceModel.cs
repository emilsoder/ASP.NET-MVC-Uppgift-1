using BlogApplication2.Data;
using System.Linq;

namespace BlogApplication2.Service.EmailServices
{
    public class EmailServiceModel
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string smtpDomain { get; set; }
        public string toEmail { get; set; }
        public string toName { get; set; }
        public int smtpPortNumber { get; set; }

        public void GetEmailData(InfoServiceDBContext _context)
        {
            foreach (var item in (from c in _context.EmailProviderInformation select c))
            {
                userName = item.UserName;
                password = item.Password;
                smtpDomain = item.SmtpDomain;
                smtpPortNumber = item.SmtpPortNumber;
                toEmail = item.ToEmail;
                toName = item.ToName;
            }
        }
    }
}
