<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="www.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style3 {
            width: 498px;
        }
        .auto-style4 {
            height: 26px;
        }
        .auto-style6 {
            text-align: right;
            width: 495px;
        }
        .auto-style7 {
            width: 230px;
        }
        .auto-style8 {
            height: 26px;
            width: 230px;
        }
        .auto-style9 {
            width: 76px;
        }
        .auto-style10 {
            width: 230px;
            height: 33px;
        }
        .auto-style12 {
            width: 76px;
            height: 33px;
        }
        .auto-style14 {
            height: 33px;
        }
        .nuevoEstilo1 {
            border-style: solid solid none solid;
            border-width: thin;
            border-color: #000000;
        }
        .nuevoEstilo2 {
            border-top-style: hidden;
            border-right-style: hidden;
            border-left-style: solid;
            border-width: thin;
            border-color: #000000;
        }
        .auto-style16 {
            border-left: thin solid #000000;
            border-right: thin hidden #000000;
            border-top: thin hidden #000000;
            text-align: right;
            border-bottom-color: #000000;
            border-bottom-width: thin;
        }
        .nuevoEstilo3 {
            border-left-style: solid;
            border-width: thin;
            border-color: #000000;
        }
        .nuevoEstilo4 {
            border-right-style: solid;
            border-bottom-style: solid;
            border-left-style: solid;
            border-width: thin;
            border-color: #000000;
        }
        .nuevoEstilo5 {
            border-right-style: solid;
            border-width: thin;
            border-color: #000000;
        }
        .nuevoEstilo6 {
            border-right-style: solid;
            border-left-style: solid;
            border-width: thin;
            border-color: #000000;
        }
        .auto-style17 {
            border-left: thin solid #000000;
            border-right: thin solid #000000;
            border-bottom: thin solid #000000;
            text-align: center;
            border-top-color: #000000;
            border-top-width: thin;
        }
        .auto-style18 {
            height: 25px;
            width: 230px;
        }
        .auto-style19 {
            height: 25px;
        }
        .nuevoEstilo7 {
            border: thin solid #000000;
        }
        .nuevoEstilo8 {
            border-style: hidden;
        }
        .auto-style20 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table style="width:100%;">
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="nuevoEstilo8">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18"></td>
                <td class="nuevoEstilo7" colspan="3">
                    <h2 class="auto-style20">
                        <asp:Label ID="lblTitulo" runat="server" Text="Inicio de Sesión"></asp:Label>
                    </h2>
                </td>
                <td class="auto-style19"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td id="tdxPassword" class="nuevoEstilo5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style16">
                    <h3>
                        <asp:Label ID="lblUsuario" runat="server" Text="Identificador de Usuario"></asp:Label>
                    </h3>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td id="tdxPassword" class="nuevoEstilo5">
                    <asp:TextBox ID="tbxUsuario" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="nuevoEstilo5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style16">
                    <h3>
                        <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                    </h3>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td class="nuevoEstilo5">
                    <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10">&nbsp;</td>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style12">&nbsp;</td>
                <td class="nuevoEstilo5">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style10"></td>
                <td class="nuevoEstilo3"></td>
                <td class="auto-style12">
                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
                </td>
                <td class="nuevoEstilo5">&nbsp;</td>
                <td class="auto-style14"></td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="nuevoEstilo6" colspan="3"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style17" colspan="3">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Usuario y/o contraseña incorrecta" Visible="False"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style7"></td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style9"></td>
                <td class="auto-style3"></td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>
