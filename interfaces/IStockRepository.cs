using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.dtos.Stock;
using webapi.models;

namespace webapi.interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllStocks();
        Task<Stock?> GetByIdStock(uint id);
        Task<Stock> CreateStock(Stock stock);
        Task<Stock?> UpdateStock(uint id, UpdateStockRequestDto updateStockDto);
        Task<Stock?> DeleteStock(uint id);
    }
}