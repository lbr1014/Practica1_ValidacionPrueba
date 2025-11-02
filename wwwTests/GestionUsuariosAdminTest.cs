using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace wwwTests;

[TestClass]
[DoNotParallelize]
public class GestionUsuariosAdminTest
{
    private bool acceptNextAlert = true;
    private IWebDriver driver;

    [TestInitialize]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.Manage().Window.Maximize();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

    }

    [TestMethod]
    public void TestGestionUsuariosAdminIncompletoTest()
    {

        driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
        driver.FindElement(By.Id("tbxUsuario")).Click();
        driver.FindElement(By.Id("tbxUsuario")).Clear();
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("lbbl@gmail.com");
        driver.FindElement(By.Id("tbxPassword")).Click();
        driver.FindElement(By.Id("tbxPassword")).Clear();
        driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
        
        Assert.AreEqual("Aceptar", driver.FindElement(By.Id("btnAceptar")).GetAttribute("value"));
       
        driver.FindElement(By.Id("btnAceptar")).Click();
       
        Assert.AreEqual("Bienvenid@, Admin!", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);
        
        Assert.AreEqual("Añadir Nuevo Usuario", driver.FindElement(By.Id("btnAñadirUsuario")).GetAttribute("value"));
      
        driver.FindElement(By.Id("btnAñadirUsuario")).Click();
        driver.Navigate().GoToUrl("https://localhost:44313/A%c3%b1adirUsuario.aspx");
        
        Assert.AreEqual("Añadir Usuario", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);
       
        driver.FindElement(By.Id("txtId")).Click();
        driver.FindElement(By.Id("txtId")).Clear();
        driver.FindElement(By.Id("txtId")).SendKeys("a-039");
        driver.FindElement(By.Id("txtNombre")).Click();
        driver.FindElement(By.Id("txtNombre")).Clear();
        driver.FindElement(By.Id("txtNombre")).SendKeys("Paula");
        driver.FindElement(By.Id("txtApellidos")).Click();
        driver.FindElement(By.Id("txtApellidos")).Clear();
        driver.FindElement(By.Id("txtApellidos")).SendKeys("Gonzalez");
        driver.FindElement(By.Id("ddlEstado")).Click();
        new SelectElement(driver.FindElement(By.Id("ddlEstado"))).SelectByText("ACTIVO");
        driver.FindElement(By.Id("ddlTipoUsuario")).Click();
        new SelectElement(driver.FindElement(By.Id("ddlTipoUsuario"))).SelectByText("NORMAL");
        driver.FindElement(By.Id("ddlSexo")).Click();
        new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("MUJER");
        driver.FindElement(By.Id("txtAltura")).Click();
        driver.FindElement(By.Id("txtAltura")).Clear();
        driver.FindElement(By.Id("txtAltura")).SendKeys("1,7");
        driver.FindElement(By.Id("txtPeso")).Click();
        driver.FindElement(By.Id("txtPeso")).Clear();
        driver.FindElement(By.Id("txtPeso")).SendKeys("68");
        driver.FindElement(By.Id("txtEdad")).Click();
        driver.FindElement(By.Id("txtEdad")).Clear();
        driver.FindElement(By.Id("txtEdad")).SendKeys("21");
        driver.FindElement(By.Id("txtContraseña")).Click();
        driver.FindElement(By.Id("txtContraseña")).Clear();
        driver.FindElement(By.Id("txtContraseña")).SendKeys("ConMasDe12Caracteres!");
        driver.FindElement(By.Id("btnGuardar")).Click();
        
        Assert.AreEqual("Error:Todos los campos son obligatorios", driver.FindElement(By.Id("lblMensaje")).Text);
        
        driver.Close();
        driver.Dispose();
    }

    [TestMethod]
    public void TestGestionUsuariosAdminErroneoTest()
    {

        driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
        driver.FindElement(By.Id("tbxUsuario")).Click();
        driver.FindElement(By.Id("tbxUsuario")).Clear();
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("lbbl@gmail.com");
        driver.FindElement(By.Id("tbxPassword")).Click();
        driver.FindElement(By.Id("tbxPassword")).Clear();
        driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");

        Assert.AreEqual("Aceptar", driver.FindElement(By.Id("btnAceptar")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAceptar")).Click();

        Assert.AreEqual("Bienvenid@, Admin!", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        Assert.AreEqual("Añadir Nuevo Usuario", driver.FindElement(By.Id("btnAñadirUsuario")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAñadirUsuario")).Click();
        driver.Navigate().GoToUrl("https://localhost:44313/A%c3%b1adirUsuario.aspx");

        Assert.AreEqual("Añadir Usuario", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        driver.FindElement(By.Id("txtId")).Click();
        driver.FindElement(By.Id("txtId")).Clear();
        driver.FindElement(By.Id("txtId")).SendKeys("a-039");
        driver.FindElement(By.Id("txtNombre")).Click();
        driver.FindElement(By.Id("txtNombre")).Clear();
        driver.FindElement(By.Id("txtNombre")).SendKeys("Paula");
        driver.FindElement(By.Id("txtApellidos")).Click();
        driver.FindElement(By.Id("txtApellidos")).Clear();
        driver.FindElement(By.Id("txtApellidos")).SendKeys("Gonzalez");
        driver.FindElement(By.Id("txtEmail")).Click();
        driver.FindElement(By.Id("txtEmail")).Clear();
        driver.FindElement(By.Id("txtEmail")).SendKeys("emailIncorrecto");
        driver.FindElement(By.Id("ddlEstado")).Click();
        new SelectElement(driver.FindElement(By.Id("ddlEstado"))).SelectByText("ACTIVO");
        driver.FindElement(By.Id("ddlTipoUsuario")).Click();
        new SelectElement(driver.FindElement(By.Id("ddlTipoUsuario"))).SelectByText("NORMAL");
        driver.FindElement(By.Id("ddlSexo")).Click();
        new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("MUJER");
        driver.FindElement(By.Id("txtAltura")).Click();
        driver.FindElement(By.Id("txtAltura")).Clear();
        driver.FindElement(By.Id("txtAltura")).SendKeys("1,7");
        driver.FindElement(By.Id("txtPeso")).Click();
        driver.FindElement(By.Id("txtPeso")).Clear();
        driver.FindElement(By.Id("txtPeso")).SendKeys("68");
        driver.FindElement(By.Id("txtEdad")).Click();
        driver.FindElement(By.Id("txtEdad")).Clear();
        driver.FindElement(By.Id("txtEdad")).SendKeys("21");

        driver.FindElement(By.Id("txtContraseña")).Click();
        driver.FindElement(By.Id("txtContraseña")).Clear();
        driver.FindElement(By.Id("txtContraseña")).SendKeys("ConMasDe12Caracteres!");
        driver.FindElement(By.Id("btnGuardar")).Click();

        Assert.AreEqual("Error: Email inválido.", driver.FindElement(By.Id("lblMensaje")).Text);

        driver.Close();
        driver.Dispose();
    }

    [TestMethod]
    public void TestGestionUsuariosAdminCorrectoTest()
    {

        driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
        driver.FindElement(By.Id("tbxUsuario")).Click();
        driver.FindElement(By.Id("tbxUsuario")).Clear();
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("lbbl@gmail.com");
        driver.FindElement(By.Id("tbxPassword")).Click();
        driver.FindElement(By.Id("tbxPassword")).Clear();
        driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");

        Assert.AreEqual("Aceptar", driver.FindElement(By.Id("btnAceptar")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAceptar")).Click();

        Assert.AreEqual("Bienvenid@, Admin!", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        Assert.AreEqual("Añadir Nuevo Usuario", driver.FindElement(By.Id("btnAñadirUsuario")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAñadirUsuario")).Click();
        driver.Navigate().GoToUrl("https://localhost:44313/A%c3%b1adirUsuario.aspx");


        Assert.AreEqual("Añadir Usuario", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        driver.FindElement(By.Id("txtId")).Click();
        driver.FindElement(By.Id("txtId")).Clear();
        driver.FindElement(By.Id("txtId")).SendKeys("a-039");
        driver.FindElement(By.Id("txtNombre")).Click();
        driver.FindElement(By.Id("txtNombre")).Clear();
        driver.FindElement(By.Id("txtNombre")).SendKeys("Paula");
        driver.FindElement(By.Id("txtApellidos")).Click();
        driver.FindElement(By.Id("txtApellidos")).Clear();
        driver.FindElement(By.Id("txtApellidos")).SendKeys("Gonzalez");
        driver.FindElement(By.Id("txtEmail")).Clear();
        driver.FindElement(By.Id("txtEmail")).SendKeys("paula@gmail.com");
        driver.FindElement(By.Id("ddlEstado")).Click();
        new SelectElement(driver.FindElement(By.Id("ddlEstado"))).SelectByText("ACTIVO");
        driver.FindElement(By.Id("ddlTipoUsuario")).Click();
        new SelectElement(driver.FindElement(By.Id("ddlTipoUsuario"))).SelectByText("NORMAL");
        driver.FindElement(By.Id("ddlSexo")).Click();
        new SelectElement(driver.FindElement(By.Id("ddlSexo"))).SelectByText("MUJER");
        driver.FindElement(By.Id("txtAltura")).Click();
        driver.FindElement(By.Id("txtAltura")).Clear();
        driver.FindElement(By.Id("txtAltura")).SendKeys("1,7");
        driver.FindElement(By.Id("txtPeso")).Click();
        driver.FindElement(By.Id("txtPeso")).Clear();
        driver.FindElement(By.Id("txtPeso")).SendKeys("68");
        driver.FindElement(By.Id("txtEdad")).Click();
        driver.FindElement(By.Id("txtEdad")).Clear();
        driver.FindElement(By.Id("txtEdad")).SendKeys("21");

        driver.FindElement(By.Id("txtContraseña")).Click();
        driver.FindElement(By.Id("txtContraseña")).Clear();
        driver.FindElement(By.Id("txtContraseña")).SendKeys("ConMasDe12Caracteres!");
        driver.FindElement(By.Id("btnGuardar")).Click();

        Assert.AreEqual("Usuario registrado correctamente", driver.FindElement(By.Id("lblMensaje")).Text);

        driver.FindElement(By.Id("btnVolver")).Click();
        driver.Navigate().GoToUrl("https://localhost:44313/PaginaPrincipal.aspx");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        driver.FindElement(By.Id("ddlOpcionesUsuario")).Click();
        new SelectElement(driver.FindElement(By.Id("ddlOpcionesUsuario"))).SelectByText("Ver Usuarios");
        driver.Navigate().GoToUrl("https://localhost:44313/VerUsuarios.aspx");

        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(d => d.FindElement(By.Id("GridViewUsuarios")));

        var filaPaula = wait.Until(d =>
            d.FindElement(By.XPath("//table[@id='GridViewUsuarios']//tr[td[normalize-space()='Paula'] and td[normalize-space()='Gonzalez']]"))
        );

        var btnEliminar = filaPaula.FindElement(By.XPath(".//input[contains(@id,'btnEliminarUsuario')]"));
        Assert.AreEqual("Eliminar", btnEliminar.GetAttribute("value"));

        btnEliminar.Click();


        IAlert alert = driver.SwitchTo().Alert();
        string alertText = alert.Text;
        Assert.IsTrue(Regex.IsMatch(alertText, @"^\s*¿Seguro que deseas eliminar este usuario\?\s*$"));
        alert.Accept();


        driver.FindElement(By.Id("btnVolver")).Click();
        driver.Navigate().GoToUrl("https://localhost:44313/PaginaPrincipal.aspx");


        driver.Close();
        driver.Dispose();
    }
}
