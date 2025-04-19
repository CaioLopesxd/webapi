using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using webapi.data;
using webapi.dtos.Comment;
using webapi.dtos.Stock;
using webapi.helpers;
using webapi.interfaces;
using webapi.models;

namespace webapi.repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Stock>> GetAllStocks(QueryObject query)
        {
            var stocks = _context.Stocks.Include(i => i.Industry)
                                  .Include(i => i.Comments)
                                 .AsQueryable();
            if (!string.IsNullOrEmpty(query.CompanyName))
            {
                stocks = stocks.Where(s => s.CompanyName.Contains(query.CompanyName));
            }

            if (!string.IsNullOrEmpty(query.Symbol))
            {
                stocks = stocks.Where(s => s.Symbol.Contains(query.Symbol));
            }

            if (query.SortBy != null)
            {
                switch (query.SortBy)
                {
                    case StockSortOptions.Symbol:
                        stocks = query.IsDescending == true
                            ? stocks.OrderByDescending(s => s.Symbol)
                            : stocks.OrderBy(s => s.Symbol);
                        break;

                    case StockSortOptions.CompanyName:
                        stocks = query.IsDescending == true
                            ? stocks.OrderByDescending(s => s.CompanyName)
                            : stocks.OrderBy(s => s.CompanyName);
                        break;
                }
            }

            var skipNumber = (query.PageNumber - 1) * query.PageSize;

            return await stocks.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }
        public async Task<Stock?> GetByIdStock(uint id)
        {
            return await _context.Stocks
                                 .Include(c => c.Comments)
                                 .Include(i => i.Industry)
                                 .FirstOrDefaultAsync(s => s.Id_Stock == id);
        }

        public async Task<Stock> CreateStock(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }
        public async Task<Stock?> DeleteStock(uint id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id_Stock == id);

            if (stock == null)
            {
                return null;
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        public async Task<Stock?> UpdateStock(uint id, UpdateStockRequestDto updateStockDto)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id_Stock == id);

            if (stockModel == null)
            {
                return null;
            }

            _context.Entry(stockModel).CurrentValues.SetValues(updateStockDto);

            await _context.SaveChangesAsync();

            return stockModel;
        }

        public Task<bool> StockExists(uint id)
        {
            return _context.Stocks.AnyAsync(s => s.Id_Stock == id);
        }
    }
}