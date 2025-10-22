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
    public partial class EditarActividad : System.Web.UI.Page
    {
        private static CapaDatos capaDatos = new CapaDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el usuario de la sesión
                Usuario usuario = Session["usuarioAutenticado"] as Usuario;

                if (usuario == null)
                {
                    // Si no hay usuario en sesión, redirigir a inicio de sesión
                    Response.Redirect("InicioSesion.aspx");
                    return;
                }
                string id = Request.QueryString["id"];
                if (string.IsNullOrWhiteSpace(id))
                {
                    Response.Redirect("VerActividades.aspx");
                    return;
                }
                var actividad = capaDatos
                .ObtenerActividades()                // lista completa
                .FirstOrDefault(a => a.IdActividad == id); // por Id

                if (actividad == null)
                {
                    // id inválido o ya no existe
                    Response.Redirect("VerActividades.aspx");
                    return;
                }

                txtNombre.Text = actividad.NombreActividad;
                txtDuracion.Text = actividad.Duracion.ToString(); 
                txtDescripcion.Text = actividad.Descripcion;

                

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Validar sesión
                var usuarioSesion = Session["usuarioAutenticado"] as Usuario;
                if (usuarioSesion == null)
                {
                    lblMensaje.Text = "Error: usuario no autenticado.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // 2) Id de la actividad desde la URL
                string id = Request.QueryString["id"];
                if (string.IsNullOrWhiteSpace(id))
                {
                    lblMensaje.Text = "Error: actividad no especificada.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // 3) Validación de campos del formulario de actividad
                string nombre = txtNombre.Text.Trim();
                if (string.IsNullOrEmpty(nombre))
                {
                    lblMensaje.Text = "El nombre de la actividad no puede estar vacío.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!int.TryParse(txtDuracion.Text.Trim(), out int duracion) || duracion <= 0)
                {
                    lblMensaje.Text = "La duración debe ser un número entero mayor que 0 (minutos).";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string descripcion = txtDescripcion.Text.Trim();

                // 4) Usuario dueño de la actividad (puede venir de ViewState)
                var usuarioActividad = (ViewState["UsuarioActividad"] as Usuario) ?? usuarioSesion;

                // 5) Construir la actividad y actualizar
                var actividadActualizada = new ActividadesFisicas(
                    id,             // mismo IdActividad
                    nombre,         // NombreActividad
                    duracion,       // Duración en minutos (según tu modelo)
                    descripcion,    // Descripción
                    usuarioActividad
                );

                bool actualizado = capaDatos.ActualizaActividad(actividadActualizada);

                if (actualizado)
                {
                    lblMensaje.Text = "Actividad actualizada correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;

                    // Vuelve al listado (evita repost y muestra datos actualizados)
                    Response.Redirect("VerActividades.aspx", true);
                }
                else
                {
                    lblMensaje.Text = "No se pudo actualizar: la actividad no existe.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}