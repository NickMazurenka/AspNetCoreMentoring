using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTraders.Domain.Categories;

namespace NorthwindTraders.Application.Categories
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> GetCategoryAsync(int categoryId);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<int> DeleteCategoryAsync(int categoryId);
    }
}
