using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.data;
using webapi.dtos.Comment;
using webapi.interfaces;
using webapi.models;

namespace webapi.repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateComment(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();

            return commentModel;
        }

        public async Task<Comment?> DeleteComment(uint id)
        {
            var comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id_Comment == id);

            if (comment == null)
            {
                return null;
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return comment;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _context.Comments
                       .FromSqlRaw("SELECT * FROM comments")
                       .ToListAsync();
        }

        public async Task<Comment?> GetByIdComment(uint id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment?> UpdateComment(uint id, UpdateCommentRequestDto updateCommentDto)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x => x.Id_Comment == id);

            if (commentModel == null)
            {
                return null;
            }

            _context.Entry(commentModel).CurrentValues.SetValues(updateCommentDto);

            await _context.SaveChangesAsync();

            return commentModel;
        }
    }
}