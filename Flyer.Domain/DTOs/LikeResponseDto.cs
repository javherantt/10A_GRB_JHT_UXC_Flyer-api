using System;
using System.Collections.Generic;
using System.Text;

namespace Flyer.Domain.DTOs
{
    public class LikeResponseDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserId { get; set; }
        public int likes { get; set; }
    }
}
