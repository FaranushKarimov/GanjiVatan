using application.DTOs.Category;
using application.Extensions;
using application.Services;
using Microsoft.EntityFrameworkCore;
using persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Entities;

namespace persistence.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly VatanDbContext _context;

        public CategoryService(VatanDbContext context)
        {
            _context = context;
        }
        public async Task<CreateCategoryResponce> CreateAsync(CreateCategoryRequest request)
        {
            var categoryName = request.ToCategory();
            await _context.Categories.AddAsync(categoryName);
            await _context.SaveChangesAsync();
            return categoryName.ToCreateCategoryResponce();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var categoryName = await _context.Categories.FindAsync(id);
            if (categoryName == null)
                return default;
            _context.Remove(categoryName);
            await _context.SaveChangesAsync();
            return categoryName.Id;
        }

        public async Task<IEnumerable<CategoryResponce>> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            var superCategories = categories.Where(x => x.ParentId == null).ToList();
            foreach (var superCategory in superCategories)
            {
                await GetSubcategories(superCategory, categories);
            }
            return superCategories.Select(x=>x.ToCategoryResponce());
        }
        
        private async Task GetSubcategories(Category superCategory, IEnumerable<Category> categories)
        {
            superCategory.SubCategories = categories.Where(x => x.ParentId == superCategory.Id).ToList();
            foreach (var category in superCategory.SubCategories)
            {
                await GetSubcategories(category, categories);
            }
        }

        public async Task<UpdateCategoryResponce> UpdateAsync(int id,UpdateCategoryRequest request)
        {
            //            var category = await _context.Categories.FindAsync(request.Id);
            var category = await _context.Categories.FindAsync(id);
            if (category == null)
                return null;
            request.ToCategory(ref category);
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category.ToUpdateCategoryResponce();
        }
    }
}
