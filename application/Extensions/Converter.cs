using application.DTOs.Banner;
using application.DTOs.Category;
using application.DTOs.Description;
using application.DTOs.Post;
using application.DTOs.ThematicAreaPost;
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
                DescriptionId = categoryname.Description?.Id,
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
                ImagePath = request.Image.FileName,
                //AdditionalImagePath = request.AdditionalImages.Select(x => x.FileName).ToList()
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

        public static UpdateBannerResponce ToUpdateBannerResponce(this Banner banner)
        {
            return new UpdateBannerResponce
            {
                Id = banner.Id,
                DescriptionBannerTJ = banner.DescriptionTJ,
                DescriptionBannerEN = banner.DescriptionEN,
                ImagePath = banner.ImagePath
            };
        }

        public static Banner ToBanner(this UpdateBannerRequest request,ref Banner banner)
        {
            banner.DescriptionTJ = request.DescriptionBannerTJ;
            banner.DescriptionEN = request.DescriptionBannerEN;
            return banner;
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

        public static DescriptionResponce ToDescriptionResponce(this Description description)
        {
            return new DescriptionResponce
            {
                Id = description.Id,
                TextEN = description.TextEN,
                TextTJ = description.TextTJ,
                CategoryId = description.CategoryId
            };
        }

        public static UpdateDescriptionResponce ToUpdateDescriptionResponce(this Description description)
        {
            return new UpdateDescriptionResponce
            {
                Id = description.Id,
                TextTJ = description.TextTJ,
                TextEN = description.TextEN,
                CategoryId = description.CategoryId
            };
        }
        public static Description ToDescription(this UpdateDescriptionRequest request,ref Description description)
        {
            description.TextTJ = request.TextTJ;
            description.TextEN = request.TextEN;
            description.CategoryId = request.CategoryId;
            return description;
        }

        public static ThematicAreaPost ToThematicAreaPost(this CreateThematicAreaPostRequest request)
        {
            return new ThematicAreaPost
            {
                TitleEN = request.TitleEN,
                TitleTJ = request.TitleTJ,
                DescriptionEN = request.DescriptionEN,
                DescriptionTJ = request.DescriptionTJ
            };
        }
        public static CreateThematicAreaPostResponse ToCreateThematicAreaPostResponse(this ThematicAreaPost thematicAreaPost)
        {
            var result = new CreateThematicAreaPostResponse()
            {
                Id = thematicAreaPost.Id,
                TitleTJ = thematicAreaPost.TitleTJ,
                TitleEN = thematicAreaPost.TitleEN,
                DescriptionTJ = thematicAreaPost.DescriptionTJ,
                DescriptionEN = thematicAreaPost.DescriptionEN
            };
            var images = new List<FileResponse>();

            for (int i = 0; i < thematicAreaPost.Files.Count(); ++i)
            {
                var cur = new FileResponse()
                {
                    Id = thematicAreaPost.Files[i].Id,
                    IsMain = thematicAreaPost.Files[i].IsMain,
                    FilePath = thematicAreaPost.Files[i].Path
                };
                images.Add(cur);
            }
            result.Files = images;
            return result;
        }

        public static ThematicAreaPostResponse ToThematicAreaPost(ThematicAreaPost thematicAreaPost)
        {
            return new ThematicAreaPostResponse
            {
                Id = thematicAreaPost.Id,
                TitleEN = thematicAreaPost.TitleEN,
                TitleTJ = thematicAreaPost.TitleTJ,
                DescriptionEN = thematicAreaPost.DescriptionEN,
                DescriptionTJ = thematicAreaPost.DescriptionTJ
            };
        }
    }
}
