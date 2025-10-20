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
            // Obtener la lista de usuarios
            var usuarios = ObtenerUsuarios()
                .Select(u => new
                {
                    u.IdUsuario,
                    Nombre = u.Nombre,
                    Apellidos = u.Apellidos,
                    Email = u.Email,
                    Sexo = u.obtenerSexo(u),
                    Edad = u.Edad,
                    Peso = u.Peso,
                    Altura = u.Altura,
                    TipoUsuario = u.ObtenerTipoUsuario(u),
                    EstadoTexto = u.obtenerEstado(u)
                })
                .ToList();

            GridViewUsuarios.DataSource = usuarios;
            GridViewUsuarios.DataBind();
        }

        private System.Collections.Generic.List<Usuario> ObtenerUsuarios()
        {
            var field = typeof(CapaDatos).GetField("UsuariosLista",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            return (System.Collections.Generic.List<Usuario>)field.GetValue(null);
        }

        protected void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                string email = btn.CommandArgument;
                var usuarios = ObtenerUsuarios();
                var usuario = usuarios.FirstOrDefault(u => u.Email == email);

                if (usuario != null)
                {
                    // Alternar estado entre ACTIVO e INACTIVO (no tocamos BLOQUEADO)
                    if (usuario.obtenerEstado(usuario) == "ACTIVO")
                    {
                        usuario.Estado = 0; // INACTIVO
                    }
                    else if (usuario.obtenerEstado(usuario) == "INACTIVO")
                    {
                        usuario.Estado = 1; // ACTIVO
                    }

                    datos.ActualizaUsuario(usuario);
                }

                CargarUsuarios();
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}