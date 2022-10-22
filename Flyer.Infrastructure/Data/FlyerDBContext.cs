using Flyer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Flyer.Infrastructure.Data
{
    public partial class FlyerDBContext : DbContext
    {
        public FlyerDBContext(DbContextOptions<FlyerDBContext> options)
           : base(options)
        { }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Follow> Follow { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<Like> Like { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasOne(b => b.Post).WithMany(i => i.Comment).HasForeignKey(s => s.PostId);
            modelBuilder.Entity<Like>().HasOne(b => b.Post).WithMany(i => i.Like).HasForeignKey(s => s.PostId);
            modelBuilder.Entity<Post>().HasOne(b => b.User).WithMany(i => i.Post).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Follow>().HasOne(b => b.User).WithMany(i => i.Follow).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Post>().HasOne(b => b.Tag).WithMany(i => i.Post).HasForeignKey(s => s.TagId);           
        }
    }
}
