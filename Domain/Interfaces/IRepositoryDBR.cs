namespace Domain.Interfaces
{
    public interface IRepositoryDBR<T> where T : class
    {
        T GetById(Guid id);

        IEnumerable<T> GetAll();

        T Register (T entity);

        T Update(T entity);

        T Delete(Guid id);
    }
}
