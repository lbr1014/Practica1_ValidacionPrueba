using Logica.ModeladoDatos;
using Logica.utils;
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
    public class ActividadesFisicasTests
    {


        private ActividadesFisicas CrearActividadCorrecta(string id, string nombre, int duracion, DateTime fecha, string descripcion, Usuario usuario)
        {
            return new ActividadesFisicas(id, nombre, duracion, fecha, descripcion, usuario);
        }
        
        private Usuario CrearUsuarioCorrecto1()
        {
            return new Usuario("a-001", "Pablo", "García", "pablo66@gmail.com", "ConMasDe12Caracteres!", "HOMBRE", 65.0f, 1.79f, 40, 1, "ADMIN");
        }
        private Usuario CrearUsuarioCorrecto2()
        {
            return new Usuario("a-002", "Alexia", "Putellas", "balondeoro@gmail.com", "ConMasDe12Caracteres!", "MUJER", 69.0f, 1.73f, 31, 1, "NORMAL");
        }
        private ActividadesFisicas CrearActividadCorrecta2(string id, Usuario usuario)
        {
            return new ActividadesFisicas(id, usuario);
        }
        [TestMethod]
        public void ActividadConstructor2()
            
        {
            var usuario = CrearUsuarioCorrecto2();
            var actividad = CrearActividadCorrecta2("AF-001", usuario);
            Assert.AreEqual(usuario, actividad.Usuario);
            Assert.AreEqual("AF-001", actividad.IdActividad);

        }


        [TestMethod]
        public void ActividadCorrecta()   
        {
            var usuario = CrearUsuarioCorrecto1();
            var actividad = CrearActividadCorrecta("AF-001", "Correr", 30, new DateTime(2 / 09 / 2020), "Correr en el gimnasio",usuario );

            Assert.AreEqual("AF-001", actividad.IdActividad);
            string nuevoID = "AF-002";
            actividad.IdActividad = nuevoID;
            Assert.AreEqual("AF-002", actividad.IdActividad);

            Assert.AreEqual("Correr", actividad.NombreActividad);
            actividad.NombreActividad = "Nadar";
            Assert.AreEqual("Nadar", actividad.NombreActividad);

            Assert.AreEqual(30/60.0f, actividad.Duracion);
            actividad.Duracion = 40;
            Assert.AreEqual(40/60.0f, actividad.Duracion);

            Assert.AreEqual("Correr en el gimnasio", actividad.Descripcion);
            actividad.Descripcion = "Hacer largos en una piscina olimpica";
            Assert.AreEqual("Hacer largos en una piscina olimpica", actividad.Descripcion);
            Assert.AreEqual(usuario, actividad.Usuario);
            var usuario2 = CrearUsuarioCorrecto2();
            actividad.Usuario = usuario2;
            Assert.AreEqual(usuario2, actividad.Usuario);

            Assert.IsNotNull(actividad.CalcularCalorias(usuario));
            Assert.IsNotNull(actividad.CalcularMetabolismobasal(usuario));
            Assert.AreNotEqual(0,actividad.MET);
            int nuevoMET = 28;
            actividad.MET = nuevoMET;
            Assert.AreNotEqual(0, actividad.MET);


        }

        [TestMethod]
        public void FechaIncorrectaTest()
        {
            var usuario = CrearUsuarioCorrecto1();

            // Caso válido: fecha pasada -> no lanza y asigna
            var pasada = DateTime.Now.AddDays(-5);
            var ok = new ActividadesFisicas("AF-001", "Correr", 30f, pasada, "Correr en el gimnasio", usuario);
            Assert.AreEqual(pasada, ok.Fecha);

            // Caso inválido: fecha futura -> DEBE lanzar la excepción del constructor
            var futura = DateTime.Now.Date.AddDays(1); // “mañana” asegura futuro incluso si solo se compara la Date
            var ex = Assert.Throws<ArgumentException>(() =>
                new ActividadesFisicas("AF-002", "Correr", 30f, futura, "Correr en el gimnasio", usuario)
            );
            StringAssert.Contains(ex.Message, "no puede ser futura");

        }

        [TestMethod]
        public void ConvertirFecha_Valida_DevuelveDateCorrecto()
        {
            // d/M/yyyy
            var d1 = ActividadesFisicas.ConvertirFecha("1/9/2025");
            Assert.AreEqual(new DateTime(2025, 9, 1), d1);
            Assert.AreEqual(TimeSpan.Zero, d1.TimeOfDay, "Debe devolver solo la fecha (hora 00:00:00)");

            // dd/M/yyyy
            var d2 = ActividadesFisicas.ConvertirFecha("01/9/2025");
            Assert.AreEqual(new DateTime(2025, 9, 1), d2);

            // d/MM/yyyy
            var d3 = ActividadesFisicas.ConvertirFecha("1/09/2025");
            Assert.AreEqual(new DateTime(2025, 9, 1), d3);

            // dd/MM/yyyy (con espacios alrededor -> Trim)
            var d4 = ActividadesFisicas.ConvertirFecha("  15/01/2024  ");
            Assert.AreEqual(new DateTime(2024, 1, 15), d4);
        }

        [TestMethod]
        public void ConvertirFecha_Invalida_LanzaExcepcionApropiada()
        {
            // nulo o vacío -> ArgumentException con nombre de parámetro
            var exNull = Assert.Throws<ArgumentException>(() => ActividadesFisicas.ConvertirFecha(null));
            StringAssert.Contains(exNull.Message, "La fecha no puede estar vacía.");
            Assert.AreEqual("fechaTexto", exNull.ParamName);

            var exEmpty = Assert.Throws<ArgumentException>(() => ActividadesFisicas.ConvertirFecha("   "));
            StringAssert.Contains(exEmpty.Message, "La fecha no puede estar vacía.");
            Assert.AreEqual("fechaTexto", exEmpty.ParamName);

            // formato o valor imposible -> FormatException
            Assert.Throws<FormatException>(() => ActividadesFisicas.ConvertirFecha("31/02/2025"));   // día no válido
            Assert.Throws<FormatException>(() => ActividadesFisicas.ConvertirFecha("15/13/2025"));   // mes 13
            Assert.Throws<FormatException>(() => ActividadesFisicas.ConvertirFecha("15-01-2024"));   // separador '-'
            Assert.Throws<FormatException>(() => ActividadesFisicas.ConvertirFecha("15/01/25"));     // año 2 dígitos
            Assert.Throws<FormatException>(() => ActividadesFisicas.ConvertirFecha("15/01/2025 10:00")); // lleva hora
            Assert.Throws<FormatException>(() => ActividadesFisicas.ConvertirFecha("Jan/15/2025"));  // cultura no es-ES
        }

        [TestMethod]
        public void FechaTest()
        {
            var usuario = CrearUsuarioCorrecto1();
            var actividad = CrearActividadCorrecta("AF-001", "Correr", 30, new DateTime(2 / 09 / 2020), "Correr en el gimnasio", usuario);

            var ahora = DateTime.Now;
            var pasado = ahora.AddDays(-10);
            var futuro = ahora.AddDays(10);

            actividad.Fecha = pasado;
            Assert.AreEqual(pasado, actividad.Fecha);

            actividad.Fecha = ahora;
            Assert.AreEqual(ahora, actividad.Fecha);

            var ex = Assert.Throws<ArgumentException>(() => actividad.Fecha = futuro);
            Assert.AreEqual(ahora, actividad.Fecha);
        }

        [TestMethod]
        public void CalculoCaloriasCorrecto()
        {
            var usuario1 = CrearUsuarioCorrecto1();
            var actividad = CrearActividadCorrecta("AF-001", "Correr", 30, new DateTime(2 / 09 / 2020), "Correr en el gimnasio", usuario1);

            var actividad2 = CrearActividadCorrecta("AF-001", "Correr", 50, new DateTime(2 / 09 / 2020), "Correr en el gimnasio", usuario1);

            float caloriasCalculadas1 = actividad.CalcularCalorias(usuario1);
           
            float caloriasEsperadas1 = actividad.MET * usuario1.Peso * (actividad.Duracion);

            float caloriasCalculadas2 = actividad2.CalcularCalorias(usuario1);

            

            Assert.AreEqual(0, Math.Abs(caloriasCalculadas1 - caloriasEsperadas1), $" Calculadas :{caloriasCalculadas1} , Esperadas: {caloriasEsperadas1}");
          


        }

        [TestMethod]
        public void CalculoMBRCorrecto()
        {
            var usuario1 = CrearUsuarioCorrecto1();
            var actividad = CrearActividadCorrecta("AF-001", "Correr", 30, new DateTime(2 / 09 / 2020), "Correr en el gimnasio", usuario1);
            var usuario2 = CrearUsuarioCorrecto2();
            var actividad2 = CrearActividadCorrecta("AF-001", "Correr", 30, new DateTime(2 / 09 / 2020), "Correr en el gimnasio", usuario2);
            var usuario3 = new Usuario("a-007", "Ivan", "Lopez", "ivan66@gmail.com", "ConMasDe12Caracteres!", "OTRO", 76.0f, 1.74f, 37, 1, "NORMAL");
            var actividad3 = CrearActividadCorrecta("AF-001", "Correr", 30, new DateTime(2 / 09 / 2020), "Correr en el gimnasio", usuario3);

            float mbrHombre = actividad.CalcularMetabolismobasal(usuario1);
            float mbrMujer = actividad2.CalcularMetabolismobasal(usuario2);
            float mbrOtro = actividad3.CalcularMetabolismobasal(usuario3);


            float mbrEsperadoHombre = (10 * usuario1.Peso) + (6.25f * usuario1.AlturaCentimetros()) - (5 * usuario1.Edad) + 5;
            float mbrEsperadoMujer = (10 * usuario2.Peso) + (6.25f * usuario2.AlturaCentimetros()) - (5 * usuario2.Edad) - 161;
            float mbrEsperadoOtro = (((10 * usuario3.Peso) + (6.25f * usuario3.AlturaCentimetros()) - (5 * usuario3.Edad) - 161) + ((10 * usuario3.Peso) + (6.25f * usuario3.AlturaCentimetros()) - (5 * usuario3.Edad) + 5)) / 2;


            Assert.AreEqual(0, Math.Abs(mbrHombre - mbrEsperadoHombre), $" CalculadasH :{mbrHombre} , EsperadasH: {mbrEsperadoHombre}");

            Assert.AreEqual(0, Math.Abs(mbrMujer - mbrEsperadoMujer), $" CalculadasM :{mbrMujer} , EsperadasM: {mbrEsperadoMujer}");

            Assert.AreEqual(0, Math.Abs(mbrOtro - mbrEsperadoOtro), $" CalculadasO :{mbrOtro} , EsperadasO: {mbrEsperadoOtro}");

        }

        [TestMethod()]
        public void EqualsTest()
        {
            var usuario = CrearUsuarioCorrecto1();
            var actividad1 = CrearActividadCorrecta("AF-001", "Correr", 30, new DateTime(2 / 09 / 2020), "Correr en el gimnasio", usuario);
            var actividad2 = CrearActividadCorrecta("AF-001", "Correr", 30, new DateTime(2 / 09 / 2020), "Correr en el gimnasio", usuario);
            Assert.IsTrue(actividad1.Equals(actividad2));

            var actividad3 = CrearActividadCorrecta("AF-002", "Nadar", 40, new DateTime(2 / 09 / 2020), "Hacer largos en una piscina olimpica", usuario);
            Assert.IsFalse(actividad1.Equals(actividad3));

        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            var usuario = CrearUsuarioCorrecto1();
            var actividad1 = CrearActividadCorrecta("AF-001", "Correr", 30, new DateTime(2 / 09 / 2020), "Correr en el gimnasio", usuario);
            var actividad2 = CrearActividadCorrecta("AF-001", "Correr", 30, new DateTime(2 / 09 / 2020), "Correr en el gimnasio", usuario);

            int hash1 = actividad1.GetHashCode();
            int hash2 = actividad2.GetHashCode();
            Assert.AreEqual(hash1, hash2);

            var actividad3 = CrearActividadCorrecta("AF-002", "Nadar", 40, new DateTime(2 / 09 / 2020), "Hacer largos en una piscina olimpica", usuario);
            int hash3 = actividad3.GetHashCode();
            Assert.AreNotEqual(hash1, hash3);
        }

    }

}