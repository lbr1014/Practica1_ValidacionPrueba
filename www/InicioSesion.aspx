<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="www.InicioSesion" %>

<!DOCTYPE html>

<html languaje="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio de sesión</title>
    <link rel="stylesheet" href="Estilos/Registro.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style91">
            <tr>
                <td class="auto-style125">&nbsp;</td>
                <td class="auto-style93">&nbsp;</td>
                <td class="auto-style115">&nbsp;</td>
                <td class="auto-style124" colspan="2">&nbsp;</td>
                <td class="auto-style117">&nbsp;</td>
                <td class="auto-style123">&nbsp;</td>
                <td class="auto-style113">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style125">&nbsp;</td>
                <td class="auto-style93">&nbsp;</td>
                <td class="auto-style115">&nbsp;</td>
                <td class="auto-style124" colspan="2">&nbsp;</td>
                <td class="auto-style117">&nbsp;</td>
                <td class="auto-style123">&nbsp;</td>
                <td class="auto-style113">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style125">&nbsp;</td>
                <td class="auto-style93">&nbsp;</td>
                <td class="auto-style115">&nbsp;</td>
                <td class="auto-style124" colspan="2">&nbsp;</td>
                <td class="auto-style126">&nbsp;</td>
                <td class="auto-style123">&nbsp;</td>
                <td class="auto-style113">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style18"></td>
                <td class="auto-style36"></td>
                <td class="auto-style118" colspan="4">
                    <h2 class="auto-style38">
                        <asp:Label ID="lblTitulo" runat="server" Text="Inicio de Sesión"></asp:Label>
                    </h2>
                </td>
                <td class="auto-style80"></td>
                <td class="auto-style19"></td>
            </tr>
            <tr>
                <td class="auto-style64">&nbsp;</td>
                <td class="auto-style65">&nbsp;</td>
                <td class="auto-style50">
                    &nbsp;</td>
                <td class="auto-style44" colspan="3">
                    <h3>
                        Email</h3>
                </td>
                <td class="auto-style82">&nbsp;</td>
                <td class="auto-style66">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style64"></td>
                <td class="auto-style65"></td>
                <td class="auto-style50">
                    &nbsp;</td>
                <td class="auto-style44" colspan="3">
                    <asp:TextBox ID="tbxUsuario" runat="server" CssClass="auto-style47" Width="240px"></asp:TextBox>
                </td>
                <td class="auto-style82"></td>
                <td class="auto-style66"></td>
            </tr>
            <tr>
                <td class="auto-style74"></td>
                <td class="auto-style75"></td>
                <td class="auto-style49">
                    <h3 class="auto-style41">
                        <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                    </h3>
                </td>
                <td class="auto-style51" colspan="3">
                    <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" CssClass="auto-style47" Width="247px"></asp:TextBox>
                </td>
                <td class="auto-style83">
                    <p>
                    </p>
                </td>
                <td class="auto-style76"></td>
            </tr>
            <tr>
                <td class="auto-style122">&nbsp;</td>
                <td class="auto-style121">&nbsp;</td>
                <td class="auto-style53" colspan="4">&nbsp;</td>
                <td class="auto-style120">&nbsp;</td>
                <td class="auto-style119">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style107"></td>
                <td class="auto-style108"></td>
                <td class="auto-style52"></td>
                <td class="auto-style89">
                    <asp:Button ID="btnRegistro" runat="server" OnClick="btnRegistro_Click" Text="Registrarse" CssClass="auto-style77" Height="36px" Width="108px" />
                </td>
                <td class="auto-style89">
                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" CssClass="auto-style77" Height="36px" Width="108px" />
                </td>
                <td class="auto-style90"></td>
                <td class="auto-style109"></td>
                <td class="auto-style114"></td>
            </tr>
            <tr>
                <td class="auto-style103"></td>
                <td class="auto-style104"></td>
                <td class="auto-style39" colspan="4">
                    &nbsp;</td>
                <td class="auto-style105"></td>
                <td class="auto-style106"></td>
            </tr>
            <tr>
                <td class="auto-style8"></td>
                <td class="auto-style34"></td>
                <td class="auto-style46" colspan="4">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Mensaje Error" Visible="False"></asp:Label>
                </td>
                <td class="auto-style85"></td>
                <td class="auto-style4"></td>
            </tr>
            <tr>
                <td class="auto-style92"></td>
                <td class="auto-style93">&nbsp;</td>
                <td class="auto-style115">&nbsp;</td>
                <td class="auto-style116" colspan="2"></td>
                <td class="auto-style78"></td>
                <td class="auto-style97"></td>
                <td class="auto-style113">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
