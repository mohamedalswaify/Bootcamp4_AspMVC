using Bootcamp4_AspMVC.Models;

namespace Bootcamp4_AspMVC.Interfaces
{
    public interface ICategoryRepo : IRepository<Category>
    {
        IEnumerable<Category> GetCategoriesWithProducts();
    }
}
