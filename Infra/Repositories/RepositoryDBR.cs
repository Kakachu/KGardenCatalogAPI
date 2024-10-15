using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class RepositoryDBR<T> : IRepositoryDBR<T>  where T : class
    {
        protected readonly AppDbContext _context;
        public RepositoryDBR(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Register(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<T> Update(T entity, Guid id)
        {
            if (entity is null)
                return null;

            T entityExist = await GetById(id);
            if (entityExist is not null)
            {
                _context.Entry(entityExist).CurrentValues.SetValues(entity);
            }

            return entityExist;
        }
    }
}
