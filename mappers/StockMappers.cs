using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}