using System;
using System.Collections.Generic;
using System.Text;
using Testes.Utils;
using TFTFS.Models;
using Xunit;

namespace Testes.Testes
{
    public class TestesDeposito
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void SaqueContaValido(int conta)
        {
            Assert.True(Validador.ValidateModel(new Deposito() { Conta = conta, Valor = SaqueValido.Valor }).Count == 0);
        }
        /*
        [Theory]
        [InlineData(null)]
        public void SaqueContaInvalido(int conta)
        {
            Assert.True(Validador.ValidateModel(new Saque() { Conta = conta, Valor = SaqueValido.Valor }).Count == 0);
        }*/

        [Theory]
        [InlineData(0.01)]
        [InlineData(0.02)]
        [InlineData(9999)]
        [InlineData(9998)]
        public void SaqueValorValido(decimal valor)
        {
            Assert.True(Validador.ValidateModel(new Deposito() { Conta = SaqueValido.Conta, Valor = valor }).Count == 0);
        }

        [Theory]
        [InlineData(0.009)]
        [InlineData(0.008)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(10000)]
        [InlineData(10001)]
        public void SaqueValorInvalido(decimal valor)
        {
            Assert.False(Validador.ValidateModel(new Deposito() { Conta = SaqueValido.Conta, Valor = valor }).Count == 0);
        }
    }
}
