using Domain.Interfaces;
using Domain.Models;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class CategoryRepository : RepositoryDBR<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Category>> GetAllByName(string name)
        {
            return await _context.Categories.Where(x => x.Name == name).ToListAsync();
        }
    }
}
