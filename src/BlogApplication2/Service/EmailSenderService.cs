using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;
using System.Net.Security;
using System.Net;

namespace BlogApplication2.Service
{
    public class EmailSenderService
    {
        public async Task SendEmailAsync(string _fromName, string _fromEmail, string _message, string _subject, string _category)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_fromName, _fromEmail.Trim()));
            message.To.Add(new MailboxAddress("Emil Sodergren", "kontakt@emilsodergren.se"));
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

                await client.ConnectAsync("smtp01.binero.se", 465, true);
                await client.AuthenticateAsync("labb@emilsodergren.se", "123qweasd");
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}