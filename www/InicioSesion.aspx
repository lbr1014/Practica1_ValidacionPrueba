<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="www.InicioSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio de sesión</title>
    <link runat="server" rel="stylesheet" href="~/Estilos/EstilosPagina.css" />
    <style type="text/css">
        .auto-style1 {
            width: 210px;
            height: 199px;
        }
    </style>
</head>
    

<body>
    <form id="form2" runat="server">

        <!-- CABECERA -->
        <header class="site-header">
          <div class="header-inner">
            <img runat="server" src="~/img/logoValkiria.png" alt="VALKIRIA" class="header-inner" />
            <div class="brand">VALKIRIA</div>
          </div>
        </header>



        <!-- CONTENIDO EXISTENTE -->
        <div class="form-container">
            <h2>Inicio de sesión</h2>

            <!-- Ejemplo de controles (ajusta a tus IDs reales) -->
            <asp:Label ID="lblEmail" runat="server" Text="Usuario"></asp:Label>
            
                <br />
            
                <asp:TextBox ID="tbxUsuario" runat="server" Width="388px"></asp:TextBox>
            
            <br />
                <asp:Label ID="lblContraseña" runat="server" Text="Contraseña"></asp:Label>
            
                <br />
            
                <asp:TextBox ID="tbxPassword" TextMode="Password" runat="server" Width="386px"></asp:TextBox>
            
            <br />
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="Mensaje Error" Visible="False"></asp:Label>

            <div class="button-container">
                <!-- Añade las clases para que cojan el estilo morado y redondeado -->
                <asp:Button ID="btnRegistro" runat="server" OnClick="btnRegistro_Click" Text="Registrarse" CssClass="boton-registro" />
                <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" CssClass="boton-inicio" />
            </div>
        </div>

    </form>
</body>

</html>
