using Logica.utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Logica.utils.Tests
{
    [TestClass()]
    public class ValidarTests
    {
        [TestMethod()]
        public void NIFTest()
        {
            Assert.IsTrue(Validar.NIF("71567703Y"));

            Assert.IsFalse(Validar.NIF(" "));
            Assert.IsFalse(Validar.NIF("22L"));
            Assert.IsFalse(Validar.NIF("71567703"));
            Assert.IsFalse(Validar.NIF("KKKKKKKK"));
            Assert.IsFalse(Validar.NIF("ABCDEFGHX"));


        }

        public static IEnumerable<object[]> LeerIbanCsv()
        {
            var ruta = Path.Combine(AppContext.BaseDirectory, "utils", "IBAN.csv");

            if (!File.Exists(ruta))
                Assert.Inconclusive($"No se encontró el archivo de datos: {ruta}");

            foreach (var linea in File.ReadLines(ruta))
            {
                if (string.IsNullOrWhiteSpace(linea)) continue;
                if (linea.StartsWith("#")) continue; 

                var partes = linea.Split(';');
                if (partes.Length < 2) continue;

                var raw = partes[0];
                string iban =
                    raw.Equals("null", StringComparison.OrdinalIgnoreCase) ? null :
                    raw.Replace("\\t", "\t").Replace("\\n", "\n"); // desescapa \t y \n

                var esperado = partes[1].Trim() == "1";

                yield return new object[] { iban, esperado };
            }
        }

        [TestMethod]
        [DynamicData(nameof(LeerIbanCsv))]
        public void IBANTest(string iban, bool esperado)
        {
            // Llama a tu método real
            bool ok = Validar.IBAN(iban); // <-- reemplaza por la clase que contiene IBAN

            Assert.AreEqual(esperado, ok, $"IBAN probado: {iban}");
        }

        [TestMethod()]
        public void ContrasenaTest()
        {
            Assert.IsTrue(Validar.Contrasena("ContraseñaCorrecta1!"));

            Assert.IsFalse(Validar.Contrasena(" "));
            Assert.IsFalse(Validar.Contrasena("aaAA1!"));
            Assert.IsFalse(Validar.Contrasena("ContrasenaSinNumeros!"));
            Assert.IsFalse(Validar.Contrasena("Contrasenasinmayusculas1!"));
            Assert.IsFalse(Validar.Contrasena("CONTRASEÑASINMINUSCULAS1!"));
            Assert.IsFalse(Validar.Contrasena("ContrasenaSinCaracteresEspeciales1"));

        }

        public static IEnumerable<object[]> ObtenerDatosDesdeJson()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "utils", "email.json");
            if (!File.Exists(filePath))
                Assert.Inconclusive($"No se encontró el archivo de datos: {filePath}");

            string json = File.ReadAllText(filePath);
            JsonArray data = JsonNode.Parse(json).AsArray();

            foreach (var item in data)
            {
                string email = item?["email"]?.ToString() ?? "";
                int correcto = item?["correcto"]?.GetValue<int?>() ?? 0;

                yield return new object[] { email, correcto == 1 };
            }
        }

        [TestMethod]
        [DynamicData(nameof(ObtenerDatosDesdeJson))]
        public void EmailTest(string email, bool esperado)
        {
            bool ok = Validar.Email(email);
            Assert.AreEqual(esperado, ok, $"Email probado: '{email}'");
        }


        [TestMethod()]
        public void UltimoInicioSesionTest()
        {
            DateTime inicioSesion = new DateTime(2025, 3, 14);
            Assert.IsTrue(Validar.ComprobarFecha(inicioSesion));

            DateTime inicioSesionIncorrectoAño = new DateTime(2026, 3, 14);
            Assert.IsFalse(Validar.ComprobarFecha(inicioSesionIncorrectoAño));

            DateTime inicioSesionIncorrectoMes = new DateTime(2025, 12, 14);
            Assert.IsFalse(Validar.ComprobarFecha(inicioSesionIncorrectoMes));

        }

        [TestMethod()]
        public void TipoUsuarioTest()
        {

            Assert.IsTrue(Validar.TipoUsuario("ADMIN"));
            Assert.IsTrue(Validar.TipoUsuario("NORMAL"));
            Assert.IsTrue(Validar.TipoUsuario("PREMIUM"));

            Assert.IsFalse(Validar.TipoUsuario(null));
            Assert.IsFalse(Validar.TipoUsuario(""));
            Assert.IsFalse(Validar.TipoUsuario(" "));
            Assert.IsFalse(Validar.TipoUsuario("admin"));
            Assert.IsFalse(Validar.TipoUsuario("Premium"));
            Assert.IsFalse(Validar.TipoUsuario("CUALQUIERA"));
            Assert.IsFalse(Validar.TipoUsuario("PREM IUM"));

        }

        [TestMethod()]
        public void EstadoTest()
        {
            Assert.IsTrue(Validar.Estado(0));
            Assert.IsTrue(Validar.Estado(1));
            Assert.IsTrue(Validar.Estado(2));

            Assert.IsFalse(Validar.Estado(-1));
            Assert.IsFalse(Validar.Estado(3));
            Assert.IsFalse(Validar.Estado(99));
        }

        [TestMethod()]
        public void PesoTest()
        {
            Assert.IsTrue(Validar.Peso(1f));
            Assert.IsTrue(Validar.Peso(75.5f));
            Assert.IsTrue(Validar.Peso(500f));

            Assert.IsFalse(Validar.Peso(0f));
            Assert.IsFalse(Validar.Peso(-0.1f));
            Assert.IsFalse(Validar.Peso(500.01f));
            Assert.IsFalse(Validar.Peso(float.NaN));
            Assert.IsFalse(Validar.Peso(float.NegativeInfinity));
            Assert.IsFalse(Validar.Peso(float.PositiveInfinity));
        }

        [TestMethod()]
        public void AlturaTest()
        {
            Assert.IsTrue(Validar.Altura(1.8f));
            Assert.IsTrue(Validar.Altura(3.0f));

            Assert.IsFalse(Validar.Altura(0f));
            Assert.IsFalse(Validar.Altura(-1f));
            Assert.IsFalse(Validar.Altura(3.01f));
            Assert.IsFalse(Validar.Altura(float.NaN));
            Assert.IsFalse(Validar.Altura(float.NegativeInfinity));
            Assert.IsFalse(Validar.Altura(float.PositiveInfinity));
        }

        [TestMethod()]
        public void EdadTest()
        {
            // Válidos
            Assert.IsTrue(Validar.Edad(1));
            Assert.IsTrue(Validar.Edad(23));
            Assert.IsTrue(Validar.Edad(120));

            // Inválidos
            Assert.IsFalse(Validar.Edad(0));
            Assert.IsFalse(Validar.Edad(-1));
            Assert.IsFalse(Validar.Edad(121));
        }

        [TestMethod()]
        public void FormatoFechaValidoTest()
        {
            var formatos = new[]
            {
                "dd/MM/yyyy",
                "d/M/yyyy",
                "dd-MM-yyyy"
            };
            Assert.IsTrue(Validar.FormatoFechaValido("31/01/2025", formatos));
            Assert.IsTrue(Validar.FormatoFechaValido("1/1/2025", formatos));       
            Assert.IsTrue(Validar.FormatoFechaValido("31-12-1999", formatos));
            Assert.IsTrue(Validar.FormatoFechaValido("29/02/2024", formatos));

            Assert.IsFalse(Validar.FormatoFechaValido(null, formatos));             
            Assert.IsFalse(Validar.FormatoFechaValido("", formatos));               
            Assert.IsFalse(Validar.FormatoFechaValido("   ", formatos));

            Assert.IsFalse(Validar.FormatoFechaValido("31/13/2025", formatos));     
            Assert.IsFalse(Validar.FormatoFechaValido("32/01/2025", formatos));     
            Assert.IsFalse(Validar.FormatoFechaValido("29/02/2023", formatos));     
            Assert.IsFalse(Validar.FormatoFechaValido("31/01/25", formatos));
            Assert.IsFalse(Validar.FormatoFechaValido("31/01/2025 10:00", formatos));

        }
    }
}