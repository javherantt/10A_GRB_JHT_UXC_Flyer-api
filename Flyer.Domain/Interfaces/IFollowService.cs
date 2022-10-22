using Flyer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Domain.Interfaces
{
    public interface IFollowService
    {
        Task AddFollow(Follow follow);
        Task DeleteFollow(int id);
        Task<IEnumerable<Follow>> GetFollows();
        Task<Follow> GetFollow(int id);
        Task UpdateFollow(Follow follow);
    }
}
