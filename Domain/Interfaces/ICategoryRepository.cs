using Domain.Models;

namespace Domain.Interfaces
{
    public interface ICategoryRepository : IRepositoryDBR<Category>
    {
        List<Category> GetAllByName(string name);

        List<Category> GetAllByInclude();
    }
}
