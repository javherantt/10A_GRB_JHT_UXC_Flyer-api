using Flyer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Domain.Interfaces
{
    public interface IUserService
    {
        Task AddUser(User user);
        Task DeleteUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task UpdateUser(User user);
    }
}
