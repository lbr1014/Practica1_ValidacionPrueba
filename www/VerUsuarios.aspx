<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerUsuarios.aspx.cs" Inherits="www.VerUsuarios" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Gestión de Usuarios</title>
    <link rel="stylesheet" href="Estilos/EstilosPagina.css" />
    <style>
        body { font-family: Arial, sans-serif; }
        .container { width: 90%; margin: 30px auto; }
        .title { font-size: 24px; text-align: center; margin-bottom: 20px; }
        .top-buttons { text-align: right; margin-bottom: 15px; }
        table { width: 100%; border-collapse: collapse; }
        th, td { border: 1px solid #000; padding: 8px; text-align: left; }
        th { background-color: #f2f2f2; }
        .btnAccion { margin-right: 5px; }
        .gridview-container { overflow-x: auto; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- CABECERA -->
        <header class="site-header">
          <div class="header-inner">
            <img runat="server" src="~/img/logoValkiria.png" alt="VALKIRIA" class="img" />
            <div class="brand">VALKIRIA</div>
          </div>
        </header>
        <div class="container">
            <div class="top-buttons">
                <asp:Button ID="btnVolver" runat="server" Text="Volver a Página Principal" OnClick="btnVolver_Click" />
            </div>

            <div class="title">Usuarios Registrados</div>

            <div class="gridview-container">
                <asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Sexo" HeaderText="Sexo" />
                        <asp:BoundField DataField="Edad" HeaderText="Edad" />
                        <asp:BoundField DataField="Peso" HeaderText="Peso" />
                        <asp:BoundField DataField="Altura" HeaderText="Altura" />
                        <asp:BoundField DataField="TipoUsuario" HeaderText="Tipo" />
                        <asp:BoundField DataField="EstadoTexto" HeaderText="Estado" />

                       
                        <asp:TemplateField HeaderText="Acciones" ControlStyle-CssClass="boton">
                            <ItemTemplate>
                                
                                <asp:Button ID="btnEliminarUsuario" runat="server" 
                                    Text="Eliminar" 
                                    CommandArgument='<%# Eval("Email") %>' 
                                    CssClass="btnAccion"
                                    OnClick="btnEliminarUsuario_Click"
                                    OnClientClick="return confirm('¿Seguro que deseas eliminar este usuario?');" />

                                
                                <asp:Button ID="btnEditarUsuario" runat="server" 
                                    Text="Editar" 
                                    CommandArgument='<%# Eval("Email") %>' 
                                    CssClass="btnAccion"
                                    OnClick="btnEditarUsuario_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>


