using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.interfaces
{
    public interface IIndustriesRepository
    {
        Task<bool> IndustryExists(uint id);

    }
}