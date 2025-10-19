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
    public partial class VerActividades : System.Web.UI.Page
    {
        private static CapaDatos capaDatos = new CapaDatos();

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

                CargarActividades(usuario);
            }
        }

        private void CargarActividades(Usuario usuario)
        {
            List<ActividadesFisicas> actividades = capaDatos.ObtenerActividadesUsuario(usuario.IdUsuario);

            var lista = actividades.Select(a => new
            {
                IdActividad = a.IdActividad,
                NombreActividad = a.NombreActividad,
                Duracion = (a.Duracion * 60).ToString("0"),
                Descripcion = a.Descripcion,
                Calorias = usuario.ObtenerTipoUsuario(usuario) == "PREMIUM" ? a.CalcularCalorias(usuario) : (float?)null,
                MET = usuario.ObtenerTipoUsuario(usuario) == "PREMIUM" ? a.MET : (float?)null
            }).ToList();

            GridViewActividades.DataSource = lista;
            GridViewActividades.DataBind();

            if (usuario.ObtenerTipoUsuario(usuario) != "PREMIUM")
            {
                GridViewActividades.Columns[3].Visible = false; // Calorias
                GridViewActividades.Columns[4].Visible = false; // MET
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var btn = sender as System.Web.UI.WebControls.Button;
            if (btn != null)
            {
                string idActividad = btn.CommandArgument;
                // Redirigir a la página de edición pasando el ID
                Response.Redirect("EditarActividad.aspx?id=" + idActividad);
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            var btn = sender as System.Web.UI.WebControls.Button;
            if (btn != null)
            {
                string idActividad = btn.CommandArgument;
                capaDatos.EliminaActividad(idActividad);
                //CargarActividades(); Recargar lista
            }
        }

        protected void btnAñadirActividad_Click(object sender, EventArgs e)
        {
            Response.Redirect("AñadirActividad.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}