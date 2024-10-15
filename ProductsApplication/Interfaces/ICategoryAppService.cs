using Application.ViewModels;

namespace Application.Interfaces
{
    public interface ICategoryAppService
    {
        Task<CategoryViewModel> GetById(Guid id);

        Task<List<CategoryViewModel>> GetAllCategories();

        Task<CategoryViewModel> Register(CategoryViewModel viewModel);

        Task<int> Update(Guid id, CategoryViewModel viewModel);

        Task<int> Delete(Guid id);
    }
}
    