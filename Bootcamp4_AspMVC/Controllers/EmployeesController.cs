using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Filters;
using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp4_AspMVC.Controllers
{
    [SessionAuthorize]
    public class EmployeesController : Controller
    {
        // private readonly ApplicationDbContext _context;
        //private readonly IEmployeeRepo _employeeRepo;
        //private readonly IRepository<Department> _repositoryDepartment;
        //private readonly IRepository<Job> _repositoryJob;

        //public EmployeesController(IEmployeeRepo employeeRepo, IRepository<Department> repositoryDepartment, IRepository<Job> repositoryJob)
        //{
        //   // _context = context;
        //    _employeeRepo = employeeRepo;
        //    _repositoryDepartment = repositoryDepartment;
        //    _repositoryJob = repositoryJob;
        //}


        private readonly IUnitOfWork _unitOfWork;
        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            //IEnumerable<Employee> Products = 
            //    _context.Employees
            //    .Include(c => c.Department)
            //    .Include(c => c.Job)
            //    .ToList();

            IEnumerable<Employee> Products = _unitOfWork._employeeRepo.GetEmployeesWithDepartmentAndJob();

            return View(Products);
        }





        private void createList()
        {
            //IEnumerable<Category> categories = _context.Categories.ToList();
            //SelectList selectListItems = new SelectList(categories,"Id","Name");
            //ViewBag.Categories = selectListItems;

            //IEnumerable<Department> depts = _context.Departments.ToList();
            IEnumerable<Department> depts = _unitOfWork._repositoryDepartment.GetAll();
            ViewBag.Depts = depts;

            //IEnumerable<Job> jobs = _context.Jobs.ToList();
            IEnumerable<Job> jobs = _unitOfWork._repositoryJob.GetAll();
            ViewBag.Jobs = jobs;

        }




        [HttpGet]
        public IActionResult Create()
        {
            createList();


            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(emp);

                }
                //_context.Employees.Add(emp);
                //_context.SaveChanges();
                _unitOfWork._employeeRepo.Add(emp);
                _unitOfWork.Save();
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
            //var emps = _context.Employees.Find(Id);
            var emps = _unitOfWork._employeeRepo.GetById(Id);
            createList();
            return View(emps);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(emp);

                }
                //_context.Employees.Update(emp);
                //_context.SaveChanges();
                _unitOfWork._employeeRepo.Update(emp);
                _unitOfWork.Save();
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
            //var products = _context.Employees.Find(Id);

            var products = _unitOfWork._employeeRepo.GetById(Id);
            createList();
            return View(products);
        }

        [HttpPost]
        public IActionResult Delete(Employee product)
        {
            try
            {
                //_context.Employees.Remove(product);
                //_context.SaveChanges();
                _unitOfWork._employeeRepo.Delete(product.Id);
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
