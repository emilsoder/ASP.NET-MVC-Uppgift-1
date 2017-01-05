using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogApplication2.Data;
using BlogApplication2.Models;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using BlogApplication2.Service;

namespace BlogApplication2.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly BlogRecordsContext _context;
        private readonly BlogPostDataService _dataService;
        public BlogPostsController(BlogRecordsContext context)
        {
            _context = context;
            _dataService = new BlogPostDataService(_context);
        }
        //GET: BlogPosts/Index
        public async Task<IActionResult> Index(string sortOrder, string searchString, string categoryName, string viewType)
        {
            var blogPosts = from s in _context.BlogPosts
                            select s;

            ViewBag.categories = _dataService.GetCategories();
            ViewBag.AllCategories = _dataService.EmptyCategories();

            ViewBag.AllPostsCount = blogPosts.Count();

            if (!string.IsNullOrEmpty(searchString))
            {
                blogPosts = blogPosts.Where(s => s.HeaderText.Contains(searchString));
            }

            else if (!string.IsNullOrEmpty(categoryName))
            {
                if (categoryName == "all")
                {
                    blogPosts = from s in _context.BlogPosts
                                select s;
                }
                else
                {
                    blogPosts = blogPosts.Where(s => s.CategoryName == categoryName);
                }
                ViewData["categoryName"] = categoryName;
            }
            switch (sortOrder)
            {
                case "date_asc":
                    blogPosts = blogPosts.OrderBy(s => s.PublishDate);
                    ViewData["SortOrder"] = "date_asc";
                    break;
                default:
                case "date_desc":
                    blogPosts = blogPosts.OrderByDescending(s => s.PublishDate);
                    ViewData["SortOrder"] = "date_desc";
                    break;
            }
            switch (viewType)
            {
                case "list":
                    ViewData["DisplayResultsAs"] = "list";
                    break;
                default:
                case "grid":
                    ViewData["DisplayResultsAs"] = "grid";
                    break;
            }
            return View(await blogPosts.AsNoTracking().ToListAsync());
        }

        // GET: BlogPosts/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewBag.categories = _dataService.AllCategories();
            return View();
        }

        // POST: BlogPosts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogPostID,BodyText,CategoryName,HeaderText,PublishDate,UserID")] BlogPost blogPost)
        {
            blogPost.PublishDate = DateTime.Now.Date;
            blogPost.UserID = User.Identity.Name;

            if (ModelState.IsValid)
            {
                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Edit
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.SingleOrDefaultAsync(m => m.BlogPostID == id);

            if (!UserIDEqualsUserName(blogPost.UserID))
            {
                return RedirectToAction("IllegalOperation", "Home");
            }

            ViewBag.categories = _dataService.AllCategories();
            return View(blogPost);
        }

        // POST: BlogPosts/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogPostID,BodyText,CategoryName,HeaderText,PublishDate,UserID")] BlogPost blogPost)
        {
            if (id != blogPost.BlogPostID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.BlogPostID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(actionName: "Index", controllerName: "BlogPosts");
            }
            return View(blogPost);
        }
        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.BlogPostID == id);
        }

        // GET: BlogPosts/Delete
        [Authorize]
        public async Task<IActionResult> Delete(int? id, string userID)
        {
            if (id == null)
            {
                return NotFound();
            }
            var blogPost = await _context.BlogPosts.SingleOrDefaultAsync(m => m.BlogPostID == id);

            if (!UserIDEqualsUserName(blogPost.UserID))
            {
                return RedirectToAction("IllegalOperation", "Home");
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.BlogPosts.SingleOrDefaultAsync(m => m.BlogPostID == id);
            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool UserIDEqualsUserName(string _userID)
        {
            if (User.Identity.Name == _userID)
            {
                return true;
            }
            else if (User.IsInRole("Admin"))
            {
                return true;
            }
            return false;
        }

    }
}