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
    public partial class AñadirActividad : System.Web.UI.Page
    {
        private static CapaDatos capaDatos = new CapaDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar que el usuario está autenticado
            Usuario usuario = Session["usuarioAutenticado"] as Usuario;
            if (usuario == null)
            {
                Response.Redirect("InicioSesion.aspx");
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = Session["usuarioAutenticado"] as Usuario;
                if (usuario == null)
                {
                    lblMensaje.Text = "Error: usuario no autenticado.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Validar campos
                string nombre = txtNombre.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                if (string.IsNullOrEmpty(nombre))
                {
                    lblMensaje.Text = "Debe ingresar el nombre de la actividad.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!float.TryParse(txtDuracion.Text.Trim(), out float duracion) || duracion <= 0)
                {
                    lblMensaje.Text = "Ingrese una duración válida en minutos.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Crear ID de actividad único (puede ser simple concatenación con timestamp)
                string idActividad = "AF-" + DateTime.Now.Ticks;

                // Crear la actividad
                ActividadesFisicas actividad = new ActividadesFisicas(
                    idActividad,
                    nombre,
                    duracion,
                    descripcion,
                    usuario
                );

                // Guardar en la capa de datos
                bool guardado = capaDatos.GuardaActividad(actividad);

                if (guardado)
                {
                    lblMensaje.Text = "Actividad guardada correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;

                    // Limpiar campos
                    txtNombre.Text = "";
                    txtDuracion.Text = "";
                    txtDescripcion.Text = "";
                }
                else
                {
                    lblMensaje.Text = "Error al guardar la actividad.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}