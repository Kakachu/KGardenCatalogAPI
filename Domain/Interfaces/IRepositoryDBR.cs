using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepositoryDBR<T> where T : class
    {
        T? GetById(Guid id);

        IEnumerable<T> GetAll();

        T Register (T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
