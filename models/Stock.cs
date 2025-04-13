using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.models
{
    public class Stock
    {

        public uint Id_Stock { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,4)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal LastDiv { get; set; }
        public uint Id_Industry { get; set; }
        public long MarketCap { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
