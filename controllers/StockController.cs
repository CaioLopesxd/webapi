using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.data;
using webapi.dtos.Stock;
using webapi.interfaces;
using webapi.mappers;
using webapi.repository;

namespace webapi.controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStockRepository _stockRepository;
        public StockController(ApplicationDbContext context, IStockRepository stockRepository)
        {
            _context = context;
            _stockRepository = stockRepository;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllStock()
        {
            var stocks = await _stockRepository.GetAllStocks();

            var stocksDto = stocks.Select(s => s.ToStockDto()).ToList();

            return Ok(stocksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdStock([FromRoute] int id)
        {
            var stock = await _stockRepository.GetByIdStock((uint)id);

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
            await _stockRepository.CreateStock(stockModel);

            return CreatedAtAction(nameof(GetByIdStock), new { id = stockModel.Id_Stock }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStock([FromRoute] uint id, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            var stockModel = await _stockRepository.UpdateStock(id, updateStockDto);

            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStock([FromRoute] uint id)
        {
            var stockModel = await _stockRepository.DeleteStock(id);

            if (stockModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}