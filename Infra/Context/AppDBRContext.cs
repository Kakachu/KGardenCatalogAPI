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

        public async Task<T?> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
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

        public async void Delete(Guid id) 
        {
            var entity = await GetById(id);
            _context.Set<T>().Remove(entity);
        }
    }
}
