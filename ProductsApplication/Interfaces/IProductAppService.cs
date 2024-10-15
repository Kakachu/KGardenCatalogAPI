using Application.ViewModels;

namespace Application.Interfaces
{
    public interface IProductAppService
    {
        Task<List<ProductViewModel>> GetAllProducts();

        Task<ProductViewModel> GetById(Guid id);

        Task<ProductViewModel> Register(ProductViewModel productViewModel);

        Task<int> Update(Guid id, ProductViewModel productViewModel);

        Task<int> Remove(Guid id);
    }
}
