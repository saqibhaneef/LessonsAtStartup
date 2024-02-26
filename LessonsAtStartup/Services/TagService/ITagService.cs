using LessonsAtStartup.Models;

namespace LessonsAtStartup.Services.TagService
{
    public interface ITagService
    {
        IEnumerable<TagModel> GetTags();
        TagModel GetById(int tagId);
        void Insert(TagModel tag);
        void Delete(int tagId);
        void Update(TagModel tag);
    }
}
