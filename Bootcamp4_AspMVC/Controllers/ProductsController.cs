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
        private readonly IWebHostEnvironment _env;
        public ProductsController(IUnitOfWork unitOfWork, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _env = env;

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



        private string? SaveImage(IFormFile? file)
        {
            if (file == null || file.Length == 0) return null;

            // التحقق من الامتداد (اختياري لكنه مهم)
            // في حاله رفع جميع انواع الملفات قد يؤدي الي مشاكل امنيه لذلك نحدد امتدادات مسموحه ونحظر الباقي مثل  .exe .dll .cs الخ
            var allowed = new[] { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowed.Contains(ext))
                throw new InvalidOperationException("امتداد الملف غير مسموح");

            // مسار المجلد داخل wwwroot
            var folder = Path.Combine("uploads", "products");
            var rootFolder = Path.Combine(_env.WebRootPath, folder);

            // إنشاء المجلد لو غير موجود
            Directory.CreateDirectory(rootFolder);

            // اسم ملف فريد
            var fileName = $"{Guid.NewGuid():N}{ext}";
            var fullPath = Path.Combine(rootFolder, fileName);

            using (var stream = System.IO.File.Create(fullPath))
            {
                file.CopyTo(stream);
            }

            // نعيد المسار النسبي للاستخدام في <img src="~/{path}">
            var relativePath = Path.Combine(folder, fileName).Replace('\\', '/');
            return "/" + relativePath;
        }



        private void DeleteImageIfExists(string? relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath)) return;

            var fullPath = Path.Combine(_env.WebRootPath, relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }
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


                if (product.ImageFile != null)
                {
                    // حفظ الصورة في المجلد وإرجاع المسار النسبي
                    var imagePath = SaveImage(product.ImageFile);
                    product.ImageUrl = imagePath;
                }


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

                    if (product.ImageFile != null)
                    {
                        // حفظ الصورة في المجلد وإرجاع المسار النسبي
                        var imagePath = SaveImage(product.ImageFile);
                        prod.ImageUrl = imagePath;
                    }


                    _unitOfWork. _productRepo.Update(prod);
                    _unitOfWork.Save();

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
