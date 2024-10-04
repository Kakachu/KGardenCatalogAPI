using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        public ProductAppService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _productRepository.GetById(id);
        }

        public async Task<Product> Register(ProductViewModel productViewModel)
        {
            var product = new Product(productViewModel.Name, productViewModel.Description, productViewModel.ImageUrl,
                                      productViewModel.Price, productViewModel.Stock, productViewModel.CategoryId);

            return await _productRepository.Register(product); 
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

            _productRepository.Update(product);

            return StatusCodes.Status200OK;
        }

        public async Task<int> Remove(Guid id)
        {
            var product = await GetById(id);
            if (product == null)
                return StatusCodes.Status404NotFound;

            _productRepository.Delete(product);

            return StatusCodes.Status200OK;
        }
    }
}
