using Flyer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Domain.Interfaces
{
    public interface ICommentService
    {
        Task AddComment(Comment comment);
        Task DeleteComment(int id);
        Task<IEnumerable<Comment>> GetComments();
        Task<Comment> GetComment(int id);
        Task UpdateComment(Comment comment);
    }
}
