using Datos;
using Logica.ModeladoDatos;
using Practica1.ModeladoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www
{
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        private Usuario usuario;
        private static CapaDatos capaDatos = new CapaDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = Session["usuarioAutenticado"] as Usuario;

            if (usuario == null)
            {
                Response.Redirect("InicioSesion.aspx");
                return;
            }

            if (usuario.ObtenerTipoUsuario(usuario) == "ADMIN")
            {
                lblUsuarioCentral.Text = "Admin";
            }
            else
            {
                lblUsuarioCentral.Text = usuario.Nombre;
            }
            
            if (!IsPostBack)
            {
                lblUsuario.Text = usuario.Nombre;
                lblTipoUsuario.Text = usuario.ObtenerTipoUsuario(usuario);
                lblUltimoInicioSesion.Text = usuario.UltimoInicioSesion == DateTime.MinValue
                    ? "Primer inicio de sesión"
                    : usuario.UltimoInicioSesion.ToString("g");

                LlenarGridActividades();
                ConfigurarOpcionesUsuario();
                // Mostrar u ocultar panel de consejos
                pnlConsejos.Visible = usuario.ObtenerTipoUsuario(usuario) != "ADMIN";

                // Cambiar título y texto de actividades según el tipo de usuario
                if (usuario.ObtenerTipoUsuario(usuario) == "ADMIN")
                {
                    lblTituloActividades.InnerText = "Actividades";
                    lblNumActividades.Text = $"Hay {capaDatos.ObtenerActividades().Count} actividad(es) registradas en total.";
                    btnAñadirUsuario.Visible = true;
                }
                else
                {
                    lblTituloActividades.InnerText = "Mis Actividades";
                    lblNumActividades.Text = $"Tienes {capaDatos.ObtenerActividadesUsuario(usuario.IdUsuario).Count} actividad(es) registradas.";
                    btnAñadirUsuario.Visible = false;
                }
            }
        }



        private void LlenarGridActividades()
        {
            List<ActividadesFisicas> actividades;

            if (usuario.ObtenerTipoUsuario(usuario) == "ADMIN")
            {
                // Mostrar todas las actividades
                actividades = capaDatos.ObtenerActividades();

                // Ejemplo: puedes agregar columnas extra si quieres
                GridViewUltimas.Columns.Clear();
                GridViewUltimas.Columns.Add(new BoundField { DataField = "NombreActividad", HeaderText = "Actividad" });
                GridViewUltimas.Columns.Add(new BoundField { DataField = "UsuarioNombre", HeaderText = "Usuario" });
                GridViewUltimas.Columns.Add(new BoundField { DataField = "Duracion", HeaderText = "Duración (min)", DataFormatString = "{0:N0}" });
                GridViewUltimas.Columns.Add(new BoundField { DataField = "Descripcion", HeaderText = "Descripción" });

                var listaAdmin = actividades.Select(a => new
                {
                    NombreActividad = a.NombreActividad,
                    UsuarioNombre = a.Usuario.Nombre,
                    Duracion = (int)(a.Duracion * 60),
                    Descripcion = a.Descripcion
                }).ToList();

                GridViewUltimas.DataSource = listaAdmin;
                GridViewUltimas.DataBind();
                lblNumActividades.Text = $"Hay {listaAdmin.Count} actividad(es) registradas en total.";
            }
            else
            {
                // Solo actividades propias
                actividades = capaDatos.ObtenerActividadesUsuario(usuario.IdUsuario);

                GridViewUltimas.Columns.Clear();
                GridViewUltimas.Columns.Add(new BoundField { DataField = "NombreActividad", HeaderText = "Actividad" });
                GridViewUltimas.Columns.Add(new BoundField { DataField = "Duracion", HeaderText = "Duración (min)" });
                GridViewUltimas.Columns.Add(new BoundField { DataField = "Descripcion", HeaderText = "Descripción" });

                var listaUsuario = actividades.Select(a => new
                {
                    NombreActividad = a.NombreActividad,
                    Duracion = (int)(a.Duracion * 60),
                    Descripcion = a.Descripcion
                }).ToList();

                GridViewUltimas.DataSource = listaUsuario;
                GridViewUltimas.DataBind();
                lblNumActividades.Text = $"Tienes {listaUsuario.Count} actividad(es) registradas.";
            }
        }


        private void ConfigurarOpcionesUsuario()
        {
            ddlOpcionesUsuario.Items.Clear();
            ddlOpcionesUsuario.Items.Add(new ListItem("Selecciona una opción", ""));

            // Opciones comunes
            ddlOpcionesUsuario.Items.Add(new ListItem("Editar Perfil", "EditarPerfil"));
            ddlOpcionesUsuario.Items.Add(new ListItem("Añadir Actividad", "AñadirActividad"));
            ddlOpcionesUsuario.Items.Add(new ListItem("Ver Actividades", "VerActividades"));

            // Opciones solo para Admin
            if (usuario.ObtenerTipoUsuario(usuario) == "ADMIN")
            {
                ddlOpcionesUsuario.Items.Add(new ListItem("Ver Usuarios", "VerUsuarios"));
                ddlOpcionesUsuario.Items.Add(new ListItem("Comprobar/ Cambiar Estados", "GestionarEstados"));

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

        protected void btnAñadirActividad_Click(object sender, EventArgs e)
        {
            Response.Redirect("AñadirActividad.aspx");
        }
        protected void btnAñadirUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AñadirUsuario.aspx");
        }

        
    }
}