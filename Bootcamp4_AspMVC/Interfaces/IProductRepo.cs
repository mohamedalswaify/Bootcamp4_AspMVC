using Bootcamp4_AspMVC.Models;

namespace Bootcamp4_AspMVC.Interfaces
{
    public interface IProductRepo : IRepository<Product>
    {
        IEnumerable<Product> GetProductsWithCategory();




    }
}
