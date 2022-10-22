using Flyer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Domain.Interfaces
{
    public interface IPostService
    {
        Task AddPost(Post post);
        Task DeletePost(int id);
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int id);
        Task UpdatePost(Post post);
    }
}
