using application.DTOs.Description;
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
    public class DescriptionService:IDescriptionService
    {
        private readonly VatanDbContext _context;
        public DescriptionService(VatanDbContext context)
        {
            _context = context;
        }

        public async Task<CreateDescriptionResponce> CreateAsync(CreateDescriptionRequest request)
        {
            var description = request.ToDescription();
            await _context.Descriptions.AddAsync(description);
            await _context.SaveChangesAsync();
            return description.ToCreateDescriptionResponce();
        }

        public async Task<int> DeleteByIdAsync(int id)
        {
            var description = await _context.Descriptions.FindAsync(id);
            if (description == null)
                return default;
            _context.Remove(description);
            await _context.SaveChangesAsync();
            return description.Id;
        }

        public async Task<IEnumerable<DescriptionResponce>> GetAllAsync()
        {
            return await _context.Descriptions.Include(x => x.Category).Select(x =>
            new DescriptionResponce
            {
                Id = x.Id,
                TextTJ = x.TextTJ,
                TextEN = x.TextEN,
                CategoryId = x.Category.Id
            }).ToListAsync();
        }
    }
}
