using Application.ViewModels;
using Domain.Models;

namespace Application.Interfaces
{
    public interface ICategoryAppService
    {
        Task<Category> GetById(Guid id);

        Task<List<Category>> GetAllCategories();

        Task<List<Category>> GetAllByInclude();

        Task<Category> Register(CategoryViewModel viewModel);

        Task<int> Update(Guid id, CategoryViewModel viewModel);

        Task<int> Delete(Guid id);
    }
}
    