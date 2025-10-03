using Microsoft.AspNetCore.Mvc;

namespace Bootcamp4_AspMVC.Controllers
{
    public class HomePageController : Controller
    {

        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
