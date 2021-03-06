﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NorthwindTraders.Adapters.Driving.Api.Models.Category;
using NorthwindTraders.Application.Categories;

namespace NorthwindTraders.Adapters.Driving.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(
            IMapper mapper,
            ICategoriesService categoriesService)
        {
            _mapper = mapper;
            _categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryGetDto>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<CategoryGetDto>>(await _categoriesService.GetCategoriesAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryGetDto>> Get(int id)
        {
            var category = await _categoriesService.GetCategoryAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CategoryGetDto>(category));
        }
    }
}
