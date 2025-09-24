using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilidad = Practica1.utils.Utilidades;
using Logica.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades.Tests
{
    [TestClass()]
    public class UtilidadesTests
    {
        [TestMethod()]
        public void EncriptarContraseñaTest()
        {
            string contraseñaSinCifrar = "ContraseñaCorrecta1!";
            string contraseñaCifrada = Utilidad.EncriptarContraseña(contraseñaSinCifrar);

            
            Assert.AreNotEqual(contraseñaSinCifrar, contraseñaCifrada);

        }
    }
}