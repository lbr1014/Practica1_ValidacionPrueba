<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="www.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio de sesión</title>
    <link rel="stylesheet" href="Estilos/EstilosPagina.css" />
</head>

<body>
    <form id="form2" runat="server">

        <!-- CABECERA -->
        <header class="site-header">
            <div class="brand">VALKIRIA</div>
        </header>

        <!-- CONTENIDO EXISTENTE -->
        <div class="form-container">
            <h2>Inicio de sesión</h2>

            <!-- Ejemplo de controles (ajusta a tus IDs reales) -->
            <td >
                <asp:Label ID="lblEmail" runat="server" Text="Usuario"></asp:Label>
                <asp:TextBox ID="tbxUsuario" runat="server"></asp:TextBox>
            </td >
            <td >
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox ID="tbxPassword" TextMode="Password" runat="server"></asp:TextBox>
            </td >

            <td >
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Mensaje Error" Visible="False"></asp:Label>
            </td >

            <div class="button-container">
                <!-- Añade las clases para que cojan el estilo morado y redondeado -->
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar"  />
                <asp:Button ID="btnRegistro" runat="server" OnClick="btnRegistro_Click" Text="Registrarse" />
            </div>
        </div>

    </form>
</body>

</html>
