using Flyer.Domain.Entities;
using Flyer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Flyer.Application.Services
{

    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddUser(User user)
        {
            Expression<Func<User, bool>> expression = item => item.Id == user.Id;
            var users = await _unitOfWork.UserRepository.FindByCondition(expression);
            if (users.Any(item => item.Id == user.Id))
                throw new Exception("Este user ya ha sido registrada");


            await _unitOfWork.UserRepository.Add(user);
        }

        public async Task DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _unitOfWork.UserRepository.GetAll();
        }

        public async Task<User> GetUser(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public async Task UpdateUser(User user)
        {
            await _unitOfWork.UserRepository.Update(user);
        }
    }
}
