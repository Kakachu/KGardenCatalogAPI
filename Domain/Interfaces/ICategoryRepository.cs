using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICategoryRepository : IRepositoryDBR<Category>
    {
        Task<List<Category>> GetAllByName(string name);

        Task<List<Category>> GetAllByInclude();
    }
}
