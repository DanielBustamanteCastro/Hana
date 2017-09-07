<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/Menu.master" AutoEventWireup="true" CodeBehind="Inicio sesion.aspx.cs" Inherits="HanaASP.Modulos.Inicio_sesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #mainheader {
            margin-top: -35px;
        }
    </style>
    <title>Inicio sesión</title>
    <script src="../Script/Ajax/Iniciar_sesion.js"></script>
    <script src="../Scripts/jquery-3.1.1.js"></script>
    <script src="../Script/PNotify/pnotify.custom.min.js"></script>
    <script src="../Script/Sweetalert/sweetalert-dev.js"></script>
    <link href="../Style/Sweetalert/sweetalert.css" rel="stylesheet" />
    <link href="../Style/PNotify/pnotify.custom.min.css" rel="stylesheet" />
    <link href="../Style/formRegister.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <form runat="server">
            <div class="form b">
                <h1>INICIAR SESIÓN </h1>
                <img class="logo" src="../images/Logo.png" />
                <div class="cont c">
                    <div class="group g">
                        <%--<asp:TextBox ID="txtCorreo" runat="server" required="required"></asp:TextBox>--%>
                        <input id="txtCorreo" type="text" class="input" name="Correo electronico" required/>
                        <span class="highlight"></span>
                        <span class="bar"></span>
                        <label class="label">Correo*</label>
                    </div>
                   <div id="correo" style="position: relative; top: -30px;color:red">
                     <%--    <asp:RegularExpressionValidator ID="regexValidarCorreo" ForeColor="Red" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidateRequestMode="Enabled" ControlToValidate="txtCorreo" ErrorMessage="Correo invalido"></asp:RegularExpressionValidator>--%>
                    </div>
                    <div class="group g" style="top: -20px">
                        <%--<asp:TextBox ID="txtContraseña" type="password" runat="server" required="required"></asp:TextBox>--%>
                        <input id="txtContraseña" type="password" class="input" name="Contraseña" required/>
                        <span class="highlight"></span>
                        <span class="bar"></span>
                        <label class="contrasena label">Contraseña*</label>
                    </div>
                    <div id="contraseña" style="color:red; position:relative;top:-50px">
                    
                    </div>
                    <div style="position: relative; top: -25px">
                        <%--<asp:Button ID="btnIniciarS" class="button-three" runat="server" Text="Iniciar sesión" OnClick="btnIniciarS_Click" />--%>
                        <input id="btnIniciarS" class="button-three"  type="button" value="Iniciar sesión" />

                        <br />
                        <p class="message"><a href="#">¿Olvidaste tu contraseña?</a></p>
                        <p class="message">¿No estas registrado? <a href="Register.aspx">Crear cuenta</a></p>
                    </div>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
