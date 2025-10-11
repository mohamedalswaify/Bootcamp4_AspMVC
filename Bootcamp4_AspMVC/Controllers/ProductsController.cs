using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Filters;
using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Models;
using Bootcamp4_AspMVC.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp4_AspMVC.Controllers
{
    [SessionAuthorize]
    public class ProductsController : Controller
    {
        // private readonly ApplicationDbContext _context;

        //private readonly IProductRepo _productRepo;
        //private readonly IRepository<Category> _categoryRepo;

        //public ProductsController(IProductRepo productRepo, IRepository<Category> categoryRepo)
        //{
        //    //_context = context;
        //    _productRepo = productRepo;
        //    _categoryRepo = categoryRepo;
        //}
        private readonly IUnitOfWork _unitOfWork;
        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            //IEnumerable<Product> Products = 
            //    _context.Products
            //    .Include(c => c.Category)
            //    .ToList();

            IEnumerable<Product> Products =
             _unitOfWork._productRepo.GetProductsWithCategory();

            //foreach (var item in Products)
            //{
            //    item.Uid = Guid.NewGuid().ToString();
            //    _context.Products.Update(item);
            //    _context.SaveChanges();
            //}
            return View(Products);
        }




        private void createList()
        {
            //IEnumerable<Category> categories = _context.Categories.ToList();
            //SelectList selectListItems = new SelectList(categories,"Id","Name");
            //ViewBag.Categories = selectListItems;

            //IEnumerable<Category> categories = _context.Categories.ToList();
            IEnumerable<Category> categories = _unitOfWork._repositoryCategory.GetAll();
            ViewBag.Categories = categories;
        }


        [HttpGet]
        public IActionResult Create()
        {
            createList();


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(product);

                }
                //_context.Products.Add(product);
                //_context.SaveChanges();

                _unitOfWork._productRepo.Add(product);


                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }






        [HttpGet]
        public IActionResult Edit(string Uid)
        {
            //var products = _context.Products.FirstOrDefault(e => e.Uid == Uid);

            var products = _unitOfWork._productRepo.GetByUId(Uid);
            createList();
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(product);

                }
                //var prod = _context.Products.FirstOrDefault(e => e.Uid == product.Uid);
                var prod = _unitOfWork._productRepo.GetByUId(product.Uid);
                if (prod != null)
                {

                    prod.Name = product.Name;
                    prod.Price = product.Price;
                    prod.Description = product.Description;
                    prod.CategoryId = product.CategoryId;

                    //_context.Products.Update(prod);
                    //_context.SaveChanges();
                    _unitOfWork. _productRepo.Update(prod);

                    return RedirectToAction("Index");

                }
                return View(product);

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }







        [HttpGet]
        public IActionResult Delete(string Uid)
        {
            //var prod = _context.Products.AsNoTracking().FirstOrDefault(e => e.Uid == Uid);
            var prod = _unitOfWork._productRepo.GetByUId(Uid);

            if (prod == null)
            {
                return NotFound();
            }
            return View(prod);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product product)
        {
            try
            {
                //_context.Products.Remove(product);
                //_context.SaveChanges();
                _unitOfWork._productRepo.Delete(product.Id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }



















    }
}
