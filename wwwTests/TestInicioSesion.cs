
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
            driver.FindElement(By.Id("tbxUsuario")).Click();
            driver.FindElement(By.Id("tbxUsuario")).Clear();
            driver.FindElement(By.Id("tbxUsuario")).SendKeys("balondeoro3@gmail.com");
            driver.FindElement(By.Id("tbxPassword")).Click();
            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnAceptar")).Click();
            driver.FindElement(By.XPath("//form[@id='form1']/table/tbody/tr")).Click();

            Assert.AreEqual("Alexia", driver.FindElement(By.Id("lblUsuario")).Text);

            driver.FindElement(By.Id("btnCerrarSesion")).Click();

            driver.Close();
            driver.Dispose();
        }
        
        
    }
}
