<%@ Page Title="" Language="C#" MasterPageFile="Menu.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HanaASP.Modulos.Usuario.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro</title>
    <script src="../Scripts/jquery-3.1.1.js"></script>
    <script src="../glDatePicker.min.js"></script>
    <link href="../glDatePicker.default.css" rel="stylesheet" />
    <link href="../Style/PNotify/pnotify.custom.min.css" rel="stylesheet" />
    <script src="../Script/PNotify/pnotify.custom.min.js"></script>
    <link href="../Style/Registrar.css" rel="stylesheet" />
    <link href="../Style/formRegister.css" rel="stylesheet" />
    <script src="../Script/Sweetalert/sweetalert2.js"></script>
    <link href="../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <script src="../Script/Ajax/Registrar.js"></script>
    <script>
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <form class="form">
            <h1>REGISTRO</h1>
            <div align="center">
                <img src="../../images/Logo.png" class="logo" />
            </div>
            <div class="cont">
                <div class="div1" id="con">
                    <!--Nombre-->
                    <div class="group" style="position: relative; top: -20px">
                        <%--<asp:TextBox ID="txtNombre" type="text" required="required" runat="server"></asp:TextBox>--%>
                        <input id="txtNombre" type="text" class="input" name="Nombre" required="required" onkeypress="return validarLetras(event)" />
                        <span class="highlight"></span>
                        <span class="bar"></span>
                        <label class="label" >Nombre</label>
                    </div>
                    <!--Fecha de nacimiento-->
                    <div class="group date">
                        <span class="span">Fecha de nacimiento</span>
                        <input id="txtFecha" type="date" class="input" required="required" name="Fecha de nacimiento" />
                        <%--<asp:TextBox ID="txtFecha" type="date" required="required" runat="server"></asp:TextBox>--%>
                        <span class="highlight"></span>
                        <span class="bar"></span>
                    </div>
                    <!--Contraseña-->
                    <div class="group div2">
                        <input id="txtContraseña" type="password" class="input" name="Contraseña" required="required" />
                        <%--<asp:TextBox ID="txtContraseña" type="password" required="required" runat="server"></asp:TextBox>--%>
                        <span class="highlight"></span>
                        <span class="bar"></span>
                        <label class="label" >Contraseña</label>
                    </div>
                </div>
                <div class="div3">
                    <!--Apellido-->
                    <div class="group">
                        <input id="txtApellido" type="text" required="required" class="input" name="Apellido" onkeypress="return validarLetras(event)" />
                        <%--<asp:TextBox ID="txtApellido" type="text" runat="server" required="required"></asp:TextBox>--%>
                        <span class="highlight"></span>
                        <span class="bar"></span>
                        <label class="label" >Apellido</label>
                    </div>
                    <!--Correo electronico-->
                    <div class="group div5">
                        <input id="txtCorreo" type="text" class="input" name="Correo electronico" required="required" />
                        <%--<asp:TextBox ID="txtCorreo" type="text" runat="server" required="required"></asp:TextBox>--%>
                        <span class="highlight"></span>
                        <span class="bar"></span>
                        <label class="label">Correo electronico</label>
                    </div>
                    <div id="Correo" class="div4" style="color: red; height: 20px">
                        <%--<asp:RegularExpressionValidator ID="regexValidarCorreo" ForeColor="Red" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidateRequestMode="Enabled" ControlToValidate="txtCorreo" ErrorMessage="Correo invalido"></asp:RegularExpressionValidator>--%>
                    </div>
                    <!--Confirmar contraseña-->
                    <div class="group" style="position: relative; top: -11px;">
                        <input id="txtConfrirmar" type="password" class="input" name="Confirmar contraseña" required="required" />
                        <%--<asp:TextBox ID="txtConfrirmar" type="password" required="required" runat="server"></asp:TextBox>--%>
                        <span class="highlight"></span>
                        <span class="bar"></span>
                        <label class="label">Confirmar contraseña</label>
                    </div>
                </div>
                <div id="Contraseña" style="color: red; position: relative; top: -50px">
                </div>


                <div class="div7">
                    <!--Municipio-->
                    <div class="group dep" align="left">
                        <span class="span">Municipio</span>
                        <select id="ddlMunicipio" class="select"></select>
                        <span class="highlight"></span>
                        <span class="bar"></span>
                    </div>
                    <%--<asp:Button ID="btnRegistrar" class="button-three" runat="server" Text="Registrarse" OnClick="btnRegistrar_Click" />--%>
                    <input id="btnRegistrar" class="button-three" value="Registrarse" />
                    <br />
                    <p class="message">¿Ya estas registrado? <a href="../../Modulos/Gestionando/Iniciar%20sesion.html">Inicia sesión</a></p>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
