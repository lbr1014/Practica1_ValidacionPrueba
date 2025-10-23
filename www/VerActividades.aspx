<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerActividades.aspx.cs" Inherits="www.VerActividades" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Mis Actividades</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }

        .container {
            width: 90%;
            margin: 20px auto;
        }

        .title {
            font-size: 24px;
            text-align: center;
            margin-bottom: 20px;
        }

        .top-buttons {
            text-align: right;
            margin-bottom: 10px;
        }

        .top-buttons button {
            margin-left: 5px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
        }

        th, td {
            border: 1px solid #000;
            padding: 8px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }

        .action-buttons button {
            margin-right: 5px;
        }
    </style>
    <link rel="stylesheet" href="Estilos/EstilosPagina.css" />
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
                <asp:Button ID="btnAñadirActividad" runat="server" Text="Añadir Actividad" OnClick="btnAñadirActividad_Click" />
            </div>

            <div class="title">Mis Actividades</div>
            <div class="gridview-container">
                <asp:GridView ID="GridViewActividades" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="NombreActividad" HeaderText="Actividad" />
                        <asp:BoundField DataField="Duracion" HeaderText="Duración (min)" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        <asp:BoundField DataField="Calorias" HeaderText="Calorías" />
                        <asp:BoundField DataField="MET" HeaderText="MET" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <div class="action-buttons">
                                    <asp:Button ID="btnEditar" runat="server" Text="Editar"
                                        CommandArgument='<%# Eval("IdActividad") %>' OnClick="btnEditar_Click" CssClass="boton"/>
                                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar"
                                        CommandArgument='<%# Eval("IdActividad") %>' OnClick="btnEliminar_Click"
                                        OnClientClick="return confirm('¿Seguro que quieres eliminar esta actividad?');" CssClass="boton" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="btnVolver" >
                <!-- Botón volver a la página principal -->
                <asp:Button ID="btnVolver" runat="server" Text="Volver a Página Principal" OnClick="btnVolver_Click" />
            </div>
        </div>

    </form>
</body>
</html>





