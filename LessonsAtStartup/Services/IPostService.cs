using LessonsAtStartup.Controllers;
using LessonsAtStartup.Data.Entities;
using LessonsAtStartup.Models;

namespace LessonsAtStartup.Repositories
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
