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
            Assert.IsTrue(Validar.NIF("71567703Y"));

            Assert.IsFalse(Validar.NIF(" "));
            Assert.IsFalse(Validar.NIF("22L"));
            Assert.IsFalse(Validar.NIF("71567703"));
            Assert.IsFalse(Validar.NIF("KKKKKKKK"));
            Assert.IsFalse(Validar.NIF("ABCDEFGHX"));


        }

        [TestMethod()]
        public void IBANTest()
        {
            Assert.IsFalse(Validar.NIF(" "));
            Assert.IsFalse(Validar.NIF("111111"));
        }

        [TestMethod()]
        public void ContrasenaTest()
        {
            Assert.IsTrue(Validar.Contrasena("ContraseñaCorrecta1!"));

            Assert.IsFalse(Validar.Contrasena(" "));
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

            Assert.IsFalse(Validar.Email(" "));
            Assert.IsFalse(Validar.Email("miUsuario@gmail"));
            Assert.IsFalse(Validar.Email("miUsuario@@gmail.com"));
            Assert.IsFalse(Validar.Email("@gmail.com"));
            Assert.IsFalse(Validar.Email(" @gmail.com"));
            Assert.IsFalse(Validar.Email("miUsu ario@gmail.com"));
            Assert.IsFalse(Validar.Email("mi-Usuario@gmail.com"));
            Assert.IsFalse(Validar.Email("miUsuario@."));
            Assert.IsFalse(Validar.Email("miUsuario@. "));
        }

        [TestMethod()]
        public void UltimoInicioSesionTest()
        {
            DateTime inicioSesion = new DateTime(2025, 3, 14);
            Assert.IsTrue(Validar.ComprobarFecha(inicioSesion));

            DateTime inicioSesionIncorrectoAño = new DateTime(2026, 3, 14);
            Assert.IsFalse(Validar.ComprobarFecha(inicioSesionIncorrectoAño));

            DateTime inicioSesionIncorrectoMes = new DateTime(2025, 12, 14);
            Assert.IsFalse(Validar.ComprobarFecha(inicioSesionIncorrectoMes));

        }

        [TestMethod()]
        public void TipoUsuarioTest()
        {

            Assert.IsTrue(Validar.TipoUsuario("ADMIN"));
            Assert.IsTrue(Validar.TipoUsuario("NORMAL"));
            Assert.IsTrue(Validar.TipoUsuario("PREMIUM"));

            Assert.IsFalse(Validar.TipoUsuario(null));
            Assert.IsFalse(Validar.TipoUsuario(""));
            Assert.IsFalse(Validar.TipoUsuario(" "));
            Assert.IsFalse(Validar.TipoUsuario("admin"));
            Assert.IsFalse(Validar.TipoUsuario("Premium"));
            Assert.IsFalse(Validar.TipoUsuario("CUALQUIERA"));
            Assert.IsFalse(Validar.TipoUsuario("PREM IUM"));

        }

        [TestMethod()]
        public void EstadoTest()
        {
            Assert.IsTrue(Validar.Estado(0));
            Assert.IsTrue(Validar.Estado(1));
            Assert.IsTrue(Validar.Estado(2));

            Assert.IsFalse(Validar.Estado(-1));
            Assert.IsFalse(Validar.Estado(3));
            Assert.IsFalse(Validar.Estado(99));
        }

        [TestMethod()]
        public void PesoTest()
        {
            Assert.IsTrue(Validar.Peso(1f));
            Assert.IsTrue(Validar.Peso(75.5f));
            Assert.IsTrue(Validar.Peso(500f));

            Assert.IsFalse(Validar.Peso(0f));
            Assert.IsFalse(Validar.Peso(-0.1f));
            Assert.IsFalse(Validar.Peso(500.01f));
            Assert.IsFalse(Validar.Peso(float.NaN));
            Assert.IsFalse(Validar.Peso(float.NegativeInfinity));
            Assert.IsFalse(Validar.Peso(float.PositiveInfinity));
        }

        [TestMethod()]
        public void AlturaTest()
        {
            Assert.IsTrue(Validar.Altura(1.8f));
            Assert.IsTrue(Validar.Altura(3.0f));

            Assert.IsFalse(Validar.Altura(0f));
            Assert.IsFalse(Validar.Altura(-1f));
            Assert.IsFalse(Validar.Altura(3.01f));
            Assert.IsFalse(Validar.Altura(float.NaN));
            Assert.IsFalse(Validar.Altura(float.NegativeInfinity));
            Assert.IsFalse(Validar.Altura(float.PositiveInfinity));
        }

        [TestMethod()]
        public void EdadTest()
        {
            // Válidos
            Assert.IsTrue(Validar.Edad(1));
            Assert.IsTrue(Validar.Edad(23));
            Assert.IsTrue(Validar.Edad(120));

            // Inválidos
            Assert.IsFalse(Validar.Edad(0));
            Assert.IsFalse(Validar.Edad(-1));
            Assert.IsFalse(Validar.Edad(121));
        }
    }
}