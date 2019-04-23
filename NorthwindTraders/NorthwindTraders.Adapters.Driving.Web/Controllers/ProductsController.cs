using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NorthwindTraders.Application.Categories;
using NorthwindTraders.Application.Products;
using NorthwindTraders.Application.Suppliers;
using NorthwindTraders.Domain.Products;
using NorthwindTraders.Web.ViewModels.Product;

namespace NorthwindTraders.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IProductsService _productsService;
        private readonly ISuppliersService _suppliersService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ProductsController(
            ICategoriesService categoriesService,
            IProductsService productsService,
            ISuppliersService suppliersService,
            IConfiguration configuration,
            IMapper mapper)
        {
            _categoriesService = categoriesService;
            _productsService = productsService;
            _suppliersService = suppliersService;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var maximumProducts = _configuration.GetValue<int>("ProductsPageMaximumProductsCount");
            var products = await _productsService.GetProductsAsync();
            var productsRestrained = maximumProducts > 0 ? products.Take(maximumProducts) : products;

            return View(_mapper.Map<IEnumerable<ProductViewModel>>(productsRestrained));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productsService.GetProductAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ProductViewModel>(product));
        }

        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] =
                new SelectList(await _categoriesService.GetCategoriesAsync(), "CategoryId", "CategoryName");
            ViewData["SupplierId"] =
                new SelectList(await _suppliersService.GetSuppliersAsync(), "SupplierId", "CompanyName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);

            if (ModelState.IsValid)
            {
                await _productsService.CreateProductAsync(product);

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(
                await _categoriesService.GetCategoriesAsync(), "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(
                await _suppliersService.GetSuppliersAsync(), "SupplierId", "CompanyName", product.SupplierId);

            return View(_mapper.Map<ProductViewModel>(product));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productsService.GetProductAsync(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(
                await _categoriesService.GetCategoriesAsync(), "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(
                await _suppliersService.GetSuppliersAsync(), "SupplierId", "CompanyName", product.SupplierId);

            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductEditModel productEditModel)
        {
            if (id != productEditModel.ProductId)
            {
                return NotFound();
            }

            var product = _mapper.Map<Product>(productEditModel);

            if (ModelState.IsValid)
            {
                try
                {
                    await _productsService.UpdateProductAsync(product);
                }
                // TODO: Move exception to Repository
                catch (DbUpdateConcurrencyException)
                {
                    if (_productsService.GetProductAsync(product.ProductId) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(
                await _categoriesService.GetCategoriesAsync(), "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(
                await _suppliersService.GetSuppliersAsync(), "SupplierId", "CompanyName", product.SupplierId);

            return View(_mapper.Map<ProductViewModel>(product));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _productsService.GetProductAsync(id.Value);

            if (products == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<ProductViewModel>(products));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productsService.DeleteProductAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
