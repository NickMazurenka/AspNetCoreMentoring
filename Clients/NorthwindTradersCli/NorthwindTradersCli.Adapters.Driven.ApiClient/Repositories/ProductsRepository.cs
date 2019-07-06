using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using NorthwindTradersCli.Adapters.Driven.ApiClient.Models.Product;
using NorthwindTradersCli.Application.Products;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Adapters.Driven.ApiClient.Repositories
{
    internal class ProductsRepository : IProductsRepository
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _client;

        public ProductsRepository(
            IHttpClientFactory httpClientFactory,
            IMapper mapper)
        {
            _mapper = mapper;
            _client = httpClientFactory.CreateClient("northwind");
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<ProductGetDto> products = null;

            var request = new HttpRequestMessage(HttpMethod.Get, "Products");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                products = await response.Content.ReadAsAsync<IEnumerable<ProductGetDto>>();
            }

            return _mapper.Map<IEnumerable<Product>>(products);
        }

        public async Task<Product> GetProduct(int productId)
        {
            ProductGetDto product = null;

            var request = new HttpRequestMessage(HttpMethod.Get, $"Products/{productId}");

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<ProductGetDto>();
            }

            return _mapper.Map<Product>(product);
        }
    }
}
