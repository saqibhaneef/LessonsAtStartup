using LessonsAtStartup.Data.Entities;

namespace LessonsAtStartup.Models
{
    public class TagModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        //public ICollection<PostTag> PostTags { get; set; }
    }
}
