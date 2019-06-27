using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NorthwindTradersCli.Adapters.Driving.CommandLine.Models.Product;
using NorthwindTradersCli.Application.Products;
using NorthwindTradersCli.Domain.Models;

namespace NorthwindTradersCli.Adapters.Driving.CommandLine.Controllers
{
    public class ProductsController
    {
        private readonly IMapper _mapper;
        private readonly IProductsService _productsService;

        public ProductsController(
            IMapper mapper,
            IProductsService productsService)
        {
            _mapper = mapper;
            _productsService = productsService;
        }

        public async Task<IEnumerable<ProductGetDto>> Get()
        {
            return _mapper.Map<IEnumerable<ProductGetDto>>(await _productsService.GetProductsAsync());
        }

        public async Task<ProductGetDto> Get(int id)
        {
            var product = await _productsService.GetProductAsync(id);

            if (product == null)
            {
                return null;
            }

            return _mapper.Map<ProductGetDto>(product);
        }

        public async Task<ProductGetDto> Post(ProductPostDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            var createdProduct = await _productsService.CreateProductAsync(product);

            return _mapper.Map<ProductGetDto>(createdProduct);

        }

        public async Task<ProductGetDto> Put(int id, ProductPutDto productDto)
        {
            if (await _productsService.GetProductAsync(id) == null)
            {
                return null;
            }

            var product = _mapper.Map<Product>(productDto);
            product.ProductId = id;

            var updatedProduct = await _productsService.UpdateProductAsync(product);

            return _mapper.Map<ProductGetDto>(updatedProduct);
        }

        public async Task Delete(int id)
        {
            if (await _productsService.GetProductAsync(id) == null)
            {
                return;
            }

            await _productsService.DeleteProductAsync(id);

            return;
        }
    }
}
