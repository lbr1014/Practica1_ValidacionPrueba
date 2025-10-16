<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InicioSesion.aspx.cs" Inherits="InicioSesion" %>
<!DOCTYPE html>
<html lang="es">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Iniciar sesión</title>
    <!-- Hoja de estilos existente -->
    <link href="~/EstilosPagina.css" rel="stylesheet" />
    <style>
        :root{
            --morado-fondo:#efe4ff; /* morado claro para el fondo */
            --morado-card:#c7b8ff;  /* morado un poco más oscuro para la tarjeta */
            --morado-accent:#7c3aed;/* acento para botones */
            --morado-titulo:#1f1147; /* mismo morado del texto 'INICIO DE SESIÓN' */
        }
        body{background:var(--morado-fondo); min-height:100vh;}
        .card-header{background:transparent; border:0; padding:0 0 10px; border-radius:0; text-align:center; font-weight:800; letter-spacing:.06em; margin-bottom:14px; color:var(--morado-titulo); font-size:18px; border-bottom:2px solid currentColor;}
        
        .login-wrapper{min-height:calc(100vh - 140px); display:flex; align-items:center; justify-content:center; padding:24px;}
        .login-card{background:var(--morado-card); color:#ffffff; border-radius:16px; box-shadow:0 10px 30px rgba(0,0,0,.12); padding:24px; width:100%; max-width:420px;}
        .form-label{color:#f5f3ff; font-weight:600; display:block; margin-bottom:6px;}
        .text-input{width:100%; background:#ffffff; color:#111827; border:1px solid #e5e7eb; border-radius:10px; padding:10px 12px; outline:none;}
        .text-input:focus{border-color:#a78bfa; box-shadow:0 0 0 3px rgba(167,139,250,.35);}        
        .input-box{background:#ffffff; border:2px solid var(--morado-titulo); border-radius:12px; padding:6px 8px;}
        .input-box:focus-within{border-color:#a78bfa; box-shadow:0 0 0 3px rgba(167,139,250,.35);} 
        .text-input.boxless{background:transparent; border:0; padding:8px 6px;}
        .text-input.boxless:focus{box-shadow:none;}
        .form-actions{margin-top:12px;}
        .btn-primary{display:inline-block; width:100%; padding:12px 16px; border:0; border-radius:10px; background:var(--morado-accent); color:#fff; font-weight:700; cursor:pointer;}
        .btn-primary:hover{filter:brightness(.95);}      
        .aux-links{margin-top:12px; text-align:center;}
        .aux-links .link{color:#f5f3ff; text-decoration:none;}
        .aux-links .link:hover{text-decoration:underline;}
        .separator{margin:0 8px; color:#ede9fe;}
        .section-divider{border:0; border-top:2px solid var(--morado-titulo); margin:16px 0 0; opacity:.9;}
        /* tabla apilada */
        .login-table{width:100%; border-collapse:separate; border-spacing:0 12px;}
        .login-table td{display:block;}
        @media (min-width:480px){.login-card{padding:28px 32px}}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- CONTENEDOR CENTRADO -->
        <div class="login-wrapper">
            <!-- TARJETA -->
            <div class="login-card">
                <div class="card-header">INICIO DE SESIÓN</div>
                <!-- Encabezado interno removido para usar el de la página -->
<!-- FORMULARIO CON TABLA (apilada por CSS) -->
                <table class="login-table">
                    <tr>
                        <td>
                            <label for="txtUsuario" class="form-label">Usuario</label>
                            <div class="input-box">$1<\/div>
                            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server"
                                ControlToValidate="txtUsuario" Display="Dynamic"
                                ErrorMessage="El usuario es obligatorio" ForeColor="#dc2626"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label for="txtPassword" class="form-label">Contraseña</label>
                            <div class="input-box">$1<\/div>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
                                ControlToValidate="txtPassword" Display="Dynamic"
                                ErrorMessage="La contraseña es obligatoria" ForeColor="#dc2626"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="form-actions">
                                <asp:Button ID="btnEntrar" runat="server" Text="Iniciar sesión" CssClass="btn-primary" />
                            </div>
                        </td>
                    </tr>
                </table>

                <!-- ENLACES AUXILIARES -->
                <hr class="section-divider" />
                <div class="aux-links">
                    <asp:HyperLink ID="hlOlvide" runat="server" CssClass="link" NavigateUrl="~/Recuperar.aspx">Iniciar sesión</asp:HyperLink>
                    <span class="separator">·</span>
                    <asp:HyperLink ID="hlRegistro" runat="server" CssClass="link" NavigateUrl="~/Registro.aspx">Crear cuenta</asp:HyperLink>
                </div>
            </div>
        </div>

        <!-- (Opcional) Validación resumen -->
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="false" ShowSummary="false" />
    </form>
</body>
</html>
