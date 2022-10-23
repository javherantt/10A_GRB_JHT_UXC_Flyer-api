using AutoMapper;
using Flyer.Api.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Flyer.Domain.Interfaces;
using Flyer.Domain.Entities;
using Flyer.Domain.DTOs;


namespace Flyer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper)
        {
            this._commentService = commentService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentService.GetComments();
            var commentsDto = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentResponseDto>>(comments);
            var response = new ApiResponse<IEnumerable<CommentResponseDto>>(commentsDto);

            return Ok(commentsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var comment = await _commentService.GetComment(id);
            var commentDto = _mapper.Map<Comment, CommentResponseDto>(comment);
            var response = new ApiResponse<CommentResponseDto>(commentDto);

            return Ok(commentDto);
        }



        [HttpPost]
        public async Task<IActionResult> Post(CommentRequestDto commentRequestDto)
        {
            var comment = _mapper.Map<CommentRequestDto, Comment>(commentRequestDto);
            await _commentService.AddComment(comment);
            var commentresponseDto = _mapper.Map<Comment, CommentResponseDto>(comment);
            var response = new ApiResponse<CommentResponseDto>(commentresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _commentService.DeleteComment(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, CommentResponseDto commentResponse)
        {
            var comment = _mapper.Map<Comment>(commentResponse);
            comment.Id = id;
            comment.UpdateAt = DateTime.Now;
            comment.UpdatedBy = 1;
            await _commentService.UpdateComment(comment);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
