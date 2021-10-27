using application.DTOs.Category;
using domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.Extensions
{
    public static class Converter
    {
        public static CreateCategoryResponce ToCreateCategoryResponce(this Category category)
        {
            return new CreateCategoryResponce
            {
                Id = category.Id
            };
        }

        public static Category ToCategory(this CreateCategoryRequest request)
        {
            return new Category
            {
                CategoryName = request.CategoryName
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
    }
}
