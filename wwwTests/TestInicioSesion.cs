
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace wwwTests
{
    [TestClass]
    public class TestInicioSesion
    {
        [TestMethod]
        public void TestInicioSesionTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Usuario", driver.FindElement(By.Id("lblEmail")).Text);
            Assert.AreEqual("Contrase�a", driver.FindElement(By.Id("lblContrase�a")).Text);
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            Assert.AreEqual("Aceptar", driver.FindElement(By.Id("btnAceptar")).GetAttribute("value"));
            driver.FindElement(By.Id("tbxUsuario")).Clear();
            driver.FindElement(By.Id("tbxUsuario")).SendKeys("usuarioinvalido@gmail.com");
            driver.FindElement(By.Id("tbxPassword")).Click();
            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("hola");
            driver.FindElement(By.Id("btnAceptar")).Click();

            Assert.AreEqual("Usuario y/o contrase�a incorectos", driver.FindElement(By.Id("lblError")).Text);

            driver.FindElement(By.Id("form2")).Click();
            driver.FindElement(By.Id("tbxUsuario")).Clear();
            driver.FindElement(By.Id("tbxUsuario")).SendKeys("balondeoro3@gmail.com");
            driver.FindElement(By.Id("tbxPassword")).Click();
            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnAceptar")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Click();

            Assert.AreEqual("Bienvenid@, Alexia!", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);
            

            Assert.AreEqual("CERRAR SESI�N", driver.FindElement(By.Id("btnCerrarSesion")).GetAttribute("value"));
            driver.FindElement(By.Id("btnCerrarSesion")).Click();
            Assert.AreEqual("Inicio de sesi�n", driver.FindElement(By.XPath("//form[@id='form2']/div[3]/h2")).Text);

            driver.Close();
            driver.Dispose();


        }
        
        
    }
}
