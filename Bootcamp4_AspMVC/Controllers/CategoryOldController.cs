using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Filters;
using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Models;
using Bootcamp4_AspMVC.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp4_AspMVC.Controllers
{
    [SessionAuthorize]
    public class CategoryOldController : Controller
    {
        //private readonly ApplicationDbContext _context;
       // private readonly IRepository<Category> _repositoryCategory;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryOldController(IUnitOfWork unitOfWork)
        {
          //  _repositoryCategory = repository;
            _unitOfWork = unitOfWork;
        }
        //public CategoryController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        public IActionResult Index()
        {
            try {

               // IEnumerable<Category> categories = _context.Categories.ToList();
                IEnumerable<Category> categories = _unitOfWork._repositoryCategory.GetAll();
                //foreach (var item in categories)
                //{
                //    item.Uid = Guid.NewGuid().ToString();
                //    item.CreatedAt = DateTime.Now;
                //    _context.Categories.Update(item);
                //    _context.SaveChanges();
                //}
                return View(categories);



            }
            catch (Exception ex)
            {

                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(category);

                }
                //_context.Categories.Add(category);
                //_context.SaveChanges();

                _unitOfWork._repositoryCategory.Add(category);
                _unitOfWork.Save();

                return RedirectToAction("Index");

            }
            catch (Exception ex) {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }






        [HttpGet]
        public IActionResult Edit(string Uid)
        {
            //var category = _context.Categories.FirstOrDefault(e => e.Uid == Uid);
            var category = _unitOfWork._repositoryCategory.GetByUId(Uid);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category,string Uid)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(category);

                }

               // var cate = _context.Categories.FirstOrDefault(e => e.Uid == Uid);
                var cate = _unitOfWork._repositoryCategory.GetByUId(Uid);
                if (cate != null)
                {

                    cate.Name = category.Name;
                    cate.Description = category.Description;
                    //_context.Categories.Update(cate);
                    //_context.SaveChanges();


                    _unitOfWork._repositoryCategory.Update(cate);
                    _unitOfWork.Save();

                    return RedirectToAction("Index");
                }

                return View(category);



            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }







        [HttpGet]
        public IActionResult Delete(int Id)
        {
            // var category = _context.Categories.Find(Id);
            var category = _unitOfWork._repositoryCategory.GetById(Id);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category category)
        {
            try
            {
                //_context.Categories.Remove(category);
                //_context.SaveChanges();

                _unitOfWork._repositoryCategory.Delete(category.Id);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }















    }
}
