using Application.Interfaces;
using Application.ViewModels;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly AppDbContext _context;
        public ProductAppService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var context = await _context.Products.AsNoTracking().ToListAsync();
            return context;
        }

        public async Task<Product> GetById(Guid id)
        {
            var context = await _context.Products.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return context;
        }

        public async Task<Product> Register(ProductViewModel productViewModel)
        {
            var product = new Product(productViewModel.Name, productViewModel.Description, productViewModel.ImageUrl,
                                      productViewModel.Price, productViewModel.Stock, productViewModel.CategoryId);

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<int> Update(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
                return StatusCodes.Status400BadRequest;

            var productValidate = await GetById(id);
            if (productValidate == null)
                return StatusCodes.Status404NotFound;

            var product = new Product(productValidate, productViewModel.Name, productViewModel.Description, productViewModel.ImageUrl,
                          productViewModel.Price, productViewModel.Stock, productViewModel.CategoryId);

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return StatusCodes.Status200OK;
        }

        public async Task<int> Remove(Guid id)
        {
            var product = await GetById(id);
            if (product == null)
                return StatusCodes.Status404NotFound;

            _context.Products.Remove(product);
            _context.SaveChanges();

            return StatusCodes.Status200OK;
        }
    }
}
