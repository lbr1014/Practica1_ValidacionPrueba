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
            // Muestra los usuarios del sistema
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

        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string email = btn.CommandArgument;
            // Elimina un usuario y vuelve a cargar los usuarios
            datos.EliminaUsuario(email);


            CargarUsuarios();
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
