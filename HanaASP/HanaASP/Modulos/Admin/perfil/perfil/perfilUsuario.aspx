<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/MenuAdmin.master" AutoEventWireup="true" CodeBehind="perfilUsuario.aspx.cs" Inherits="HanaASP.Modulos.Admin.perfil.perfilAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../../Style/stylePerfil.css" rel="stylesheet" />
    <link href="../../../../Style/galeria/tooltip.css" rel="stylesheet" />
    <script src="../../../../Scripts/jquery-3.1.1.js"></script>
    <script src="../../../../Script/Sweetalert/sweetalert2.js"></script>
    <link href="../../../../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <script src="../../../../Script/Ajax/PerfilAdmin.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contPerfil">
        <div class="contImage">
            <a href="../../../indexUsuario.aspx"><img src="../../../../images/Logo.png" /></a>
            <div class="buttons">
                <a class="mover" href="../../../indexUsuario.aspx">Ir a inicio</a>
                <a id="aCambioContraseña">Cambiar contraseña</a>
            </div>
        </div>
        <div class="contData">
            <div class="itemPerfil">
                <label class="name" id="lblNombre"></label>
                <label class="name" id="lblApellido"></label>
            </div>
            <div class="itemPerfil">
                <label class="date" id="lblFechaNacimiento"></label>
            </div>
            <div class="itemPerfil">
                <label id="lblCorreo"></label>
            </div>
            <div class="itemPerfil">
                <label id="lblMunicipio"></label>
            </div>
            <div class="itemPerfil img" tooltip="Modificar" flow="down">
                <a href="modificarPerfilUsuario.aspx"><img src="../../../../images/settings.png" /></a>
            </div>
        </div>
    </div>
    <script src="../../../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../../../Script/icono.js"></script>
</asp:Content>
