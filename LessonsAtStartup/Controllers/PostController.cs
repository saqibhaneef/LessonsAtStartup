using Microsoft.AspNetCore.Mvc;

namespace LessonsAtStartup.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
