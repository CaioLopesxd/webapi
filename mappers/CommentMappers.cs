using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.dtos.Comment;
using webapi.models;

namespace webapi.mappers
{
    public static class CommentMappers
    {
        public static CommentDto ToCommentDto(this Comment CommentModel)
        {
            return new CommentDto
            {
                Id_Comment = CommentModel.Id_Comment,
                Title = CommentModel.Title,
                Content = CommentModel.Content,
                CreatedOn = CommentModel.CreatedOn,
                CreatedBy = CommentModel.AppUser.UserName,
                Id_Stock = CommentModel.Id_Stock
            };
        }
        public static Comment ToCommentFromCreateDto(this CreateCommentRequestDto commentDto, uint id_Stock)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                Id_Stock = id_Stock
            };
        }
    }
}