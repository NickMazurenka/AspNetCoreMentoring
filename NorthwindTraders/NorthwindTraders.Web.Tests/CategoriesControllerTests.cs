using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NorthwindTraders.Adapters.Driving.Web.Controllers;
using NorthwindTraders.Adapters.Driving.Web.ViewModels.Category;
using NorthwindTraders.Application.Categories;
using NorthwindTraders.Domain.Categories;
using Xunit;

namespace NorthwindTraders.Web.Tests
{
    public class CategoriesControllerTests
    {
        [Fact]
        public async Task Index_Get_ReturnsViewWithAllCategories()
        {
            // Arrange
            var testCategories = GetTestCategories();
            var testCategoriesMapped = GetTestCategoriesViewModel().ToList();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<IEnumerable<CategoryViewModel>>(testCategories))
                .Returns(testCategoriesMapped);
            var categoriesServiceMock = new Mock<ICategoriesService>();
            categoriesServiceMock.Setup(x => x.GetCategoriesAsync())
                .ReturnsAsync(testCategories);
            var controller = new CategoriesController(categoriesServiceMock.Object, mapperMock.Object);

            // Act
            var result = await controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CategoryViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(testCategoriesMapped, model);
        }

        [Fact]
        public async Task Details_GetByValidId_ReturnsViewWithCategory()
        {
            // Arrange
            var categoryIdToRequest = 27;
            var testCategory = GetTestCategories().First();
            var testCategoryMapped = GetTestCategoriesViewModel().First();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<CategoryViewModel>(testCategory))
                .Returns(testCategoryMapped);
            var categoriesServiceMock = new Mock<ICategoriesService>();
            categoriesServiceMock.Setup(x => x.GetCategoryAsync(categoryIdToRequest))
                .ReturnsAsync(testCategory);
            var controller = new CategoriesController(categoriesServiceMock.Object, mapperMock.Object);

            // Act
            var result = await controller.Details(categoryIdToRequest);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CategoryViewModel>(viewResult.ViewData.Model);
            Assert.Equal(testCategoryMapped, model);
        }

        [Fact]
        public void Create_Get_ReturnsView()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var controller = new CategoriesController(categoriesServiceMock.Object, mapperMock.Object);

            // Act
            var result = controller.Create();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Create_ValidModel_RedirectsToIndex()
        {
            // Arrange
            var testCategoryToCreate = new CategoryCreateModel
            {
                CategoryName = "Test category for create",
                Description = "Test category for create description"
            };
            var testCategory = new Category
            {
                CategoryId = 27,
                CategoryName = "Test category for create",
                Description = "Test category for create description"
            };
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<CategoryCreateModel, Category>(testCategoryToCreate))
                .Returns(testCategory);
            var categoriesServiceMock = new Mock<ICategoriesService>();
            categoriesServiceMock.Setup(x => x.CreateCategoryAsync(testCategory))
                .ReturnsAsync(testCategory);
            var controller = new CategoriesController(categoriesServiceMock.Object, mapperMock.Object);

            // Act
            var result = await controller.Create(testCategoryToCreate);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task Edit_GetByValidId_ReturnsViewWithCategory()
        {
            // Arrange
            var categoryIdToRequest = 27;
            var testCategory = GetTestCategories().First();
            var testCategoryMapped = GetTestCategoriesViewModel().First();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<CategoryViewModel>(testCategory))
                .Returns(testCategoryMapped);
            var categoriesServiceMock = new Mock<ICategoriesService>();
            categoriesServiceMock.Setup(x => x.GetCategoryAsync(categoryIdToRequest))
                .ReturnsAsync(testCategory);
            var controller = new CategoriesController(categoriesServiceMock.Object, mapperMock.Object);

            // Act
            var result = await controller.Edit(categoryIdToRequest);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CategoryViewModel>(viewResult.ViewData.Model);
            Assert.Equal(testCategoryMapped, model);
        }

        [Fact]
        public async Task Edit_PostMismatchId_ReturnsNotFound()
        {
            // Arrange
            var categoryId = 27;
            var testCategory = new CategoryEditModel
            {
                CategoryId = 72,
                CategoryName = "T",
                Description = "D"
            };
            var mapperMock = new Mock<IMapper>();
            var categoriesServiceMock = new Mock<ICategoriesService>();
            var controller = new CategoriesController(categoriesServiceMock.Object, mapperMock.Object);

            // Act
            var result = await controller.Edit(categoryId, testCategory);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_GetByValidId_ReturnsViewWithCategory()
        {
            // Arrange
            var categoryIdToRequest = 27;
            var testCategory = GetTestCategories().First();
            var testCategoryMapped = GetTestCategoriesViewModel().First();
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(x => x.Map<CategoryViewModel>(testCategory))
                .Returns(testCategoryMapped);
            var categoriesServiceMock = new Mock<ICategoriesService>();
            categoriesServiceMock.Setup(x => x.GetCategoryAsync(categoryIdToRequest))
                .ReturnsAsync(testCategory);
            var controller = new CategoriesController(categoriesServiceMock.Object, mapperMock.Object);

            // Act
            var result = await controller.Delete(categoryIdToRequest);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CategoryViewModel>(viewResult.ViewData.Model);
            Assert.Equal(testCategoryMapped, model);
        }

        [Fact]
        public async Task DeleteConfirmed_ValidId_RedirectsToIndex()
        {
            // Arrange
            var categoryId = 27;
            var mapperMock = new Mock<IMapper>();
            var categoriesServiceMock = new Mock<ICategoriesService>();
            categoriesServiceMock.Setup(x => x.DeleteCategoryAsync(categoryId))
                .ReturnsAsync(categoryId);
            var controller = new CategoriesController(categoriesServiceMock.Object, mapperMock.Object);

            // Act
            var result = await controller.DeleteConfirmed(categoryId);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
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

        private IEnumerable<CategoryViewModel> GetTestCategoriesViewModel()
        {
            return new[]
            {
                new CategoryViewModel
                {
                    CategoryId = 1,
                    CategoryName = "Test category 1",
                    Description = "Test category 1 description"
                },
                new CategoryViewModel
                {
                    CategoryId = 2,
                    CategoryName = "Test category 2",
                    Description = "Test category 2 description"
                },
                new CategoryViewModel
                {
                    CategoryId = 3,
                    CategoryName = "Test category 3",
                    Description = "Test category 3 description"
                }
            };
        }
    }
}
