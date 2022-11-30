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

    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        public TagController(ITagService tagService, IMapper mapper)
        {
            this._tagService = tagService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tags = await _tagService.GetTags();
            var tagsDto = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagResponseDto>>(tags);
            var response = new ApiResponse<IEnumerable<TagResponseDto>>(tagsDto);

            return Ok(tagsDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var tag = await _tagService.GetTag(id);
            var tagDto = _mapper.Map<Tag, TagResponseDto>(tag);
            var response = new ApiResponse<TagResponseDto>(tagDto);

            return Ok(tagDto);
        }



        [HttpPost]
        public async Task<IActionResult> Post([FromForm] TagRequestDto tagRequestDto)
        {
            var tag = _mapper.Map<TagRequestDto, Tag>(tagRequestDto);
            await _tagService.AddTag(tag);
            var tagresponseDto = _mapper.Map<Tag, TagResponseDto>(tag);
            var response = new ApiResponse<TagResponseDto>(tagresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _tagService.DeleteTag(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, TagResponseDto tagResponse)
        {
            var tag = _mapper.Map<Tag>(tagResponse);
            tag.Id = id;
            tag.UpdateAt = DateTime.Now;
            tag.UpdatedBy = 1;
            await _tagService.UpdateTag(tag);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }
    }
}
