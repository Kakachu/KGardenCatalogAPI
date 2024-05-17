using Application.Interfaces;
using Application.ViewModels;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;

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

        public async Task<HttpStatusCode> Update(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
                return HttpStatusCode.BadRequest;

            var productValidate = await GetById(id);
            if (productValidate == null)
                return HttpStatusCode.NotFound;

            var product = new Product(productValidate, productViewModel.Name, productViewModel.Description, productViewModel.ImageUrl,
                          productViewModel.Price, productViewModel.Stock, productViewModel.CategoryId);

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return HttpStatusCode.OK;
        }
    }
}
