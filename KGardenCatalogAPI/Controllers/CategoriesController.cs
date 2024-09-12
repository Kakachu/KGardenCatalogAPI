using Application.Interfaces;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KGardenCatalogAPI.Controllers
{
    [ApiController]
    public class CategoriesController : Controller
    {

        private readonly ICategoryAppService _categoryAppService;
        public CategoriesController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [Route("categories/get-category/{id}", Name = "GetCategory")]
        [HttpGet]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var result = await _categoryAppService.GetById(id);
            if (result == null)
                return NotFound($"Category with id: {id} was not found...");

            return Ok(result);
        }

        [Route("categories/get-all-categories")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _categoryAppService.GetAllCategories();
            if (result == null)
                return NotFound("Categories not found...");

            return Ok(result);
        }

        [Route("categories/get-include-all-categories")]
        [HttpGet]
        public async Task<IActionResult> GetIncludeAllCategories()
        {
            var result = await _categoryAppService.GetIncludeAllCategories();
            if (result == null)
                return NotFound("Categories not found...");

            return Ok(result);
        }

        [Route("categories/register-category")]
        [HttpPost]
        public async Task<IActionResult> RegisterCategory(CategoryViewModel categoryViewModel)
        {
            var result = await _categoryAppService.Register(categoryViewModel);
            return new CreatedAtRouteResult("GetCategory", new { id = result.Id }, result);
        }

        [Route("categories/update-category/{id?}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryViewModel categoryViewModel)
        {
            var result = await _categoryAppService.Update(id, categoryViewModel);
            if (result != StatusCodes.Status200OK)
                return StatusCode(result);

            return Ok(categoryViewModel);
        }

        [Route("categories/remove-category/{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(Guid id)
        {
            var result = await _categoryAppService.Delete(id);
            if (result != StatusCodes.Status200OK)
                return StatusCode(result);

            return Ok();
        }
    }
}
