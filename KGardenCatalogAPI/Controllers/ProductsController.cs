using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace KGardenCatalogAPI.Controllers
{
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        public ProductsController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [Route("products/get-all-products")]
        [HttpGet]
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
                return NotFound("Product not found...");

            return Ok(product);
        }

        [Route("products/create-product")]
        [HttpPost]
        public async Task<IActionResult> RegisterProduct(ProductViewModel productViewModel)
        {
            var result = await _productAppService.Register(productViewModel);
            return new CreatedAtRouteResult("GetProduct", new { id = result.Id }, result);
        }

        [Route("products/update-product/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductViewModel productViewModel)
        {
            var result = await _productAppService.Update(id, productViewModel);
            if (result != HttpStatusCode.OK)
                return StatusCode((int)result);

            return Ok(productViewModel);
        }
    }
}
