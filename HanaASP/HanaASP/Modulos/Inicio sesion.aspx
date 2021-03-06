﻿<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Modulos/Menu.master" AutoEventWireup="true" CodeBehind="Inicio sesion.aspx.cs" Inherits="HanaASP.Modulos.Inicio_sesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #mainheader {
            margin-top: -35px;
        }
    </style>
    <title>Inicio sesión</title>
    <link rel="stylesheet" href="../Style/formsAveArbol3.css" />
    <script src="../Script/Sweetalert/sweetalert2.js"></script>
    <script src="../Script/PNotify/pnotify.custom.min.js"></script>
    <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css' />
    <link href="../Style/PNotify/pnotify.custom.min.css" rel="stylesheet" />
    <link href="../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <script src="https://storage.googleapis.com/code.getmdl.io/1.0.1/material.min.js"></script>
    <script src="../Script/Ajax/Iniciar_sesion.js"></script>
    <script>
        $(document).ready(function () {
            $('#olvContra').click(function () {
                swal({
                    title: 'Ingresa tu correo electrónico.',
                    input: 'email',
                    showCancelButton: true,
                    cancelButtonText: 'Cancelar',
                    confirmButtonText: 'Enviar',
                    showLoaderOnConfirm: true,
                    preConfirm: function (email) {
                        return new Promise(function (resolve, reject) {
                            setTimeout(function () {
                                alert(email);
                                $.ajax({
                                    type: "POST",
                                    url: "../Services/Iniciar_sesion/Service_Iniciar_sesion.svc/Recuperar",
                                    data: '{"Correo": "' + email + '"}',
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    processdata: true,
                                    success: function (Mensaje) {
                                        item = Mensaje.RecuperarResult;
                                 

                                        swal(item);
                                        return;
                                    },
                                    error: function (Mensaje) {
                                        alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                                    }

                                });
                            }, 2000)
                        })
                    },
                    allowOutsideClick: false
                }).then(function (email) {
                    swal({
                        type: 'success',
                        title: '',
                        html: 'Enviado correctamente'
                    })
                })
            });
        });       $(document).ready(function () {
           window.location.hash = "no-back-button";
           3
           window.location.hash = "Again-No-back-button" //chrome
           4
           window.onhashchange = function () { window.location.hash = " "; }


           $('li').removeClass('tl-current');
           $('li.s1').addClass('tl-current');
       });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal-wrap login">
        <div class="modal-header"><span class="is-active"></span></div>
        <form class="modal-bodies">
            <div class="modal-body modal-body-step-1 is-showing">
                <ul></ul>
                <div class="title">Iniciar sesión</div>
                <div class="contLogo">
                    <img class="logo" src="../images/Logo.png" />
                </div>
                <div>
                    <!--Correo electronico-->
                    <div class="group b inputData">
                        <input id="txtCorreo" type="text" class="input" name="Correo electronico" required/>
                        <span class="bar"></span>
                        <label class="label">Correo electrónico:</label>
                    </div>
                    <div id="correo" style="position: relative; top: -30px; color: red"></div>
                    <!--Contraseña-->
                    <div class="group inputData">
                        <input id="txtContraseña" type="password" class="input" name="Contraseña" required/>
                        <span class="bar"></span>
                        <label class="label">Contraseña:</label>
                    </div>
                    <div id="contraseña" style="color: red; position: relative; top: -50px"></div>
                    <div class="text-center">
                        <input value="Iniciar sesión" type="button" id="btnIniciarS" class="button" />
                    </div>
                </div>
                <p class="message"><a id="olvContra">¿Olvidaste tu contraseña?</a></p>
                <p class="message">¿No estas registrado? <a href="Register.aspx">Crear cuenta</a></p>
            </div>
            <div class="modal-body modal-body-step-2">
                <div class="title">Registro Guardado</div>
                <div class="description">Un correo de verificación ha sido enviado a tu correo electronico por favor ingrese a su correo y siga los pasos que se le indicaran.</div>
                <div class="text-center">
                    <a href="index.aspx">
                        <input value="Ir a Inicio" type="button" class="button" /></a>
                </div>
            </div>
        </form>
    </div>
    <script src="../Script/pagRegist2.js"></script>
</asp:Content>
