using BlogApplication2.Data;
using BlogApplication2.Service.BlogPostViewModels;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<ItemsPerCategory>> CategoriesCountAsync()
        {
            var query = (from obj in _context.BlogPosts
                         group obj by new
                         {
                             obj.CategoryName
                         }
                         into ic
                         select new ItemsPerCategory()
                         {
                             categoryName = ic.Key.CategoryName,
                             count = ic.Count()
                         }).OrderByDescending(c => c.categoryName);

            return await query.ToListAsync();
        }

        public async Task<List<EmptyCategories>> EmptyCategoriesAsync()
        {
            var q1 = await CategoriesCountAsync();
            var outList = new List<EmptyCategories>();

            foreach (var item in (await AllCategoriesAsync()))
            {
                var query = q1.SingleOrDefault(obj => obj.categoryName == item);

                if (query == null)
                {
                    outList.Add(new EmptyCategories
                    {
                        categoryName = item,
                        count = 0
                    });
                }
            }
            return outList;
        }

        public async Task<List<string>> AllCategoriesAsync()
        {
            var query = from obj in _context.Categories
                        select obj.CategoryName;
            return await query.ToListAsync();
        }
    }
}
