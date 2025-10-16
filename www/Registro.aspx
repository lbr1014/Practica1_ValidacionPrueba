<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="www.Registro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Registro de Usuario</title>
    <link rel="stylesheet" href="Estilos/EstilosPagina.css"/>
</head>
<body>
     <div class="form-container">
        <h2>                   
            <asp:Label ID="lblRegistro" runat="server" Text="REGISTRO"></asp:Label>
        </h2>
             <form id="form1" runat="server">
        <div>
            </div>
        <table >
            <tr>
                <td> </td>
                <td> </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblNombre" runat="server" Text="NOMBRE"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td> </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblApellidos" runat="server" Text="APELLIDOS"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtApellidos" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblEmail" runat="server" Text="EMAIL"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtEmail" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblSexo" runat="server" Text="SEXO"></asp:Label>
                </td>
                <td> 
                    <asp:DropDownList ID="ddlSexo" runat="server">
                        <asp:ListItem Text="Selecciona una opción" Value="" />
                        <asp:ListItem Text="Femenino" Value="Femenino" />
                        <asp:ListItem Text="Masculino" Value="Masculino" />
                        <asp:ListItem Text="Otro" Value="Otro" />
                    </asp:DropDownList>
                </td>
                <td> </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblPeso" runat="server" Text="PESO"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtPeso" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td> </td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblAltura" runat="server" Text="ALTURA"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAltura" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td ></td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblEdad" runat="server" Text="EDAD"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="txtEdad" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                </td>
                <td >&nbsp;</td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblPremium" runat="server" Text="PREMIUM"></asp:Label>
                </td>
                <td >
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </td>
                <td >&nbsp;</td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblContraseña" runat="server" Text="CONTRASEÑA"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="tbxPassword" runat="server" TextMode="Password" CssClass="auto-style47" Width="247px"></asp:TextBox>
                </td>
                <td >&nbsp;</td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblContraseña1" runat="server" Text="CONFIRMAR CONTRASEÑA"></asp:Label>
                </td>
                <td >
                    <asp:TextBox ID="tbxPassword1" runat="server" TextMode="Password" CssClass="auto-style47" Width="247px"></asp:TextBox>
                </td>
                <td >&nbsp;</td>
            </tr>
            <tr>
                <td >&nbsp;</td>
                <td >
                    <asp:Button ID="btnRegistro" runat="server" Text="REGISTRO" />
                </td>
                <td >&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
