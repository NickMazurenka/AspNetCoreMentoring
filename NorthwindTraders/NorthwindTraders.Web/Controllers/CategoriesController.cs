﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindTraders.Application.Categories;
using NorthwindTraders.Domain.Categories;
using NorthwindTraders.Web.ViewModels.Category;

namespace NorthwindTraders.Web.Controllers
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

        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Category/Edit/5
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

            return View(_mapper.Map<CategoryViewModel>(category));
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryEditModel categoryEditModel)
        {
            if (id != categoryEditModel.CategoryId)
            {
                return NotFound();
            }

            var category = _mapper.Map<Category>(categoryEditModel);

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
            return View(_mapper.Map<CategoryViewModel>(category));
        }

        // GET: Category/Delete/5
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
