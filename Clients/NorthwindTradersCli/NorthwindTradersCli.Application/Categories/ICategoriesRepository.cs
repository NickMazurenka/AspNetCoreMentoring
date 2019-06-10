using System.Collections.Generic;
using System.Threading.Tasks;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Application.Categories
{
    public interface ICategoriesRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> GetCategoryAsync(int categoryId);
        Task<Category> UpdateCategoryAsync(Category category);
        Task<int> DeleteCategoryAsync(int categoryId);
    }
}
