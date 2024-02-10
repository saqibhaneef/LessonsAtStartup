using LessonsAtStartup.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace LessonsAtStartup.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        //public List<PostModel> Posts { get; set; }
    }
}
