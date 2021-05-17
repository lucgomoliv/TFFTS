using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFTFS.Controllers;
using Xunit.Sdk;

namespace Testes
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CriarUsuarioValido()
        {
            new TFTFS.Models.Usuario(1, "Lucas", 0);
        }
        [TestMethod]
        public void CriarUsuarioInvalido()
        {
            new TFTFS.Models.Usuario(1, "asodhaoushduiashdiuahidhaiusdhaiisdhuasodhaoushduiashdiuahidhaiusdhaiisdhuasodhaoushduiashdiuahidhaiusdhaiisdhuasodhaoushduiashdiuahidhaiusdhaiisdhu", 0);
            Assert.Fail();
        }
    }
}
