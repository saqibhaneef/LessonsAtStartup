using System.ComponentModel.DataAnnotations.Schema;

namespace LessonsAtStartup.Data.Entities
{
    public class PostCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
