using System;
using System.Collections.Generic;
using System.Text;

namespace Flyer.Domain.DTOs
{
    public class FollowResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string followed { get; set; }
    }
}
