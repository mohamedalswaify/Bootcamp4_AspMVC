using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp4_AspMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        { 
        IEnumerable<Category> categories= _context.Categories.ToList();
            return View(categories);
        }
    }
}
