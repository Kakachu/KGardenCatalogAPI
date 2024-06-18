using Application.Interfaces;
using Application.ViewModels;
using Domain.Models;
using Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly AppDbContext _context;

        public CategoryAppService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<Category> GetById(Guid id)
        {
            var category = _context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return category;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var listCategory = await _context.Categories.AsNoTracking().ToListAsync();
            return listCategory;
        }

        public async Task<List<Category>> GetIncludeAllCategories()
        {
            var listCategory = await _context.Categories.Include(x => x.Products).AsNoTracking().ToListAsync();
            return listCategory;
        }

        public async Task<Category> Register(CategoryViewModel categoryViewModel)
        {
            var category = new Category(categoryViewModel.Name, categoryViewModel.ImageUrl);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<int> Update(Guid id, CategoryViewModel categoryViewModel)
        {
            var category = await GetById(id);
            if (category == null)
                return StatusCodes.Status404NotFound;

            _context.Categories.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return StatusCodes.Status200OK;
        }

        public async Task<int> Delete(Guid id)
        {
            var category = await GetById(id);
            if (category == null)
                return StatusCodes.Status404NotFound;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return StatusCodes.Status200OK;
        }
    }
}
