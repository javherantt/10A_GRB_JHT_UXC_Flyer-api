using AutoMapper;
using Flyer.Domain.DTOs;
using Flyer.Domain.Entities;
using System;

namespace Flyer.Application.Mappings
{

    public class PostMapperProfile : Profile
    {
        public PostMapperProfile()
        {
            CreateMap<Post, PostRequestDto>();
            CreateMap<Post, PostResponseDto>();
            CreateMap<PostRequestDto, Post>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.Status = true;
            }));
            CreateMap<PostResponseDto, Post>();
        }

    }
}
