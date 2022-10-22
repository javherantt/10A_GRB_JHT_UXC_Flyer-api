using Flyer.Domain.Entities;
using Flyer.Domain.Interfaces;
using Flyer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Flyer.Infrastructure.Repositories
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly FlyerDBContext _context;
        private DbSet<T> _entity;

        public SQLRepository(FlyerDBContext context)
        {
            this._context = context;
            this._entity = context.Set<T>();
        }

        public async Task Add(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity");
            _entity.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("Entity");
            var entity = await GetById(id);
            _entity.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expresssion)
        {
            return await _entity.Where(expresssion).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entity.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entity.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("Entity");
            if (entity.Id <= 0)
                throw new ArgumentNullException("Entity");
            _entity.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
