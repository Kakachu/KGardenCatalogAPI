using Application.Interfaces;
using Infra.Data.Context;

namespace Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly AppDbContext _context;

        public CategoryAppService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
    }
}
