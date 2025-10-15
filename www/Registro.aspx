<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="www.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 320px;
        }
        .auto-style2 {
            height: 106px;
        }
        .auto-style3 {
            height: 105px;
        }
        .auto-style4 {
            height: 106px;
            width: 126px;
        }
        .auto-style5 {
            width: 126px;
            height: 29px;
        }
        .auto-style6 {
            height: 105px;
            width: 126px;
        }
        .auto-style7 {
            height: 29px;
        }
        .auto-style47 {
            font-weight: bold;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Label ID="lblRegistro" runat="server" Text="REGISTRO"></asp:Label>
                </td>
                <td class="auto-style2">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:Label ID="lblNombre" runat="server" Text="NOMBRE"></asp:Label>
                </td>
                <td class="auto-style2">
                    <asp:TextBox ID="txtNombre" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style2"></td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <asp:Label ID="lblApellidos" runat="server" Text="APELLIDOS"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtApellidos" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style7"></td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblEmail" runat="server" Text="EMAIL"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtEmail" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblSexo" runat="server" Text="SEXO"></asp:Label>
                </td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblPeso" runat="server" Text="PESO"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtPeso" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblAltura" runat="server" Text="ALTURA"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtAltura" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblEdad" runat="server" Text="EDAD"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtEdad" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblPremium" runat="server" Text="PREMIUM"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblContraseña" runat="server" Text="CONTRASEÑA"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" CssClass="auto-style47" Width="247px"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblContraseña1" runat="server" Text="CONFIRMAR CONTRASEÑA"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="tbxPassword1" runat="server" TextMode="Password" CssClass="auto-style47" Width="247px"></asp:TextBox>
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style3">
                    <asp:Button ID="btnRegistro" runat="server" Text="REGISTRO" />
                </td>
                <td class="auto-style3">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
