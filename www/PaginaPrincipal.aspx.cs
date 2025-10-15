using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Practica1.ModeladoDatos;

namespace www
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuarioAutenticado"] as Usuario;

            lblUsuario.Text= usuario.Nombre;

            if (usuario.UltimoInicioSesion == DateTime.MinValue)
                lblUltimoInicioSesion.Text = "Primera vez";
            else
                lblUltimoInicioSesion.Text = usuario.UltimoInicioSesion.ToString("dd/MM/yyyy HH:mm");

        }
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Usuario usuario = Session["usuarioAutenticado"] as Usuario;
            CapaDatos datos = Application["Conexión"] as CapaDatos;

            usuario.CambioUltimoInicioSesion();         // ultimo = inicioActual
            datos.ActualizaUsuario(usuario);

            Session.Remove("usuarioAutenticado");
            Session.Abandon();
            Response.Redirect("InicioSesion.aspx", false);
            Context.ApplicationInstance.CompleteRequest();
        }

        protected void btnIdiomaEspañol_Click(object sender, EventArgs e)
        {

        }
    }
}