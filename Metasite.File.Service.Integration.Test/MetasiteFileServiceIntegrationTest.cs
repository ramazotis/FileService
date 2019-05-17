using System;
using System.Threading.Tasks;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Metasite.File.Service.Integration.Test
{
    public class MetasiteFileServiceIntegrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> _factory;

        public MetasiteFileServiceIntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task File_GivenExistingFileName_ShouldReturnFile()
        {
            // arange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync($"/test.txt");

            // assert
            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task File_GivenNotExistingFile_ShouldReturnError()
        {
            // arange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync($"/test1.txt");

            // assert
            Assert.Equal(500, (int)response.StatusCode);

            var json = response.Content.ReadAsStringAsync().Result;

            Assert.Contains("File doesn't exist on server", json);
        }

        [Theory]
        [InlineData("aka")]
        [InlineData("pdf")]
        [InlineData("exe")]
        public async Task File_GivenWrongFileExtension_ShouldReturnError(string extension)
        {
            // arange
            var client = _factory.CreateClient();

            // act
            var response = await client.GetAsync($"/test.{extension}");

            // assert
            Assert.Equal(500, (int)response.StatusCode);

            var json = response.Content.ReadAsStringAsync().Result;

            Assert.Contains("Content type is not supported", json);
        }
    }
}
