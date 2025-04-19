using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using webapi.dtos.Stock;

namespace webapi.dtos.Industry
{
    public class IndustryDto
    {
        public string Description { get; set; } = string.Empty;
        public List<StockDto>? Stocks { get; set; }
    }
}