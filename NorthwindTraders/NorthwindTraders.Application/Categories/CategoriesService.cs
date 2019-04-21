using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTraders.Domain.Categories;

namespace NorthwindTraders.Application.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoriesRepository.GetCategoriesAsync();
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            return await _categoriesRepository.CreateCategoryAsync(category);
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _categoriesRepository.GetCategoryAsync(categoryId);
        }

        public async Task<Category> UpdateCategoryAsync(Category category)
        {
            return await _categoriesRepository.UpdateCategoryAsync(category);
        }

        public async Task<int> DeleteCategoryAsync(int categoryId)
        {
            return await _categoriesRepository.DeleteCategoryAsync(categoryId);
        }
    }
}
