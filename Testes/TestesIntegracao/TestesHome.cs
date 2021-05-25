using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes.TestesIntegracao
{
    public class TestesHome : IClassFixture<WebApplicationFactory<TFTFS.Startup>>
    {
        private readonly WebApplicationFactory<TFTFS.Startup> _factory;

        public TestesHome(WebApplicationFactory<TFTFS.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        [InlineData("/Home/Index")]
        public async Task HomeEndpoints(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
