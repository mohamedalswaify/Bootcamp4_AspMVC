using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp4_AspMVC.Repositories
{
    public class CategoryRepo : MainRepository<Category>, ICategoryRepo
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


        public IEnumerable<Category> GetCategoriesWithProducts()
        {
            var categories = _context.Categories.Include(e => e.Products).ToList();
            return categories;
        }
    }
}
