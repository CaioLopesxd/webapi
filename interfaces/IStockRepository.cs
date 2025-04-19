using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.dtos.Comment;
using webapi.dtos.Stock;
using webapi.helpers;
using webapi.models;

namespace webapi.interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllStocks(QueryObject query);
        Task<Stock?> GetByIdStock(uint id);
        Task<Stock> CreateStock(Stock stock);
        Task<Stock?> UpdateStock(uint id, UpdateStockRequestDto updateStockDto);
        Task<Stock?> DeleteStock(uint id);
        Task<bool> StockExists(uint id);
  
    }
}