using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.data;
using webapi.dtos.Stock;
using webapi.helpers;
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

        private readonly IIndustriesRepository _industriesRepository;
        public StockController(ApplicationDbContext context, IStockRepository stockRepository, IIndustriesRepository industriesRepository)
        {
            _industriesRepository = industriesRepository;
            _context = context;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStock([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stocks = await _stockRepository.GetAllStocks(query);

            var stocksDto = stocks.Select(s => s.ToStockDto()).ToList();

            return Ok(stocksDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdStock([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stock = await _stockRepository.GetByIdStock(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] CreateStockRequestDto createStockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = createStockDto.ToStockFromCreateDto();

            if (!await _industriesRepository.IndustryExists(stockModel.Id_Industry))
            {
                return BadRequest("Industry not found");
            }

            await _stockRepository.CreateStock(stockModel);

            return CreatedAtAction(nameof(GetByIdStock), new { id = stockModel.Id_Stock }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateStock([FromRoute] uint id, [FromBody] UpdateStockRequestDto updateStockDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockModel = await _stockRepository.UpdateStock(id, updateStockDto);

            if (stockModel == null)
            {
                return NotFound();
            }

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteStock([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var stockModel = await _stockRepository.DeleteStock(id);

            if (stockModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}