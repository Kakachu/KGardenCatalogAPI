using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
            try
            {
                var products = await _productAppService.GetAllProducts();
                if (!products.Any())
                    return NotFound("Products not found...");

                return Ok(products);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An unexpected error has occurred");
            }
        }

        [Route("products/get-product/{id?}", Name = "GetProduct")]
        [HttpGet]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            try
            {
                var product = await _productAppService.GetById(id);
                if (product == null)
                    return NotFound($"Product with id: {id} was not found...");

                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An unexpected error has occurred");
            }
        }

        [Route("products/create-product")]
        [HttpPost]
        public async Task<IActionResult> RegisterProduct(ProductViewModel productViewModel)
        {
            try
            {
                var result = await _productAppService.Register(productViewModel);
                return new CreatedAtRouteResult("GetProduct", new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An unexpected error has occurred");
            }
        }

        [Route("products/update-product/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Guid id, ProductViewModel productViewModel)
        {
            try
            {
                var result = await _productAppService.Update(id, productViewModel);
                if (result != StatusCodes.Status200OK)
                    return StatusCode(result);

                return Ok(productViewModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An unexpected error has occurred");
            }
        }

        [Route("products/remove-product/{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveProduct(Guid id)
        {
            try
            {
                var result = await _productAppService.Remove(id);
                if (result != StatusCodes.Status200OK)
                    return StatusCode(result, "Product not found");

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An unexpected error has occurred");
            }
        }
    }
}
