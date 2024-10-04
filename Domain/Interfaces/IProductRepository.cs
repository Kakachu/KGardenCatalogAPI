using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProductRepository : IRepositoryDBR<Product>
    {
        Task<List<Product>> GetAllByCategory(Guid categoryId);
    }
}
