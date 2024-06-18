using Application.ViewModels;
using Domain.Models;
using System.Net;

namespace Application.Interfaces
{
    public interface IProductAppService
    {
        Task<List<Product>> GetAllProducts();

        Task<Product> GetById(Guid id);

        Task<Product> Register(ProductViewModel productViewModel);

        Task<int> Update(Guid id, ProductViewModel productViewModel);

        Task<int> Remove(Guid id);
    }
}
