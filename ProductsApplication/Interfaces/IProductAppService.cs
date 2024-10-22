using Application.ViewModels;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Interfaces
{
    public interface IProductAppService
    {
        Task<List<ProductViewModel>> GetAllProducts();

        Task<ProductViewModel> GetById(Guid id);

        Task<ProductViewModel> Register(ProductViewModel productViewModel);

        Task<int> Update(Guid id, ProductViewModel productViewModel);

        Task<ProductStockUpdateRequestViewModel> MapProductRequest(Guid id);

        Task<ProductStockUpdateResponseViewModel> UpdatePartial(Guid id, ProductStockUpdateRequestViewModel productStockUpdateRequestViewModel);

        Task<int> Remove(Guid id);
    }
}
