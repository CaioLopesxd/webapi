using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.data;
using webapi.dtos.Industry;
using webapi.interfaces;
using webapi.models;

namespace webapi.repository
{
    public class IndustriesRepository : IIndustriesRepository

    {
        private readonly ApplicationDbContext _context;

        public IndustriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Industry> CreateIndustry(Industry industryModel)
        {
            await _context.Industries.AddAsync(industryModel);
            await _context.SaveChangesAsync();
            return industryModel;
        }

        public async Task<Industry?> DeleteIndustry(uint id)
        {
            var industry = await _context.Industries.FirstOrDefaultAsync(x => x.Id_Industry == id);

            if (industry == null)
            {
                return null;
            }

            _context.Industries.Remove(industry);
            await _context.SaveChangesAsync();

            return industry;
        }

        public async Task<List<Industry>> GetAllIndustries()
        {
            return await _context.Industries.Include(i => i.Stocks).ToListAsync();
        }

        public async Task<Industry?> GetByIdIndustry(uint id)
        {
            return await _context.Industries.FindAsync(id);
        }

        public async Task<string> GetIndustryNameById(uint id)
        {
            var industry = await _context.Industries.FindAsync(id);
            return industry?.Description ?? string.Empty;
        }


        public async Task<bool> IndustryExists(uint id)
        {
            return await _context.Industries.AnyAsync(i => i.Id_Industry == id);
        }

        public async Task<Industry?> UpdateIndustry(uint id, UpdateIndustryRequestDto industryModel)
        {
            var existingIndustry = await _context.Industries.FirstOrDefaultAsync(i => i.Id_Industry == id);

            if (existingIndustry == null)
            {
                return null;
            }

            _context.Entry(existingIndustry).CurrentValues.SetValues(industryModel);
            await _context.SaveChangesAsync();

            return existingIndustry;
        }
    }
}