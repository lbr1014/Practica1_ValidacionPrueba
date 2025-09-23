using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.utils.Tests
{
    [TestClass()]
    public class ValidarTests
    {
        [TestMethod()]
        public void NIFTest()
        {
            Assert.IsFalse(Validar.NIF("111111K"));
            Assert.IsTrue(Validar.NIF("71567703Y"));
        }

        [TestMethod()]
        public void IBANTest()
        {
            Assert.IsFalse(Validar.NIF("111111"));
        }

        [TestMethod()]
        public void ContrasenaTest()
        {
            Assert.IsTrue(Validar.Contrasena("ContraseñaCorrecta1!"));

            Assert.IsFalse(Validar.Contrasena("aaAA1!"));
            Assert.IsFalse(Validar.Contrasena("ContrasenaSinNumeros!"));
            Assert.IsFalse(Validar.Contrasena("Contrasenasinmayusculas1!"));
            Assert.IsFalse(Validar.Contrasena("CONTRASEÑASINMINUSCULAS1!"));
            Assert.IsFalse(Validar.Contrasena("ContrasenaSinCaracteresEspeciales1"));
            
        }


        [TestMethod()]
        public void EmailTest()
        {

            Assert.IsTrue(Validar.Email("nombre@gmail.com"));

            Assert.IsFalse(Validar.Email("miUsuario@gmail"));
            Assert.IsFalse(Validar.Email("miUsuario@@gmail.com"));
            Assert.IsFalse(Validar.Email("@gmail.com"));
            Assert.IsFalse(Validar.Email("miUsu ario@gmail.com"));
            Assert.IsFalse(Validar.Email("mi-Usuario@gmail.com"));
            Assert.IsFalse(Validar.Email("miUsuario@."));
        }
    }
}