using AutoMapper;
using Flyer.Domain.DTOs;
using Flyer.Domain.Entities;
using System;

namespace Flyer.Application.Mappings
{

    public class LikeMapperProfile : Profile
    {
        public LikeMapperProfile()
        {
            CreateMap<Like, LikeRequestDto>();
            CreateMap<Like, LikeResponseDto>();
            CreateMap<LikeRequestDto, Like>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.Status = true;
            }));
            CreateMap<LikeResponseDto, Like>();
        }

    }
}
