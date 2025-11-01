
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
    public class TestFormularioRegistro
    {
        [TestMethod]
        public void TestFormularioRegistroContraseñaIncorrectaTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");
            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("OtraContraseñaDistinta1!");
            Assert.AreEqual("Registro", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error:Las contraseñas no coinciden", driver.FindElement(By.Id("lblError")).Text);
            
            new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Close();
            driver.Dispose();


        }

        [TestMethod]
        public void TestFormularioRegistroNombreIncompeltoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);

            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");
            
            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error:Todos los campos son obligatorios", driver.FindElement(By.Id("lblError")).Text);

            new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Close();
            driver.Dispose();


        }



        [TestMethod]
        public void TestFormularioRegistroApellidosIncompeltoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");

            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error:Todos los campos son obligatorios", driver.FindElement(By.Id("lblError")).Text);
            
            new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Close();
            driver.Dispose();

        }


        [TestMethod]
        public void TestFormularioRegistroEmailIncompeltoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");

            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error:Todos los campos son obligatorios", driver.FindElement(By.Id("lblError")).Text);
            
            new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Close();
            driver.Dispose();


        }

        [TestMethod]
        public void TestFormularioRegistroSexoIncompeltoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");

            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error:Todos los campos son obligatorios", driver.FindElement(By.Id("lblError")).Text);
            
            new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Close();
            driver.Dispose();


        }


        [TestMethod]
        public void TestFormularioRegistroPesoIncompeltoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");

            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error:Todos los campos son obligatorios", driver.FindElement(By.Id("lblError")).Text);
            
            new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Close();
            driver.Dispose();


        }

        [TestMethod]
        public void TestFormularioRegistroAlturaIncompeltoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");

            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error:Todos los campos son obligatorios", driver.FindElement(By.Id("lblError")).Text);

            new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Close();
            driver.Dispose();


        }

        [TestMethod]
        public void TestFormularioRegistroEdadIncompeltoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Clear();

            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error:Todos los campos son obligatorios", driver.FindElement(By.Id("lblError")).Text);
            
            new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Close();
            driver.Dispose();


        }

        [TestMethod]
        public void TestFormularioRegistroContraseñaIncompeltoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");

            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            Assert.AreEqual("Error:Todos los campos son obligatorios", driver.FindElement(By.Id("lblError")).Text);

            new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            driver.Close();
            driver.Dispose();


        }


        [TestMethod]
        public void TestFormularioRegistroEmailErroneoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Click();
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Click();
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("correoErroneo");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Click();
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Click();
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Click();
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");
            
            driver.FindElement(By.Id("tbxPassword")).Click();
            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Click();
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error: Email inválido.", driver.FindElement(By.Id("lblError")).Text);


            new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            driver.Close();
            driver.Dispose();


        }


        [TestMethod]
        public void TestFormularioRegistroPesoErroneoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Click();
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Click();
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Click();
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("-7");
            driver.FindElement(By.Id("txtAltura")).Click();
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Click();
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");

            driver.FindElement(By.Id("tbxPassword")).Click();
            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Click();
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error: El peso debe estar en kilogramos.", driver.FindElement(By.Id("lblError")).Text);

            new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            driver.Close();
            driver.Dispose();


        }


        [TestMethod]
        public void TestFormularioRegistroAlturaErroneoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Click();
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Click();
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Click();
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Click();
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("172");
            driver.FindElement(By.Id("txtEdad")).Click();
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");

            driver.FindElement(By.Id("tbxPassword")).Click();
            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Click();
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error: La altura debe estar en metros.", driver.FindElement(By.Id("lblError")).Text);


            new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            driver.Close();
            driver.Dispose();


        }

        [TestMethod]
        public void TestFormularioRegistroEdadaErroneoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Click();
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Click();
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Click();
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Click();
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Click();
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("500");

            driver.FindElement(By.Id("tbxPassword")).Click();
            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Click();
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error: La edad debe estar entre 1 y 120 años.", driver.FindElement(By.Id("lblError")).Text);

            new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            driver.Close();
            driver.Dispose();


        }


        [TestMethod]
        public void TestFormularioRegistroIBANErroneoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Click();
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Click();
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Click();
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Click();
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Click();
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");

            driver.FindElement(By.Id("chkPremium")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("txtIBAN")).Click();
            driver.FindElement(By.Id("txtIBAN")).SendKeys("500");
            driver.FindElement(By.Id("tbxPassword")).Click();
            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Click();
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error:El IBAN debe ser correcto", driver.FindElement(By.Id("lblError")).Text);

            new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            driver.Close();
            driver.Dispose();


        }

        [TestMethod]
        public void TestFormularioRegistroContraseñaErroneoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Click();
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Click();
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lb@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Click();
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Click();
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Click();
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");

            driver.FindElement(By.Id("tbxPassword")).Click();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("contraseñamala");
            driver.FindElement(By.Id("tbxPassword1")).Click();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("contraseñamala");
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("Error: La contraseña no cumple la política (mín. 12, 2 mayús., 2 minús., 1 dígito, 1 especial).", driver.FindElement(By.Id("lblError")).Text);

            new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            driver.Close();
            driver.Dispose();


        }

        [TestMethod]
        public void TestFormularioRegistroCorrectoTest()
        {
            IWebDriver driver;

            driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
            Assert.AreEqual("Registrarse", driver.FindElement(By.Id("btnRegistro")).GetAttribute("value"));
            driver.FindElement(By.Id("btnRegistro")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Assert.AreEqual("REGISTRO", driver.FindElement(By.Id("lblRegistro")).Text);
            driver.FindElement(By.Id("txtNombre")).Click();
            driver.FindElement(By.Id("txtNombre")).Clear();
            driver.FindElement(By.Id("txtNombre")).SendKeys("Lydia");
            driver.FindElement(By.Id("txtApellidos")).Clear();
            driver.FindElement(By.Id("txtApellidos")).SendKeys("Llorente");
            driver.FindElement(By.Id("txtEmail")).Click();
            driver.FindElement(By.Id("txtEmail")).Clear();
            driver.FindElement(By.Id("txtEmail")).SendKeys("lydiabea@gmail.com");
            driver.FindElement(By.Id("ddlSexo")).Click();
            new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("Femenino");
            driver.FindElement(By.Id("txtPeso")).Click();
            driver.FindElement(By.Id("txtPeso")).Clear();
            driver.FindElement(By.Id("txtPeso")).SendKeys("69");
            driver.FindElement(By.Id("txtAltura")).Click();
            driver.FindElement(By.Id("txtAltura")).Clear();
            driver.FindElement(By.Id("txtAltura")).SendKeys("1,72");
            driver.FindElement(By.Id("txtEdad")).Click();
            driver.FindElement(By.Id("txtEdad")).Clear();
            driver.FindElement(By.Id("txtEdad")).SendKeys("21");
            driver.FindElement(By.Id("chkPremium")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.FindElement(By.Id("txtIBAN")).Click();
            driver.FindElement(By.Id("txtIBAN")).Clear();
            driver.FindElement(By.Id("txtIBAN")).SendKeys("ES2200491500010002000345");
            driver.FindElement(By.Id("tbxPassword")).Click();
            driver.FindElement(By.Id("tbxPassword")).Clear();
            driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("tbxPassword1")).Click();
            driver.FindElement(By.Id("tbxPassword1")).Clear();
            driver.FindElement(By.Id("tbxPassword1")).SendKeys("ConMasDe12Caracteres!");
            driver.FindElement(By.Id("btnRegistro")).Click();
            driver.Navigate().GoToUrl("https://localhost:44313/PaginaPrincipal.aspx");
            driver.FindElement(By.XPath("//form[@id='form1']/div[4]")).Click();
            Assert.AreEqual("Bienvenid@, Lydia!", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

            new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            driver.Close();
            driver.Dispose();


        }




    }
}

