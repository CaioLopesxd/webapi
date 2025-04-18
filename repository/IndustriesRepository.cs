using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.data;
using webapi.interfaces;

namespace webapi.repository
{
    public class IndustriesRepository : IIndustriesRepository

    {
        private readonly ApplicationDbContext _context;

        public IndustriesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> IndustryExists(uint id)
        {
            return _context.Industries.AnyAsync(i => i.Id_Industry == id);
        }
    }
}