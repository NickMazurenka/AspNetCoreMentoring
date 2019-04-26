using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Application.Categories;
using NorthwindTraders.Domain.Categories;

namespace NorthwindTraders.Adapters.Driven.EntityFramework.Repositories
{
    internal class CategoriesRepository : ICategoriesRepository
    {
        private readonly NorthwindContext _context;

        public CategoriesRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(m => m.CategoryId == categoryId);
        }

        public async Task<int> DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return categoryId;
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }
    }
}
