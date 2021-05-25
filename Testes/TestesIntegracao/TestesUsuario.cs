using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Testes.Utils;
using Xunit;

namespace Testes.TestesIntegracao
{
    public class TestesUsuario : IClassFixture<WebApplicationFactory<TFTFS.Startup>>
    {
        private readonly WebApplicationFactory<TFTFS.Startup> _factory;

        public TestesUsuario(WebApplicationFactory<TFTFS.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/Usuario")]
        [InlineData("/Usuario/Create")]
        [InlineData("/Usuario/Edit")]
        public async Task UsuarioEndpoints(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task CreateUsuario()
        {
            var client = _factory.CreateClient();
            var form = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                {"Nome", UsuarioMock.Nome },
                {"Valor", UsuarioMock.Valor.ToString() },
            }); ;
            var response = await client.PostAsync("/Usuario/Create", form);
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }

        [Fact]
        public async Task EditUsuario()
        {
            var client = _factory.CreateClient();
            var form = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
                {"Nome", UsuarioMock.Nome },
            });
            var response = await client.PostAsync("/Usuario/Edit/1", form);
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
