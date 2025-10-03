using Bootcamp4_AspMVC.Filters;
using Bootcamp4_AspMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bootcamp4_AspMVC.Controllers
{
    [SessionAuthorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("UserEmail"));
        }


        public IActionResult Index()
        {
            //var email = HttpContext.Session.GetString("UserEmail");
            //if(email ==null)
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            //if (!IsLoggedIn())
            //{
            //    return RedirectToAction("Login", "Account");
            //}


            return View();
        }

  

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
