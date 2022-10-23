using Flyer.Domain.Entities;
using Flyer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Application.Services
{
   
    public class FollowService : IFollowService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddFollow(Follow follow)
        {
            Expression<Func<Follow, bool>> expression = item => item.Id == follow.Id;
            var follows = await _unitOfWork.FollowRepository.FindByCondition(expression);
            if (follows.Any(item => item.Id == follow.Id))
                throw new Exception("Este follow ya ha sido registrada");


            await _unitOfWork.FollowRepository.Add(follow);
        }

        public async Task DeleteFollow(int id)
        {
            await _unitOfWork.FollowRepository.Delete(id);
        }

        public async Task<IEnumerable<Follow>> GetFollows()
        {
            return await _unitOfWork.FollowRepository.GetAll();
        }

        public async Task<Follow> GetFollow(int id)
        {
            return await _unitOfWork.FollowRepository.GetById(id);
        }

        public async Task UpdateFollow(Follow follow)
        {
            await _unitOfWork.FollowRepository.Update(follow);
        }
    }
}
