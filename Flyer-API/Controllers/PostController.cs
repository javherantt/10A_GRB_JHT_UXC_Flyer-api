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

    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        public PostController(IPostService postService, IMapper mapper)
        {
            this._postService = postService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _postService.GetPosts();
            var postsDto = _mapper.Map<IEnumerable<Post>, IEnumerable<PostResponseDto>>(posts);
            var response = new ApiResponse<IEnumerable<PostResponseDto>>(postsDto);

            return Ok(postsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _postService.GetPost(id);
            var postDto = _mapper.Map<Post, PostResponseDto>(post);
            var response = new ApiResponse<PostResponseDto>(postDto);

            return Ok(postDto);
        }



        [HttpPost]
        public async Task<IActionResult> Post(PostRequestDto postRequestDto)
        {
            var post = _mapper.Map<PostRequestDto, Post>(postRequestDto);
            await _postService.AddPost(post);
            var postresponseDto = _mapper.Map<Post, PostResponseDto>(post);
            var response = new ApiResponse<PostResponseDto>(postresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _postService.DeletePost(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PostResponseDto postResponse)
        {
            var post = _mapper.Map<Post>(postResponse);
            post.Id = id;
            post.UpdateAt = DateTime.Now;
            post.UpdatedBy = 1;
            await _postService.UpdatePost(post);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
