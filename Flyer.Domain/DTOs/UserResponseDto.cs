using System;
using System.Collections.Generic;
using System.Text;

namespace Flyer.Domain.DTOs
{
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
    }
}
