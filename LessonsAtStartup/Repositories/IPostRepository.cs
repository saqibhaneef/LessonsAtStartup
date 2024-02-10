using LessonsAtStartup.Data.Entities;

namespace LessonsAtStartup.Repositories
{
    public interface IPostRepository : IDisposable
    {

        IEnumerable<Post> GetPosts();
        Post GetPostById(int bookId);
        void InsertPost(Post book);
        void DeletePost(int bookID);
        void UpdatePost(Post book);
        void Save();
    }
}
