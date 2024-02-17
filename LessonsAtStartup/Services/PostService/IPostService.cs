using LessonsAtStartup.Controllers;
using LessonsAtStartup.Data.Entities;
using LessonsAtStartup.Models;

namespace LessonsAtStartup.Services.PostService
{
    public interface IPostService
    {
        IEnumerable<PostModel> GetPosts();
        PostModel GetById(int postId);
        void Insert(PostModel post);
        void Delete(int postId);
        void Update(PostModel post);
    }
}
