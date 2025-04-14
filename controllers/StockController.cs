using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.data;
using webapi.dtos.Stock;
using webapi.mappers;

namespace webapi.controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllStock()
        {
            var stocks = await _context.Stocks.ToListAsync();

            var stocksDto = stocks.Select(s => s.ToStockDto()).ToList();

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdStock([FromRoute] int id)
        {
            var stock = await _context.Stocks
                .FromSqlRaw("SELECT Stocks.Id_Stock, Stocks.Symbol, Stocks.CompanyName, Stocks.Purchase, Stocks.LastDiv, Stocks.MarketCap, Stocks.Id_Industry FROM Stocks WHERE Stocks.Id_Stock = {0}", id)
                .FirstOrDefaultAsync();

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockRequestDto createStockDto)
        {
            var stockModel = createStockDto.ToStockFromCreateDto();
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetByIdStock), new { id = stockModel.Id_Stock }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStock([FromRoute] uint id, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id_Stock == id);

            if (stockModel == null)
            {
                return NotFound();
            }

            _context.Entry(stockModel).CurrentValues.SetValues(updateStockDto);

            await _context.SaveChangesAsync();

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] uint id)
        {
            var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id_Stock == id);

            if (stockModel == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}