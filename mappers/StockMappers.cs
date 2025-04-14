using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using webapi.dtos.Stock;
using webapi.models;


namespace webapi.mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new StockDto
            {
                Id_Stock    = stockModel.Id_Stock,
                Symbol      = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase    = stockModel.Purchase,
                LastDiv     = stockModel.LastDiv,
                Id_Industry = stockModel.Id_Industry,
                MarketCap   = stockModel.MarketCap
            };
        }
        public static Stock ToStockFromCreateDto(this CreateStockRequestDto stockDto){
            return new Stock
            {
                Symbol      = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase    = stockDto.Purchase,
                LastDiv     = stockDto.LastDiv,
                Id_Industry = stockDto.Id_Industry,
                MarketCap   = stockDto.MarketCap
            };
        }
    }
}