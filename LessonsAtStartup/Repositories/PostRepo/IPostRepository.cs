using LessonsAtStartup.Data.Entities;

namespace LessonsAtStartup.Repositories.PostRepo
{
    public interface IPostRepository : IDisposable
    {

        IEnumerable<Post> GetPosts();
        Post GetPostById(int postId);
        void InsertPost(Post post);
        void InsertPostTag(PostTag postTag);
        void DeletePostTag(PostTag postTag);
        void DeletePostCategory(PostCategory postCategory);
        void InsertPostCategory(PostCategory postTag);
        void DeletePost(int postId);
        void UpdatePost(Post post);
        void Save();
    }
}
