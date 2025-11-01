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
public class NavegacionActividadesTest
{
    private bool acceptNextAlert = true;


    [TestMethod]
    public void TestNavegacionActividadesDuracionIncorrectaTest()
    {
        IWebDriver driver;

        driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
        driver.FindElement(By.Id("tbxUsuario")).Click();
        driver.FindElement(By.Id("tbxUsuario")).Clear();
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("norris@gmail.com");
        driver.FindElement(By.Id("tbxPassword")).Click();
        driver.FindElement(By.Id("tbxPassword")).Clear();
        driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");
        
        Assert.AreEqual("Aceptar", driver.FindElement(By.Id("btnAceptar")).GetAttribute("value"));
       
        driver.FindElement(By.Id("btnAceptar")).Click();
        
        Assert.AreEqual("Bienvenid@, Lando!", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);
      
        Assert.AreEqual("Añadir Nueva Actividad", driver.FindElement(By.Id("btnAñadirActividad")).GetAttribute("value"));
       
        driver.FindElement(By.Id("btnAñadirActividad")).Click();
        driver.Navigate().GoToUrl("https://localhost:44313/A%c3%b1adirActividad.aspx");
       
        Assert.AreEqual("Añadir Actividad", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);
        
        driver.FindElement(By.Id("txtNombre")).Click();
        driver.FindElement(By.Id("txtNombre")).Clear();
        driver.FindElement(By.Id("txtNombre")).SendKeys("Correr");
        driver.FindElement(By.Id("txtDuracion")).Click();
        
        driver.FindElement(By.Id("txtDuracion")).Clear();
        driver.FindElement(By.Id("txtDuracion")).SendKeys("-30");
        driver.FindElement(By.Id("txtFecha")).Click();
        driver.FindElement(By.Id("txtFecha")).Clear();
        driver.FindElement(By.Id("txtFecha")).SendKeys("09/03/2025");
        driver.FindElement(By.Id("txtDescripcion")).Click();
        driver.FindElement(By.Id("txtDescripcion")).Clear();
        driver.FindElement(By.Id("txtDescripcion")).SendKeys("Correr durante media hora");

        driver.FindElement(By.Id("btnGuardar")).Click();

        Assert.AreEqual("Ingrese una duración válida en minutos.", driver.FindElement(By.Id("lblMensaje")).Text);       
           
        
        driver.Close();
        driver.Dispose();
        

}

