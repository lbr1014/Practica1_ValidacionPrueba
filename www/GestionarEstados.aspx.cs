using Datos;
using Practica1.ModeladoDatos;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www
{
    public partial class GestionarEstados : System.Web.UI.Page
    {
        private static CapaDatos datos = new CapaDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios(datos);
            }
        }

        private void CargarUsuarios(CapaDatos capaDatos)
        {
            var usuarios = capaDatos.ObtenerUsuarios()
                .Select(u => new
                {
                    NombreCompleto = u.Nombre + " " + u.Apellidos,
                    u.Email,
                    TipoUsuario = u.ObtenerTipoUsuario(u),
                    EstadoTexto = u.obtenerEstado(u)
                })
                .ToList();

            GridViewUsuarios.DataSource = usuarios;
            GridViewUsuarios.DataBind();
        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                string email = btn.CommandArgument;
                var usuario = datos.ObtenerUsuarios().FirstOrDefault(u => u.Email == email);
                if (usuario != null)
                {
                    // Alternar entre ACTIVO e INACTIVO, y desbloquear cuenta
                    if (usuario.obtenerEstado(usuario) == "ACTIVO")
                        usuario.Estado = 0; // INACTIVO
                    else if (usuario.obtenerEstado(usuario) == "INACTIVO")
                        usuario.Estado = 1; // ACTIVO
                    else if (usuario.obtenerEstado(usuario) == "BLOQUEADO")
                        usuario.Estado = 1; // ACTIVO

                    datos.ActualizaUsuario(usuario);
                }
                CargarUsuarios(datos);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}
