﻿<%@ Page Title="Modificar ave" Language="C#" MasterPageFile="~/Modulos/MenuAdmin.master" AutoEventWireup="true" CodeBehind="ModificarAve.aspx.cs" Inherits="HanaASP.Modulos.Admin.Registrar.ResgistroAve2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../../Style/formsAveArbol3.css" />
    <script src="../../../Scripts/jquery-3.1.1.js"></script>
    <script src="../../../Script/Sweetalert/sweetalert2.js"></script>
    <script src="../../../Script/PNotify/pnotify.custom.min.js"></script>
    <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css' />
    <link href="../../../Style/PNotify/pnotify.custom.min.css" rel="stylesheet" />
    <link href="../../../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <script src="https://storage.googleapis.com/code.getmdl.io/1.0.1/material.min.js"></script>
    <script src="../../../Script/Ajax/ModificarAve.js"></script>
    <script>

</script>
    <script>


        function getGET() {
            var loc = document.location.href;
            if (loc.indexOf('?') > 0) {
                var getString = loc.split('?')[1];
                var GET = getString.split('&');
                var get = {};
                for (var i = 0, l = GET.length; i < l; i++) {
                    var tmp = GET[i].split('=');
                    get[tmp[0]] = unescape(decodeURI(tmp[1]));
                }
                return get;
            }
        }
        window.onload = function () {
            var valores = getGET();
            if (valores == null) {
                swal('', 'Error al buscar', 'error').then(function () {
                    location.href = "../GaleriasAdmin/GaleriaAves.aspx";
                });
            }
            else {
            if (valores) {
                for (var index in valores) {
                    alert(valores[index].length);
                 
                        $.ajax({
                            type: "POST",
                            url: "../../../Services/Modificar_ave/Service_Modificar_ave.svc/Cargar_ave",
                            data: '{"NombreCientifico":"' + valores[index] + '"}',
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            async: false,
                            processdata: true,
                            success: function (Mensaje) {
                               
                                var ave = Mensaje.Cargar_aveResult;
                                if (ave==null) {
                                    swal('','Error al cargar los tados','error').then(function(){ 
                                        location.href = "../GaleriasAdmin/GaleraAves.aspx";});
                                }else{
                                    $("#txtNombreCientifico").val(ave[1]);
                                    $("#txtNombreComun").val(ave[2]);
                                    dominio(ave[5]);
                                    reino(ave[5], ave[6]);
                                    filum(ave[6], ave[7]);
                                    clase(ave[7], ave[21]);
                                    orden(ave[21], ave[9]);
                                    familia(ave[9], ave[10]);
                                    genero(ave[10], ave[11]);
                                    especie(ave[11], ave[12]);
                                    origen(ave[13]);
                                    tipo(ave[14]);
                                    clase_dieta(ave[20]);
                                    dieta(ave[20], ave[8]);
                                    Comportamiento_ave(ave[15]);
                                    habitat_ave(ave[16]);
                                    reproducccion_ave(ave[17]);
                                    color_plumaje(ave[18]);
                                    tamaño_ave(ave[19]);
                                    $("#txaDescripcion").val(ave[3]);




                                    $.ajax({
                                        type: "POST",
                                        url: "../../../Services/Galeria_ave/Service_Galeria_ave.svc/Llamar_fotos_aves",
                                        data: '{"idAve":"' + ave[0] + '"}',
                                        contentType: "application/json; charset=utf-8",
                                        dataType: "json",
                                        async: false,
                                        processdata: true,
                                        success: function (Fotos) {
                                            var img = Fotos.Llamar_fotos_avesResult;
                                            $("#div").append("<output id=" + " out" + 0 + " class='out'><div id=" + " list" + 0 + " class='imagen'>  </div></output > ");
                                            $.each(img, function (index, imagen) {
                                                var input = $("#div output").length;
                                                var asa = input - 1;
                                                $("#list" + asa).append('<img class="thumb" id="im" src="' + imagen.Fotos_aves + '" title="' + imagen.id_Fotos_aves + '"/> <img id="' + input + '" class="x"  src="../../../images/X-roja.png" />')
                                                $("#" + input).click(function () {
                                                    swal({
                                                        title: 'Esta seguro que desea eliminar esta imagen?',
                                                        type: 'warning',
                                                        showCancelButton: true,
                                                        confirmButtonColor: '#3085d6',
                                                        cancelButtonColor: '#d33',
                                                        confirmButtonText: 'Si, eliminar'
                                                    }).then(function () {
                                                        $("#out" + asa).remove();
                                                        $("#files").get(0).value = '';
                                                        $("#files").get(0).type = '';
                                                        $("#files").get(0).type = 'file';
                                                    })
                                                });

                                                input = input + 1;
                                            })

                                        }, error: function (Mensaje) {
                                            alert('Error al llamar el servicion : ' + Mensaje.status + ' ' + Mensaje.statusText);
                                        }
                                    });
                                }

                            },
                            error: function (Mensaje) {
                                alert('Error al llamar el servicion : ' + Mensaje.status + ' ' + Mensaje.statusText);
                            }

                            });
                        }
                    }
                }
            }


    </script>
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
                <div class="title">Modificar Ave</div>
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
                        <a>
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
                        <a>
                            <input value="Atrás" type="button" class="button previous" /></a>
                        <a>
                            <input value="Siguiente" type="button" class="button next" /></a>
                    </div>
                </div>
            </div>
            <!-- Third step-->
            <div class="modal-body modal-body-step-3">
                <div class="title">Característcas de Ave</div>
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
                        <label class="mdl-select__label"><span>Habitat:</span></label>
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
                    <a>
                        <input value="Atrás" type="button" class="button previous" /></a>
                    <a>
                        <input value="Siguiente" type="button" class="button next" /></a>
                </div>
            </div>
            <!-- Forth step-->
            <div class="modal-body modal-body-step-4">
                <div class="title">Cargar imagenes</div>
                <div class="description">Aquí se subirán las imágenes del ave.</div>
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
                    <div class="button " id="btnGuardar">Editar</div>
                </div>
            </div>
        </form>
    </div>
    <script src="../../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../../Script/pagRegist2.js"></script>
    <script src="../../../Script/icono.js"></script>
</asp:Content>
