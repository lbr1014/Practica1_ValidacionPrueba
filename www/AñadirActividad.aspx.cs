using Datos;
using Logica.ModeladoDatos;
using Practica1.ModeladoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (!IsPostBack)
            {
                bool esAdmin = string.Equals(usuario.ObtenerTipoUsuario(usuario) , "ADMIN", StringComparison.OrdinalIgnoreCase);
                // Muestra/oculta solo para admin
                lblId.Visible = esAdmin;         
                txtId.Visible = esAdmin;
                lblUsuario.Visible = esAdmin;
                txtUsuario.Visible = esAdmin;


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
                bool esAdmin = string.Equals(usuario.ObtenerTipoUsuario(usuario), "ADMIN", StringComparison.OrdinalIgnoreCase);

                // Por defecto, el propio usuario autenticado
                Usuario usuarioAsociado = usuario;
                if (esAdmin && !string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    string emailDestino = txtUsuario.Text.Trim();

                    // Buscar en capaDatos (case-insensitive)
                    var usuarioEncontrado = capaDatos.ObtenerUsuarios()
                        .FirstOrDefault(u => string.Equals(u.Email, emailDestino, StringComparison.OrdinalIgnoreCase));

                    if (usuarioEncontrado == null)
                    {
                        lblMensaje.Text = "El email indicado no existe.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    usuarioAsociado = usuarioEncontrado;
                }

                if (usuario == null)
                {
                    lblMensaje.Text = "Error: usuario no autenticado.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Validar campos
                string nombre = txtNombre.Text.Trim();
                string fechatexto = txtFecha.Text.Trim();
                DateTime fecha = ActividadesFisicas.ConvertirFecha(fechatexto);
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

                // Crear ID de actividad único

                string idActividad;
                if (string.IsNullOrWhiteSpace(txtId.Text.Trim()))
                {
                    idActividad = "AF-" + DateTime.Now.Ticks;
                }
                else
                {

                    if (!Regex.IsMatch(txtId.Text.Trim(), @"^[A-Za-z]{2}-\d{3,}$"))
                    {
                        lblMensaje.Text = "El ID debe tener el formato letra-guion-números (ejemplo: af-001).";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;

                        return;
                    }
                    idActividad = txtId.Text.Trim();
                }

                // Crear la actividad
                ActividadesFisicas actividad = new ActividadesFisicas(
                        idActividad,
                        nombre,
                        duracion,
                        fecha,
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
                    txtFecha.Text = "";
                    txtDuracion.Text = "";
                    txtDescripcion.Text = "";
                    txtUsuario.Text = "";
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