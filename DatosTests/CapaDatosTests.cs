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
           

            var actividad1_Usuario1 = new ActividadesFisicas("AF-001", "Correr", 30, "Correr en el gimnasio",usuario1 ); 
            var actividad2_Usuario1 = new ActividadesFisicas("AF-002", "Nadar", 40, "Hacer largos en una piscina olimpica", usuario1); 
            var actividad1_Usuario2 = new ActividadesFisicas("AF-003", "Pesas", 50, "Ir al gimnasio y levantar pesas",usuario2);

            capaDatos.GuardaActividad(actividad1_Usuario1);
            capaDatos.GuardaActividad(actividad2_Usuario1);
            capaDatos.GuardaActividad(actividad1_Usuario2);

            var totalUsuario1 = capaDatos.NumActividades("a-002");

            Assert.AreEqual(2, totalUsuario1);
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


    }

}