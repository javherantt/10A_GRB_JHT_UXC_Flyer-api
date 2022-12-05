using AutoMapper;
using Flyer.Api.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Flyer.Domain.Interfaces;
using Flyer.Domain.Entities;
using Flyer.Domain.DTOs;
using System.Linq;

namespace Flyer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetUsers();
            var usersDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserResponseDto>>(users);
            var response = new ApiResponse<IEnumerable<UserResponseDto>>(usersDto);

            return Ok(usersDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userService.GetUser(id);
            var userDto = _mapper.Map<User, UserResponseDto>(user);
            var response = new ApiResponse<UserResponseDto>(userDto);

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]UserRequestDto userRequestDto)
        {            
            var user = _mapper.Map<UserRequestDto, User>(userRequestDto);            
            await _userService.AddUser(user);
            var userresponseDto = _mapper.Map<User, UserResponseDto>(user);
            var response = new ApiResponse<UserResponseDto>(userresponseDto);
            return Ok(response);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteUser(id);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPut("id={id:int}")]
        public async Task<IActionResult> Put(int id, [FromForm]UserResponseDto userResponse)
        {
            var user = _mapper.Map<User>(userResponse);
            user.Id = id;
            user.UpdateAt = DateTime.Now;
            user.UpdatedBy = 1;
            await _userService.UpdateUser(user);
            var result = new ApiResponse<bool>(true);
            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<int> Login([FromForm]User user)
        {
            var users = await _userService.GetUsers();
            var usersDto = _mapper.Map<IEnumerable<User>, IEnumerable<UserResponseDto>>(users);
            var existUser = usersDto.FirstOrDefault(e => e.Email.Equals(user.Email) && e.Password.Equals(user.Password));
            if (existUser != null)
                return existUser.Id;
            else
                return 0;
        }
    }
}
