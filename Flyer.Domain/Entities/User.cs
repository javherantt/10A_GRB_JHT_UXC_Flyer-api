using System.Collections.Generic;

namespace Flyer.Domain.Entities
{
    public partial class User : BaseEntity
    {
        public User()
        {
            Follow = new HashSet<Follow>();
            Post = new HashSet<Post>();
        }
        
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Follow> Follow { get; set; }
        public virtual ICollection<Post> Post { get; set; }
    }
}
