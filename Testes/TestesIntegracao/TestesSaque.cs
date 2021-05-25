using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Testes.Utils;
using Xunit;

namespace Testes.TestesIntegracao
{
    public class TestesSaque : IClassFixture<WebApplicationFactory<TFTFS.Startup>>
    {
        private readonly WebApplicationFactory<TFTFS.Startup> _factory;

        public TestesSaque(WebApplicationFactory<TFTFS.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/Saque")]
        [InlineData("/Saque/Create")]
        public async Task SaqueEndpoints(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task CreateSaque()
        {
            var client = _factory.CreateClient();
            var form = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                {"Conta", SaqueMock.Conta.ToString() },
                {"Valor", SaqueMock.Valor.ToString() },
            });
            var response = await client.PostAsync("/Saque/Create", form);
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
