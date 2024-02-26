using LessonsAtStartup.Data.Entities;

namespace LessonsAtStartup.Repositories.PostRepo
{
    public interface IPostRepository : IDisposable
    {

        IEnumerable<Post> GetPosts();
        Post GetPostById(int postId);
        void InsertPost(Post post);
        void InsertPostTag(PostTag postTag);
        void DeletePost(int postId);
        void UpdatePost(Post post);
        void Save();
    }
}
