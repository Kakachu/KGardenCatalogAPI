using Application.ViewModels;
using Domain.Models;
using System.Net;

namespace Application.Interfaces
{
    public interface ICategoryAppService
    {
        Task<Category> GetById(Guid id);

        Task<List<Category>> GetAllCategories();

        Task<List<Category>> GetIncludeAllCategories();

        Task<Category> Register(CategoryViewModel viewModel);

        Task<HttpStatusCode> Update(Guid id, CategoryViewModel viewModel);

        Task<HttpStatusCode> Delete(Guid id);
    }
}
    