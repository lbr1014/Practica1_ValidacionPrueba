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
            if (!IsPostBack)
            {
                Usuario usuario = Session["usuarioAutenticado"] as Usuario;

                if (usuario == null)
                {
                    Response.Redirect("InicioSesion.aspx");
                    return;
                }

                // Mostrar nombre, tipo y último inicio de sesión
                lblUsuario.Text = usuario.Nombre;
                lblTipoUsuario.Text = usuario.ObtenerTipoUsuario(usuario);
                lblUltimoInicioSesion.Text = usuario.UltimoInicioSesion == DateTime.MinValue
                    ? "Primer inicio de sesión"
                    : usuario.UltimoInicioSesion.ToString("g");

                // Llenar el DropDownList de opciones según el tipo de usuario
                ddlOpcionesUsuario.Items.Clear();
                ddlOpcionesUsuario.Items.Add(new ListItem("Selecciona una opción", ""));

                // Opciones básicas para todos
                ddlOpcionesUsuario.Items.Add(new ListItem("Editar perfil", "EditarPerfil"));
                ddlOpcionesUsuario.Items.Add(new ListItem("Añadir actividad", "AñadirActividad"));
                ddlOpcionesUsuario.Items.Add(new ListItem("Ver actividades", "VerActividades"));

                // Opciones para ADMIN
                if (usuario.ObtenerTipoUsuario(usuario) == "ADMIN")
                {
                    ddlOpcionesUsuario.Items.Add(new ListItem("Ver usuarios", "VerUsuarios"));
                    ddlOpcionesUsuario.Items.Add(new ListItem("Comprobar y cambiar estados", "GestionarEstados"));
                }
            }
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

        protected void ddlOpcionesUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = ddlOpcionesUsuario.SelectedValue;

            if (string.IsNullOrEmpty(opcion))
                return;

            switch (opcion)
            {
                case "EditarPerfil":
                    Response.Redirect("EditarPerfil.aspx");
                    break;
                case "AñadirActividad":
                    Response.Redirect("AñadirActividad.aspx");
                    break;
                case "VerActividades":
                    Response.Redirect("VerActividades.aspx");
                    break;
                case "VerUsuarios":
                    Response.Redirect("VerUsuarios.aspx");
                    break;
                case "GestionarEstados":
                    Response.Redirect("GestionarEstados.aspx");
                    break;
            }
        }
    }
}