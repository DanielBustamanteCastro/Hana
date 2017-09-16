<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/MenuUsuario.master" AutoEventWireup="true" CodeBehind="perfilUsuario.aspx.cs" Inherits="HanaASP.Modulos.Admin.perfil.perfilAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Style/stylePerfil.css" rel="stylesheet" />
    <link href="../../../Style/galeria/tooltip.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contPerfil">
        <div class="contImage">
            <a href="../../indexUsuario.aspx"><img src="../../../images/Logo.png" /></a>
            <div class="buttons">
                <a class="mover" href="../../indexUsuario.aspx">Ir a inicio</a>
                <a>Cambiar contraseña</a>
            </div>
        </div>
        <div class="contData">
            <div class="itemPerfil">
                <label class="name">Victor Manuel</label>
                <label class="name">Soto Morales</label>
            </div>
            <div class="itemPerfil">
                <label class="date">19/03/1999</label>
            </div>
            <div class="itemPerfil">
                <label>vmsoto86@misena.edu.co</label>
            </div>
             <div class="itemPerfil">
                <label class="rol">Usuario</label>
            </div>
            <div class="itemPerfil">
                <label>Medellín</label>
            </div>
            <div class="itemPerfil img" tooltip="Modificar" flow="down">
                <a href="modificarPerfilUsuario.aspx"><img src="../../../images/settings.png" /></a>
            </div>
        </div>
    </div>
    <script src="../../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../../Script/icono.js"></script>
</asp:Content>
