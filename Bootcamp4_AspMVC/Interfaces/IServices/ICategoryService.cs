using Bootcamp4_AspMVC.Models;

namespace Bootcamp4_AspMVC.Interfaces.IServices
{
    public interface ICategoryService
    {


        IEnumerable<Category> GetAll();
        IEnumerable<Category> GetAllCategoriesWithProducts();


        Category? GetByUid(string uid);
        bool Create(Category category);
        bool Update(string uid, Category input);
        bool DeleteByUid(string uid);

    }
}
