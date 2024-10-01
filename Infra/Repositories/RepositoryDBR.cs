using Domain.Interfaces;
using Infra.Data.Context;

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
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T? GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public T Register(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
