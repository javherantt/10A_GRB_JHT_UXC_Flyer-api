using AutoMapper;
using Flyer.Domain.DTOs;
using Flyer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flyer.Application.Mappings
{
    public class TagMapperProfile : Profile
    {
        public TagMapperProfile()
        {
            CreateMap<Tag, TagRequestDto>();
            CreateMap<Tag, TagResponseDto>();
            CreateMap<TagRequestDto, Tag>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.Status = true;
            }));
            CreateMap<TagResponseDto, Tag>();
        }

    }
}
