using Microsoft.AspNetCore.Mvc;

namespace MyAcademyMediatorProject.Areas.User.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
