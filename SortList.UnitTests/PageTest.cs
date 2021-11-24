using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using SortList.Data;
using Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SortList.Pages;
using Microsoft.AspNetCore.Mvc.Routing;

namespace SortList.UnitTests
{
    public class PageTest
    {
        [Fact]
        public void OnGetAsyncTest()
        {
            // Arrange
            var optionsBuilder = new DbContextOptionsBuilder<RazorPagesSortListContext>();
            var mockAppDbContext = new Mock<RazorPagesSortListContext>(optionsBuilder.Options);
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();


            var actionContext = new ActionContext();
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var pageModel = new IndexModel(mockAppDbContext.Object)
            {
                PageContext = pageContext,
                TempData = tempData,
                Url = new UrlHelper(actionContext)
            };

            pageModel.ModelState.AddModelError("FirstName.Text", "The Text field is required.");

            // Act
            var result = pageModel.ListData;

            // Assert
            Assert.Equal("Alice", result[0].FirstName);
            Assert.Equal("Bob", result[0].LastName);

            Assert.Equal("Jake", result[1].FirstName);
            Assert.Equal("Peralta", result[1].LastName);

            Assert.Equal("Jane", result[2].FirstName);
            Assert.Equal("Doe", result[2].LastName);

            Assert.Equal("John", result[2].FirstName);
            Assert.Equal("Doe", result[2].LastName);
        }

    }
}
