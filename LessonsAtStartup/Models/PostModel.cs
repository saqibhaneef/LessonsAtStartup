using LessonsAtStartup.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace LessonsAtStartup.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public string Country { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
    }
}
