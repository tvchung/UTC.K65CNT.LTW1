using Microsoft.AspNetCore.Mvc;

namespace TvcLesson04Review.Controllers
{
    public class TvcAboutController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.name = "Chung Trịnh";
            ViewData["age"] = "20++";
            TempData["address"] = "Hà Nội";
            return View();
        }
    }
}
