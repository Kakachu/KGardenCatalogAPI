using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductAppService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductViewModel>> GetAllProducts()
        {
            return _mapper.Map<List<ProductViewModel>>(await _productRepository.GetAll());
        }

        public async Task<ProductViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProductViewModel>(await _productRepository.GetById(id));
        }

        public async Task<ProductViewModel> Register(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            return _mapper.Map<ProductViewModel>(await _productRepository.Register(product)); 
        }

        public async Task<int> Update(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id)
                return StatusCodes.Status400BadRequest;

            var product = _mapper.Map<Product>(productViewModel);
            var updateResult = _productRepository.Update(product, id);
            if(updateResult is null)
                return StatusCodes.Status404NotFound;

            return StatusCodes.Status200OK;
        }

        public async Task<int> Remove(Guid id)
        {
            var product = await GetById(id);
            if (product == null)
                return StatusCodes.Status404NotFound;

            _productRepository.Delete(_mapper.Map<Product>(product));

            return StatusCodes.Status200OK;
        }
    }
}
