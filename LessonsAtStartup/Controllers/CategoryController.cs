using Microsoft.AspNetCore.Mvc;

namespace LessonsAtStartup.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
