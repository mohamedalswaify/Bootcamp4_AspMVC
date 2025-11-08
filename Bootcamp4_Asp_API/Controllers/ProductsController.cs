using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Interfaces.IServices;
using Bootcamp4_AspMVC.Models;
using Bootcamp4_AspMVC.Serivces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp4_Asp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController( IProductService productService)
        {
            _productService = productService;

        }


        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            try
            {
                var products = _productService.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please contact support.");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Product>> Get(int id)
        {
            try
            {
                var product = _productService.Get(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred. Please contact support.");
            }
        }

    }
}
