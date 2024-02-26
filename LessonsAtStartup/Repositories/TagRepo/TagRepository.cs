using LessonsAtStartup.Data;
using LessonsAtStartup.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace LessonsAtStartup.Repositories.TagRepo
{
    public class TagRepository : ITagRepository
    {
        private AppDbContext _context;
        public TagRepository(AppDbContext bookContext)
        {
            _context = bookContext;
        }
        public IEnumerable<Tag> GetTags()
        {
            //return _context.Posts
            //    .Include(category => category.Category)
            //    .Include(tag => tag.PostTags)
            //         .ThenInclude(tag => tag.Tag).AsNoTracking()
            //              .ToList();

            return _context.Tags.AsNoTracking().ToList();
        }
        public Tag GetTagById(int id)
        {
            return _context.Tags.Find(id);
        }
        public void InsertTag(Tag post)
        {
            _context.Tags.Add(post);
        }
        public void DeleteTag(int postId)
        {
            Tag tag = _context.Tags.Find(postId);
            _context.Tags.Remove(tag);
        }
        public void UpdateTag(Tag tag)
        {
            _context.Entry(tag).State = EntityState.Modified;
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
    }
}
