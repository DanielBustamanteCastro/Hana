<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validacion.aspx.cs" Inherits="HanaASP.Modulos.Validacion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Script/Sweetalert/sweetalert2.js"></script>
    <link href="../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <link href="../Style/validacion/validacion.css" rel="stylesheet" />
</head>
<body class="fondo">
    <form id="form1" runat="server">

        <div class="mensaje">
            <div class="titulo">
                Activar cuenta:
            </div>
            <div class="descripcion">
                ¿Desea activar su cuenta?
            </div>
            <div class="botones">
                <asp:Button ID="tbnSi" runat="server" class="button aceptar" Text="Si" OnClick="tbnSi_Click" />
                <asp:Button ID="tbnNo" class="button cancelar" runat="server" Text="No" OnClick="tbnNo_Click" />
            </div>
        </div>
    </form>
</body>
</html>
