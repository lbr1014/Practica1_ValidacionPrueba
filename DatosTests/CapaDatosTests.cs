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
        public void NumActividades()
        {
            var usuario1 = new Usuario("a-002", "Alexia", "Putellas", "balondeoro@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69, 1.73f, 31, 0, "NORMAL");
            var usuario2 = new Usuario("a-003", "María", "Pérez", "maria22@gmail.com", "ConMasDe12Caracteres!", "MUJER", 60, 1.7f, 22, 0, "NORMAL");
            var usuarioSinActvidades = new Usuario("a-010", "Claudia", "Sanchez", "claudia2@gmail.com", "ConMasDe12Caracteres!", "MUJER", 65, 1.67f, 23, 0, "NORMAL");


            var actividad1_Usuario1 = new ActividadesFisicas("AF-001", "Correr", 30, "Correr en el gimnasio",usuario1 ); 
            var actividad2_Usuario1 = new ActividadesFisicas("AF-002", "Nadar", 40, "Hacer largos en una piscina olimpica", usuario1); 
            var actividad1_Usuario2 = new ActividadesFisicas("AF-003", "Pesas", 50, "Ir al gimnasio y levantar pesas",usuario2);

            capaDatos.GuardaUsuario(usuarioSinActvidades);
            capaDatos.GuardaActividad(actividad1_Usuario1);
            capaDatos.GuardaActividad(actividad2_Usuario1);
            capaDatos.GuardaActividad(actividad1_Usuario2);
            var totalUsuario1 = capaDatos.NumActividades("a-002");
            var totalUsuarioSinActividades = capaDatos.NumActividades("a - 010");
            int numActividades = capaDatos.NumActividades("no-existe");
            int numActividadesUsuarioNulo = capaDatos.NumActividades(null);

            Assert.AreEqual(0, numActividadesUsuarioNulo);
            Assert.AreEqual(0, numActividades);
            Assert.AreEqual(2, totalUsuario1);
            Assert.AreEqual(0, totalUsuarioSinActividades);
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
            var actividadSinActualizar = new ActividadesFisicas("AF-015", "Correr", 56, "Carrera larga", usuario);


            var actividadActualizada = new ActividadesFisicas("AF-001", "Correr", 45, "Carrera larga", usuario);

            var resultadoVerdadero = capaDatos.ActualizaActividad(actividadActualizada);

            Assert.IsTrue(resultadoVerdadero);
            var actividad = capaDatos.LeeActividad(2);
            Assert.AreEqual(45/60.0f, actividad.Duracion);

            var actividadFalsa = new ActividadesFisicas("AF-999", "Boxeo", 60, "Entrenamiento duro", usuario);

            var resultadoFalsa = capaDatos.ActualizaActividad(actividadFalsa);

            Assert.IsFalse(resultadoFalsa);

        }
    }

}