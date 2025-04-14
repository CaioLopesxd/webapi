using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.models
{
    public class Comment
    {
        [Key]
        public uint Id_Comment{ get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public required uint Id_Stock { get; set; }
        public Stock? Stock { get; set; }
    }
}