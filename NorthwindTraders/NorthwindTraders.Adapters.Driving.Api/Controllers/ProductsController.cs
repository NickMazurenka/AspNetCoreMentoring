using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindTraders.Adapters.Driving.Api.Models.Product;
using NorthwindTraders.Application.Products;
using NorthwindTraders.Domain.Products;

namespace NorthwindTraders.Adapters.Driving.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductGetDto>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<ProductGetDto>>(await _productsService.GetProductsAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGetDto>> Get(int id)
        {
            var product = await _productsService.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductGetDto>(product));
        }

        [HttpPost]
        public async Task<ActionResult<ProductGetDto>> Post(ProductPostDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            var createdProduct = await _productsService.CreateProductAsync(product);

            return CreatedAtAction(nameof(Get), new {id = createdProduct.ProductId}, _mapper.Map<ProductGetDto>(createdProduct));

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductGetDto>> Put(int id, ProductPutDto productDto)
        {
            if (await _productsService.GetProductAsync(id) == null)
            {
                return NotFound();
            }

            var product = _mapper.Map<Product>(productDto);
            product.ProductId = id;

            var updatedProduct = await _productsService.UpdateProductAsync(product);

            return Ok(_mapper.Map<ProductGetDto>(updatedProduct));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await _productsService.GetProductAsync(id) == null)
            {
                return NotFound();
            }

            await _productsService.DeleteProductAsync(id);

            return NoContent();
        }
    }
}
