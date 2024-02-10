using LessonsAtStartup.Data;
using LessonsAtStartup.Data.Entities;
using LessonsAtStartup.Models;
using Microsoft.EntityFrameworkCore;

namespace LessonsAtStartup.Repositories
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {

            _postRepository = postRepository;

        }
        public void Delete(int postId)
        {
            throw new NotImplementedException();
        }

        public PostModel GetById(int postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PostModel> GetPosts()
        {
            var posts=_postRepository.GetPosts().AsEnumerable();
            return posts.Select(x => new PostModel
            {
                Id = x.Id,
                Title = x.Title,
                Url = x.Url,
                Description = x.Description,
                PublishedDate = x.PublishedDate,
                CreatedOn = x.CreatedOn,
                Category = new CategoryModel()
                {
                    Id = x.Category.Id,
                    Name=x.Category.Name,
                    Description=x.Category.Description,
                    CreatedOn=x.Category.CreatedOn
                },

            }).AsEnumerable();
        }

        public void Insert(PostModel postModel)
        {
            Post post = new Post()
            {
                Title= postModel.Title,
                Url= postModel.Url,
                Description=postModel.Description,
                Country=postModel.Country,
                CategoryId=postModel.CategoryId,
                CreatedOn=DateTime.Now,
                PublishedDate= postModel.PublishedDate
            };
            _postRepository.InsertPost(post);
            _postRepository.Save();
        }

        public void Update(PostModel post)
        {
            throw new NotImplementedException();
        }
    }
}
