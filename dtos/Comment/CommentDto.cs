using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.dtos.Comment
{
    public class CommentDto
    {
        public uint Id_Comment { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public required uint Id_Stock { get; set; }
        public string? CreatedBy { get; internal set; }
    }
}