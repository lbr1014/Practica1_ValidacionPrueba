using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logica.ModeladoDatos;
using Practica1.ModeladoDatos; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.ModeladoDatos.Tests
{
    [TestClass()]
    public class ActividadesFisicasTests
    {

        private ActividadesFisicas CrearActividadCorrecta(string id, string nombre, int duracion, string descripcion)
        {
            return new ActividadesFisicas(id, nombre, duracion, descripcion);
        }

        [TestMethod]
        public void ActividadCorrecta()
        {
            var actividad = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio");

            Assert.AreEqual("Correr", actividad.NombreActividad);
            actividad.NombreActividad = "Nadar";
            Assert.AreEqual("Nadar", actividad.NombreActividad);

            Assert.AreEqual(30, actividad.Duracion);
            actividad.Duracion = 40;
            Assert.AreEqual(40, actividad.Duracion);

            Assert.AreEqual("Correr en el gimnasio", actividad.Descripcion);
            actividad.Descripcion = "Hacer largos en una piscina olimpica";
            Assert.AreEqual("Hacer largos en una piscina olimpica", actividad.Descripcion);
        }

        [TestMethod()]
        public void EqualsTest()
        {
            var actividad1 = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio");
            var actividad2 = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio");
            Assert.IsTrue(actividad1.Equals(actividad2));

            var actividad3 = CrearActividadCorrecta("AF-002", "Nadar", 40, "Hacer largos en una piscina olimpica");
            Assert.IsFalse(actividad1.Equals(actividad3));

        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var actividad1 = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio");
            var actividad2 = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio");

            int hash1 = actividad1.GetHashCode();
            int hash2 = actividad2.GetHashCode();
            Assert.AreEqual(hash1, hash2);

            var actividad3 = CrearActividadCorrecta("AF-002", "Nadar", 40, "Hacer largos en una piscina olimpica");
            int hash3 = actividad3.GetHashCode();
            Assert.AreNotEqual(hash1, hash3);
        }

    }

}