<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="www.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio de sesión</title>
    <link rel="stylesheet" href="Estilos/EstilosPagina.css" />
</head>
<body>
    <div class="form-container">
   <h2>                   
        <asp:Label ID="lblTitulo" runat="server" Text="Inicio de Sesión"></asp:Label>
   </h2>
    <form id="form1" runat="server">
        <div>
        </div>
        <table >
      
            </tr>
            <tr>
                <td ></td>
                <td ></td>
                <td  >
                <td ></td>
                <td ></td>
            </tr>
            <tr>
                <td >&nbsp;</td>
                <td >&nbsp;</td>
                <td >
                    <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>

                </td>
                <td  >
                    <asp:TextBox ID="tbxUsuario" runat="server" ></asp:TextBox>

                </td>
                <td >
                    &nbsp;</td>
                <td ></td>
                <td ></td>
            </tr>
            <tr>
                <td ></td>
                <td ></td>
                <td >
                      <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" ></asp:TextBox>
                </td>
                <td >
                    <p>
                    </p>
                </td>
                <td ></td>
            </tr>
            <tr>
                <td >&nbsp;</td>
                <td >&nbsp;</td>
                <td >&nbsp;</td>
                <td >&nbsp;</td>
                <td >&nbsp;</td>
            </tr>
            <tr>
                <td ></td>
                <td ></td>
                <td >
                    <asp:Button ID="btnRegistro" runat="server" OnClick="btnRegistro_Click" Text="Registrarse" />
                </td>
                <td >
                    <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar"  />
                </td>
                <td>
                    &nbsp;</td>
                <td ></td>
                <td ></td>
                <td ></td>
            </tr>
            <tr>
                <td ></td>
                <td ></td>
                <td >
                    &nbsp;</td>
                <td ></td>
                <td ></td>
            </tr>
            <tr>
                <td ></td>
                <td ></td>
                <td colspan="2" >
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Mensaje Error" Visible="False"></asp:Label>
                </td>
                <td ></td>
            </tr>
            <tr>
                <td ></td>
                <td >&nbsp;</td>
                <td >&nbsp;</td>
                <td ></td>
                <td ></td>
                <td ></td>
                <td >&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
