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
   
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;
        private readonly IMapper _mapper;
        public FollowController(IFollowService followService, IMapper mapper)
        {
            this._followService = followService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var follows = await _followService.GetFollows();
            var followsDto = _mapper.Map<IEnumerable<Follow>, IEnumerable<FollowResponseDto>>(follows);
            var response = new ApiResponse<IEnumerable<FollowResponseDto>>(followsDto);

            return Ok(followsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var follow = await _followService.GetFollow(id);
            var followDto = _mapper.Map<Follow, FollowResponseDto>(follow);
            var response = new ApiResponse<FollowResponseDto>(followDto);

            return Ok(followDto);
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromForm] FollowRequestDto followRequestDto)
        {
            var follow = _mapper.Map<FollowRequestDto, Follow>(followRequestDto);
            await _followService.AddFollow(follow);
            var followresponseDto = _mapper.Map<Follow, FollowResponseDto>(follow);
            var response = new ApiResponse<FollowResponseDto>(followresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _followService.DeleteFollow(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut("id={id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm]FollowResponseDto followResponse)
        {
            var follow = _mapper.Map<Follow>(followResponse);
            follow.Id = id;
            follow.UpdateAt = DateTime.Now;
            follow.UpdatedBy = 1;
            await _followService.UpdateFollow(follow);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
