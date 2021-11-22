using application.DTOs.Banner;
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
                CategoryRU = category.CategoryRU,
                CategoryEN = category.CategoryEN
            };
        }

        public static Category ToCategory(this UpdateCategoryRequest request,ref Category category)
        {
            category.CategoryRU = request.CategoryRU;
            category.CategoryEN = request.CategoryEN;
 //           category.ParentId = request.ParentId == 0 ? null : request.ParentId;
            return category;
        }

        public static Category ToCategory(this CreateCategoryRequest request)
        {
            return new Category
            {
                CategoryRU = request.CategoryRU,
                CategoryEN = request.CategoryEN,
                ParentId = request.ParentId != 0 ? request.ParentId : null
            };
        }

       public static CategoryResponce ToCategoryResponce(this Category categoryname)
        {
            return new CategoryResponce
            {
                Id = categoryname.Id,
                CategoryRU = categoryname.CategoryRU,
                CategoryEN = categoryname.CategoryEN,
                SubCategories = categoryname.SubCategories.Select(x=>x.ToCategoryResponce())
            };
        }

        public static UpdateCategoryResponce ToUpdateCategoryResponce(this Category category)
        {
            return new UpdateCategoryResponce
            {
                Id = category.Id,
                CategoryRU = category.CategoryRU,
                CategoryEN = category.CategoryEN
            };
        }

        public static Post ToPost(this UpdatePostRequest request,ref Post post)
        {
            post.Title = request.Title;
            post.Description = request.Description;
            post.ImagePath = request.Image.FileName;
            return post;
        }

        public static UpdatePostResponce ToUpdatePostResponce(this Post post)
        {
            return new UpdatePostResponce
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                ImagePath = post.ImagePath
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

        public static PostResponce ToPostResponce(this Post post)
        {
            return new PostResponce
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                ImagePath = post.ImagePath
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

        public static CreateBannerResponce ToCreateBannerResponce(this Banner banner)
        {
            return new CreateBannerResponce
            {
                Id = banner.Id,
                ImagePath = banner.ImagePath,
                PostId = banner.PostId,
                Description = banner.Description
            };
        }

        public static Banner ToBanner(this CreateBannerRequest request)
        {
            return new Banner
            {
                ImagePath = request.Image.FileName,
                PostId = request.PostId,
                Description = request.Description
            };
        }

        public static BannerResponce ToBannerResponce(this Banner banner)
        {
            return new BannerResponce
            {
                Id = banner.Id,
                ImagePath = banner.ImagePath,
                PostId = banner.PostId,
                DescriptionBanner = banner.Description
            };
        }
    }
}
