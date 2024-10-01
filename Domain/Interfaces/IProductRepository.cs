using Domain.Models;

namespace Domain.Interfaces
{
    public interface IProductRepository : IRepositoryDBR<Product>
    {
        List<Product> GetAllByCategory(Guid categoryId);
    }
}
