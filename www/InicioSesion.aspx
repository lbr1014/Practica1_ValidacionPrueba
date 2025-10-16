<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="www.InicioSesion" %>

<!DOCTYPE html>

<html languaje="es" xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio de sesión</title>
    <style type="text/css">
        .auto-style4 {
            height: 28px;
            width: 112px;
        }
        .auto-style8 {
            height: 28px;
            width: 214px;
        }
        .auto-style18 {
            height: 58px;
            width: 214px;
        }
        .auto-style19 {
            height: 58px;
            width: 112px;
        }
        .auto-style34 {
            height: 28px;
            width: 242px;
        }
        .auto-style36 {
            width: 242px;
            height: 58px;
        }
        .auto-style38 {
            color: #FFFFFF;
            background-color: #AF8C70;
            background-repeat: repeat;
            text-align: center;
        }
        .auto-style39 {
            background-color: #E0CDC0;
            height: 36px;
            text-align: center;
        }
        .auto-style41 {
            text-align: center;
        }
        .auto-style44 {
            padding: 0;
            background-color: #E0CDC0;
            text-align: center;
            height: 54px;
        }
        .auto-style46 {
            background-color: #E0CDC0;
            height: 28px;
            text-align: center;
            font-weight: bold;
        }
        .auto-style47 {
            font-weight: bold;
        }
        .auto-style49 {
            padding: 0;
            background-color: #E0CDC0;
            font-weight: bold;
            text-align: center;
            height: 51px;
            width: 134px;
        }
        .auto-style50 {
            padding: 0;
            background-color: #E0CDC0;
            height: 54px;
            font-weight: bold;
            text-align: center;
            width: 134px;
        }
        .auto-style51 {
            padding: 0;
            background-color: #E0CDC0;
            font-weight: bold;
            text-align: center;
            height: 51px;
        }
        .auto-style52 {
            padding: 0;
            background-color: #E0CDC0;
            text-align: center;
            height: 35px;
        }
        .auto-style53 {
            padding: 0;
            background-color: #E0CDC0;
            font-weight: bold;
            text-align: center;
        }
        .auto-style64 {
            width: 214px;
            height: 54px;
        }
        .auto-style65 {
            width: 242px;
            height: 54px;
        }
        .auto-style66 {
            height: 54px;
            width: 112px;
        }
        .auto-style74 {
            width: 214px;
            height: 51px;
        }
        .auto-style75 {
            width: 242px;
            height: 51px;
        }
        .auto-style76 {
            height: 51px;
            width: 112px;
        }
        .auto-style77 {
            font-weight: bold;
            color: #FFFFFF;
            margin-left: 32px;
            background-color: #AF8C70;
        }
        .auto-style78 {
            width: 135px;
            height: 22px;
        }
        .auto-style80 {
            height: 58px;
            width: 367px;
        }
        .auto-style82 {
            width: 367px;
            height: 54px;
        }
        .auto-style83 {
            width: 367px;
            height: 51px;
        }
        .auto-style85 {
            height: 28px;
            width: 367px;
        }
        .auto-style89 {
            background-color: #E0CDC0;
            height: 35px;
            width: 134px;
        }
        .auto-style90 {
            background-color: #E0CDC0;
            text-align: center;
            height: 35px;
            width: 135px;
        }
        .auto-style91 {
            width: 1491px;
            position: absolute;
            height: 421px;
            top: 37px;
            left: 10px;
            z-index: 1;
        }
        .auto-style92 {
            width: 214px;
            height: 22px;
        }
        .auto-style93 {
            width: 242px;
            height: 22px;
            text-align: center;
        }
        .auto-style97 {
            width: 367px;
            height: 22px;
        }
        .auto-style103 {
            height: 36px;
            width: 214px;
        }
        .auto-style104 {
            height: 36px;
            width: 242px;
        }
        .auto-style105 {
            height: 36px;
            width: 367px;
        }
        .auto-style106 {
            height: 36px;
            width: 112px;
        }
        .auto-style107 {
            width: 214px;
            height: 35px;
        }
        .auto-style108 {
            width: 242px;
            height: 35px;
        }
        .auto-style109 {
            width: 367px;
            height: 35px;
        }
        .auto-style113 {
            height: 22px;
            width: 112px;
            text-align: center;
        }
        .auto-style114 {
            height: 35px;
            width: 112px;
        }
        .auto-style115 {
            text-align: center;
            width: 134px;
            height: 22px;
        }
        .auto-style116 {
            width: 122px;
            height: 22px;
        }
        .auto-style117 {
            width: 135px;
            height: 22px;
            text-align: center;
        }
        .auto-style118 {
            text-align: center;
            height: 58px;

        }
        .auto-style119 {
            height: 35px;
            width: 112px;
            text-align: center;
        }
        .auto-style120 {
            width: 367px;
            height: 35px;
            text-align: center;
        }
        .auto-style121 {
            width: 242px;
            height: 35px;
            text-align: center;
        }
        .auto-style122 {
            width: 214px;
            height: 35px;
            text-align: center;
        }
        .auto-style123 {
            width: 367px;
            height: 22px;
            text-align: center;
        }
        .auto-style124 {
            width: 122px;
            height: 22px;
            text-align: center;
        }
        .auto-style125 {
            width: 214px;
            height: 22px;
            text-align: center;
        }
        .auto-style126 {
            width: 135px;
            height: 22px;
            text-align: center;
        }
    </style>
    <link rel="stylesheet" href="Estilos/EstilosPagina.css" />
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
                <td class="auto-style64"></td>
                <td class="auto-style65"></td>
                <td class="auto-style50">
                    <h3>
                        Email</h3>
                </td>
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
