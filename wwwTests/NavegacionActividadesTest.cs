using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace wwwTests;

[TestClass]
[DoNotParallelize]
public class NavegacionActividadesTest
{
    private bool acceptNextAlert = true;
    private IWebDriver driver;

    [TestInitialize]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }



    [TestMethod]
    public void TestNavegacionActividadesDuracionIncorrectaTest()
    {

        driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("norris@gmail.com");
        driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
        
        Assert.AreEqual("Aceptar", driver.FindElement(By.Id("btnAceptar")).GetAttribute("value"));
       
        driver.FindElement(By.Id("btnAceptar")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        Assert.AreEqual("Bienvenid@, Lando!", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);
      
        Assert.AreEqual("Añadir Nueva Actividad", driver.FindElement(By.Id("btnAñadirActividad")).GetAttribute("value"));
       
        driver.FindElement(By.Id("btnAñadirActividad")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        Assert.AreEqual("Añadir Actividad", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);
        
        driver.FindElement(By.Id("txtNombre")).SendKeys("Correr");
        driver.FindElement(By.Id("txtDuracion")).SendKeys("-30");
        driver.FindElement(By.Id("txtFecha")).SendKeys("09/03/2025");
        driver.FindElement(By.Id("txtDescripcion")).SendKeys("Correr durante media hora");

        driver.FindElement(By.Id("btnGuardar")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        var byMsg = By.Id("lblMensaje");
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(d =>
        {
            try
            {
                return d.FindElement(byMsg).Text.Trim()
                       == "Ingrese una duración válida en minutos.";
            }
            catch (StaleElementReferenceException)
            {
                return false; // reintenta hasta que el DOM se estabilice
            }
        });

        Assert.AreEqual("Ingrese una duración válida en minutos.", driver.FindElement(By.Id("lblMensaje")).Text);       
           
        driver.Close();
        driver.Dispose();

}

    [TestMethod]
    public void TestNavegacionActividadesFechaIncorrectaTest()
    {

        driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("norris@gmail.com");
        driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");

        Assert.AreEqual("Aceptar", driver.FindElement(By.Id("btnAceptar")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAceptar")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        Assert.AreEqual("Bienvenid@, Lando!", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        Assert.AreEqual("Añadir Nueva Actividad", driver.FindElement(By.Id("btnAñadirActividad")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAñadirActividad")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        Assert.AreEqual("Añadir Actividad", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        driver.FindElement(By.Id("txtNombre")).SendKeys("Correr");
        driver.FindElement(By.Id("txtDuracion")).SendKeys("30");
        driver.FindElement(By.Id("txtFecha")).SendKeys("32/03/2025");
        driver.FindElement(By.Id("txtDescripcion")).SendKeys("Correr durante media hora");

        driver.FindElement(By.Id("btnGuardar")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        var byMsg = By.Id("lblMensaje");
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(d =>
        {
            try
            {
                return d.FindElement(byMsg).Text.Trim()
                       == "Error: Fecha inválida. Usa el formato día/mes/año (ej.: 19/09/2025).";
            }
            catch (StaleElementReferenceException)
            {
                return false; // reintenta hasta que el DOM se estabilice
            }
        });

        Assert.AreEqual("Error: Fecha inválida. Usa el formato día/mes/año (ej.: 19/09/2025).", driver.FindElement(By.Id("lblMensaje")).Text);

        driver.Close();
        driver.Dispose();


    }

    [TestMethod]
    public void TestNavegacionActividadesCorrectoTest()
    {

        driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("norris@gmail.com");
        driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");

        Assert.AreEqual("Aceptar", driver.FindElement(By.Id("btnAceptar")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAceptar")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        Assert.AreEqual("Bienvenid@, Lando!", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        Assert.AreEqual("Añadir Nueva Actividad", driver.FindElement(By.Id("btnAñadirActividad")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAñadirActividad")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        Assert.AreEqual("Añadir Actividad", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        driver.FindElement(By.Id("txtNombre")).SendKeys("Correr");
        driver.FindElement(By.Id("txtDuracion")).SendKeys("30");
        driver.FindElement(By.Id("txtFecha")).SendKeys("09/03/2025");
        driver.FindElement(By.Id("txtDescripcion")).SendKeys("Correr durante media hora");
        driver.FindElement(By.Id("btnGuardar")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        var byMsg = By.Id("lblMensaje");
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        wait.Until(d =>
        {
            try
            {
                return d.FindElement(byMsg).Text.Trim()
                       == "Actividad guardada correctamente.";
            }
            catch (StaleElementReferenceException)
            {
                return false; // reintenta hasta que el DOM se estabilice
            }
        });


        Assert.AreEqual("Actividad guardada correctamente.", driver.FindElement(By.Id("lblMensaje")).Text);

        driver.FindElement(By.Id("btnVolver")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        driver.FindElement(By.Id("ddlOpcionesUsuario")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        new SelectElement(driver.FindElement(By.Id("ddlOpcionesUsuario"))).SelectByText("Ver Actividades");


        wait.Until(d => d.FindElement(By.Id("GridViewActividades")));

        var filaCorrer = wait.Until(d =>
            d.FindElement(By.XPath("//table[@id='GridViewActividades']//tr[td[normalize-space()='Correr']]"))
        );

        var btnEliminar = filaCorrer.FindElement(By.XPath(".//input[contains(@id,'btnEliminar')]"));
        Assert.AreEqual("Eliminar", btnEliminar.GetAttribute("value"));

        btnEliminar.Click();


        IAlert alert = driver.SwitchTo().Alert();
        string alertText = alert.Text;
        Assert.IsTrue(Regex.IsMatch(alertText, @"^\s*¿Seguro que quieres eliminar esta actividad\?\s*$")); 
        alert.Accept();

        driver.FindElement(By.Id("btnVolver")).Click();
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

        Assert.AreEqual("Tienes 1 actividad(es) registradas.", driver.FindElement(By.Id("lblNumActividades")).Text);

        driver.Close();
        driver.Dispose();


    }

}
