using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infra.Data.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ProductAppService(IProductRepository productRepository, IUnitOfWork uow, IMapper mapper)
        {
            _productRepository = productRepository;
            _uow = uow;
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
            if (updateResult is null)
                return StatusCodes.Status404NotFound;

            return StatusCodes.Status200OK;
        }

        public async Task<ProductStockUpdateRequestViewModel> MapProductRequest(Guid id)
        {
            var product = await GetById(id);
            if (product is null)
                return null;

            var productUpdateRequest = _mapper.Map<ProductStockUpdateRequestViewModel>(product);
            return productUpdateRequest;
        }

        public async Task<ProductStockUpdateResponseViewModel> UpdatePartial(Guid id, ProductStockUpdateRequestViewModel productStockUpdateRequestViewModel)
        {
            var product = await GetById(id);
            _mapper.Map(productStockUpdateRequestViewModel, product);

            var updateResult = await Update(id, product);
            if (updateResult != StatusCodes.Status200OK)
                return null;

            _uow.Commit();
            return _mapper.Map<ProductStockUpdateResponseViewModel>(product);
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
