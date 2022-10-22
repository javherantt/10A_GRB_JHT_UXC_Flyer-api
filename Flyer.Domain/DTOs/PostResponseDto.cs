using System;
using System.Collections.Generic;
using System.Text;

namespace Flyer.Domain.DTOs
{
    public class PostResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TagId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }
        public int Views { get; set; }
        public DateTime timestamp { get; set; }
    }
}
