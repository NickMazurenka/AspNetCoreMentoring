using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NorthwindTradersCli.Application.Categories;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Adapters.Driven.ApiClient.Repositories
{
    internal class CategoriesRepository : ICategoriesRepository
    {
        private readonly HttpClient _client;

        public CategoriesRepository(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("northwind");
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            IEnumerable<Category> categories = null;

            var request = new HttpRequestMessage(HttpMethod.Get, "Categories");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                categories = await response.Content.ReadAsAsync<IEnumerable<Category>>();
            }

            return await _client.Categories.ToListAsync();
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
