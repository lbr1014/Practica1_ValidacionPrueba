using Logica.ModeladoDatos;
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

        private Usuario CrearUsuarioCorrecto(string id, string nombre, string apellidos, string email, string password, string sexo, float peso, float altura, int edad, int estado = 1, string tipo = "NORMAL") { 
            return new Usuario(id,nombre, apellidos, email, password, sexo, peso, altura, edad, estado, tipo);
            

        }
        private Usuario CrearUsuariodCorrecto2(string id)
        {
            return new Usuario(id);
        }

        [TestMethod()]
        public void UsuarioTestConValoresValidos()
        {
            var usuarioActivo = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f,23, ACTIVO, "ADMIN");
            var usuarioInactivo = CrearUsuarioCorrecto("a-002", "Maria", "Perez", "maria22@gmail.com", "ConMasDe12Caracteres!", "MUJER",60,1.7f,22, INACTIVO, "ADMIN");
            var usuarioBloqueado = CrearUsuarioCorrecto("a-003", "Alexia", "Putellas", "alexia11@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69, 1.73f, 31, BLOQUEADO, "ADMIN");
            
            Assert.IsNotNull(usuarioActivo);
            Assert.AreEqual("Pablo", usuarioActivo.Nombre);
            Assert.AreEqual("García", usuarioActivo.Apellidos);
            Assert.AreEqual("pablo66@gmail.com", usuarioActivo.Email);
            Assert.AreEqual("ACTIVO", usuarioActivo.obtenerEstado(usuarioActivo));
            Assert.AreEqual("ADMIN", usuarioActivo.ObtenerTipoUsuario(usuarioActivo));
            Assert.AreEqual(67, usuarioActivo.Peso);
            Assert.AreEqual(1.83f, usuarioActivo.Altura);
            Assert.AreEqual(23, usuarioActivo.Edad);

            Assert.IsTrue(usuarioActivo.ComprobarContraseña("ConMasDe12Caracteres!"));
            Assert.IsFalse(usuarioActivo.ComprobarContraseña("mala"));

            Assert.AreEqual("INACTIVO", usuarioInactivo.obtenerEstado(usuarioInactivo));
            Assert.AreEqual("BLOQUEADO", usuarioBloqueado.obtenerEstado(usuarioBloqueado));

            Assert.ThrowsException<ArgumentException>(() =>
                CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, 5, "ADMIN"));

            var usuarioID = CrearUsuariodCorrecto2("a-004");
            Assert.IsNotNull(usuarioID);


        }


        [TestMethod()]
        public void UsuarioTestEmailIncorrecto()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                CrearUsuarioCorrecto("a-001", "Pablo", "García", "noemail", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "ADMIN"));
        }


        [TestMethod()]
        public void UsuarioTestContraseñaIncorrecto()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "mala!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "ADMIN"));
        }

        [TestMethod()]
        public void UsuarioTestTipoIncorrecto()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "MALO"));
        }

        [TestMethod()]
        public void UsuarioTestPesoIncorre()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 6700, 1.83f, 23, ACTIVO, "NORMAL"));
        }

        [TestMethod()]
        public void UsuarioTestAlturaIncorre()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 183.0f, 23, ACTIVO, "NORMAL"));
        }

        [TestMethod()]
        public void UsuarioTestEdadIncorre()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 200, ACTIVO, "NORMAL"));
        }

        [TestMethod()]
        public void UsuarioTestCamposVacios()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                CrearUsuarioCorrecto(" ", " ", " ", " ", " ", "", 0,0f,0, ACTIVO, " "));

        }

        [TestMethod()]
        public void SetTest()
        {
            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "DESCONOCIDO", 67, 1.83f, 23, ACTIVO, "NORMAL");
            Assert.ThrowsException<ArgumentException>(() => usuario.Email = "sin-arroba");
            Assert.AreEqual("garcia44@gmail.com",usuario.Email = "garcia44@gmail.com");

            Assert.ThrowsException<ArgumentException>(() => usuario.Password = "corta");

            Assert.ThrowsException<ArgumentException>(() => usuario.Estado = 5);

            Assert.AreEqual("NORMAL", usuario.ObtenerTipoUsuario(usuario));
            Assert.ThrowsException<ArgumentException>(() => usuario.TipoUsuario = "Cualquiera");
            Assert.AreEqual("NORMAL", usuario.ObtenerTipoUsuario(usuario));

            Assert.AreEqual("OTRO", usuario.obtenerSexo(usuario));
            usuario.Sexo = "MUJER";
            Assert.AreEqual("MUJER", usuario.obtenerSexo(usuario));

            usuario.Sexo = "HOMBRE";
            Assert.AreEqual("HOMBRE", usuario.obtenerSexo(usuario));

            usuario.Sexo = "NO BINARIO";
            Assert.AreEqual("OTRO", usuario.obtenerSexo(usuario));

            Assert.ThrowsException<ArgumentException>(() => usuario.Peso = 0f);
            Assert.ThrowsException<ArgumentException>(() => usuario.Peso = 999f);
            Assert.AreEqual(72, usuario.Peso = 72);

            Assert.ThrowsException<ArgumentException>(() => usuario.Altura = 0f);
            Assert.ThrowsException<ArgumentException>(() => usuario.Altura = 3.5f);
            Assert.AreEqual(183f, usuario.AlturaCentimetros(), 0.001);

            Assert.AreEqual(1.72f, usuario.Altura = 1.72f);

            Assert.ThrowsException<ArgumentException>(() => usuario.Edad = 0);
            Assert.ThrowsException<ArgumentException>(() => usuario.Edad = 121);
            Assert.AreEqual(32, usuario.Edad = 32);

            /*
            var futuro = DateTime.Now.AddMinutes(1);
            Assert.ThrowsException<ArgumentException>(() => CrearUsuarioCorrecto("a-002", "Maria", "Perez", "maria22@gmail.com", "ConMasDe12Caracteres!", "MUJER", 60, 1.7f, 22, INACTIVO, "ADMIN", futuro));
            Assert.ThrowsException<ArgumentException>(() => usuario.InicioSesionActual = DateTime.Now.AddHours(1));
            */
        }

        [TestMethod()]
        public void CambiarEstadoTest()
        {
            var usuarioActivo = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f,23, ACTIVO, "ADMIN");
            Assert.AreEqual("ACTIVO", usuarioActivo.obtenerEstado(usuarioActivo));
            usuarioActivo.Estado = BLOQUEADO; 
            Assert.AreEqual("BLOQUEADO", usuarioActivo.obtenerEstado(usuarioActivo));
        }

        [TestMethod()]
        public void ObtenerYCambiarTipoUsuarioTest()
        {
            var usuarioAdmin = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "ADMIN");
            Assert.AreEqual("ADMIN", usuarioAdmin.ObtenerTipoUsuario(usuarioAdmin));

            usuarioAdmin.TipoUsuario = "PREMIUM";
            Assert.AreEqual("PREMIUM", usuarioAdmin.ObtenerTipoUsuario(usuarioAdmin));

            usuarioAdmin.TipoUsuario = "NORMAL";
            Assert.AreEqual("NORMAL", usuarioAdmin.ObtenerTipoUsuario(usuarioAdmin));

            Assert.ThrowsException<ArgumentException>(() => usuarioAdmin.TipoUsuario = "Cualquiera");

        }

        [TestMethod()]
        public void BloquearYDesbloquearCuentaTest()
        {
            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ContraseñaCorrecta1!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "NORMAL");
            var usuarioAdmin = CrearUsuarioCorrecto("a-003", "Alexia", "Putellas", "alexia11@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69, 1.73f, 31, ACTIVO, "ADMIN");

            usuario.BloquearCuenta();
            Assert.AreEqual("BLOQUEADO", usuario.obtenerEstado(usuario));
            Assert.AreNotEqual("ACTIVO", usuario.obtenerEstado(usuario));

            usuario.DesbloquearCuenta(usuario);
            Assert.AreNotEqual("ACTIVO", usuario.obtenerEstado(usuario));

            usuarioAdmin.DesbloquearCuenta(usuario);
            Assert.AreEqual("ACTIVO", usuario.obtenerEstado(usuario));
            Assert.AreNotEqual("BLOQUEADO", usuario.obtenerEstado(usuario));

        }

        [TestMethod()]
        public void ComprobarContraseñaTest()
        {
            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ContraseñaCorrecta1!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "NORMAL");
            bool resultado = usuario.ComprobarContraseña("ContraseñaCorrecta1!");
            Assert.IsTrue(resultado);
            Assert.AreNotEqual("BLOQUEADO", usuario.obtenerEstado(usuario));

            resultado = usuario.ComprobarContraseña("OtraContraseñaDistinta1!");
            Assert.IsFalse(resultado);
            Assert.AreNotEqual("BLOQUEADO", usuario.obtenerEstado(usuario));

            Assert.IsFalse(usuario.ComprobarContraseña("ClaveMala1"));
            Assert.IsFalse(usuario.ComprobarContraseña("ClaveMala2"));
            Assert.IsFalse(usuario.ComprobarContraseña("ClaveMala3"));
            Assert.AreEqual("BLOQUEADO", usuario.obtenerEstado(usuario));

            var usuarioAdmin = CrearUsuarioCorrecto("a-003", "Alexia", "Putellas", "alexia11@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69, 1.73f, 31, ACTIVO, "ADMIN");
            usuarioAdmin.DesbloquearCuenta(usuario);
            Assert.AreEqual("ACTIVO", usuario.obtenerEstado(usuario));

            Assert.IsFalse(usuario.ComprobarContraseña("mala1"));
            Assert.IsFalse(usuario.ComprobarContraseña("mala2"));
            // Acierta: debe resetear (no bloquear tras un fallo más)
            Assert.IsTrue(usuario.ComprobarContraseña("ContraseñaCorrecta1!"));
            Assert.IsFalse(usuario.ComprobarContraseña("mala3"));
            Assert.AreNotEqual("BLOQUEADO", usuario.obtenerEstado(usuario));

        }  

        [TestMethod()]
        public void AsignarContraseñaTest()
        {
            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ContraseñaCorrecta1!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "ADMIN");

            Assert.IsTrue(usuario.ComprobarContraseña("ContraseñaCorrecta1!"));
            usuario.Password = "NuevaContraseñaCorrecta1!";

            Assert.IsFalse(usuario.ComprobarContraseña("ContraseñaCorrecta1!"));
            Assert.IsTrue(usuario.ComprobarContraseña("NuevaContraseñaCorrecta1!"));


        }
        /*
        [TestMethod()]
        public  void UltimoInicioSesion_ConParametros()
        {
            DateTime prueba1 = new DateTime(2025, 3, 14);

            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ContraseñaCorrecta1!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "ADMIN", prueba1);
           
            Assert.AreEqual(prueba1, usuario.InicioSesionActual);

            DateTime prueba2 = new DateTime(2025, 9, 24);
            usuario.InicioSesionActual = prueba2;
            
            Assert.AreEqual(prueba2, usuario.InicioSesionActual);

        }*/
        /*
        [TestMethod()]
        public void InicioSesionActual_SinParametros()
        {
            DateTime antes = DateTime.Now;

            var usuario = new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com","ContraseñaCorrecta1!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "ADMIN");

            DateTime despues = DateTime.Now;

            Assert.IsTrue(usuario.InicioSesionActual >= antes && usuario.InicioSesionActual <= despues);
        }*/

        [TestMethod()]
        public void EqualsTest()
        {
            var usuario1 = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "ADMIN");
            var usuario2 = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "ADMIN");
            Assert.IsTrue(usuario1.Equals(usuario2));

            var usuario3 = CrearUsuarioCorrecto("a-002", "Maria", "Pérez", "maria22@gmail.com", "ConMasDe12Caracteres!", "MUJER", 60, 1.7f, 22, ACTIVO, "ADMIN");
            Assert.IsFalse(usuario1.Equals(usuario3));

        }
        
        [TestMethod()]
        public void GetHashCodeTest()
        {
            var usuario1 = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "ADMIN");
            var usuario2 = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, ACTIVO, "ADMIN");

            int hash1 = usuario1.GetHashCode();
            int hash2 = usuario2.GetHashCode();
            Assert.AreEqual(hash1, hash2);

            var usuario3 = CrearUsuarioCorrecto("a-002", "Maria", "Pérez", "maria22@gmail.com", "ConMasDe12Caracteres!", "MUJER", 60, 1.7f, 22, ACTIVO, "ADMIN");
            int hash3 = usuario3.GetHashCode();
            Assert.AreNotEqual(hash1, hash3);
        }
    }
}