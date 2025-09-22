using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica1.ModeladoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.ModeladoDatos.Tests
{
    [TestClass()]
    public class UsuarioTests
    {
        private const int INACTIVO = 0;
        private const int ACTIVO = 1;
        private const int BLOQUEADO = 2;

        private Usuario CrearUsuarioCorrecto(string id = "a-001", string nombre = "Pablo", string apellidos = "García", string email = "pablo66@gmail.com", string password = "Conmasde12caracteres", int estado=ACTIVO, string tipo = "ADMIN") { 
            return new Usuario(id,nombre, apellidos, email, password, estado, tipo);
        }

        [TestMethod()]
        public void UsuarioTest_CrearConValoresValidos()
        {
            var usuario = CrearUsuarioCorrecto();
            
            Assert.IsNotNull(usuario);
            Assert.AreEqual("ACTIVO", usuario.obtenerEstado(usuario));
            Assert.AreEqual("ADMIN", usuario.TipoUsuario);
            Assert.IsTrue(usuario.ComprobarContraseña("Conmasde12caracteres"));
            Assert.IsFalse(usuario.ComprobarContraseña("mala"));
        }

        [TestMethod()]
        public void UsuarioTest_EmailIncorrecto()
        {
            _ = CrearUsuarioCorrecto(email: "noemail");
        }

        [TestMethod()]
        public void UsuarioTest_CamposVacios()
        {
            _ = CrearUsuarioCorrecto(id: "", nombre: "", apellidos: "", email: "", password: "");

        }
            [TestMethod()]
        public void CambiarEstadoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void obtenerEstadoTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TipoUsuarioTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ComprobarContraseñaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BloquearCuentaTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EqualsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Assert.Fail();
        }
    }
}