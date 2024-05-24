using Application.ViewModels;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Interfaces
{
    public interface IProductAppService
    {
        Task<List<Product>> GetAllProducts();

        Task<Product> GetById(Guid id);

        Task<Product> Register(ProductViewModel productViewModel);

        Task<HttpStatusCode> Update(Guid id, ProductViewModel productViewModel);

        Task<HttpStatusCode> Remove(Guid id);
    }
}
