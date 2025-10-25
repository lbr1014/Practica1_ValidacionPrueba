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
    public partial class Registro : System.Web.UI.Page
    {
        private static CapaDatos datos = new CapaDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblError.Text = ""; // solo se limpia la primera vez
            }
        }

        protected void lblUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            lblError.Text = ""; // Limpiar mensaje previo

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPeso.Text) ||
                string.IsNullOrWhiteSpace(txtAltura.Text) ||
                string.IsNullOrWhiteSpace(txtEdad.Text) ||
                string.IsNullOrWhiteSpace(tbxPassword.Text) ||
                string.IsNullOrWhiteSpace(tbxPassword1.Text) ||
                ddlSexo.SelectedValue == "")
            {
                lblError.Text = ":Todos los campos son obligatorios.";
                return;
            }
            var email = txtEmail.Text.Trim();
            bool emailExiste = datos.ObtenerUsuarios().Any(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));

            if (emailExiste)
            {
                lblError.Text = "Ya estas registrado";
                return;
            }
            // Verificar contraseñas iguales
            if (tbxPassword.Text != tbxPassword1.Text)
            {
                lblError.Text = ":Las contraseñas no coinciden.";
                return;
            }

            // Convertir valores
            string sexo;
            switch (ddlSexo.SelectedValue)
            {
                case "Femenino":
                    sexo = "MUJER";
                    break;
                case "Masculino":
                    sexo = "HOMBRE";
                    break;
                case "Otro":
                    sexo = "OTRO";
                    break;
                default:
                    lblError.Text = "Debes seleccionar un sexo válido.";
                    return;
            }

            // Determinar tipo de usuario (Premium opcional)
            string tipoUsuario = CheckBox1.Checked ? "PREMIUM" : "NORMAL";

            // Convertir datos numéricos
            if (!float.TryParse(txtPeso.Text, out float peso))
            {
                lblError.Text = ":El peso debe ser un número válido.";
                return;
            }

            if (!float.TryParse(txtAltura.Text, out float altura))
            {
                lblError.Text = ":La altura debe ser un número válido.";
                return;
            }

            if (!int.TryParse(txtEdad.Text, out int edad))
            {
                lblError.Text = ":La edad debe ser un número entero.";
                return;
            }

            try
            {
                // Crear nuevo usuario
                var nuevoUsuario = new Usuario(
                    idUsuario: Guid.NewGuid().ToString(),
                    name: txtNombre.Text.Trim(),
                    apellidos: txtApellidos.Text.Trim(),
                    email: txtEmail.Text.Trim(),
                    password: tbxPassword.Text,
                    sexo: sexo,
                    peso: peso,
                    altura: altura,
                    edad: edad,
                    estado: 1,
                    tipoUsuario: tipoUsuario
                );

                // Guardar en la capa de datos
                bool guardado = datos.GuardaUsuario(nuevoUsuario);

                if (guardado)
                {
                    // Guardar usuario en la sesión
                    Session["usuarioAutenticado"] = nuevoUsuario;

                    // Redirigir a la página principal
                    Response.Redirect("PaginaPrincipal.aspx");
                }
                else
                {
                    lblError.Text = "Error: al guardar el usuario. Inténtalo de nuevo.";
                }
            }
            catch (Exception ex)
            {
                // Mostrar error de validaciones de la clase Usuario
                lblError.Text = "Error: " + ex.Message;
            }
        }


        protected void btnInicioSesion_Click(object sender, EventArgs e)
        {
            // Redirigir a la página de inicio de sesión
            Response.Redirect("InicioSesion.aspx", true);
        }
    }
}