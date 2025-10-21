<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaginaPrincipal.aspx.cs" Inherits="www.PaginaPrincipal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Página Principal</title>
    <style type="text/css">
        .auto-style1 {
            width: 600px;
        }
        .auto-style2 {
            text-align: right;
        }
        .nuevoEstilo1 {
            border-bottom-style: solid;
            border-width: medium;
            border-color: #000000;
        }
        .ddl-usuario {
            width: 200px;
        }
    </style>
    <link runat="server" rel="stylesheet" href="~/Estilos/EstilosPagina.css" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- CABECERA -->
        <header class="site-header">
          <div class="header-inner">
            <img runat="server" src="~/img/logoValkiria.png" alt="VALKIRIA" class="header-inner" />
            <div class="brand">VALKIRIA</div>
          </div>
        </header>

        <table class="nuevoEstilo1" style="width:100%;">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style1">
                    <!-- Nombre del usuario y tipo al lado -->
                    <asp:Label ID="lblUsuario" runat="server" Text="Nombre Usuario"></asp:Label>
                    &nbsp;-&nbsp;
                    <asp:Label ID="lblTipoUsuario" runat="server" Text=""></asp:Label>
                    &nbsp;(
                    <asp:Label ID="lblUltimoInicioSesion" runat="server" Text="UltimoInicioSesion"></asp:Label>
                    )
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style2">
                    <!-- Desplegable de opciones del usuario con AutoPostBack -->
                    <asp:DropDownList ID="ddlOpcionesUsuario" runat="server" CssClass="ddl-usuario"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlOpcionesUsuario_SelectedIndexChanged">
                    </asp:DropDownList>
                    &nbsp;
                    <asp:Button ID="btnCerrarSesion" runat="server" Text="CERRAR SESIÓN" OnClick="btnCerrarSesion_Click" />
                </td>
            </tr>
        </table>
        <!-- PANEL DE BIENVENIDA -->
        <div class="welcome-panel">
            <h2>Bienvenid@, <asp:Label ID="lblUsuarioCentral" runat="server" Text="Usuario"></asp:Label>!</h2>
            
        </div>

        <!-- RESUMEN DE ACTIVIDADES -->
        <div class="resumen-actividades">
            <h3 id="lblTituloActividades" runat="server">Mis Actividades</h3>
            <asp:Label ID="lblNumActividades" runat="server" Text="Tienes X actividades registradas."></asp:Label>
            <h3 id="lblTituloUsuarios" runat="server" Visible= "false ">Numero de Usuarios </h3>
            <br /><br />
            <asp:Label ID="lblNumUsuarios" runat="server" Text="Tienes X usuarios registrados." Visible= "false "></asp:Label>

            <br /><br />
            <asp:Button ID="btnAñadirActividad" runat="server" Text="Añadir Nueva Actividad" OnClick="btnAñadirActividad_Click" />
            <asp:Button ID="btnAñadirUsuario" runat="server" Text="Añadir Nuevo Usuario" OnClick="btnAñadirUsuario_Click" Visible="false" />

        </div>


        <!-- GRID DE ÚLTIMAS ACTIVIDADES -->
        <div class="gridview-container">
                    <asp:GridView ID="GridViewUltimas" runat="server" AutoGenerateColumns="False"
                        EmptyDataText="No hay actividades registradas.">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Actividad" />
                            <asp:TemplateField HeaderText="Duración (min)">
                                <ItemTemplate>
                                  <%# ((int)(Convert.ToDouble(Eval("Duracion")) * 60)) %> 
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                        </Columns>
                    </asp:GridView>
                </div>

        <!-- PANEL DE CONSEJOS -->
          <asp:Panel ID="pnlConsejos" runat="server">
            
            <div class="panel-tips">
                <h3>Consejo del día 💡</h3>
                <p>Mantén una rutina de ejercicios constante y bebe al menos 2 litros de agua diarios.</p>
                <p>Recuerda que descansar bien también es parte del entrenamiento.</p>
            </div>
        </asp:Panel>


       
    </form>
</body>
</html>


