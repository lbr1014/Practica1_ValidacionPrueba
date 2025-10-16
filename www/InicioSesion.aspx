<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="www.InicioSesion" %>

<!DOCTYPE html>

<html languaje="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio de sesión</title>
    <link rel="stylesheet" href="Estilos/EstilosPagina.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-wrapper">
            <div class="login-card" role="region" aria-label="Formulario de inicio de sesión">
                <!-- Si quieres mantener la estructura de tabla -->
                <table class="login-table" role="presentation">
                    <!-- Email -->
                    <tr>
                        <td>
                            <label class="form-label" for="<%= txtEmail.ClientID %>">Email</label>
                        </td>
                   </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="text-input" TextMode="Email" placeholder="tu@correo.com" />
                        </td>
                    </tr>

                    <!-- Contraseña -->
                    <tr>
                        <td>
                            <label class="form-label" for="<%= txtContrasena.ClientID %>">Contraseña</label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtContrasena" runat="server" CssClass="text-input" TextMode="Password" placeholder="••••••••" />
                        </td>
                        </tr>


                        <!-- Acciones -->
                        <tr>
                            <td class="form-actions">
                                <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar sesión" CssClass="btn-primary" OnClick="btnIniciarSesion_Click" />
                            </td>
                        </tr>


                        <!-- Opcional: enlaces de ayuda -->
                        <tr>
                            <td>
                                <div class="aux-links">
                                    <a runat="server" href="~/RecuperarPassword.aspx" class="link">¿Olvidaste tu contraseña?</a>
                                    <span class="separator">•</span>
                                    <a runat="server" href="~/Registro.aspx" class="link">Crear cuenta</a>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </form>
</body>
</html>
