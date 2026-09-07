using Microsoft.AspNetCore.Mvc;

namespace TvcLesson04Views.Controllers
{
    public class TvcContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
