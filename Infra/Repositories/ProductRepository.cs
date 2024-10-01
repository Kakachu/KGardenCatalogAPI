using Domain.Interfaces;
using Domain.Models;
using Domain.Repositories;
using Infra.Data.Context;

namespace Infra.Data.Repositories
{
    public class ProductRepository : RepositoryDBR<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
            
        }

        public List<Product> GetAllByCategory(Guid categoryId)
        {
            var context = GetAll().Where(x => x.CategoryId == categoryId).ToList();
            return context;
        }
    }
}
