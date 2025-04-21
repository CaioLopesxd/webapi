using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.models
{
    [Table("Portifolios")]
    public class Portifolio
    {
        public string AppUserId { get; set; }
        public uint Id_Stock { get; set; }
        public AppUser AppUser { get; set; }
        public Stock Stock { get; set; }
    }
}