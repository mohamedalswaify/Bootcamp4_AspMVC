using Bootcamp4_AspMVC.Dtos;
using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Interfaces.IServices;

namespace Bootcamp4_AspMVC.Serivces
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public ProductDto Get(int id)
        {
            var product = _unitOfWork._productRepo.GetById(id);
            if (product == null)
            {
                return null; // Or throw an exception, or return an empty list, based on your design choice
            }

            var productDto = new ProductDto
            {
                Id = product.Id,
                Uid = product.Uid,
                Name = product.Name,
                Description = product.Description,

                Price = product.Price,
                Qty = 25,
                ReservedQty = 5,
                CategoryId = product.CategoryId ?? 0,
                ImageUrl = "https://ljw8bld3-7259.uks1.devtunnels.ms" + product.ImageUrl,
                CategoryName = product.Category != null ? product.Category.Name : ""
            };

            return  productDto;

        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = _unitOfWork._productRepo.GetAll();
            var productDtos = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Uid = p.Uid,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Qty = 25,
                ReservedQty = 5,
                CategoryId = p.CategoryId ?? 0,
                ImageUrl = "https://ljw8bld3-7259.uks1.devtunnels.ms"+ p.ImageUrl,
                CategoryName = p.Category != null ? p.Category.Name : null
            });
            return productDtos;


        }






    }
}
