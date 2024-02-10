using LessonsAtStartup.Controllers;
using LessonsAtStartup.Data.Entities;
using LessonsAtStartup.Models;

namespace LessonsAtStartup.Repositories
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetCategories();
        Category GetById(int categoryId);
        void Insert(CategoryModel category);
        void Delete(int categoryId);
        void Update(Category category);        
    }
}
