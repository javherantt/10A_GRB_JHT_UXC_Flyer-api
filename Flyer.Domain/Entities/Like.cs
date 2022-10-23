namespace Flyer.Domain.Entities
{
    public partial class Like : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int likes { get; set; }

        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
