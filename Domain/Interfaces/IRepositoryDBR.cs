using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepositoryDBR<T> where T : class
    {
        Task<T?> GetById(Guid id);

        Task<List<T>> GetAll();

        Task<T> Register (T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
