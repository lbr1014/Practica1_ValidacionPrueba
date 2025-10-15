using Datos;
using Practica1.ModeladoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        CapaDatos datos;
        Usuario usuarioAutenticado;
        protected void Page_Load(object sender, EventArgs e)
        {
            datos = (CapaDatos)Application["Conexión"];
            if (datos == null)
            {
                datos = new CapaDatos();
                Application["Conexión"] = datos;
            }
            usuarioAutenticado = null;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            usuarioAutenticado = datos.LeeUsuario(tbxUsuario.Text);
            if (usuarioAutenticado != null && usuarioAutenticado.ComprobarContraseña(tbxPassword.Text))
            {

                usuarioAutenticado.InicioSesionActual = DateTime.Now;

                datos.ActualizaUsuario(usuarioAutenticado);

                Session["usuarioAutenticado"] = usuarioAutenticado;
                lblError.Text = string.Empty;
                Server.Transfer("PaginaPrincipal.aspx", true);
            }
            else
            {
                lblError.Text = "Usuario y/o contraseña incorectos";
                lblError.Visible = true;
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Server.Transfer("Registro.aspx", true);
        }
    }
}