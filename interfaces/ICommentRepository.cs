using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.dtos.Comment;
using webapi.models;

namespace webapi.interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllComment();
        Task<Comment?> GetByIdComment(uint id);
        Task<Comment> CreateComment(Comment commentModel);
        Task<Comment?> UpdateComment(uint id, UpdateCommentRequestDto updateCommentDto);
        Task<Comment?> DeleteComment(uint id);
    }
}