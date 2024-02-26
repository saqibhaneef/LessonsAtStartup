using LessonsAtStartup.Models;
using LessonsAtStartup.Services.CategoryService;
using LessonsAtStartup.Services.PostService;
using LessonsAtStartup.Services.TagService;
using Microsoft.AspNetCore.Mvc;

namespace LessonsAtStartup.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        public PostController(IPostService postService, ICategoryService categoryService,ITagService tagService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;

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
            var tags = _tagService.GetTags();
            PostModel postModel = new PostModel()
            {
                Categories = catgories,
                Tags= tags
            };

            return PartialView(postModel);
        }
        [HttpPost]
        public IActionResult Create(PostModel postModel)
        {
            _postService.Insert(postModel);
            return Json("ok");
        }

        public IActionResult _Edit(int id)
        {
            var tags= _tagService.GetTags();
            List<int> tagIds=new List<int>();

            var post = _postService.GetById(id);
            
            post.Tags.ToList().ForEach(x=>tagIds.Add(x.Id));//get tag ids against post

            post.Tags = tags;
            post.TagIds= tagIds;
            post.Categories = _categoryService.GetCategories();

            return PartialView(post);
        }
        [HttpPost]
        public IActionResult Edit(PostModel postModel)
        {
            _postService.Update(postModel);
            return Json("ok");
        }
    }
}
