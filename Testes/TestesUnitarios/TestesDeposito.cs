using System;
using System.Collections.Generic;
using System.Text;
using Testes.Utils;
using TFTFS.Models;
using Xunit;

namespace Testes.TestesUnitarios
{
    public class TestesDeposito
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void DepositoContaValido(int conta)
        {
            Assert.True(new Deposito() { Conta = conta, Valor = SaqueMock.Valor }.Validate());
        }
        /*
        [Theory]
        [InlineData(null)]
        public void DepositoContaInvalido(int conta)
        {
            Assert.True(Validador.ValidateModel(new Deposito() { Conta = conta, Valor = SaqueValido.Valor }).Count == 0);
        }*/

        [Theory]
        [InlineData(0.01)]
        [InlineData(0.02)]
        [InlineData(9999)]
        [InlineData(9998)]
        public void DepositoValorValido(decimal valor)
        {
            Assert.True(new Deposito() { Conta = SaqueMock.Conta, Valor = valor }.Validate());
        }

        [Theory]
        [InlineData(0.009)]
        [InlineData(0.008)]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(10000)]
        [InlineData(10001)]
        public void DepositoValorInvalido(decimal valor)
        {
            Assert.False(new Deposito() { Conta = SaqueMock.Conta, Valor = valor }.Validate());
        }
    }
}
