using AutoMapper;
using Flyer.Domain.DTOs;
using Flyer.Domain.Entities;
using System;

namespace Flyer.Application.Mappings
{

    public class CommentMapperProfile : Profile
    {
        public CommentMapperProfile()
        {
            CreateMap<Comment, CommentRequestDto>();
            CreateMap<Comment, CommentResponseDto>();
            CreateMap<CommentRequestDto, Comment>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.Status = true;
            }));
            CreateMap<CommentResponseDto, Comment>();
        }

    }
}
