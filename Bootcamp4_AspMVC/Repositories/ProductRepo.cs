using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp4_AspMVC.Repositories
{
    public class ProductRepo : MainRepository<Product>, IProductRepo
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetProductsWithCategory()
        {
            return _context.Products.Include(c => c.Category).ToList();

        }
    }
}
