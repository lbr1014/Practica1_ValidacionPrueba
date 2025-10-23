<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditarActividad.aspx.cs" Inherits="www.EditarActividad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Esditar Actividad</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .btn-container {
            text-align: center;
            margin-top: 20px;
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
         <<header class="site-header">
            <div class="header-inner">
            <img runat="server" src="~/img/logoValkiria.png" alt="VALKIRIA" class="img" />
            <div class="brand">VALKIRIA</div>
            </div>
        </header>
         <div class="form-container">

            <h2>Editar Perfil</h2>

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
                    <td><asp:Label ID="lblFecha" runat="server" Text="Fecha (día/mes/año)"></asp:Label></td>
                    <td><asp:TextBox ID="txtFecha" runat="server"></asp:TextBox></td>
                </tr>

                <tr>
                    <td><asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label></td>
                    <td><asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2" class="btn-container">
                        &nbsp;<asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" OnClick="btnGuardar_Click" CssClass="boton"/>
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
