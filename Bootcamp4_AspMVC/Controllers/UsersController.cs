using Bootcamp4_AspMVC.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp4_AspMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            var users = userService.GetAll();

            return View(users);
        }
    }
}
