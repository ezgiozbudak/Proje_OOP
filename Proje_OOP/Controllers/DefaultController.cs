using Microsoft.AspNetCore.Mvc;

namespace Proje_OOP.Controllers
{
    public class DefaultController : Controller
    {
        void messages()
        {
            ViewBag.m1 = "a";
            ViewBag.m2 = "b";
            ViewBag.m3 = "c";
        }
        public IActionResult Index()
        {
            messages();
            return View();
        }
    }
}
