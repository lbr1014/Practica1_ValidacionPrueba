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

        private Usuario CrearUsuarioCorrecto(string id, string nombre, string apellidos, string email, string password, int estado = 1, string tipo = "NORMAL", string sexo, float peso, float altura, int edad, DateTime? ultimoInicioSesion = null) { 
            return new Usuario(id,nombre, apellidos, email, password, estado, tipo, sexo, peso, altura, edad, ultimoInicioSesion ?? DateTime.Now);
            

        }

        [TestMethod()]
        public void UsuarioTest_CrearConValoresValidosActivo()
        {
            var usuarioActivo = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres!", ACTIVO, "ADMIN", "HOMBRE", 67, 1.83f,23);
            var usuarioInactivo = CrearUsuarioCorrecto("a-002", "Maria", "Perez", "maria22@gmail.com", "Conmasde12caracteres!", INACTIVO, "ADMIN", "MUJER",60,1.7f,22);
            var usuarioBloqueado = CrearUsuarioCorrecto("a-003", "Alexia", "Putellas", "alexia11@gmail.com", "Conmasde12caracteres!", BLOQUEADO, "ADMIN", "MUJER", 69, 1.73f, 31);
            var error = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres", 5, "ADMIN", "HOMBRE", 67, 1.83f, 23);

            Assert.IsNotNull(usuarioActivo);
            Assert.AreEqual("Pablo", usuarioActivo.Nombre);
            Assert.AreEqual("García", usuarioActivo.Apellidos);
            Assert.AreEqual("pablo66@gmail.com", usuarioActivo.Email);
            Assert.AreEqual("ACTIVO", usuarioActivo.obtenerEstado(usuarioActivo));
            Assert.AreEqual("ADMIN", usuarioActivo.ObtenerTipoUsuario(usuarioActivo));
            Assert.IsTrue(usuarioActivo.ComprobarContraseña("Conmasde12caracteres"));
            Assert.IsFalse(usuarioActivo.ComprobarContraseña("mala"));

            Assert.AreEqual("INACTIVO", usuarioInactivo.obtenerEstado(usuarioInactivo));
            Assert.AreEqual("BLOQUEADO", usuarioBloqueado.obtenerEstado(usuarioBloqueado));
            Assert.AreEqual("ERROR", error.obtenerEstado(error));

        }


        [TestMethod()]
        public void UsuarioTest_EmailIncorrecto()
        {
            _ = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres!", ACTIVO, "ADMIN", "HOMBRE", 67, 1.83f, 23);
        }

        [TestMethod()]
        public void UsuarioTest_CamposVacios()
        {
            _ = CrearUsuarioCorrecto(" ", " ", " ", " ", " ", ACTIVO, " ", "", 0,0f,0);

        }

        [TestMethod()]
        public void CambiarEstadoTest()
        {
            var usuarioActivo = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres!", ACTIVO, "ADMIN", "HOMBRE", 67, 1.83f,23);
            Assert.AreEqual("ACTIVO", usuarioActivo.obtenerEstado(usuarioActivo));
            usuarioActivo.Estado = BLOQUEADO; 
            Assert.AreEqual("BLOQUEADO", usuarioActivo.obtenerEstado(usuarioActivo));
        }

        [TestMethod()]
        public void ObtenerTipoUsuarioTest()
        {
            var usuarioAdmin = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres!", ACTIVO, "ADMIN", "HOMBRE", 67, 1.83f, 23);
            Assert.AreEqual("ADMIN", usuarioAdmin.ObtenerTipoUsuario(usuarioAdmin));

            usuarioAdmin.TipoUsuario = "PREMIUM";
            Assert.AreEqual("PREMIUM", usuarioAdmin.ObtenerTipoUsuario(usuarioAdmin));

            usuarioAdmin.TipoUsuario = "NORMAL";
            Assert.AreEqual("NORMAL", usuarioAdmin.ObtenerTipoUsuario(usuarioAdmin));

            var usuarioError = CrearUsuarioCorrecto("a-002", "Maria", "Perez", "maria22@gmail.com", "Conmasde12caracteres!", INACTIVO, "ERROR", "MUJER", 60, 1.7f, 22);
            Assert.AreEqual("ERROR", usuarioError.ObtenerTipoUsuario(usuarioError));

        }

        [TestMethod()]
        public void CambiarTipoUsuarioTest()
        {
            var usuarioAdmin = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres", ACTIVO, "ADMIN");
            Assert.AreEqual("ADMIN", usuarioAdmin.TipoUsuario);

            usuarioAdmin.CambiarTipoUsuario("PREMIUM");
            Assert.AreEqual("PREMIUM", usuarioAdmin.TipoUsuario);

            usuarioAdmin.CambiarTipoUsuario("NORMAL");
            Assert.AreEqual("NORMAL", usuarioAdmin.TipoUsuario);
        }

        [TestMethod()]
        public void BloquearCuentaTest()
        {
            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ContraseñaCorrecta1!", ACTIVO, "ADMIN");
            usuario.BloquearCuenta();
            Assert.AreEqual("BLOQUEADO", usuario.obtenerEstado(usuario));
            Assert.AreNotEqual("ACTIVO", usuario.obtenerEstado(usuario));
        }

        [TestMethod()]
        public void DesbloquearCuentaTest()
        {
            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ContraseñaCorrecta1!", ACTIVO, "NORMAL");
            usuario.BloquearCuenta();
            Assert.AreEqual("BLOQUEADO", usuario.obtenerEstado(usuario));
            Assert.AreNotEqual("ACTIVO", usuario.obtenerEstado(usuario));

            usuario.DesbloquearCuenta();
            Assert.AreNotEqual("ACTIVO", usuario.obtenerEstado(usuario));

            usuario.TipoUsuario="ADMIN";
            usuario.DesbloquearCuenta();
            Assert.AreEqual("ACTIVO", usuario.obtenerEstado(usuario));
            Assert.AreNotEqual("BLOQUEADO", usuario.obtenerEstado(usuario));

        }

        [TestMethod()]
        public void ComprobarContraseñaCorrectaTest()
        {
            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ContraseñaCorrecta1!", ACTIVO, "ADMIN");
            bool resultado = usuario.ComprobarContraseña("ContraseñaCorrecta1!");
            Assert.IsTrue(resultado);
            Assert.AreNotEqual("BLOQUEADO", usuario.obtenerEstado(usuario));

        }

        [TestMethod()]
        public void ComprobarContraseñaIncorrectaTest()
        {
            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ContraseñaCorrecta1!", ACTIVO, "ADMIN");
            bool resultado = usuario.ComprobarContraseña("OtraContraseñaDistinta1!");
            Assert.IsFalse(resultado);
            Assert.AreNotEqual("BLOQUEADO", usuario.obtenerEstado(usuario));

        }

        [TestMethod()]
        public void ComprobarContraseñaBloquearUsuarioTest()
        {
            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ContraseñaCorrecta1!", ACTIVO, "ADMIN");
            usuario.ComprobarContraseña("ClaveMala1");
            usuario.ComprobarContraseña("ClaveMala2");
            bool resultado = usuario.ComprobarContraseña("ClaveMala3");

            Assert.IsFalse(resultado);
            Assert.AreEqual("BLOQUEADO", usuario.obtenerEstado(usuario));
        }

        [TestMethod()]
        public void AsignarContraseñaTest()
        {
            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ContraseñaCorrecta1!", ACTIVO, "ADMIN");

            Assert.IsTrue(usuario.ComprobarContraseña("ContraseñaCorrecta1!"));
            usuario.Password = "NuevaContraseñaCorrecta1!";

            Assert.IsFalse(usuario.ComprobarContraseña("ContraseñaCorrecta1!"));
            Assert.IsTrue(usuario.ComprobarContraseña("NuevaContraseñaCorrecta1!"));


        }
        [TestMethod()]
        public  void UltimoInicioSesion_ConParametros()
        {
            DateTime prueba1 = new DateTime(2025, 3, 14);

            var usuario = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "ContraseñaCorrecta1!", ACTIVO, "ADMIN", prueba1);
           
            Assert.AreEqual(prueba1, usuario.UltimoInicioSesion);

            DateTime prueba2 = new DateTime(2025, 9, 24);
            usuario.UltimoInicioSesion = prueba2;
            
            Assert.AreEqual(prueba2, usuario.UltimoInicioSesion);

        }

        [TestMethod()]
        public void UltimoInicioSesion_SinParametros()
        {
            DateTime antes = DateTime.Now;

            var usuario = new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com","ContraseñaCorrecta1!", 1, "ADMIN");

            DateTime despues = DateTime.Now;

            Assert.IsTrue(usuario.UltimoInicioSesion >= antes && usuario.UltimoInicioSesion <= despues);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var usuario1 = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres", ACTIVO, "ADMIN");
            var usuario2 = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres", ACTIVO, "ADMIN");
            Assert.IsTrue(usuario1.Equals(usuario2));

            var usuario3 = CrearUsuarioCorrecto("a-002", "Maria", "Pérez", "maria22@gmail.com", "Conmasde12caracteres", ACTIVO, "ADMIN");
            Assert.IsFalse(usuario1.Equals(usuario3));

        }
        
        [TestMethod()]
        public void GetHashCodeTest()
        {
            var usuario1 = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres", ACTIVO, "ADMIN");
            var usuario2 = CrearUsuarioCorrecto("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres", ACTIVO, "ADMIN");

            int hash1 = usuario1.GetHashCode();
            int hash2 = usuario2.GetHashCode();
            Assert.AreEqual(hash1, hash2);

            var usuario3 = CrearUsuarioCorrecto("a-002", "Maria", "Pérez", "maria22@gmail.com", "Conmasde12caracteres", ACTIVO, "ADMIN");
            int hash3 = usuario3.GetHashCode();
            Assert.AreNotEqual(hash1, hash3);
        }
    }
}