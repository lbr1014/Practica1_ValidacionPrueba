using Microsoft.VisualStudio.TestTools.UnitTesting;
using Datos;
using System;
using Practica1.ModeladoDatos;
using Logica.ModeladoDatos;
using System.Collections.Generic;
using System.Linq;
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
            var usuario = new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres", 1, "NORMAL"); 
            var antes = capaDatos.NumUsuarios();

            var usuarioNuevoSistema = capaDatos.GuardaUsuario(usuario);

            Assert.IsTrue(usuarioNuevoSistema);
            Assert.AreEqual(antes + 1, capaDatos.NumUsuarios());
        }

        [TestMethod]
        public void GuardaUsuarioDuplicate()
        {
            var usuario = new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres", 1, "NORMAL");
            capaDatos.GuardaUsuario(usuario);
            var before = capaDatos.NumUsuarios();

            capaDatos.GuardaUsuario(usuario);

            Assert.AreEqual(before, capaDatos.NumUsuarios());
        }

        [TestMethod]
        public void NumUsuariosVacio()
        {
            Assert.AreEqual(0, capaDatos.NumUsuarios());
        }

        [TestMethod]
        public void NumUsuariosConUsuarios()
        {
            capaDatos.GuardaUsuario(new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres", 1, "NORMAL"));
            capaDatos.GuardaUsuario(new Usuario("a-002", "María", "Pérez", "maria22@gmail.com", "Conmasde12caracteres", 1, "ADMIN"));
            Assert.AreEqual(2, capaDatos.NumUsuarios());
        }

        [TestMethod]
        public void GuardaActividadVacia()
        {
            var antes = capaDatos.NumActividades(123);

            var actividadNuevoSistema = capaDatos.GuardaActividad(null);

            Assert.IsFalse(actividadNuevoSistema);
            Assert.AreEqual(antes, capaDatos.NumActividades(123));
        }

        [TestMethod]
        public void GuardaActividadBuena()
        {
            var actividad = new ActividadesFisicas("AF-001", "Correr", 30, "Correr en el gimnasio");
            var antes = capaDatos.NumActividades(999);

            var actividadNuevoSistema = capaDatos.GuardaActividad(actividad);

            Assert.IsTrue(actividadNuevoSistema);
            Assert.AreEqual(antes + 1, capaDatos.NumActividades(999));
        }

        [TestMethod]
        public void NumUsuariosActivos()
        {
            var activo = new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres", 1, "NORMAL");
            var activo1 = new Usuario("a-002", "Alexia", "Putellas", "balondeoro@gmail.com", "Conmasde12caracteres", 1, "NORMAL");

            var inactivo = new Usuario("a-003", "María", "Pérez", "maria22@gmail.com", "Conmasde12caracteres", 0, "NORMAL");


            capaDatos.GuardaUsuario(activo);
            capaDatos.GuardaUsuario(inactivo);
            capaDatos.GuardaUsuario(activo1); 

            var count = capaDatos.NumUsuariosActivos();

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void NumUsuariosActivosNulo()
        {
            var inactivo = new Usuario("a-002", "Alexia", "Putellas", "balondeoro@gmail.com", "Conmasde12caracteres", 0, "NORMAL");
            var inactivo1 = new Usuario("a-003", "María", "Pérez", "maria22@gmail.com", "Conmasde12caracteres", 0, "NORMAL");

            capaDatos.GuardaUsuario(inactivo);
            capaDatos.GuardaUsuario(inactivo1);

            Assert.AreEqual(0, capaDatos.NumUsuariosActivos());
        }

        [TestMethod]
        public void NumActividades()
        {
            var actividad1_Usuario1 = new ActividadesFisicas("AF-001", "Correr", 30, "Correr en el gimnasio"); 
            var actividad2_Usuario1 = new ActividadesFisicas("AF-002", "Nadar", 40, "Hacer largos en una piscina olimpica"); 
            var actividad1_Usuario2 = new ActividadesFisicas("AF-003", "Pesas", 50, "Ir al gimnasio y levantar pesas");

            capaDatos.GuardaActividad(actividad1_Usuario1);
            capaDatos.GuardaActividad(actividad2_Usuario1);
            capaDatos.GuardaActividad(actividad1_Usuario2);

            var totalUsuario1 = capaDatos.NumActividades(1);

            Assert.AreEqual(2, totalUsuario1);
        }



    }

}