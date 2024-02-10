using LessonsAtStartup.Models;
using LessonsAtStartup.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LessonsAtStartup.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        public PostController(IPostService postService, ICategoryService categoryService)
        {
            _postService = postService;
            _categoryService = categoryService;

        }
        public IActionResult Index()
        {
            var posts = _postService.GetPosts();
            return View(posts);
        }
        public IActionResult _PostsList(List<PostModel> posts)
        {
            if(posts.Count==0)
            {
                posts = _postService.GetPosts().ToList();
            }
            return PartialView(posts);
        }
        public IActionResult _Create()
        {
            var catgories=_categoryService.GetCategories();
            PostModel postModel = new PostModel()
            {
                Categories = catgories
            };
            return PartialView(postModel);
        }
        [HttpPost]
        public IActionResult Create(PostModel postModel)
        {
            _postService.Insert(postModel);
            return Json("ok");
        }
    }
}
