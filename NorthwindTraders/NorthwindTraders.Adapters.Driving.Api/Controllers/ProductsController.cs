using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindTraders.Adapters.Driving.Api.Models;
using NorthwindTraders.Application.Products;

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
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<ProductDto>>(await _productsService.GetProductsAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            var product = await _productsService.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDto>(product));
        }
    }
}
