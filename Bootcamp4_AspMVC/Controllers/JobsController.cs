using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Filters;
using Bootcamp4_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp4_AspMVC.Controllers
{
    [SessionAuthorize]
    public class JobsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext context)
        {
            _context = context;
        }





        [HttpGet]
        public IActionResult Index()
        {
            try
            {

                IEnumerable<Job> depts = _context.Jobs.ToList();
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
        public IActionResult Create(Job job)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(job);

                }
                _context.Jobs.Add(job);
                _context.SaveChanges();
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
            var dept = _context.Jobs.Find(Id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Job job)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return View(job);

                }
                _context.Jobs.Update(job);
                _context.SaveChanges();
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
            var dept = _context.Jobs.Find(Id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Delete(Job dept)
        {
            try
            {
                _context.Jobs.Remove(dept);
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
