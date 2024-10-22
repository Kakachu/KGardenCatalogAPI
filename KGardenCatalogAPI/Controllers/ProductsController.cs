using Application.Interfaces;
using Application.ViewModels;
using Infra.Data.UnitOfWork;
using KGardenCatalogAPI.Filters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace KGardenCatalogAPI.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IUnitOfWork _uow;
        public ProductsController(IProductAppService productAppService, IUnitOfWork uow)
        {
            _productAppService = productAppService;
            _uow = uow;
        }

        [Route("products/get-all-products")]
        [HttpGet]
        [ServiceFilter(typeof(ApiLoggingFilter))]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _productAppService.GetAllProducts();
            if (!products.Any())
                return NotFound("Products not found...");

            return Ok(products);
        }

        [Route("products/get-product/{id?}", Name = "GetProduct")]
        [HttpGet]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            var product = await _productAppService.GetById(id);
            if (product == null)
                return NotFound($"Product with id: {id} was not found...");

            return Ok(product);
        }

        [Route("products/create-product")]
        [HttpPost]
        public async Task<IActionResult> RegisterProduct(ProductViewModel productViewModel)
        {
            var result = await _productAppService.Register(productViewModel);
            _uow.Commit();
            return new CreatedAtRouteResult("GetProduct", new { id = result.Id }, result);
        }

        [Route("products/update-product/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductViewModel productViewModel)
        {
            var result = await _productAppService.Update(id, productViewModel);
            if (result != StatusCodes.Status200OK)
                return StatusCode(result);

            _uow.Commit();
            return Ok(productViewModel);
        }

        [Route("products/update-product-partial/{id}")]
        [HttpPatch]
        public async Task<IActionResult> UpdateProductStock(Guid id, JsonPatchDocument<ProductStockUpdateRequestViewModel> productUpdatePatchRequest)
        {
            if (productUpdatePatchRequest is null || id == default)
                return BadRequest();

            var productUpdateRequest = await _productAppService.MapProductRequest(id);
            if (productUpdateRequest is null)
                return NotFound();

            productUpdatePatchRequest.ApplyTo(productUpdateRequest, ModelState);
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var updateProductResponse = await _productAppService.UpdatePartial(id, productUpdateRequest);
            return Ok(updateProductResponse);
        }

        [Route("products/remove-product/{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            var result = await _productAppService.Remove(id);
            if (result != StatusCodes.Status200OK)
                return StatusCode(result, "Product not found");

            _uow.Commit();
            return Ok();
        }
    }
}
