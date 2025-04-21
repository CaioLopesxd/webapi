using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.data;
using webapi.interfaces;
using webapi.models;

namespace webapi.repository
{
    public class PortifolioRepository : IPortifolioRepository
    {
        private readonly ApplicationDbContext _context;
        public PortifolioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Portifolio> CreatePortifolio(Portifolio portifolio)
        {
            await _context.Portifolios.AddAsync(portifolio);
            await _context.SaveChangesAsync();
            return portifolio;
        }

        public async Task<Portifolio?> DeletePortifolio(AppUser appUser, string symbol)
        {
            var portifolioModel = await _context.Portifolios.FirstOrDefaultAsync(x => x.AppUserId == appUser.Id && x.Stock.Symbol.ToLower() == symbol.ToLower());

            if (portifolioModel == null) return null;

            _context.Portifolios.Remove(portifolioModel);
            await _context.SaveChangesAsync();

            return portifolioModel;
        }

        public async Task<List<Stock>> GetUserPortifolio(AppUser appUser)
        {
            return await _context.Portifolios.Where(u => u.AppUserId == appUser.Id).Select(stock => new Stock
            {
                Id_Stock = stock.Id_Stock,
                Symbol = stock.Stock.Symbol,
                CompanyName = stock.Stock.CompanyName,
                Purchase = stock.Stock.Purchase,
                LastDiv = stock.Stock.LastDiv,
                Id_Industry = stock.Stock.Id_Industry,
                MarketCap = stock.Stock.MarketCap,
            }).ToListAsync();
        }
    }
}