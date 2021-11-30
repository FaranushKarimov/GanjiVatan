using application.DTOs.Banner;
using application.DTOs.Category;
using application.DTOs.Description;
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
                CategoryTJ = category.CategoryTJ,
                CategoryEN = category.CategoryEN
            };
        }

        public static Category ToCategory(this UpdateCategoryRequest request,ref Category category)
        {
            category.CategoryTJ = request.CategoryTJ;
            category.CategoryEN = request.CategoryEN;
 //           category.ParentId = request.ParentId == 0 ? null : request.ParentId;
            return category;
        }

        public static Category ToCategory(this CreateCategoryRequest request)
        {
            return new Category
            {
                CategoryTJ = request.CategoryTJ,
                CategoryEN = request.CategoryEN,
                ParentId = request.ParentId != 0 ? request.ParentId : null
            };
        }

       public static CategoryResponce ToCategoryResponce(this Category categoryname)
        {
            return new CategoryResponce
            {
                Id = categoryname.Id,
                CategoryTJ = categoryname.CategoryTJ,
                CategoryEN = categoryname.CategoryEN,
                DescriptionId = categoryname.Description.Id,
                SubCategories = categoryname.SubCategories.Select(x=>x.ToCategoryResponce())
            };
        }

        public static UpdateCategoryResponce ToUpdateCategoryResponce(this Category category)
        {
            return new UpdateCategoryResponce
            {
                Id = category.Id,
                CategoryTJ = category.CategoryTJ,
                CategoryEN = category.CategoryEN
            };
        }

        public static Post ToPost(this UpdatePostRequest request,ref Post post)
        {
            post.TitleTJ = request.TitleTJ;
            post.TitleEN = request.TitleEN;
            post.DescriptionTJ = request.DescriptionTJ;
            post.DescriptionEN = request.DescriptionEN;
            return post;
        }

        public static UpdatePostResponce ToUpdatePostResponce(this Post post)
        {
            return new UpdatePostResponce
            {
                Id = post.Id,
                TitleTJ = post.TitleTJ,
                TitleEN = post.TitleEN,
                DescriptionTJ = post.DescriptionTJ,
                DescriptionEN = post.DescriptionEN,
                ImagePath = post.ImagePath
            };
        }
        public static Post ToPost(this CreatePostRequest request)
        {
            return new Post
            {
                TitleTJ = request.TitleTJ,
                TitleEN = request.TitleEN,
                DescriptionTJ = request.DescriptionTJ,
                DescriptionEN = request.DescriptionEN,
                ImagePath = request.Image.FileName
            };
        }

        public static PostResponce ToPostResponce(this Post post)
        {
            return new PostResponce
            {
                Id = post.Id,
                TitleTJ = post.TitleTJ,
                TitleEN = post.TitleEN,
                DescriptionTJ = post.DescriptionTJ,
                DescriptionEN = post.DescriptionEN,
                ImagePath = post.ImagePath
            };
        }
        public static CreatePostResponce ToCreatePostResponce(this Post post)
        {
            return new CreatePostResponce
            {
                Id = post.Id,
                TitleTJ = post.TitleTJ,
                TitleEN = post.TitleEN,
                DescriptionTJ = post.DescriptionTJ,
                DescriptionEN = post.DescriptionEN,
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
                DescriptionBannerTJ = banner.DescriptionTJ,
                DescriptionBannerEN = banner.DescriptionEN
            };
        }

        public static Banner ToBanner(this CreateBannerRequest request)
        {
            return new Banner
            {
                ImagePath = request.Image.FileName,
                PostId = request.PostId,
                DescriptionTJ = request.DescriptionBannerTJ,
                DescriptionEN = request.DescriptionBannerEN
            };
        }

        public static BannerResponce ToBannerResponce(this Banner banner)
        {
            return new BannerResponce
            {
                Id = banner.Id,
                ImagePath = banner.ImagePath,
                PostId = banner.PostId,
                DescriptionTJBanner = banner.DescriptionTJ,
                DescriptionENBanner = banner.DescriptionEN
            };
        }

        public static Description ToDescription(this CreateDescriptionRequest request)
        {
            return new Description
            {
                TextEN = request.TextEN,
                TextTJ = request.TextTJ,
                CategoryId = request.CategoryId
            };
        }

        public static CreateDescriptionResponce ToCreateDescriptionResponce(this Description description)
        {
            return new CreateDescriptionResponce
            {
                Id = description.Id,
                TextEN = description.TextEN,
                TextTJ = description.TextTJ,
                CategoryId = description.CategoryId
            };
        }
    }
}
