<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="www.PaginaPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 811px;
        }
        .auto-style2 {
            text-align: right;
        }
        .nuevoEstilo1 {
            border-bottom-style: solid;
            border-width: medium;
            border-color: #000000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="nuevoEstilo1" style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">
                    <asp:Label ID="lblUsuario" runat="server" Text="Nombre Usuario"></asp:Label>
                &nbsp; (<asp:Label ID="lblUltimoInicioSesion" runat="server" Text="UltimoInicioSesion"></asp:Label>
                    )</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnIdiomaEspañol" runat="server" Text="IDIOMA" />
                    <asp:Button ID="btnCerrarSesion" runat="server" Text="CERRAR SESIÓN" OnClick="btnCerrarSesion_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
