using AutoMapper;
using Flyer.Domain.DTOs;
using Flyer.Domain.Entities;
using System;

namespace Flyer.Application.Mappings
{

    public class FollowMapperProfile : Profile
    {
        public FollowMapperProfile()
        {
            CreateMap<Follow, FollowRequestDto>();
            CreateMap<Follow, FollowResponseDto>();
            CreateMap<FollowRequestDto, Follow>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.Status = true;
            }));
            CreateMap<FollowResponseDto, Follow>();
        }

    }
}
