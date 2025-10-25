<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AñadirUsuario.aspx.cs" Inherits="www.AñadirUsuario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Añadir Usuario</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .form-container {
            width: 400px;
            margin: 50px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            position: relative;
        }

        .form-container table {
            width: 100%;
        }

        .form-container td {
            padding: 5px;
        }

        .btn-top-right {
            position: absolute;
            top: 10px;
            right: 10px;
        }

        .btn-container {
            text-align: center;
            margin-top: 20px;
        }

        .error {
            color: red;
            font-weight: bold;
        }

        .success {
            color: green;
            font-weight: bold;
        }
        .btn-container-volver {
            text-align: center;
            margin-top: 5px;
        }

    </style>
    <link rel="stylesheet" href="Estilos/EstilosPagina.css" />
</head>
<body>
    <form id="form1" runat="server">
        
        <!-- CABECERA -->
        <header class="site-header">
          <div class="header-inner">
            <img runat="server" src="~/img/logoValkiria.png" alt="VALKIRIA" class="img" />
            <div class="brand">VALKIRIA</div>
          </div>
        </header>
        <div class="form-container">

            <h2>Añadir Usuario</h2>

            <table>
                <tr>
                    <td><asp:Label ID="lblId" runat="server" Text="IdUsuario"></asp:Label></td>
                    <td><asp:TextBox ID="txtId" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label></td>
                    <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblApellidos" runat="server" Text="Apellidos"></asp:Label></td>
                    <td><asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label></td>
                    <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label></td>
                    <td><asp:TextBox ID="txtContraseña" TextMode="Password"  runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server">
                            <asp:ListItem Text="Selecciona una opción" Value="" />
                            <asp:ListItem Text="INACTIVO" Value="0" />
                            <asp:ListItem Text="ACTIVO" Value="1" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblTipoUsuario" runat="server" Text="Tipo Usuario"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlTipoUsuario" runat="server">
                            <asp:ListItem Text="Selecciona una opción" Value="" />
                            <asp:ListItem Text="NORMAL" Value="NORMAL" />
                            <asp:ListItem Text="PREMIUM" Value="PREMIUM" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblSexo" runat="server" Text="Sexo"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlSexo" runat="server">
                            <asp:ListItem Text="Selecciona una opción" Value="" />
                            <asp:ListItem Text="HOMBRE" Value="HOMBRE" />
                            <asp:ListItem Text="MUJER" Value="MUJER" />
                            <asp:ListItem Text="OTRO" Value="OTRO" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblAltura" runat="server" Text="Altura (m)"></asp:Label></td>
                    <td><asp:TextBox ID="txtAltura" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPeso" runat="server" Text="Peso (kg)"></asp:Label></td>
                    <td><asp:TextBox ID="txtPeso" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblEdad" runat="server" Text="Edad"></asp:Label></td>
                    <td><asp:TextBox ID="txtEdad" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" class="btn-container">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" class="boton" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="btn-container">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="btn-container-volver">
            <!-- Botón volver a la página principal -->
            <asp:Button ID="btnVolver" runat="server" Text="Volver a Página Principal" OnClick="btnVolver_Click"  class="btnVolver"/>
         </div>
    </form>
</body>
</html>