using Application.Interfaces;
using Application.ViewModels;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAppService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> GetById(Guid id)
        {
            return await _categoryRepository.GetById(id);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _categoryRepository.GetAll();
        }

        public async Task<List<Category>> GetAllByInclude()
        {
            return await _categoryRepository.GetAllByInclude();
        }

        public async Task<Category> Register(CategoryViewModel categoryViewModel)
        {
            var category = new Category(categoryViewModel.Name, categoryViewModel.ImageUrl);
            return await _categoryRepository.Register(category);
        }

        public async Task<int> Update(Guid id, CategoryViewModel categoryViewModel)
        {
            var category = await GetById(id);
            if (category == null)
                return StatusCodes.Status404NotFound;

            _categoryRepository.Update(new Category(categoryViewModel.Name, categoryViewModel.ImageUrl));

            return StatusCodes.Status200OK;
        }

        public async Task<int> Delete(Guid id)
        {
            var category = await GetById(id);
            if (category == null)
                return StatusCodes.Status404NotFound;

            _categoryRepository.Delete(category);

            return StatusCodes.Status200OK;
        }
    }
}
