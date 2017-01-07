using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApplication2.Models;
using System.Net;

using BlogApplication2.Service;

namespace BlogApplication2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Om bloggen foodbyemil";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Kontakta oss";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                EmailSenderService messageService = new EmailSenderService();
                await messageService.SendEmailAsync(model.FromName, model.FromEmail, model.Message, model.Subject, model.Category);
                return RedirectToAction("MessageSent");
            }
            return View(model);
        }
        public ActionResult MessageSent()
        {
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult IllegalOperation()
        {
            return View();
        }
    }
}
//MessageServices msgService = new MessageServices();
//msgService.SendEmailAsync();

//var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
//var message = new MailMessage();
//message.To.Add(new MailAddress("recipient@gmail.com"));  // replace with valid value 
//message.From = new MailAddress("sender@outlook.com");  // replace with valid value
//message.Subject = "Your email subject";
//message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
//message.IsBodyHtml = true;

//using (var smtp = new SmtpClient())
//{
//    var credential = new NetworkCredential
//    {
//        UserName = "user@outlook.com",  // replace with valid value
//        Password = "password"  // replace with valid value
//    };
//    smtp.Credentials = credential;
//    smtp.Host = "smtp-mail.outlook.com";
//    smtp.Port = 587;
//    smtp.EnableSsl = true;
//    await smtp.SendMailAsync(message);
//    return RedirectToAction("Sent");
//}