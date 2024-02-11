using LessonsAtStartup.Data.Entities;

namespace LessonsAtStartup.Repositories.Category
{
    public interface ICategoryRepository : IDisposable
    {

        IEnumerable<Category> GetCategories();
        Category GetById(int categoryId);
        void Insert(Category category);
        void Delete(int categoryId);
        void Update(Category category);
        void Save();
    }
}
