using Domain.Interfaces;
using Domain.Models;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class ProductRepository : RepositoryDBR<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
            
        }

        public async Task<List<Product>> GetAllByCategory(Guid categoryId)
        {
            var context = await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
            return context;
        }
    }
}
