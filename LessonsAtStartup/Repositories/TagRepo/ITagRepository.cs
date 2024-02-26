using LessonsAtStartup.Data.Entities;

namespace LessonsAtStartup.Repositories.TagRepo
{
    public interface ITagRepository : IDisposable
    {

        IEnumerable<Tag> GetTags();
        Tag GetTagById(int tagId);
        void InsertTag(Tag tag);
        void DeleteTag(int tagId);
        void UpdateTag(Tag tag);
        void Save();
    }
}
