using LessonsAtStartup.Data;
using LessonsAtStartup.Data.Entities;
using LessonsAtStartup.Models;
using LessonsAtStartup.Repositories.CategoryRepo;
using Microsoft.EntityFrameworkCore;

namespace LessonsAtStartup.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {

            _categoryRepository = categoryRepository;

        }
        public void Delete(int categoryId)
        {
            _categoryRepository.Delete(categoryId);
            _categoryRepository.Save();
        }

        public CategoryModel GetById(int categoryId)
        {
            Category category = _categoryRepository.GetById(categoryId);
            return new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                CreatedOn = category.CreatedOn
            };
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            var categories = _categoryRepository.GetCategories().ToList();

            List<CategoryModel> list = new List<CategoryModel>();
            foreach (var category in categories)
            {
                CategoryModel categoryModel = new CategoryModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    CreatedOn = category.CreatedOn,
                };
                list.Add(categoryModel);
            }
            return list;
        }

        public void Insert(CategoryModel category)
        {
            Category categ = new Category()
            {
                Name = category.Name,
                Description = category.Description,
                CreatedOn = DateTime.Now,
            };
            _categoryRepository.Insert(categ);
            _categoryRepository.Save();
        }

        public void Update(CategoryModel categoryModel)
        {
            Category category = new Category()
            {
                Id = categoryModel.Id,
                Name = categoryModel.Name,
                Description = categoryModel.Description,
            };
            _categoryRepository.Update(category);
            _categoryRepository.Save();
        }
    }
}
