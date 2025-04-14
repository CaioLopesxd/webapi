using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.models
{
public class Industry
{
    [Key]
    public uint Id_Industry { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<Stock> Stocks { get; set; } = new List<Stock>();
}

}