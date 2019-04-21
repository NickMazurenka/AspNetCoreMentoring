using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NorthwindTraders.Application.Categories;
using NorthwindTraders.Domain.Categories;
using NorthwindTraders.Web.Controllers;
using NorthwindTraders.Web.MappingProfiles;
using NorthwindTraders.Web.ViewModels.Category;
using Xunit;

namespace NorthwindTraders.Web.Tests
{
    public class CategoriesControllerTests
    {
        [Fact]
        public async Task Index_Get_ReturnsViewWithAllCategories()
        {
            // Arrange
            var mapper = new Mapper(new MapperConfiguration(x => x.AddProfile(new CategoryProfile())));
            var categoriesServiceMock = new Mock<ICategoriesService>();
            categoriesServiceMock.Setup(x => x.GetCategoriesAsync()).ReturnsAsync(GetTestCategories());
            var controller = new CategoriesController(categoriesServiceMock.Object, mapper);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CategoryViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        private IEnumerable<Category> GetTestCategories()
        {
            return new[]
            {
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Test category 1",
                    Description = "Test category 1 description"
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Test category 2",
                    Description = "Test category 2 description"
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Test category 3",
                    Description = "Test category 3 description"
                }
            };
        }
    }
}
