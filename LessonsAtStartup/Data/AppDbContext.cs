using LessonsAtStartup.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace LessonsAtStartup.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<PostTag> PostTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasOne(p => p.Category).WithMany(x => x.Posts)
                .HasForeignKey(x => x.CategoryId).HasPrincipalKey(x => x.Id).IsRequired(false);

            modelBuilder.Entity<PostTag>()
        .HasKey(bc => new { bc.PostId, bc.TagId });

            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Post)
                .WithMany(p=>p.PostTags)
                .HasForeignKey(pt => pt.PostId);
            
            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t=>t.PostTags)
                .HasForeignKey(pt => pt.TagId);


            modelBuilder.Entity<Post>(
                entity =>
                {
                    entity.Property<int>("Id").IsRequired();
                    entity.Property("Title").IsRequired();
                    entity.Property("Description").IsRequired(false);
                    entity.Property("Url").IsRequired();
                    entity.Property("PublishedDate").IsRequired();
                    entity.Property("Country").IsRequired();
                    entity.Property("CreatedOn").IsRequired();
                    
                });

            modelBuilder.Entity<Category>(
                entity =>
                {
                    entity.Property<int>("Id").IsRequired();
                    entity.Property("Name").IsRequired();
                    entity.Property("Description").IsRequired(false);                    
                    entity.Property("CreatedOn").IsRequired();
                });
            base.OnModelCreating(modelBuilder);
        }


    }
}
