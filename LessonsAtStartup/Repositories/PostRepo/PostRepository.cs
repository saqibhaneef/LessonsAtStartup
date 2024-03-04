using LessonsAtStartup.Data;
using LessonsAtStartup.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace LessonsAtStartup.Repositories.PostRepo
{
    public class PostRepository : IPostRepository
    {
        private AppDbContext _context;
        public PostRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts
                .Include(category => category.PostCategories)
                     .ThenInclude(category=> category.Category)
                .Include(tag => tag.PostTags)
                     .ThenInclude(tag => tag.Tag)
                          .ToList();
        }
        public Post GetPostById(int id)
        {
            return _context.Posts.
                Where(x => x.Id == id).AsNoTracking().
                Include(x => x.PostCategories).
                       ThenInclude(c=>c.Category).AsNoTracking().
                Include(x => x.PostTags).
                       ThenInclude(x=>x.Tag).
                       AsNoTracking().                       
                       FirstOrDefault();
        }
        public void InsertPost(Post post)
        {
            _context.Posts.Add(post);
        }
        public void DeletePost(int postId)
        {
            Post post = _context.Posts.Find(postId);
            _context.Posts.Remove(post);
        }
        public void UpdatePost(Post post)
        {
            //_context.Posts.Update(post);
            _context.Entry(post).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void InsertPostTag(PostTag postTag)
        {
            _context.PostTags.Add(postTag);
        }
        public void DeletePostTag(PostTag postTag)
        {
            _context.PostTags.Remove(postTag);
        }
        public void DeletePostCategory(PostCategory postCategory)
        {
            _context.PostCategories.Remove(postCategory);
        }
        public void InsertPostCategory(PostCategory postCategory)
        {
            _context.PostCategories.Add(postCategory);
        }
    }
}
