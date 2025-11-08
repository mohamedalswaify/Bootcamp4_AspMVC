using Bootcamp4_AspMVC.Dtos;

namespace Bootcamp4_AspMVC.Interfaces.IServices
{
    public interface IProductService
    {

        // Define product-related service methods here

        IEnumerable<ProductDto> GetAll();
        ProductDto Get(int id);
    }
}
