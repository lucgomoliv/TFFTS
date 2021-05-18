using System;
using System.Collections.Generic;
using System.Text;
using Testes.Utils;
using TFTFS.Models;
using Xunit;

namespace Testes.Testes
{
    public class TestesUsuario
    {
        [Theory]
        [InlineData("bwjPlwmUiwWZMfVnpKA2ANAHBuDrHDQbYUXeVov95rl6Rra9Pm7aX55Bh4CVDs6FXkS4oxAQdEMd9nr4T2h9HnKw4yuC1nwMyE3")]
        [InlineData("GaoMz3D4zq9Udw8DvmsMg5zy4HU4bsZtKOau0JjSl2Y2OHCCfj4ydn7fBaoT8uyJZcrxkmDRQc6v3JWYKHe83XBoyLvmD5YvJF")]
        [InlineData("R")]
        [InlineData("nR")]
        public void UsuarioNomeValido(string nome)
        {
            Assert.True(Validador.ValidateModel(new Usuario() { Conta = UsuarioValido.Conta, Nome = nome, Valor = UsuarioValido.Valor }).Count == 0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("mQMYJvqZRk4OLnD1pu24BKjYJlaJeRDMUCJQHvwDnST8KHVb4KLWhllN8rsiZ0QQd7Urui4bVzxy9JZFHYTKRu86OQn9yULjvJceO")]
        [InlineData("mQMYJvqZRk4OLnD1pu24BKjYJlaJeRDMUCJQHvwDnST8KHVb4KLWhllN8rsiZ0QQd7Urui4bVzxy9JZFHYTKRu86OQn9yULjvJceOn")]
        public void UsuarioNomeInvalido(string nome)
        {
            Assert.False(Validador.ValidateModel(new Usuario() { Conta = UsuarioValido.Conta, Nome = nome, Valor = UsuarioValido.Valor }).Count == 0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(999.9)]
        [InlineData(999.8)]
        public void UsuarioValorValido(decimal valor)
        {
            Assert.True(Validador.ValidateModel(new Usuario() { Conta = UsuarioValido.Conta, Nome = UsuarioValido.Nome, Valor = valor }).Count == 0);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(1000)]
        [InlineData(1001)]
        public void UsuarioValorInvalido(decimal valor)
        {
            Assert.False(Validador.ValidateModel(new Usuario() { Conta = UsuarioValido.Conta, Nome = UsuarioValido.Nome, Valor = valor }).Count == 0);
        }
    }
}
