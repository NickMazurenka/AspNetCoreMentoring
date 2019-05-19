using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Adapters.Driving.Web.ViewModels.Category;
using NorthwindTraders.Application.Categories;
using NorthwindTraders.Domain.Categories;

namespace NorthwindTraders.Adapters.Driving.Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesService categoriesService, IMapper mapper)
        {
            _categoriesService = categoriesService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _categoriesService.GetCategoriesAsync();
            return View(_mapper.Map<IEnumerable<CategoryViewModel>>(data));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoriesService.GetCategoryAsync(id.Value);

            if (category == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CategoryViewModel>(category));
        }

        [Route("[controller]/[action]/{id}")]
        [Route("images/{id}")]
        public async Task<IActionResult> GetImageForCategory(int id)
        {
            var category = await _categoriesService.GetCategoryAsync(id);

            if (category.Picture == null)
            {
                return NotFound();
            }

            return File(category.Picture.Skip(78).ToArray(), "image/bmp");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateModel category)
        {
            if (ModelState.IsValid)
            {
                await _categoriesService.CreateCategoryAsync(_mapper.Map<CategoryCreateModel, Category>(category));

                return RedirectToAction(nameof(Index));
            }

            return View(_mapper.Map<CategoryViewModel>(category));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoriesService.GetCategoryAsync(id.Value);

            if (category == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CategoryEditModel>(category));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryEditModel categoryEditModel)
        {
            if (id != categoryEditModel.CategoryId)
            {
                return NotFound();
            }

            var category = _mapper.Map<Category>(categoryEditModel);

            if (categoryEditModel.Picture != null)
            {
                byte[] brokenPictureBytes;
                using (var ms = new MemoryStream())
                {
                    await categoryEditModel.Picture.CopyToAsync(ms);
                    var pictureBytes = ms.ToArray();
                    brokenPictureBytes = new byte[78 + pictureBytes.Length];
                    pictureBytes.CopyTo(brokenPictureBytes, 78);
                }

                category.Picture = brokenPictureBytes;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoriesService.UpdateCategoryAsync(category);
                }
                // TODO: Move exception to Repository
                catch (DbUpdateConcurrencyException)
                {
                    if (await _categoriesService.GetCategoryAsync(category.CategoryId) == null)
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

            return View(_mapper.Map<CategoryEditModel>(category));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _categoriesService.GetCategoryAsync(id.Value);

            if (category == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<CategoryViewModel>(category));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriesService.DeleteCategoryAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
