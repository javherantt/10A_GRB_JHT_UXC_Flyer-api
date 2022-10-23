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
   
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LikeService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddLike(Like like)
        {
            Expression<Func<Like, bool>> expression = item => item.Id == like.Id;
            var likes = await _unitOfWork.LikeRepository.FindByCondition(expression);
            if (likes.Any(item => item.Id == like.Id))
                throw new Exception("Este like ya ha sido registrada");
            

            await _unitOfWork.LikeRepository.Add(like);
        }

        public async Task DeleteLike(int id)
        {
            await _unitOfWork.LikeRepository.Delete(id);
        }

        public async Task<IEnumerable<Like>> GetLikes()
        {
            return await _unitOfWork.LikeRepository.GetAll();
        }

        public async Task<Like> GetLike(int id)
        {
            return await _unitOfWork.LikeRepository.GetById(id);
        }

        public async Task UpdateLike(Like like)
        {
            await _unitOfWork.LikeRepository.Update(like);
        }
    }
}
