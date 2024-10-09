using Domain.Interfaces;
using Infra.Data.Context;
using Infra.Data.Repositories;

namespace Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public AppDbContext _context;
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository
        {
            get
            {
                return _productRepository = _productRepository ?? new ProductRepository(_context);
            }
        }

        public ICategoryRepository CategoryRepository 
        {
            get
            {
                return _categoryRepository = _categoryRepository ?? new CategoryRepository(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose() 
        {
            _context.Dispose();
        }
    }
}
