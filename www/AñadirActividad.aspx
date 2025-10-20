<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AñadirActividad.aspx.cs" Inherits="www.AñadirActividad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Añadir Actividad</title>
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

        .error {
            color: red;
            font-weight: bold;
        }

        .success {
            color: green;
            font-weight: bold;
        }

        /* Botón en la esquina superior derecha */
        .btn-top-right {
            position: absolute;
            top: 10px;
            right: 10px;
        }

        .btn-container {
            text-align: center;
            margin-top: 20px;
        }
    </style>
    <link rel="stylesheet" href="Estilos/EstilosPagina.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <!-- Botón volver arriba a la derecha -->
            <asp:Button ID="btnVolver" runat="server" Text="Volver a Página Principal" 
                        CssClass="btn-top-right" OnClick="btnVolver_Click" />

            <h2>Añadir Actividad</h2>

            <table>
                <tr>
                    <td><asp:Label ID="lblNombre" runat="server" Text="Nombre Actividad"></asp:Label></td>
                    <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblDuracion" runat="server" Text="Duración (min)"></asp:Label></td>
                    <td><asp:TextBox ID="txtDuracion" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label></td>
                    <td><asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" class="btn-container">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Actividad" OnClick="btnGuardar_Click" />
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
