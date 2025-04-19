using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using webapi.dtos.Comment;
using webapi.models;

namespace webapi.dtos.Stock
{
    public class StockDto
    {
        public uint Id_Stock { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public uint Id_Industry { get; set; }
        public string? IndustryDescription { get; set; } = string.Empty;
        public long MarketCap { get; set; }
        public List<CommentDto>? Comments { get; set; }
    }
}