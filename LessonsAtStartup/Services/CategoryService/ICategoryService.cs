﻿using LessonsAtStartup.Controllers;
using LessonsAtStartup.Data.Entities;
using LessonsAtStartup.Models;

namespace LessonsAtStartup.Services.CategoryService
{
    public interface ICategoryService
    {
        IEnumerable<CategoryModel> GetCategories();
        CategoryModel GetById(int categoryId);
        void Insert(CategoryModel category);
        void Delete(int categoryId);
        void Update(CategoryModel category);
    }
}
