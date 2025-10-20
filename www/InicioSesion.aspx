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
            <asp:Label ID="lblEmail" runat="server" Text="Usuario"></asp:Label>
            <td >
                <asp:TextBox ID="tbxUsuario" runat="server"></asp:TextBox>
            </td >
            <br />
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
            <td >
                <asp:TextBox ID="tbxPassword" TextMode="Password" runat="server"></asp:TextBox>
            </td >
            <br />
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Mensaje Error" Visible="False"></asp:Label>

            <div class="button-container">
                <!-- Añade las clases para que cojan el estilo morado y redondeado -->
                <asp:Button ID="btnRegistro" runat="server" OnClick="btnRegistro_Click" Text="Registrarse" />
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar"  />
            </div>
        </div>

    </form>
</body>

</html>
