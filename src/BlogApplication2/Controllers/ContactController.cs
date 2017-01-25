using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApplication2.Data;
using BlogApplication2.Models;
using BlogApplication2.Service.EmailServices;

namespace BlogApplication2.Controllers
{
    public class ContactController : Controller
    {
        private readonly InfoServiceDBContext _context;

        public ContactController(InfoServiceDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(string status)
        {
            ViewData["Message"] = "Kontakta oss";
            ViewData["StatusMessage"] = status;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(EmailFormModel model)
        {
            if (ModelState.IsValid)
            {
                EmailSenderService messageService = new EmailSenderService(_context);
                await messageService.SendEmailAsync(model.FromName, model.FromEmail, model.Message, model.Subject, model.Category);
                return RedirectToAction("Index", new { status = "OK" });
            }
            return View(model);
        }

        public IActionResult RedirectTo(string url)
        {
            switch (url.ToLower())
            {
                case "home":
                    RedirectToAction("Index", "Home");
                    break;
                case "blog":
                    RedirectToAction("Index", "BlogPosts");
                    break;
                case "contact":
                    RedirectToAction("Index", "Contact");
                    break;
                default:
                    RedirectToAction("Index", "Home");
                    break;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult MessageSent()
        {
            return View();
        }
    }
}
