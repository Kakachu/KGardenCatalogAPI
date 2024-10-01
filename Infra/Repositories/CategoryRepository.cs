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

        public List<Category> GetAllByName(string name)
        {
            return GetAll().Where(x => x.Name.Contains(name)).ToList();
        }

        public List<Category> GetAllByInclude()
        {
            return _context.Categories.Include(x => x.Products).ToList();
        }
    }
}
