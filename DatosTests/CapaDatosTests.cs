using Datos;
using Logica.ModeladoDatos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practica1.ModeladoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Datos.Tests
{
    [TestClass()]
    public class CapaDatosTests
    {
        private CapaDatos capaDatos;

        [TestInitialize]
        public void Setup()
        {
            capaDatos = new CapaDatos();
        }
        
        [TestMethod]
        public void CapaDatosTest()
        {
            Assert.AreEqual(2, capaDatos.NumUsuarios());
            Assert.AreEqual(2, capaDatos.NumActividades("a-005"));
            Assert.AreEqual(1, capaDatos.NumActividades("a-004"));

        }

        [TestMethod]
        public void GuardaUsuarioVacio()
        {
            var antes = capaDatos.NumUsuarios();

            var usuarioNuevoSistema = capaDatos.GuardaUsuario(null);

            Assert.IsFalse(usuarioNuevoSistema);
            Assert.AreEqual(antes, capaDatos.NumUsuarios());
        }

        [TestMethod]
        public void GuardaUsuarioBueno()
        {
            var usuario = new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, 1, "NORMAL"); 
            var antes = capaDatos.NumUsuarios();

            var usuarioNuevoSistema = capaDatos.GuardaUsuario(usuario);

            Assert.IsTrue(usuarioNuevoSistema);
            Assert.AreEqual(antes + 1, capaDatos.NumUsuarios());
        }

        [TestMethod]
        public void GuardaUsuarioDuplicate()
        {
            var usuario = new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, 1, "NORMAL");
            capaDatos.GuardaUsuario(usuario);
            var before = capaDatos.NumUsuarios();

            capaDatos.GuardaUsuario(usuario);

            Assert.AreEqual(before, capaDatos.NumUsuarios());
        }

        [TestMethod]
        public void NumUsuariosVacio()
        {
            Assert.AreEqual(2, capaDatos.NumUsuarios());
        }

        [TestMethod]
        public void NumUsuariosConUsuarios()
        {
            capaDatos.GuardaUsuario(new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, 1, "NORMAL"));
            capaDatos.GuardaUsuario(new Usuario("a-002", "María", "Pérez", "maria22@gmail.com", "ConMasDe12Caracteres!", "MUJER", 60, 1.7f, 22, 1, "ADMIN"));
            Assert.AreEqual(4, capaDatos.NumUsuarios());
        }

        [TestMethod]
        public void GuardaActividadVacia()
        {
            var antes = capaDatos.NumActividades("a-001");

            var actividadNuevoSistema = capaDatos.GuardaActividad(null);

            Assert.IsFalse(actividadNuevoSistema);
            Assert.AreEqual(antes, capaDatos.NumActividades("a-001"));
        }

        [TestMethod]
        public void GuardaActividadBuena()
        {
            var usuario1 = new Usuario("a-002", "Alexia", "Putellas", "balondeoro@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69, 1.73f, 31, 0, "NORMAL");
            var actividad = new ActividadesFisicas("AF-001", "Correr", 30, "Correr en el gimnasio", usuario1);
            var antes = capaDatos.NumActividades("a-002");

            var actividadNuevoSistema = capaDatos.GuardaActividad(actividad);

            Assert.IsTrue(actividadNuevoSistema);
            Assert.AreEqual(antes + 1, capaDatos.NumActividades("a-002"));
        }

        [TestMethod]
        public void NumUsuariosActivos()
        {
            var activo = new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 67, 1.83f, 23, 1, "NORMAL");
            var activo1 = new Usuario("a-002", "Alexia", "Putellas", "balondeoro@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69, 1.73f, 31, 1, "NORMAL");

            var inactivo = new Usuario("a-003", "María", "Pérez", "maria22@gmail.com", "ConMasDe12Caracteres!", "MUJER", 60, 1.7f, 22, 0, "NORMAL");


            capaDatos.GuardaUsuario(activo);
            capaDatos.GuardaUsuario(inactivo);
            capaDatos.GuardaUsuario(activo1); 

            var count = capaDatos.NumUsuariosActivos();

            Assert.AreEqual(4, count);
        }

        [TestMethod]
        public void NumUsuariosActivosNulo()
        {
            var inactivo = new Usuario("a-002", "Alexia", "Putellas", "balondeoro@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69, 1.73f, 31, 0, "NORMAL");
            var inactivo1 = new Usuario("a-003", "María", "Pérez", "maria22@gmail.com", "ConMasDe12Caracteres!", "MUJER", 60, 1.7f, 22, 0, "NORMAL");

            capaDatos.GuardaUsuario(inactivo);
            capaDatos.GuardaUsuario(inactivo1);

            Assert.AreEqual(2, capaDatos.NumUsuariosActivos());
        }

        [TestMethod]
        public void NumActividades_CompruebaTodosLosEscenarios()
        {
          
            var usuario1 = new Usuario("a-055", "Carlos", "Sainz", "carlos@f1.com", "PaSssword123!", "HOMBRE", 70, 1.75f, 29, 1, "NORMAL");
            var usuario2 = new Usuario("a-016", "Charles", "Leclerc", "charles@f1.com", "PasSsword123!", "HOMBRE", 68, 1.78f, 27, 1, "PREMIUM");

            capaDatos.GuardaUsuario(usuario1);
            capaDatos.GuardaUsuario(usuario2);

           
            capaDatos.GuardaActividad(new ActividadesFisicas("AF-100", "Correr", 30, "Carrera corta", usuario1));
            capaDatos.GuardaActividad(new ActividadesFisicas("AF-101", "Nadar", 45, "Piscina", usuario1));
            capaDatos.GuardaActividad(new ActividadesFisicas("AF-102", "Pesas", 60, "Entrenamiento de fuerza", null));


            int numUsuario1 = capaDatos.NumActividades("a-055");
            int numUsuario2 = capaDatos.NumActividades("a-016");
            int numNulo = capaDatos.NumActividades(null);
            Assert.AreEqual(2, numUsuario1);
            Assert.AreEqual(0, numUsuario2);
            Assert.AreEqual(0, numNulo);
        }

        [TestMethod]
        public void LeeActividadConIdValido()
        {
            var usuario1 = new Usuario("a-002", "Alexia", "Putellas", "balondeoro@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69, 1.73f, 31, 0, "NORMAL");
            var actividad1_Usuario1 = new ActividadesFisicas("AF-001", "Correr", 30, "Correr en el gimnasio", usuario1);
            capaDatos.GuardaActividad(actividad1_Usuario1);

            var lecturaActividad = capaDatos.LeeActividad(0);
            Assert.IsNotNull(lecturaActividad, "La actividad no debería ser nula.");
            Assert.AreEqual("Correr", lecturaActividad.NombreActividad);


        }

        [TestMethod]
        public void LeeActividadConIdInvalido()
        {
            var actividadSuperior = capaDatos.LeeActividad(99);
            var actividadInferior = capaDatos.LeeActividad(-2);

            Assert.IsNull(actividadSuperior, "Se esperaba null para un índice fuera de rango.");
            Assert.IsNull(actividadInferior, "Se esperaba null para un índice fuera de rango.");
        }

        [TestMethod]
        public void LeeUsuarioIdValido()
        {
            var usuario1 = new Usuario("a-002", "Alexia", "Putellas", "balondeoro@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69, 1.73f, 31, 0, "NORMAL");
            capaDatos.GuardaUsuario(usuario1);

            var usuarioLeido = capaDatos.LeeUsuario("balondeoro@gmail.com");
            Assert.IsNotNull(usuarioLeido, "El usuario no debería ser nulo.");
            Assert.AreEqual("Alexia", usuarioLeido.Nombre);
        }

        [TestMethod]
        public void LeeUsuarioIdInvalido()
        {
            
            var usuarioLeido = capaDatos.LeeUsuario("NoSeMereceElBalonAitana@gmail.com");
            Assert.IsNull(usuarioLeido, "El usuario no debería existir no ese email");
        }

        [TestMethod]
        public void ValidaUsuario()
        {

            var resultadoCorrecto = capaDatos.ValidaUsuario("balondeoro3@gmail.com", "ConMasDe12Caracteres!");
            Assert.IsTrue(resultadoCorrecto);

            var resultadoIncorrecto = capaDatos.ValidaUsuario("balondeoro3@gmail.com", "ConMasDe12Caracters!");
            Assert.IsFalse(resultadoIncorrecto);

            var resultadoNulo = capaDatos.ValidaUsuario(null, "ConMasDe12Caracters!");
            Assert.IsFalse(resultadoNulo);
        }


        [TestMethod]
        public void ActualizaUsuario()
        {
           
            var usuarioSinActualizar = new Usuario("a-033", "Max", "Verstappen", "max@f1.com", "COntraseña456!", "HOMBRE", 72, 1.80f, 26, 1, "NORMAL");
            capaDatos.GuardaUsuario(usuarioSinActualizar);

            var usuarioActualizado = new Usuario("a-033", "Max", "Verstappen", "max@f1.com", "COntraseñad476!", "HOMBRE", 72, 1.80f, 26, 1, "PREMIUM");
            var resultadoCorrecto = capaDatos.ActualizaUsuario(usuarioActualizado);

            Assert.IsTrue(resultadoCorrecto, "La actualización debería ser exitosa.");

            var usuarioLeido = capaDatos.LeeUsuario("max@f1.com");
            Assert.AreEqual("PREMIUM", usuarioLeido.ObtenerTipoUsuario(usuarioLeido));

            var usuarioFalso = new Usuario("a-999", "Paco", "Mer", "Pacorreo@correo.com", "PaSsjkfsgfdksj123!", "HOMBRE", 80, 1.80f, 40, 1, "NORMAL");
            var resultadoFalso = capaDatos.ActualizaUsuario(usuarioFalso);

            Assert.IsFalse(resultadoFalso);

        }

        [TestMethod]
        public void ActualizaActividad()
        {
            var usuario = new Usuario("a-034", "Maximilian", "Verstappen", "max@f1.com", "COntraseñad476!", "HOMBRE", 72, 1.80f, 26, 1, "PREMIUM");
            
            var actividadSinActualizar = new ActividadesFisicas("AF-016", "Correr", 50, "Carrera larga", usuario);

            capaDatos.GuardaActividad(actividadSinActualizar);
           
            var actividadActualizada = new ActividadesFisicas("AF-016", "Correr", 45, "Carrera larga", usuario);
            
            
            var resultadoVerdadero = capaDatos.ActualizaActividad(actividadActualizada);

           Assert.IsTrue(resultadoVerdadero, $"La actualización debería ser exitosa. pero es {resultadoVerdadero}");
            var actividad = capaDatos.LeeActividad(3);
            Assert.AreEqual(45/60.0f, actividad.Duracion);

            var actividadFalsa = new ActividadesFisicas("AF-999", "Boxeo", 60, "Entrenamiento duro", usuario);

            var resultadoFalsa = capaDatos.ActualizaActividad(actividadFalsa);

            Assert.IsFalse(resultadoFalsa);

        }

        [TestMethod]
        public void EliminaUsuario()
        {
            var usuario = new Usuario("a-034", "Max", "Verstappen", "max@f1.com", "CContraseña123!", "HOMBRE", 72, 1.80f, 26, 1, "PREMIUM");
            var actividad = new ActividadesFisicas("AF-016", "Correr", 50, "Carrera larga", usuario);
            capaDatos.GuardaUsuario(usuario);
            capaDatos.GuardaActividad(actividad);

            var resultadoCorrecto = capaDatos.EliminaUsuario("max@f1.com");
            Assert.IsTrue(resultadoCorrecto);

            var resultado = capaDatos.EliminaUsuario("noexiste@correo.com");

            Assert.IsFalse(resultado, "Eliminación debería fallar con email inexistente.");

            var resultadNulo = capaDatos.EliminaUsuario(null);
            Assert.IsFalse(resultadNulo, "Eliminación debería fallar con email inexistente.");
        }

        [TestMethod]
        public void EliminaActividad()
        {
            var usuario = new Usuario("a-034", "Max", "Verstappen", "max@f1.com", "CContraseña123!", "HOMBRE", 72, 1.80f, 26, 1, "PREMIUM");
            var actividad = new ActividadesFisicas("AF-016", "Correr", 50, "Carrera larga", usuario);
            capaDatos.GuardaUsuario(usuario);
            capaDatos.GuardaActividad(actividad);

            var resultadoCorrecto = capaDatos.EliminaActividad("AF-016");

            Assert.IsTrue(resultadoCorrecto, "Eliminación debería ser exitosa.");
            Assert.IsNull(capaDatos.LeeActividad(3), "La actividad debería haber sido eliminada.");

            var resultadNulo = capaDatos.EliminaActividad(null);
            Assert.IsFalse(resultadNulo, "Eliminación debería fallar con actividad inexistente.");


        }


        [TestMethod]
        public void ObtenerActividadesUsuario()
        {
            var actividadesCorrecto = capaDatos.ObtenerActividadesUsuario("a-005");

            Assert.IsNotNull(actividadesCorrecto, "La lista no debería ser nula.");
            Assert.AreEqual(2, actividadesCorrecto.Count, "Se esperaba 1 actividad para el usuario.");

            var actividadesIncorrecto = capaDatos.ObtenerActividadesUsuario("a-999");

            Assert.IsNotNull(actividadesIncorrecto, "La lista no debería ser nula.");
            Assert.AreEqual(0, actividadesIncorrecto.Count, "La lista debería estar vacía.");

        }


    }

}