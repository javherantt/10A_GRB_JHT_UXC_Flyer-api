using Flyer.Domain.Entities;
using Flyer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Flyer.Application.Services
{

    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task AddTag(Tag tag)
        {
            Expression<Func<Tag, bool>> expression = item => item.Id == tag.Id;
            var tags = await _unitOfWork.TagRepository.FindByCondition(expression);
            if (tags.Any(item => item.Id == tag.Id))
                throw new Exception("Este tag ya ha sido registrada");


            await _unitOfWork.TagRepository.Add(tag);
        }

        public async Task DeleteTag(int id)
        {
            await _unitOfWork.TagRepository.Delete(id);
        }

        public async Task<IEnumerable<Tag>> GetTags()
        {
            return await _unitOfWork.TagRepository.GetAll();
        }

        public async Task<Tag> GetTag(int id)
        {
            return await _unitOfWork.TagRepository.GetById(id);
        }

        public async Task UpdateTag(Tag tag)
        {
            await _unitOfWork.TagRepository.Update(tag);
        }
    }
}
