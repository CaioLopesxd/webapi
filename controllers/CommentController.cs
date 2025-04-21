using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using webapi.dtos.Comment;
using webapi.extentions;
using webapi.interfaces;
using webapi.mappers;
using webapi.models;

namespace webapi.controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository, UserManager<AppUser> userManager)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comments = await _commentRepository.GetAllComments();
            var commentsDto = comments.Select(s => s.ToCommentDto()).ToList();
            return Ok(commentsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdComment([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = await _commentRepository.GetByIdComment(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{id_stock:int}")]
        [Authorize]
        public async Task<IActionResult> CreateComment([FromRoute] uint id_stock, CreateCommentRequestDto createCommentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _stockRepository.StockExists(id_stock))
            {
                return BadRequest("Stock Doesn t exist");
            }

            var username = User.GetUsername();
            var AppUser = await _userManager.FindByNameAsync(username);

            var commentModel = createCommentDto.ToCommentFromCreateDto(id_stock);

            commentModel.AppUserId = AppUser.Id;

            await _commentRepository.CreateComment(commentModel);
            return CreatedAtAction(nameof(GetByIdComment), new { id = commentModel.Id_Comment }, commentModel.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteComment([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentModel = await _commentRepository.DeleteComment(id);

            if (commentModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] uint id, [FromBody] UpdateCommentRequestDto updateCommentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commentModel = await _commentRepository.UpdateComment(id, updateCommentDto);

            if (commentModel == null)
            {
                return NotFound();
            }
            return Ok(commentModel.ToCommentDto());
        }
    }
}