using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Filters;
using Bootcamp4_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp4_AspMVC.Controllers
{
    [SessionAuthorize]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> Products = _context.Products.Include(c => c.Category).ToList();

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

            IEnumerable<Category> categories = _context.Categories.ToList();
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
                _context.Products.Add(product);
                _context.SaveChanges();
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
            var products = _context.Products.FirstOrDefault(e => e.Uid == Uid);
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
                var prod = _context.Products.FirstOrDefault(e => e.Uid == product.Uid);
                if (prod != null)
                {

                    prod.Name = product.Name;
                    prod.Price = product.Price;
                    prod.Description = product.Description;
                    prod.CategoryId = product.CategoryId;

                    _context.Products.Update(prod);
                    _context.SaveChanges();
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
            var prod = _context.Products.AsNoTracking().FirstOrDefault(e => e.Uid == Uid);
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
                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }



















    }
}
