using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using NorthwindTradersCli.Adapters.Driven.ApiClient.Models.Category;
using NorthwindTradersCli.Application.Categories;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Adapters.Driven.ApiClient.Repositories
{
    internal class CategoriesRepository : ICategoriesRepository
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _client;

        public CategoriesRepository(
            IHttpClientFactory httpClientFactory,
            IMapper mapper)
        {
            _mapper = mapper;
            _client = httpClientFactory.CreateClient("northwind");
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            IEnumerable<CategoryGetDto> categories = null;

            var request = new HttpRequestMessage(HttpMethod.Get, "Categories");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                categories = await response.Content.ReadAsAsync<IEnumerable<CategoryGetDto>>();
            }

            return _mapper.Map<IEnumerable<Category>>(categories);
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            CategoryGetDto category = null;

            var request = new HttpRequestMessage(HttpMethod.Get, $"Categories/{categoryId}");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                category = await response.Content.ReadAsAsync<CategoryGetDto>();
            }

            return _mapper.Map<Category>(category);
        }
    }
}
