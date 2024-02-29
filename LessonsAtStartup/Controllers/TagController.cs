using LessonsAtStartup.Models;
using LessonsAtStartup.Services.TagService;
using Microsoft.AspNetCore.Mvc;

namespace LessonsAtStartup.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        public IActionResult Index()
        {
            var posts = _tagService.GetTags();
            return View(posts);
        }
        public IActionResult _TagList(List<TagModel> tags)
        {
            if (tags.Count == 0)
            {
                tags = _tagService.GetTags().ToList();
            }
            return PartialView(tags);
        }

        public IActionResult _Create()
        {            
            
            return PartialView();
        }
        [HttpPost]
        public IActionResult Create(TagModel tagModel)
        {
            
            _tagService.Insert(tagModel);
            return Json("ok");
        }
        public IActionResult _Edit(int id)
        {

            var tag=_tagService.GetById(id);
            return PartialView(tag);
        }
        [HttpPost]
        public IActionResult Edit(TagModel tagModel)
        {

            _tagService.Update(tagModel);

            return Json("ok");
        }

        public IActionResult Delete(int id)
        {
            _tagService.Delete(id);
            return Json("ok"); ;
        }
    }
}
