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
   
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddPost(Post post)
        {
            Expression<Func<Post, bool>> expression = item => item.Id == post.Id;
            var posts = await _unitOfWork.PostRepository.FindByCondition(expression);
            if (posts.Any(item => item.Id == post.Id))
                throw new Exception("Este post ya ha sido registrada");


            await _unitOfWork.PostRepository.Add(post);
        }

        public async Task DeletePost(int id)
        {
            await _unitOfWork.PostRepository.Delete(id);
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            return await _unitOfWork.PostRepository.GetAll();
        }

        public async Task<Post> GetPost(int id)
        {
            return await _unitOfWork.PostRepository.GetById(id);
        }

        public async Task UpdatePost(Post post)
        {
            await _unitOfWork.PostRepository.Update(post);
        }
    }
}
