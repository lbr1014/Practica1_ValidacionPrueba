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
    public partial class EditarPerfil : System.Web.UI.Page
    {
        private static CapaDatos capaDatos = new CapaDatos();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el usuario de la sesión
                Usuario usuario = Session["usuarioAutenticado"] as Usuario;

                var emailParam = Request.QueryString["email"];
                if (!string.IsNullOrWhiteSpace(emailParam))
                {
                    lblTitulo.Text = "Perfil Usuario";
                    var email = Server.UrlDecode(emailParam);
                    usuario = capaDatos.LeeUsuario(email);

                }


                if (usuario == null)
                {
                    // Si no hay usuario en sesión, redirigir a inicio de sesión
                    Response.Redirect("InicioSesion.aspx");
                    return;
                }

                // Mostrar los valores actuales en los campos
                txtNombre.Text = usuario.Nombre;
                txtApellidos.Text = usuario.Apellidos;
                txtEdad.Text = usuario.Edad.ToString();
                txtPeso.Text = usuario.Peso.ToString();
                txtAltura.Text = usuario.Altura.ToString();
                ddlSexo.SelectedValue = usuario.obtenerSexo(usuario);
                chkPremium.Checked = usuario.ObtenerTipoUsuario(usuario) == "PREMIUM";
                panelIBAN.Visible = chkPremium.Checked;

                if (chkPremium.Checked && Session["ibanTemporal"] != null)
                {
                    txtIBAN.Text = Session["ibanTemporal"].ToString();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = Session["usuarioAutenticado"] as Usuario;
                if (usuario == null)
                {
                    lblMensaje.Text = "Error:Usuario no autenticado.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Validación de campos
                string nombre = txtNombre.Text.Trim();
                if (string.IsNullOrEmpty(nombre))
                {
                    lblMensaje.Text = "Error:El nombre no puede estar vacío.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                string apellidos = txtApellidos.Text.Trim();
                if (string.IsNullOrEmpty(apellidos))
                {
                    lblMensaje.Text = "Error:El Apellido no puede estar vacío.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!int.TryParse(txtEdad.Text.Trim(), out int edad) || edad < 1 || edad > 120)
                {
                    lblMensaje.Text = "Error:Ingrese una edad válida (1-120).";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!float.TryParse(txtPeso.Text.Trim(), out float peso) || peso <= 0)
                {
                    lblMensaje.Text = "Error:Ingrese un peso válido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (!float.TryParse(txtAltura.Text.Trim(), out float altura) || altura <= 0)
                {
                    lblMensaje.Text = "Error:Ingrese una altura válida.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                string sexo = ddlSexo.SelectedValue;
                if (sexo != "HOMBRE" && sexo != "MUJER" && sexo != "OTRO")
                {
                    lblMensaje.Text = "Error:Seleccione un sexo válido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                string tipoUsuario = chkPremium.Checked ? "PREMIUM" : "NORMAL";

                if (chkPremium.Checked)
                {
                    string iban = txtIBAN.Text.Trim();

                    if (string.IsNullOrEmpty(iban))
                    {
                        lblMensaje.Text = "Error:Debe introducir un IBAN si el usuario es PREMIUM.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    // Validar IBAN usando la clase Validar
                    if (!Logica.utils.Validar.IBAN(iban))
                    {
                        lblMensaje.Text = "Error:El IBAN introducido no es válido.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    Session["ibanTemporal"] = iban;
                }
               

                // Actualizar usuario
                usuario.Nombre = nombre;
                usuario.Apellidos =apellidos;
                usuario.Edad = edad;
                usuario.Peso = peso;
                usuario.Altura = altura;
                usuario.Sexo = sexo;
                usuario.TipoUsuario = tipoUsuario;


                bool actualizado = capaDatos.ActualizaUsuario(usuario);

                if (actualizado)
                {
                    // Actualizar la sesión para reflejar cambios inmediatamente
                    Session["usuarioAutenticado"] = usuario;

                    lblMensaje.Text = "Perfil actualizado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "Error:Al actualizar el perfil.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void chkPremium_CheckedChanged(object sender, EventArgs e)
        {
            // Si está marcado, mostramos el campo IBAN
            panelIBAN.Visible = chkPremium.Checked;
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }
    }
}