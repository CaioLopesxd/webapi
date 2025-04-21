using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapi.extentions;
using webapi.interfaces;
using webapi.models;
using webapi.repository;

namespace webapi.controllers
{
    [Route("api/portifolio")]
    [ApiController]
    public class PortifolioController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStockRepository _stockRepository;
        private readonly IPortifolioRepository _portifolioRepository;
        public PortifolioController(UserManager<AppUser> userManager, IStockRepository stockRepository, IPortifolioRepository portifolioRepository)
        {
            _userManager = userManager;
            _stockRepository = stockRepository;
            _portifolioRepository = portifolioRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserPortifolio()
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var userPortifolio = await _portifolioRepository.GetUserPortifolio(appUser);

            return Ok(userPortifolio);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPortifolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);
            var stock = await _stockRepository.GetBySymbol(symbol);

            if (stock == null) return BadRequest("Stock not found");

            var userPortifolio = await _portifolioRepository.GetUserPortifolio(appUser);

            if (userPortifolio.Any(e => e.Symbol.ToLower() == stock.Symbol.ToLower())) return BadRequest("Cannot add Same Stock to the portifolio");

            var portifolioModel = new Portifolio
            {
                Id_Stock = stock.Id_Stock,
                AppUserId = appUser.Id
            };

            await _portifolioRepository.CreatePortifolio(portifolioModel);
            if (portifolioModel == null) return StatusCode(500, "Could not create");

            return Created();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeletePortifolio(string symbol)
        {
            var username = User.GetUsername();
            var appUser = await _userManager.FindByNameAsync(username);


            var userPortifolio = await _portifolioRepository.GetUserPortifolio(appUser);

            var stockFiltered = userPortifolio.Where(s => s.Symbol.ToLower() == symbol.ToLower()).ToList();

            if (stockFiltered.Count() == 1)
            {
                await _portifolioRepository.DeletePortifolio(appUser, symbol);
            }
            else
            {
                return BadRequest("Stock Is not in your portifolio");
            }

            return Ok();
        }
    }
}