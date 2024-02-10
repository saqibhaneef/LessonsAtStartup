using LessonsAtStartup.Data;
using LessonsAtStartup.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace LessonsAtStartup.Repositories
{
    public class PostRepository : IPostRepository
    {
        private AppDbContext _context;
        public PostRepository(AppDbContext bookContext)
        {
            this._context = bookContext;
        }
        public IEnumerable<Post> GetPosts()
        {
            return _context.Posts.Include(x=>x.Category).ToList();
        }
        public Post GetPostById(int id)
        {
            return _context.Posts.Find(id);
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
            _context.Entry(post).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
