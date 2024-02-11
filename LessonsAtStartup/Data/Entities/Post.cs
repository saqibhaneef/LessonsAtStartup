using System.ComponentModel.DataAnnotations.Schema;

namespace LessonsAtStartup.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime PublishedDate { get; set;}
        public string Country { get; set; }

        public DateTime CreatedOn { get; set; }

        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
        

    }
}
