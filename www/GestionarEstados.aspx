<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionarEstados.aspx.cs" Inherits="www.GestionarEstados" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Gestionar Estados de Usuarios</title>
    <link runat="server" rel="stylesheet" href="~/Estilos/EstilosPagina.css" />
    <style>
        .gridview-container {
            width: 80%;
            margin: 20px auto;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="gridview-container">
            <h2>Usuarios y Estados</h2>
            <asp:GridView ID="GridViewUsuarios" runat="server" AutoGenerateColumns="False" 
                EmptyDataText="No hay usuarios registrados.">
                <Columns>
                    <asp:BoundField DataField="NombreCompleto" HeaderText="Usuario" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="TipoUsuario" HeaderText="Tipo Usuario" />
                    <asp:BoundField DataField="EstadoTexto" HeaderText="Estado" />
                    <asp:TemplateField HeaderText="Acción">
                        <ItemTemplate>
                            <asp:Button ID="btnCambiarEstado" runat="server" 
                                CommandArgument='<%# Eval("Email") %>'
                                Text="Cambiar Estado"
                                OnClick="btnCambiarEstado_Click"
                                CssClass="btnCambiarEstado"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnVolver" runat="server" Text="Volver a Página Principal" OnClick="btnVolver_Click" />
        </div>
    </form>
</body>
</html>

