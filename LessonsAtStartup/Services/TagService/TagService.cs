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
            throw new NotImplementedException();
        }

        public TagModel GetById(int tagId)
        {
            throw new NotImplementedException();
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

        public void Update(TagModel tag)
        {
            throw new NotImplementedException();
        }
    }
}
