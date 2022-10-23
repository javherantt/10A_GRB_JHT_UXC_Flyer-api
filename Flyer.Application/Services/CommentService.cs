using Flyer.Domain.Entities;
using Flyer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Flyer.Application.Services
{

    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddComment(Comment comment)
        {
            Expression<Func<Comment, bool>> expression = item => item.Id == comment.Id;
            var comments = await _unitOfWork.CommentRepository.FindByCondition(expression);
            if (comments.Any(item => item.Id == comment.Id))
                throw new Exception("Esta cita ya ha sido registrada");


            await _unitOfWork.CommentRepository.Add(comment);
        }

        public async Task DeleteComment(int id)
        {
            await _unitOfWork.CommentRepository.Delete(id);
        }

        public async Task<IEnumerable<Comment>> GetComments()
        {
            return await _unitOfWork.CommentRepository.GetAll();
        }

        public async Task<Comment> GetComment(int id)
        {
            return await _unitOfWork.CommentRepository.GetById(id);
        }

        public async Task UpdateComment(Comment comment)
        {
            await _unitOfWork.CommentRepository.Update(comment);
        }
    }
}
