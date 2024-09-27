using Domain.Interfaces;
using Infra.Data.Context;

namespace Domain.Repositories
{
    public class RepositoryDBR<T> where T : class, IRepositoryDBR<T>
    {
        private readonly AppDbContext _context;
        public RepositoryDBR(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public T GetById(Guid id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity is null)
                throw new ArgumentNullException();

            return entity;
        }

        public T Register(T entity)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
