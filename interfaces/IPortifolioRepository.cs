using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.models;

namespace webapi.interfaces
{
    public interface IPortifolioRepository
    {
        Task<List<Stock>> GetUserPortifolio(AppUser appUser);
        Task<Portifolio> CreatePortifolio(Portifolio portifolio);
        Task<Portifolio?> DeletePortifolio(AppUser appUser, string symbol);
    }
}