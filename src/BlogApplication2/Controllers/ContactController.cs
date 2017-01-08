using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogApplication2.Data;
using BlogApplication2.Models;
using BlogApplication2.Service;
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
        public IActionResult Index()
        {
            ViewData["Message"] = "Kontakta oss";
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
                return RedirectToAction("MessageSent");
            }
            return View(model);
        }
        public ActionResult MessageSent()
        {
            return View();
        }
    }
}
