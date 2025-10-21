<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarPerfil.aspx.cs" Inherits="www.EditarPerfil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Editar Perfil</title>
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
    </style>
    <link rel="stylesheet" href="Estilos/EstilosPagina.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <!-- Botón volver a la página principal -->
            <asp:Button ID="btnVolver" runat="server" Text="Volver a Página Principal" CssClass="btn-top-right" OnClick="btnVolver_Click" />

            <h2>Editar Perfil</h2>

            <table>
                <tr>
                    <td><asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label></td>
                    <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblApellidos" runat="server" Text="Apellidos"></asp:Label></td>
                    <td><asp:TextBox ID="txtApellidos" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblEdad" runat="server" Text="Edad"></asp:Label></td>
                    <td><asp:TextBox ID="txtEdad" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPeso" runat="server" Text="Peso (kg)"></asp:Label></td>
                    <td><asp:TextBox ID="txtPeso" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblAltura" runat="server" Text="Altura (m)"></asp:Label></td>
                    <td><asp:TextBox ID="txtAltura" runat="server"></asp:TextBox></td>
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
                    <td colspan="2" class="btn-container">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="btn-container">
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

