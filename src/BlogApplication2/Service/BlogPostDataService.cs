using BlogApplication2.Data;
using BlogApplication2.Service.BlogPostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApplication2.Service
{
    public class BlogPostDataService
    {
        private readonly BlogRecordsContext _context;

        public BlogPostDataService(BlogRecordsContext context)
        {
            _context = context;
        }

        public IQueryable<ItemsPerCategory> GetCategories()
        {
            var result = from c in _context.BlogPosts
                         group c by new
                         {
                             c.CategoryName
                         }
                         into ic
                         select new ItemsPerCategory()
                         {
                             categoryName = ic.Key.CategoryName,
                             count = ic.Count()
                         };

            return result.OrderByDescending(c => c.categoryName);
        }

        public IEnumerable<EmptyCategories> EmptyCategories()
        {
            var q1 = GetCategories();
            var q3 = from c in _context.Categories select c.CategoryName;

            List<EmptyCategories> outList = new List<EmptyCategories>();

            foreach (var item in q3)
            {
                var result = q1.SingleOrDefault(s => s.categoryName == item);

                if (result == null)
                {
                    outList.Add(new EmptyCategories { categoryName = item, count = 0 });
                }
            }
            return outList;
        }

        public List<string> AllCategories()
        {
            var _categories = from c in _context.Categories select c.CategoryName;
            return _categories.ToList();
        }
    }
}
