using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Filters;
using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp4_AspMVC.Controllers
{
    [SessionAuthorize]
    public class DepartmentsController : Controller
    {


      //  private readonly ApplicationDbContext _context;
        private readonly IRepository<Department> _repositoryDepartment;

        public DepartmentsController(IRepository<Department> repository)
        {
            _repositoryDepartment = repository;
        }

      //  public DepartmentsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}





        [HttpGet]
        public IActionResult Index()
        {
            try
            {

              //  IEnumerable<Department> depts = _context.Departments.ToList();
                IEnumerable<Department> depts = _repositoryDepartment.GetAll();
                return View(depts);



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
        public IActionResult Create(Department dept)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(dept);

                }
                //_context.Departments.Add(dept);
                //_context.SaveChanges();

                _repositoryDepartment.Add(dept);

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }






        [HttpGet]
        public IActionResult Edit(int Id)
        {
            //var dept = _context.Departments.Find(Id);
            var dept = _repositoryDepartment.GetById(Id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Department dept)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(dept);

                }
                //_context.Departments.Update(dept);
                //_context.SaveChanges();
                _repositoryDepartment.Update(dept);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }







        [HttpGet]
        public IActionResult Delete(int Id)
        {
          //  var dept = _context.Departments.Find(Id);
            var dept = _repositoryDepartment.GetById(Id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Delete(Department dept)
        {
            try
            {
                //_context.Departments.Remove(dept);
                //_context.SaveChanges();
                _repositoryDepartment.Delete(dept.Id);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return Content("حدث خطا  غير متوقع يرجي مراجهة الدعم الفني:0565455252545");
            }
        }



















    }
}
