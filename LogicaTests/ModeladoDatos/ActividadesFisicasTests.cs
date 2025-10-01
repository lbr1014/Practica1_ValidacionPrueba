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


        private ActividadesFisicas CrearActividadCorrecta(string id, string nombre, int duracion, string descripcion, Usuario usuario)
        {
            return new ActividadesFisicas(id, nombre, duracion, descripcion, usuario);
        }
        
        private Usuario CrearUsuarioCorrecto1()
        {
            return new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com", "Conmasde12caracteres!", 1,  "ADMIN", "HOMBRE", 65.0f, 179.0f, 40);
        }
        private Usuario CrearUsuarioCorrecto2()
        {
            return new Usuario("a-002", "Alexia", "Putellas", "balondeoro@gmail.com", "Conmasde12caracteres!", 1, "NORMAL", "MUJER", 69.0f, 173.0f, 31);
        }


        [TestMethod]
        public void ActividadCorrecta()   
        {
            var usuario = CrearUsuarioCorrecto1();
            var actividad = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio",usuario );
        

        Assert.AreEqual("Correr", actividad.NombreActividad);
            actividad.NombreActividad = "Nadar";
            Assert.AreEqual("Nadar", actividad.NombreActividad);

            Assert.AreEqual(30, actividad.Duracion);
            actividad.Duracion = 40;
            Assert.AreEqual(40, actividad.Duracion);

            Assert.AreEqual("Correr en el gimnasio", actividad.Descripcion);
            actividad.Descripcion = "Hacer largos en una piscina olimpica";
            Assert.AreEqual("Hacer largos en una piscina olimpica", actividad.Descripcion);
            Assert.AreEqual(usuario, actividad.Usuario);

            Assert.IsNotNull(actividad.CalcularCalorias(usuario));
            Assert.IsNotNull(actividad.CalcularMetabolismobasal(usuario));
            Assert.IsNotNull(actividad.Met);

        }

        [TestMethod]
        public void CalculoCaloriasCorrecto()
        {
            var usuario1 = CrearUsuarioCorrecto1();
            var actividad = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio", usuario1);

            float caloriasCalculadas1 = actividad.CalcularCalorias(usuario1);
            float caloriasEsperadas1 = 10f * usuario1.Peso * 30f;

            Assert.IsTrue(Math.Abs(caloriasCalculadas1 - caloriasEsperadas1) == 0);

        }

        [TestMethod]
        public void CalculoMBRCorrecto()
        {
            var usuario1 = CrearUsuarioCorrecto1();
            var actividad = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio", usuario1);
            var usuario2 = CrearUsuarioCorrecto2();
            var actividad2 = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio", usuario2);
            var usuario3 = new Usuario("a-007", "Ivan", "Lopez", "ivan66@gmail.com", "Conmasde12caracteres!", 1, "NORMAL", "OTRO", 76.0f, 174.0f, 37);
            var actividad3 = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio", usuario3);

            float mbrHombre = actividad.CalcularMetabolismobasal(usuario1);
            float mbrMujer = actividad2.CalcularMetabolismobasal(usuario2);
            float mbrOtro = actividad3.CalcularMetabolismobasal(usuario3);


            float mbrEsperadoHombre = (10 * usuario1.Peso) + (6.25f * usuario1.Altura) - (5 * usuario1.Edad) + 5;
            float mbrEsperadoMujer = (10 * usuario2.Peso) + (6.25f * usuario2.Altura) - (5 * usuario2.Edad) - 161;
            float mbrEsperadoOtro = (((10 * usuario3.Peso) + (6.25f * usuario3.Altura) - (5 * usuario3.Edad) - 161) + ((10 * usuario3.Peso) + (6.25f * usuario3.Altura) - (5 * usuario3.Edad) + 5)) / 2;


            Assert.IsTrue(Math.Abs(mbrHombre - mbrEsperadoHombre) == 0);

            Assert.IsTrue(Math.Abs(mbrMujer - mbrEsperadoMujer) == 0);

            Assert.IsTrue(Math.Abs(mbrOtro - mbrEsperadoOtro) == 0);

        }

        [TestMethod()]
        public void EqualsTest()
        {
            var usuario = CrearUsuarioCorrecto1();
            var actividad1 = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio", usuario);
            var actividad2 = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio", usuario);
            Assert.IsTrue(actividad1.Equals(actividad2));

            var actividad3 = CrearActividadCorrecta("AF-002", "Nadar", 40, "Hacer largos en una piscina olimpica", usuario);
            Assert.IsFalse(actividad1.Equals(actividad3));

        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var usuario = CrearUsuarioCorrecto1();
            var actividad1 = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio", usuario);
            var actividad2 = CrearActividadCorrecta("AF-001", "Correr", 30, "Correr en el gimnasio", usuario);

            int hash1 = actividad1.GetHashCode();
            int hash2 = actividad2.GetHashCode();
            Assert.AreEqual(hash1, hash2);

            var actividad3 = CrearActividadCorrecta("AF-002", "Nadar", 40, "Hacer largos en una piscina olimpica", usuario);
            int hash3 = actividad3.GetHashCode();
            Assert.AreNotEqual(hash1, hash3);
        }

    }

}