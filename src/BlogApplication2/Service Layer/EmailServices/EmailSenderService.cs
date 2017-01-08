using System;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using BlogApplication2.Data;

namespace BlogApplication2.Service.EmailServices
{
    
    public class EmailSenderService
    {
        private readonly InfoServiceDBContext _context;
        public EmailSenderService(InfoServiceDBContext context)
        {
            _context = context;
        }
        public async Task SendEmailAsync(string _fromName, string _fromEmail, string _message, string _subject, string _category)
        {
            EmailProviderInformation epi = new EmailProviderInformation();
            epi.GetEmailData(_context);
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_fromName, _fromEmail.Trim()));
            message.To.Add(new MailboxAddress(epi.ToName, epi.ToEmail));
            message.Subject = _subject;
            message.Date = DateTime.Now;

            message.Body = new TextPart("plain")
            {
                Text = ""
                + "Category: \n" + _category
                + "\n\n"
                + "Message: \n" + _message
            };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.ConnectAsync(epi.SmtpDomain, epi.SmtpPortNumber, true);
                await client.AuthenticateAsync(epi.UserName, epi.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}