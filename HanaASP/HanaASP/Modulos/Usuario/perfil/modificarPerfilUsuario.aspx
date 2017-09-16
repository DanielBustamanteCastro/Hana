<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/MenuUsuario.master" AutoEventWireup="true" CodeBehind="modificarPerfilUsuario.aspx.cs" Inherits="HanaASP.Modulos.Usuario.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../../Style/formsAveArbol3.css" />
    <script src="../../../Scripts/jquery-3.1.1.js"></script>
    <script src="../../../Script/Sweetalert/sweetalert2.js"></script>
    <script src="../../../Script/PNotify/pnotify.custom.min.js"></script>
    <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css' />
    <link href="../../../Style/PNotify/pnotify.custom.min.css" rel="stylesheet" />
    <link href="../../../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <script src="https://storage.googleapis.com/code.getmdl.io/1.0.1/material.min.js"></script>
    <script src="../../../Script/Ajax/Registrar.js"></script>
    <script>
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal-wrap">
        <div class="modal-header"><span class="is-active"></span></div>
        <form class="modal-bodies">
            <div class="modal-body modal-body-step-1 is-showing">
                <ul></ul>
                <div class="title">Modificar</div>
                <div class="description">Cambie cualquier cambio por el nuevo campo y valida la contraseña para poder modificar.</div>
                <div>
                    <!--Nombre-->
                    <div class="group b inputData">
                        <input id="txtNombre" type="text" class="input" name="Nombre" required="required" onkeypress="return validarLetras(event)" />
                        <span class="bar"></span>
                        <label class="label">Nombre:</label>
                    </div>
                    <!--Apellido-->
                    <div class="group inputData">
                        <input id="txtApellido" type="text" required="required" class="input" name="Apellido" onkeypress="return validarLetras(event)" />
                        <span class="bar"></span>
                        <label class="label">Apellido:</label>
                    </div>
                    <!--Fecha nacimiento-->
                    <div class="group b f inputData">
                        <input id="txtFecha" type="date" class="input" required="required" name="Fecha de nacimiento" style="padding-bottom: 1px;" />
                        <span class="bar"></span>
                        <label class="label">Fecha nacimiento:</label>
                    </div>
                    <!--Correo electronico-->
                    <div class="group inputData">
                        <input id="txtCorreo" type="text" class="input" name="Correo electronico" required="required" />
                        <span class="bar"></span>
                        <label class="label">Correo electronico:</label>
                        <div id="Correo" class="div4" style="color: red; position: absolute; left: 30%;"></div>
                    </div>
                    <div class="mdl-select mdl-js-select mdl-select--floating-label a z" style="margin-bottom: 40px;">
                        <select class="mdl-select__input" id="ddlMunicipio">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Municipio:</span></label>
                    </div>
                    <!--Contraseña-->
                    <div class="group b inputData">
                        <input id="txtContraseña" type="password" class="input" name="Contraseña" required="required" />
                        <span class="bar"></span>
                        <label class="label">Contraseña actual:</label>
                    </div>
                    <!--Confirmar contraseña-->
                    <div class="group inputData">
                        <input id="txtConfrirmar" type="password" class="input" name="Confirmar contraseña" required="required" />
                        <span class="bar"></span>
                        <label class="label">Confirmar contraseña actual:</label>
                        <div id="Contraseña" style="color: red; position: absolute;"></div>
                    </div>
                    <div class="text-center">
                        <input value="Modificar" type="button" id="btnRegistrar" class="button next" />
                    </div>
                </div>
            </div>
            <div class="modal-body modal-body-step-2">
                <div class="title">Modificado exitosamente</div>
                <div class="text-center">
                    <a href="../../indexUsuario.aspx">
                        <input value="Ir a Inicio" type="button" class="button" /></a>
                </div>
            </div>
        </form>
    </div>
    <script src="../../../Script/icono.js"></script>
    <script src="../../../Script/pagRegist2.js"></script>
</asp:Content>
