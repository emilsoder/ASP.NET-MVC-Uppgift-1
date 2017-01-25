using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogApplication2.Models;
using BlogApplication2.Models.ManageViewModels;
using BlogApplication2.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using BlogApplication2.Models.ViewModels.ManageViewModels;

namespace BlogApplication2.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly BlogRecordsContext _context;

        public ManageController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILoggerFactory loggerFactory, BlogRecordsContext cx)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<ManageController>();
            _context = cx;
        }

        public async Task<IList<UsersInRoleViewModel>> UsersInRole()
        {
            IList<UsersInRoleViewModel> AllUsersList = new List<UsersInRoleViewModel>();

            foreach (var item in from y in _userManager.Users select y)
            {
                bool _isUserInRole = await _userManager.IsInRoleAsync(item, "Admin");
                if (!_isUserInRole)
                {
                    AllUsersList.Add(new UsersInRoleViewModel
                    {
                        UserName = item.UserName,
                        Role = "None"
                    });
                }
                else
                {
                    AllUsersList.Add(new UsersInRoleViewModel
                    {
                        UserName = item.UserName,
                        Role = "Admin"
                    });
                }
            }
            return AllUsersList;
        }

        // GET: /Manage/Index
        [HttpGet]
        public async Task<IActionResult> Index(ManageMessageId? message = null)
        {
            var user = User.Identity.Name;

            ViewData["StatusMessage"] =
                message == ManageMessageId.ChangePasswordSuccess ? "Ditt lösenord har ändrats."
                : message == ManageMessageId.SetPasswordSuccess ? "Ditt lösenord har satts."
                : message == ManageMessageId.Error ? "Ett fel har inträffat."
                : "";

            var currentUser = await GetCurrentUserAsync();
            if (currentUser == null)
            {
                return View("Error");
            }
            var model = new IndexViewModel
            {
                HasPassword = await _userManager.HasPasswordAsync(currentUser),
                PhoneNumber = await _userManager.GetPhoneNumberAsync(currentUser),
                TwoFactor = await _userManager.GetTwoFactorEnabledAsync(currentUser),
                Logins = await _userManager.GetLoginsAsync(currentUser),
                BrowserRemembered = await _signInManager.IsTwoFactorClientRememberedAsync(currentUser)
            };

            ViewBag.indexViewModel = model;

            var blogPosts = from s in _context.BlogPosts
                            where s.UserID == user
                            select s;
            if (User.IsInRole("Admin"))
            {
                ViewBag.UsersInRole = await UsersInRole();
            }
            return View(await blogPosts.AsNoTracking().ToListAsync());
        }

        // GET: /Manage/ChangePassword
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GetCurrentUserAsync();
            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User changed their password successfully.");
                    return RedirectToAction(nameof(Index), new { Message = ManageMessageId.ChangePasswordSuccess });
                }

                AddErrors(result);
                return View(model);
            }
            return RedirectToAction(nameof(Index), new { Message = ManageMessageId.Error });
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            Error
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }
    }
}