    [TestMethod]
    public void TestNavegacionActividadesFechaIncorrectaTest()
    {
        IWebDriver driver;

        driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
        driver.FindElement(By.Id("tbxUsuario")).Click();
        driver.FindElement(By.Id("tbxUsuario")).Clear();
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("norris@gmail.com");
        driver.FindElement(By.Id("tbxPassword")).Click();
        driver.FindElement(By.Id("tbxPassword")).Clear();
        driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");

        Assert.AreEqual("Aceptar", driver.FindElement(By.Id("btnAceptar")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAceptar")).Click();

        Assert.AreEqual("Bienvenid@, Lando!", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        Assert.AreEqual("Añadir Nueva Actividad", driver.FindElement(By.Id("btnAñadirActividad")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAñadirActividad")).Click();
        driver.Navigate().GoToUrl("https://localhost:44313/A%c3%b1adirActividad.aspx");

        Assert.AreEqual("Añadir Actividad", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        driver.FindElement(By.Id("txtNombre")).Click();
        driver.FindElement(By.Id("txtNombre")).Clear();
        driver.FindElement(By.Id("txtNombre")).SendKeys("Correr");
        driver.FindElement(By.Id("txtDuracion")).Click();

        driver.FindElement(By.Id("txtDuracion")).Clear();
        driver.FindElement(By.Id("txtDuracion")).SendKeys("30");
        driver.FindElement(By.Id("txtFecha")).Click();
        driver.FindElement(By.Id("txtFecha")).Clear();
        driver.FindElement(By.Id("txtFecha")).SendKeys("32/03/2025");
        driver.FindElement(By.Id("txtDescripcion")).Click();
        driver.FindElement(By.Id("txtDescripcion")).Clear();
        driver.FindElement(By.Id("txtDescripcion")).SendKeys("Correr durante media hora");

        driver.FindElement(By.Id("btnGuardar")).Click();

        Assert.AreEqual("Error: Fecha inválida. Usa el formato día/mes/año (ej.: 19/09/2025).", driver.FindElement(By.Id("lblMensaje")).Text);


        driver.Close();
        driver.Dispose();


    }

    [TestMethod]
    public void TestNavegacionActividadesCorrectoTest()
    {
        IWebDriver driver;

        driver = new ChromeDriver();

        driver.Navigate().GoToUrl("https://localhost:44313/InicioSesion.aspx");
        driver.FindElement(By.Id("tbxUsuario")).Click();
        driver.FindElement(By.Id("tbxUsuario")).Clear();
        driver.FindElement(By.Id("tbxUsuario")).SendKeys("norris@gmail.com");
        driver.FindElement(By.Id("tbxPassword")).Click();
        driver.FindElement(By.Id("tbxPassword")).Clear();
        driver.FindElement(By.Id("tbxPassword")).SendKeys("ConMasDe12Caracteres!");

        Assert.AreEqual("Aceptar", driver.FindElement(By.Id("btnAceptar")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAceptar")).Click();

        Assert.AreEqual("Bienvenid@, Lando!", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        Assert.AreEqual("Añadir Nueva Actividad", driver.FindElement(By.Id("btnAñadirActividad")).GetAttribute("value"));

        driver.FindElement(By.Id("btnAñadirActividad")).Click();
        driver.Navigate().GoToUrl("https://localhost:44313/A%c3%b1adirActividad.aspx");

        Assert.AreEqual("Añadir Actividad", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/h2")).Text);

        driver.FindElement(By.Id("txtNombre")).Click();
        driver.FindElement(By.Id("txtNombre")).Clear();
        driver.FindElement(By.Id("txtNombre")).SendKeys("Correr");
        driver.FindElement(By.Id("txtDuracion")).Click();

        driver.FindElement(By.Id("txtDuracion")).Clear();
        driver.FindElement(By.Id("txtDuracion")).SendKeys("30");
        driver.FindElement(By.Id("txtFecha")).Click();
        driver.FindElement(By.Id("txtFecha")).Clear();
        driver.FindElement(By.Id("txtFecha")).SendKeys("09/03/2025");
        driver.FindElement(By.Id("txtDescripcion")).Click();
        driver.FindElement(By.Id("txtDescripcion")).Clear();
        driver.FindElement(By.Id("txtDescripcion")).SendKeys("Correr durante media hora");
        driver.FindElement(By.Id("btnGuardar")).Click();

        Assert.AreEqual("Actividad guardada correctamente.", driver.FindElement(By.Id("lblMensaje")).Text);

        driver.FindElement(By.Id("btnVolver")).Click();
        driver.Navigate().GoToUrl("https://localhost:44313/PaginaPrincipal.aspx");
        driver.FindElement(By.Id("ddlOpcionesUsuario")).Click();
        new SelectElement(driver.FindElement(By.Id("ddlOpcionesUsuario"))).SelectByText("Ver Actividades");
        driver.Navigate().GoToUrl("https://localhost:44313/VerActividades.aspx");

        Assert.AreEqual("Mis Actividades", driver.FindElement(By.XPath("//form[@id='form1']/div[3]/div[2]")).Text);
        Assert.AreEqual("Correr", driver.FindElement(By.XPath("//table[@id='GridViewActividades']/tbody/tr[3]/td")).Text);

        Assert.AreEqual("Eliminar", driver.FindElement(By.Id("GridViewActividades_btnEliminar_1")).GetAttribute("value"));
        driver.FindElement(By.Id("GridViewActividades_btnEliminar_1")).Click();

        IAlert alert = driver.SwitchTo().Alert();
        string alertText = alert.Text;
        Assert.IsTrue(Regex.IsMatch(alertText, @"^\s*¿Seguro que quieres eliminar esta actividad\?\s*$")); 
        alert.Accept();

        driver.FindElement(By.Id("btnVolver")).Click();
        driver.Navigate().GoToUrl("https://localhost:44313/PaginaPrincipal.aspx");

        Assert.AreEqual("Tienes 1 actividad(es) registradas.", driver.FindElement(By.Id("lblNumActividades")).Text);

        driver.Close();
        driver.Dispose();


    }

}
