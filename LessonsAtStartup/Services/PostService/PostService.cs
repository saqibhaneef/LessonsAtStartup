﻿using LessonsAtStartup.Data;
using LessonsAtStartup.Data.Entities;
using LessonsAtStartup.Migrations;
using LessonsAtStartup.Models;
using LessonsAtStartup.Repositories.PostRepo;
using LessonsAtStartup.Repositories.TagRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace LessonsAtStartup.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        public PostService(IPostRepository postRepository,ITagRepository tagRepository)
        {

            _postRepository = postRepository;
            _tagRepository = tagRepository;

        }
        public void Delete(int postId)
        {
            throw new NotImplementedException();
        }

        public PostModel GetById(int postId)
        {
            var post=_postRepository.GetPostById(postId);
            return new  PostModel(){
                Id=post.Id,
                Title=post.Title,
                Url=post.Url,
                Description=post.Description,
                Country=post.Country,             
                Categories=post.PostCategories.Select(c=>new CategoryModel()
                {
                    Id=c.Category.Id,
                    Name=c.Category.Name,
                }),
                Tags=post.PostTags.Select(t => new TagModel()
                {
                    Id=t.Tag.Id,
                    Name=t.Tag.Name
                })
            };
        }

        public IEnumerable<PostModel> GetPosts()
        {            
            var posts = _postRepository.GetPosts().Select(x => new PostModel
            {
                Id = x.Id,
                Title = x.Title,
                Url = x.Url,
                Description = x.Description,
                PublishedDate = x.PublishedDate,
                CreatedOn = x.CreatedOn,
                Country=x.Country,
                //Category = new CategoryModel()
                //{
                //    Id = x.Category.Id,
                //    Name = x.Category.Name,
                //    Description = x.Category.Description,
                //    CreatedOn = x.Category.CreatedOn
                //},
                Categories=x?.PostCategories?.Select(y=>new CategoryModel()
                {
                    Id =y.CategoryId,
                    Name=y.Category.Name,
                    Description=y.Category.Description,
                    CreatedOn=y.Category.CreatedOn
                }),
                Tags = x.PostTags.Select(y => new TagModel()
                {
                    Id = y.TagId,
                    Name = y.Tag.Name,
                    Description = y.Tag.Description,
                }),

            }).ToList();


            
            return posts;
        }

        public void Insert(PostModel postModel)
        {
            Post post = new Post()
            {
                Title = postModel.Title,
                Url = postModel.Url,
                Description = postModel.Description,
                Country = postModel.Country,
                CreatedOn = DateTime.Now,
                PublishedDate = postModel.PublishedDate               
            };                       
            _postRepository.InsertPost(post);
            _postRepository.Save();

            if (postModel.TagIds is not null)
            {
                foreach (var tagId in postModel.TagIds)
                {
                    var postTag = new PostTag()
                    {
                        PostId = post.Id,
                        TagId = tagId
                    };
                    _postRepository.InsertPostTag(postTag);
                    //_postRepository.Save();
                }
            }

            if (postModel.CategoryIds is not null)
            {
                foreach (var categoryId in postModel.CategoryIds)
                {
                    var postCategory = new PostCategory()
                    {
                        PostId = post.Id,
                        CategoryId = categoryId
                    };
                    _postRepository.InsertPostCategory(postCategory);
                }
            }
            _postRepository.Save();
        }

        public void Update(PostModel postModel)
        {
            var existingPost = _postRepository.GetPostById(postModel.Id);
            var existingCategories=existingPost.PostCategories.Where(x=>x.PostId==existingPost.Id).ToList();
            var existingTags=existingPost.PostTags.Where(x=>x.PostId == existingPost.Id).ToList();


            Post updatedPost = new Post()
            {
                Id = postModel.Id,
                Title = postModel.Title,
                Url = postModel.Url,
                Description = postModel.Description,
                Country = postModel.Country
            };
            _postRepository.UpdatePost(updatedPost);
            //remove uncheck tags if exists in database
            foreach (var tag in existingTags)
            {
                PostTag postTag = new PostTag()
                {
                    Id=tag.Id,
                    TagId = tag.TagId,
                    PostId=tag.PostId
                };
                if (!postModel.TagIds.Contains(tag.TagId))
                    _postRepository.DeletePostTag(postTag);
            }
            //save new checked tags            
            foreach (var tagId in postModel.TagIds)
            {
                if (!existingTags.Select(x => x.TagId).Contains(tagId))
                {
                    var postTag = new PostTag()
                    {
                        PostId = postModel.Id,
                        TagId = tagId
                    };
                    _postRepository.InsertPostTag(postTag);
                }
                //_postRepository.Save();
            }


            //remove uncheck categories if exist in database
            foreach (var category in existingCategories)
            {
                PostCategory postCategory = new PostCategory()
                {
                    Id = category.Id,
                    CategoryId = category.CategoryId,
                    PostId = category.PostId
                };
                if (!postModel.CategoryIds.Contains(category.CategoryId))
                    _postRepository.DeletePostCategory(postCategory);
            }
            //save nnew checked categories            
            foreach (var categoryId in postModel.CategoryIds)
            {
                if (!existingCategories.Select(x => x.CategoryId).Contains(categoryId))
                {
                    var postCategory = new PostCategory()
                    {
                        PostId = postModel.Id,
                        CategoryId = categoryId
                    };
                    _postRepository.InsertPostCategory(postCategory);
                }
            }


            _postRepository.Save();           


        }
    }
}
