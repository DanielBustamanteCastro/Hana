﻿<%@ Page Title="Registro ave" Language="C#" MasterPageFile="~/Modulos/MenuAdmin.master" AutoEventWireup="true" CodeBehind="ResgistroAve.aspx.cs" Inherits="HanaASP.Modulos.Admin.Registrar.ResgistroAve2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../../Style/formsAveArbol3.css" />
    <script src="../../../Scripts/jquery-3.1.1.js"></script>
    <script src="../../../Script/Sweetalert/sweetalert2.js"></script>
    <script src="../../../Script/PNotify/pnotify.custom.min.js"></script>
    <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css' />
    <link href="../../../Style/PNotify/pnotify.custom.min.css" rel="stylesheet" />
    <link href="../../../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <script src="https://storage.googleapis.com/code.getmdl.io/1.0.1/material.min.js"></script>
    <script src="../../../Script/Ajax/Registrar_ave.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal-wrap">
        <!-- Modal header - contains the pagination-->
        <div class="modal-header"><span class="is-active"></span><span></span><span></span><span></span></div>
        <!-- Modal bodies-->
        <form class="modal-bodies">
            <!-- First step-->
            <div class="modal-body modal-body-step-1 is-showing">
                <ul></ul>
                <div class="title">Registro Ave</div>
                <div class="sub-title">Datos comunes</div>
                <div class="description">Aquí va toda la información que caracteriza a un ave dependiendo de su tipo.</div>
                <div>
                    <!--Nombre Común:-->
                    <div class="group b inputData">
                        <input id="txtNombreComun" class="input" required="required" name="Nombre comun" onkeypress="return validarLetras(event)" />
                        <span class="bar"></span>
                        <label class="label">Nombre Común:</label>
                    </div>
                    <!--Nombre Cientifico-->
                    <div class="group inputData">
                        <input id="txtNombreCientifico" class="input" required="required" name="Nombre cientifico" onkeypress="return validarLetras(event)" />
                        <span class="bar"></span>
                        <label class="label">Nombre Científico:</label>
                    </div>
                    <!--Dominio:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlDominio">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Dominio:</span></label>
                    </div>
                    <!--Reino:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlReino">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Reino:</span></label>
                    </div>
                    <!--Filum:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label b">
                        <select class="mdl-select__input" id="ddlFilum">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Filum:</span></label>
                    </div>
                    <!--Clase:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlClase">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Clase:</span></label>
                    </div>
                    <div class="text-center">
                        <a href="#">
                            <input value="Siguiente" type="button" class="button next" /></a>
                    </div>
                </div>
            </div>
            <!-- Second step-->
            <div class="modal-body modal-body-step-2">
                <div class="title">Datos comunes</div>
                <div class="description b">Aquí va toda la información que caracteriza a un ave dependiendo de su tipo.</div>
                <div>
                    <!--Orden:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label b">
                        <select class="mdl-select__input" id="ddlOrden">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Orden:</span></label>
                    </div>
                    <!--Familia:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlFamilia">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Familia:</span></label>
                    </div>
                    <!--Género:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label b">
                        <select class="mdl-select__input" id="ddlGenero">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Género:</span></label>
                    </div>
                    <!--Especie:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlEspecie">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Especie:</span></label>
                    </div>
                    <!--Origen:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label b">
                        <select class="mdl-select__input" id="ddlOrigen">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Origen:</span></label>
                    </div>
                    <!--Tipo:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlTipo">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Tipo:</span></label>
                    </div>
                    <div class="text-center fade-in">
                        <a href="#">
                            <input value="Atrás" type="button" class="button previous" /></a>
                        <a href="#">
                            <input value="Siguiente" type="button" class="button next" /></a>
                    </div>
                </div>
            </div>
            <!-- Third step-->
            <div class="modal-body modal-body-step-3">
                <div class="title">Características de Ave</div>
                <div class="description b">Aquí van las características comunes del ave.</div>
                <div>
                    <!--Clase de dieta:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label b">
                        <select class="mdl-select__input" id="ddClase_dieta">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Clase de dieta:</span></label>
                    </div>
                    <!--Dieta:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlDieta">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Dieta:</span></label>
                    </div>
                    <!--Comportamiento:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label b">
                        <select class="mdl-select__input" id="ddlComportamiento_ave">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Comportamiento:</span></label>
                    </div>
                    <!--Habitat:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlHabitat">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Hábitat:</span></label>
                    </div>
                    <!--Reproduccion:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label b">
                        <select class="mdl-select__input" id="ddlReproduccion">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Reproducción:</span></label>
                    </div>
                    <!--Color plumaje:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlColorplumaje">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Color plumaje:</span></label>
                    </div>
                    <!--Tamaño ave:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label a">
                        <select class="mdl-select__input" id="ddlTamaño_ave">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Tamaño ave:</span></label>
                    </div>
                </div>
                <div class="text-center">
                    <a href="#">
                        <input value="Atrás" type="button" class="button previous" /></a>
                    <a href="#">
                        <input value="Siguiente" type="button" class="button next" /></a>
                </div>
            </div>
            <!-- Forth step-->
            <div class="modal-body modal-body-step-4">
                <div class="title">Cargar imágenes</div>
                <div class="description">Aquí se subirán las primeras imágenes del ave.</div>
                <div id="div">
                </div>
                <label class="file">
                    <input type="file" class="aa" id="files" />
                    <i class=" "></i>Subir imagen
                </label>
                <div>
                    <p align="left"><span class="span">Descripción:</span></p>
                    <textarea id="txaDescripcion" name="Descripción" class="textarea"></textarea>
                </div>
                <div class="text-center">
                    <div class="button previous">Atrás</div>
                    <div class="button" id="btnGuardar">Guardar</div>
                </div>
            </div>
            <!-- Fifth step-->
            
        </form>
    </div>
    <script src="../../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../../Script/pagRegist2.js"></script>
    <script src="../../../Script/icono.js"></script>
</asp:Content>
