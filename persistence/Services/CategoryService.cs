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
            return await _context.Categories.Select(x => x.ToCategoryResponce()).ToListAsync();
        }

        
    }
}
