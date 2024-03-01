namespace LessonsAtStartup.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        public ICollection<PostCategory> PostCategories { get; set; }
    }
}
