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
            Assert.AreEqual(30, actividad.Duracion);
            Assert.AreEqual("Correr en el gimnasio", actividad.Descripcion);
        }

    }
}