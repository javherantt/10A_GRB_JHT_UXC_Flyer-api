using Flyer.Domain.Entities;
using Flyer.Domain.Interfaces;
using Flyer.Infraestructure.Data;
using System.Threading.Tasks;

namespace Flyer.Infraestructure.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly FlyerDBContext _context;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Tag> _tagRepository;
        private readonly IRepository<Like> _likeRepository;
        private readonly IRepository<Follow> _followRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IRepository<Post> _postRepository;

        public UnitOfWork(FlyerDBContext context)
        {
            this._context = context;
        }

        
        public IRepository<User> UserRepository => _userRepository ?? new SQLRepository<User>(_context);
        public IRepository<Tag> TagRepository => _tagRepository ?? new SQLRepository<Tag>(_context);

        public IRepository<Like> LikeRepository => _likeRepository ?? new SQLRepository<Like>(_context);

        public IRepository<Follow> FollowRepository => _followRepository ?? new SQLRepository<Follow>(_context);

        public IRepository<Comment> CommentRepository => _commentRepository ?? new SQLRepository<Comment>(_context);

        public IRepository<Post> PostRepository => _postRepository ?? new SQLRepository<Post>(_context);

        public void Dispose()
        {
            if (_context == null)
                _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
