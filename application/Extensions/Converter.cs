using application.DTOs.Category;
using application.DTOs.Post;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace application.Extensions
{
    public static class Converter
    {
        public static CreateCategoryResponce ToCreateCategoryResponce(this Category category)
        {
            return new CreateCategoryResponce
            {
                Id = category.Id,
                Name = category.CategoryName
            };
        }

        public static Category ToCategory(this UpdateCategoryRequest request,ref Category category)
        {
            category.CategoryName = request.Name;
            return category;
        }

        public static Category ToCategory(this CreateCategoryRequest request)
        {
            return new Category
            {
                CategoryName = request.CategoryName,
                ParentId = request.ParentId != 0 ? request.ParentId : null
            };
        }

       public static CategoryResponce ToCategoryResponce(this Category categoryname)
        {
            return new CategoryResponce
            {
                Id = categoryname.Id,
                CategoryName = categoryname.CategoryName
            };
        }

        public static UpdateCategoryResponce ToUpdateCategoryResponce(this Category category)
        {
            return new UpdateCategoryResponce
            {
                Id = category.Id,
                Name = category.CategoryName
            };
        }

        public static Post ToPost(this CreatePostRequest request)
        {
            return new Post
            {
                Title = request.Title,
                Description = request.Description,
                ImagePath = request.Image.FileName
            };
        }

        public static CreatePostResponce ToCreatePostResponce(this Post post)
        {
            return new CreatePostResponce
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                ImagePath = post.ImagePath

            };
        }
    }
}
