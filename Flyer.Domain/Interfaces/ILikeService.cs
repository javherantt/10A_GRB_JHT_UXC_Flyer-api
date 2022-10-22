using Flyer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Domain.Interfaces
{
    public interface ILikeService
    {
        Task AddLike(Like like);
        Task DeleteLike(int id);
        Task<IEnumerable<Like>> GetLikes();
        Task<Like> GetLike(int id);
        Task UpdateLike(Like like);
    }
}
