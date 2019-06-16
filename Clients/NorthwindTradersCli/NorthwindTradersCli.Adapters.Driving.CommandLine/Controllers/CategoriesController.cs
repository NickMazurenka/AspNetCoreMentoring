using AutoMapper;
using NorthwindTraders.Adapters.Driving.Api.Models.Category;
using NorthwindTradersCli.Application.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NorthwindTraders.Adapters.Driving.Api.Controllers
{
    public class CategoriesController
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

        public async Task<IEnumerable<CategoryGetDto>> Get()
        {
            return _mapper.Map<IEnumerable<CategoryGetDto>>(await _categoriesService.GetCategoriesAsync());
        }

        public async Task<CategoryGetDto> Get(int id)
        {
            var category = await _categoriesService.GetCategoryAsync(id);

            if (category == null)
            {
                return null;
            }

            return _mapper.Map<CategoryGetDto>(category);
        }
    }
}
