using LessonsAtStartup.Data;
using LessonsAtStartup.Data.Entities;
using LessonsAtStartup.Models;
using Microsoft.EntityFrameworkCore;

namespace LessonsAtStartup.Repositories
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

        public Category GetById(int categoryId)
        {
            throw new NotImplementedException();
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
                CreatedOn= DateTime.Now,
            };
            _categoryRepository.Insert(categ);
            _categoryRepository.Save();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
