using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Flyer.Domain.Entities
{
    public partial class Post : BaseEntity
    {
        public Post()
        {
            Like = new HashSet<Like>();
            Comment = new HashSet<Comment>();
        }
     
        public int UserId { get; set; }
        public int TagId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }
        public int Views { get; set; }
       
        public DateTime timestamp { get; set; }

        public virtual User User { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual ICollection<Like> Like { get; set; }
        public virtual ICollection<Comment> Comment { get; set; }
    }
}
