using System;

namespace Flyer.Domain.Entities
{
    public partial class Comment : BaseEntity
    {    
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string comment { get; set; }
        public DateTime timestamp { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
