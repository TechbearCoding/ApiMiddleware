using Xunit;
using Moq;
using System.Threading.Tasks;
using ApiMiddleware.Controllers;
using ApiMiddleware.Services;
using ApiMiddleware.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMiddleware.Tests
{
    public class ContentControllerTest
    {
        private DbContextOptions<ContentContext> _options;

        public ContentControllerTest()
        {
            _options = new DbContextOptionsBuilder<ContentContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDb")
                .Options;
        }

        [Fact]
        public async Task GetAllContent_ReturnsAllContent()
        {
            var mockService = new Mock<IAPiService>();
            var contentEntities = GetTestContent();

            mockService.Setup(service => service.GetAllContent()).ReturnsAsync(contentEntities);

            var controller = new ContentController(null, mockService.Object);

            var result = await controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<ContentEntity>>(okResult.Value);
        }

        private List<ContentEntity> GetTestContent()
        {
            var content = new List<ContentEntity>();
            content.Add(new ContentEntity("1", "Test Title 1", "Test Content 1"));
            content.Add(new ContentEntity("2", "Test Title 2", "Test Content 2"));
            return content;
        }
    }
}
