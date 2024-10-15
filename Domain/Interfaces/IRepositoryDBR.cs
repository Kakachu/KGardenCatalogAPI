namespace Domain.Interfaces
{
    public interface IRepositoryDBR<T> where T : class
    {
        Task<T?> GetById(Guid id);

        Task<List<T>> GetAll();

        Task<T> Register (T entity);

        Task<T> Update(T entity, Guid id);

        void Delete(T entity);
    }
}
