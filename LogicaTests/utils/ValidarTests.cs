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
        public static IEnumerable<object[]> LeerNifCsv()
        {
            // Busca el archivo en la carpeta de salida (bin)
            string path = Path.Combine(AppContext.BaseDirectory, "utils", "NIF.csv");
            if (!File.Exists(path))
                Assert.Inconclusive($"No se encontró el archivo de datos: {path}");

            foreach (var line in File.ReadLines(path))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;
                if (line.StartsWith("#")) continue; // comentarios

                var parts = line.Split(';');
                if (parts.Length < 2) continue;

                // Permitir escribir "null" en el CSV para probar el caso null
                var raw = parts[0].Trim();
                string nif = raw.Equals("null", StringComparison.OrdinalIgnoreCase) ? null : raw;

                bool esperado = parts[1].Trim() == "1";
                yield return new object[] { nif, esperado };
            }
        }

        [TestMethod]
        [DynamicData(nameof(LeerNifCsv))]
        public void NIFTest(string nif, bool esperado)
        {
            bool ok = Validar.NIF(nif);
            Assert.AreEqual(esperado, ok, $"NIF probado: '{nif}'");
        }


        public static IEnumerable<object[]> ObtenerIBANDesdeJson()
        {
            string filePath = Path.Combine(AppContext.BaseDirectory, "utils", "IBAN.json");
            if (!File.Exists(filePath))
                Assert.Inconclusive($"No se encontró el archivo de datos: {filePath}");

            string json = File.ReadAllText(filePath);
            JsonArray data = JsonNode.Parse(json).AsArray();

            foreach (var item in data)
            {
                string email = item?["IBAN"]?.ToString() ?? "";
                int correcto = item?["correcto"]?.GetValue<int?>() ?? 0;

                yield return new object[] { email, correcto == 1 };
            }
        }

        [TestMethod]
        [DynamicData(nameof(ObtenerIBANDesdeJson))]
        public void IBANTest(string iban, bool esperado)
        {
            // Llama a tu método real
            bool ok = Validar.IBAN(iban); 

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

        public static IEnumerable<object[]> ObtenerEmailDesdeJson()
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
        [DynamicData(nameof(ObtenerEmailDesdeJson))]
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
        [DataRow("31/01/2025", true)]
        [DataRow("1/1/2025", true)]
        [DataRow("31-12-1999", true)]
        [DataRow("29/02/2024", true)]
        [DataRow(null, false)]
        [DataRow("", false)]
        [DataRow("   ", false)]
        [DataRow("31/13/2025", false)]
        [DataRow("32/01/2025", false)]
        [DataRow("29/02/2023", false)]
        [DataRow("31/01/25", false)]
        [DataRow("31/01/2025 10:00", false)]
        public void FormatoFechaValidoTest(string fecha, bool esperado)
        {
            var formatos = new[]
            {
                "dd/MM/yyyy",
                "d/M/yyyy",
                "dd-MM-yyyy"
            };
            var ok = Validar.FormatoFechaValido(fecha, formatos);
            Assert.AreEqual(esperado, ok);

        }
    }
}