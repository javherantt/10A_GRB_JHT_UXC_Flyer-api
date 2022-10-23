using System;
using System.Collections.Generic;
using System.Text;

namespace Flyer.Domain.DTOs
{
    public class LikeRequestDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int likes { get; set; }
    }
}
