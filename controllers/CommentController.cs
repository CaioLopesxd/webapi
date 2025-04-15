using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using webapi.dtos.Comment;
using webapi.interfaces;
using webapi.mappers;

namespace webapi.controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            var comments = await _commentRepository.GetAllComment();
            var commentsDto = comments.Select(s => s.ToCommentDto()).ToList();
            return Ok(commentsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdComment([FromRoute] uint id)
        {
            var comment = await _commentRepository.GetByIdComment(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{id_stock}")]
        public async Task<IActionResult> CreateComment([FromRoute] uint id_stock, CreateCommentRequestDto createCommentDto)
        {
            if (!await _stockRepository.StockExists(id_stock))
            {
                return BadRequest("Stock Doesn t exist");
            }

            var commentModel = createCommentDto.ToCommentFromCreateDto(id_stock);

            await _commentRepository.CreateComment(commentModel);

            return CreatedAtAction(nameof(GetByIdComment), new { id = commentModel.Id_Comment }, commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] uint id)
        {
            var commentModel = await _commentRepository.DeleteComment(id);

            if (commentModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateComment([FromRoute] uint id, [FromBody] UpdateCommentRequestDto updateCommentDto)
        {
            var commentModel = await _commentRepository.UpdateComment(id, updateCommentDto);

            if (commentModel == null)
            {
                return NotFound();
            }
            return Ok(commentModel.ToCommentDto());
        }
    }
}