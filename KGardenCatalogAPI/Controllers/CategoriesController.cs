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
            try
            {
                var result = await _categoryAppService.GetById(id);
                if (result == null)
                    return NotFound($"Category with id: {id} was not found...");

                return Ok(result);
            }
            catch(Exception) 
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An unexpected error has occurred");
            }
        }

        [Route("categories/get-all-categories")]
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var result = await _categoryAppService.GetAllCategories();
                if (result == null)
                    return NotFound("Categories not found...");

                return Ok(result);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An unexpected error has occurred");
            }
        }

        [Route("categories/get-include-all-categories")]
        [HttpGet]
        public async Task<IActionResult> GetIncludeAllCategories()
        {
            try
            {
                var result = await _categoryAppService.GetIncludeAllCategories();
                if (result == null)
                    return NotFound("Categories not found...");

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An unexpected error has occurred");
            }
        }

        [Route("categories/register-category")]
        [HttpPost]
        public async Task<IActionResult> RegisterCategory(CategoryViewModel categoryViewModel)
        {
            try
            {
                var result = await _categoryAppService.Register(categoryViewModel);
                return new CreatedAtRouteResult("GetCategory", new { id = result.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An unexpected error has occurred");
            }
        }

        [Route("categories/update-category/{id?}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Guid id, CategoryViewModel categoryViewModel)
        {
            try
            {
                var result = await _categoryAppService.Update(id, categoryViewModel);
                if (result != StatusCodes.Status200OK)
                    return StatusCode(result);

                return Ok(categoryViewModel);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An unexpected error has occurred");
            }
        }

        [Route("categories/remove-category/{id}")]
        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(Guid id)
        {
            try
            {
                var result = await _categoryAppService.Delete(id);
                if (result != StatusCodes.Status200OK)
                    return StatusCode(result);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "An unexpected error has occurred");
            }
        }
    }
}
