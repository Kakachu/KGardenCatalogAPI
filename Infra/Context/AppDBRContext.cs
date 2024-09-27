using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class AppDBRContext<T> where T : DbContext
    {
        private readonly DbContext _context;

        public AppDBRContext(DbContext context)
        {
            _context = context;
        }

        public T GetById(Guid id)
        {
            return _context.Set<T>().FirstOrDefault(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Register(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Guid id) 
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
        }
    }
}
