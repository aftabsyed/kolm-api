using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Kolmeo.API;
using Kolmeo.API.Model;
using Kolmeo.UnitTests.Extensions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using System.ComponentModel.DataAnnotations;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Http;

namespace Komeo.UnitTests
{
    public class ProductControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly IFixture _fixture;
        private readonly WebApplicationFactory<Startup> _factory;

        public ProductControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _fixture = new Fixture();
        }

        [Fact]
        public async Task GivenProductId1_WhenGettingProducts_ThenReturnCanonD9()
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = $"{client.BaseAddress}api/Product/1";

            // Act
            var responseMessage = await client.GetAsync(url);

            // Assert
            responseMessage.EnsureSuccessStatusCode();
            var product = await responseMessage.DeserializeContentAsync<Product>();
            product.Name.Should()
                .Be("Canon D9");
        }

        [Theory]
        [AutoData]
        public async Task GivenInvalidProductId_WhenGettingProductById_ThenReturn404NotFound([Range(-99, 0)] int Id)
        {
            // Arrange
            var client = _factory.CreateClient();
            var url = $"{client.BaseAddress}api/Product/{Id}";

            // Act
            var responseMessage = await client.GetAsync(url);

            // Assert
            responseMessage.StatusCode.Should()
                .Be(StatusCodes.Status404NotFound);
        }
    }
}