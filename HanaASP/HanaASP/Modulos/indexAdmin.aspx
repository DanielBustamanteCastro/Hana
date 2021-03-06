﻿<%@ Page Title="" Language="C#" MasterPageFile="MenuAdmin.master" AutoEventWireup="true" CodeBehind="indexAdmin.aspx.cs" Inherits="HanaASP.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Inicio</title>
    <link href="../Style/slider.css" rel="stylesheet" />
    <script src="../../Script/Sweetalert/sweetalert2.js"></script>
    <link href="../../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            window.location.hash = "no-back-button";
            3
            window.location.hash = "Again-No-back-button" //chrome
            4
            window.onhashchange = function () { window.location.hash = "#"; }
            $.ajax({
                type: "POST",
                url: "../Services/Iniciar_sesion/Service_Iniciar_sesion.svc/Validar_sesion",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                processdata: true,
                success: function (Fotos) {
                    $("body").css('dysplay', 'none');
                    var img = Fotos.Validar_sesionResult;
                    if (img == "No iniciado") {
                        swal({
                            allowOutsideClick: false,
                            title: 'Inicia sesión para ingresar',
                            type: 'error'
                        }).then(function () { location.href = "index.aspx" });
                    }
                    if (img == "Usuario") {
                        swal({
                            allowOutsideClick: false,
                            title: 'Tu rol no tiene acceso a esta seccion',
                            type: 'info'
                        }).then(function () { location.href = "indexUsuario.aspx" });
                        swal('', 'Tu rol no tiene acceso a esta seccion', 'info').then(function () { location.href = "indexUsuario.aspx" });
                    }
                }
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Modern-Slider" hidden="hidden">
        <!-- Item -->
        <div class="item" data-thumbnail="../images/slider/img1.jpg">
            <div class="img-fill">
                <img src="../images/slider/img1.jpg" alt="">
                <div class="info">
                    <div>
                        <h3 class="titleHana">HANA</h3>
                        <h5>Virtualmente natural.</h5>
                    </div>
                </div>
            </div>
        </div>
        <!-- // Item -->
        <!-- Item -->
        <div class="item" data-thumbnail="../images/slider/img2.jpg">
            <div class="img-fill">
                <img src="../images/slider/img2.jpg" alt="">
                <div class="info">
                    <div>
                        <h3>¿QUÉ ES?</h3>
                        <h5>Es un sistema de información desarrollado por aprendices SENA.</h5>
                    </div>
                </div>
            </div>
        </div>
        <!-- // Item -->
        <!-- Item -->
        <div class="item" data-thumbnail="../images/slider/img3.jpg">
            <div class="img-fill">
                <img src="../images/slider/img3.jpg" alt="">
                <div class="info">
                    <div>
                        <h3>¿Para que sirve?</h3>
                        <h5>Este sistema mostrara cierta información de aves y arboles localizadas en el valle de aburrá.</h5>
                    </div>
                </div>
            </div>
        </div>
        <!-- // Item -->
        <!-- Item -->
        <div class="item" data-thumbnail="../images/slider/img4.jpg">
            <div class="img-fill">
                <img src="../images/slider/img4.jpg" alt="">
                <div class="info">
                    <div>
                        <h3>SIEMPRE EN FUNCIONAMIENTO</h3>
                    </div>
                </div>
            </div>
        </div>
        <!-- // Item -->
    </div>
    <script src="../Script/slider/slider.js"></script>
    <script src="../Script/slider/slick.js"></script>

</asp:Content>
