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
using Logica.utils;



namespace www
{
    public partial class AñadirUsuario : System.Web.UI.Page
    {
        private static CapaDatos capaDatos = new CapaDatos();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaginaPrincipal.aspx");
        }

        //Hay que editar esto 
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblMensaje.Text = ""; // Limpiar mensaje previo

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellidos.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPeso.Text) ||
                string.IsNullOrWhiteSpace(txtAltura.Text) ||
                string.IsNullOrWhiteSpace(txtEdad.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) ||
                ddlSexo.SelectedValue == "")
            {
                lblMensaje.Text = ":Todos los campos son obligatorios.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }


            var email = txtEmail.Text.Trim();
            bool emailExiste = capaDatos.ObtenerUsuarios().Any(u => string.Equals(u.Email, email, StringComparison.OrdinalIgnoreCase));

            if (emailExiste)
            {
                lblMensaje.Text = "Ya esta registrado";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }


            string idUsuario;
            if (string.IsNullOrWhiteSpace(txtId.Text.Trim()))
            {
                idUsuario = "a-" + DateTime.Now.Ticks;
            }
            else
            {

                if (!Regex.IsMatch(txtId.Text.Trim(), @"^[A-Za-z]-\d{3,}$"))
                {
                    lblMensaje.Text = "El ID debe tener el formato letra-guion-números (ejemplo: a-001).";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    
                    return;
                }
                idUsuario = txtId.Text.Trim();
            }

            string tipoUsuario;
            switch (ddlTipoUsuario.SelectedValue)
            {
                case "NORMAL":
                    tipoUsuario = "NORMAL";
                    break;
                case "PREMIUM":
                    tipoUsuario = "PREMIUM";
                    break;
                default:
                    lblMensaje.Text = "Error:Debes seleccionar un tipo de usuario válido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
            }

            // Convertir valores
            string sexo;
            switch (ddlSexo.SelectedValue)
            {
                case "MUJER":
                    sexo = "MUJER";
                    break;
                case "HOMBRE":
                    sexo = "HOMBRE";
                    break;
                case "OTRO":
                    sexo = "OTRO";
                    break;
                default:
                    lblMensaje.Text = "Error:Debes seleccionar un sexo válido.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
            }
            var IBAN = txtIBAN.Text;

            // Convertir datos numéricos
            if (!float.TryParse(txtPeso.Text, out float peso))
            {
                lblMensaje.Text = "Error:El peso debe ser un número válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!float.TryParse(txtAltura.Text, out float altura))
            {
                lblMensaje.Text = "Error:La altura debe ser un número válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!int.TryParse(txtEdad.Text, out int edad))
            {
                lblMensaje.Text = "Error:La edad debe ser un número entero.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (!Validar.IBAN(IBAN))
            {
                lblMensaje.Text = "Error:El IBAN debe ser correcto.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            try
            {
                // Crear nuevo usuario
                var nuevoUsuario = new Usuario(
                    idUsuario,
                    name: txtNombre.Text.Trim(),
                    apellidos: txtApellidos.Text.Trim(),
                    email: txtEmail.Text.Trim(),
                    password: txtContraseña.Text,
                    sexo: sexo,
                    peso: peso,
                    altura: altura,
                    edad: edad,
                    estado: 1,
                    tipoUsuario: tipoUsuario
                );

                // Guardar en la capa de datos
                bool guardado = capaDatos.GuardaUsuario(nuevoUsuario);

                if (guardado)
                {

                    lblMensaje.Text = "Usuario registrado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMensaje.Text = "Error: al guardar el usuario. Inténtalo de nuevo.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                // Mostrar error de validaciones de la clase Usuario
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ddlTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar IBAN solo si se selecciona PREMIUM
            panelIBAN.Visible = ddlTipoUsuario.SelectedValue == "PREMIUM";
        }


    }
}