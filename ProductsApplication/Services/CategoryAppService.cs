using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryAppService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryViewModel> GetById(Guid id)
        {

            return _mapper.Map<CategoryViewModel>(await _categoryRepository.GetById(id));
        }

        public async Task<List<CategoryViewModel>> GetAllCategories()
        {
            return _mapper.Map<List<CategoryViewModel>>(await _categoryRepository.GetAll());
        }

        public async Task<CategoryViewModel> Register(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            return _mapper.Map<CategoryViewModel>(await _categoryRepository.Register(category));
        }

        public async Task<int> Update(Guid id, CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            var updateResult = await _categoryRepository.Update(category, id);
            if (updateResult is null)
                return StatusCodes.Status404NotFound;

            return StatusCodes.Status200OK;
        }

        public async Task<int> Delete(Guid id)
        {
            var categoryViewModel = await GetById(id);
            if (categoryViewModel == null)
                return StatusCodes.Status404NotFound;

            _categoryRepository.Delete(_mapper.Map<Category>(categoryViewModel));

            return StatusCodes.Status200OK;
        }
    }
}
