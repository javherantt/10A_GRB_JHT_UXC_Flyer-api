using AutoMapper;
using Flyer.Domain.DTOs;
using Flyer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Flyer.Application.Mappings
{
 
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserRequestDto>();
            CreateMap<User, UserResponseDto>();
            CreateMap<UserRequestDto, User>().AfterMap(
            ((source, destination) => {
                destination.CreateAt = DateTime.Now;
                destination.Status = true;
            }));
            CreateMap<UserResponseDto, User>();
        }

    }
}
