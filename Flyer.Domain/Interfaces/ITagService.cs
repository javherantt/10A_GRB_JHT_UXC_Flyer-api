using Flyer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Domain.Interfaces
{
    public interface ITagService
    {
        Task AddTag(Tag tag);
        Task DeleteTag(int id);
        Task<IEnumerable<Tag>> GetTags();
        Task<Tag> GetTag(int id);
        Task UpdateTag(Tag tag);
    }
}
