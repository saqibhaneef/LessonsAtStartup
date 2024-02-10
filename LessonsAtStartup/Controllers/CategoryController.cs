using LessonsAtStartup.Models;
using LessonsAtStartup.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LessonsAtStartup.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {

            var list=_categoryService.GetCategories().AsEnumerable();
            return View(list);
        }        
        public IActionResult _CategoriesList()
        {
            var list = _categoryService.GetCategories().AsEnumerable();
            return PartialView(list);
        }
        public IActionResult _Create()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult Create(CategoryModel model)
        {
            _categoryService.Insert(model);
            return Json("ok"); ;
        }

        public IActionResult Delete(int id)
        {
            _categoryService.Delete(id);
            return Json("ok"); ;
        }

        public IActionResult _Edit(int id)
        {
            var category = _categoryService.GetById(id);
            return PartialView(category);
        }
        [HttpPost]
        public IActionResult Edit(CategoryModel categoryModel)
        {
            _categoryService.Update(categoryModel);
            return Json("ok");
        }

    }
}
