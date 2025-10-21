using Datos;
using Practica1.ModeladoDatos;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www
{
    public partial class VerUsuarios : System.Web.UI.Page
    {
        private static CapaDatos datos = new CapaDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuarios();
            }
        }

        private void CargarUsuarios()
        {
            var usuarios = datos.ObtenerUsuarios()
                .Select(u => new
                {
                    u.IdUsuario,
                    u.Nombre,
                    u.Apellidos,
                    u.Email,
                    Sexo = u.obtenerSexo(u),
                    u.Edad,
                    u.Peso,
                    u.Altura,
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
                    // Cambiar entre ACTIVO e INACTIVO
                    if (usuario.obtenerEstado(usuario) == "ACTIVO")
                        usuario.Estado = 0;
                    else if (usuario.obtenerEstado(usuario) == "INACTIVO")
                        usuario.Estado = 1;

                    datos.ActualizaUsuario(usuario);
                    CargarUsuarios();
                }
            }
        }

        protected void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                string email = btn.CommandArgument;
                // Redirigir a EditarPerfil pasando email
                Response.Redirect("EditarPerfil.aspx?email=" + Server.UrlEncode(email));
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}
