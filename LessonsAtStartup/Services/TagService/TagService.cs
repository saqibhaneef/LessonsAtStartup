using LessonsAtStartup.Data.Entities;
using LessonsAtStartup.Models;
using LessonsAtStartup.Repositories.TagRepo;

namespace LessonsAtStartup.Services.TagService
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public void Delete(int tagId)
        {
            _tagRepository.DeleteTag(tagId);
            _tagRepository.Save();
        }

        public TagModel GetById(int tagId)
        {
            var tag=_tagRepository.GetTagById(tagId);
            TagModel tagModel = new TagModel()
            {
                Id = tag.Id,
                Name = tag.Name,
                Description=tag.Description,
            };
            return tagModel;
        }

        public IEnumerable<TagModel> GetTags()
        {
            var tags= _tagRepository.GetTags().Select(x=> new TagModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
            }).AsEnumerable();

            return tags;
        }

        public void Insert(TagModel tagModel)
        {
            Tag tag = new Tag()
            {
                Name = tagModel.Name,
                Description = tagModel.Description
            };
            _tagRepository.InsertTag(tag);
            _tagRepository.Save();
        }

        public void Update(TagModel tagModel)
        {
            Tag tag = new Tag()
            {
                Id= tagModel.Id,
                Name = tagModel.Name,
                Description= tagModel.Description
            };
            _tagRepository.UpdateTag(tag);
            _tagRepository.Save();
        }
    }
}
