<%@ Page Title="Modificar Arbol" Language="C#" MasterPageFile="~/Modulos/MenuAdmin.master" AutoEventWireup="true" CodeBehind="ModificarArbol.aspx.cs" Inherits="HanaASP.Modulos.Admin.Registrar.ResgistroAve2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../../Style/formsAveArbol3.css" />
    <script src="../../../Scripts/jquery-3.1.1.js"></script>
    <script src="../../../Script/Sweetalert/sweetalert2.js"></script>
    <script src="../../../Script/PNotify/pnotify.custom.min.js"></script>
    <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css' />
    <link href="../../../Style/PNotify/pnotify.custom.min.css" rel="stylesheet" />
    <link href="../../../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <script src="https://storage.googleapis.com/code.getmdl.io/1.0.1/material.min.js"></script>
    <script src="../../../Script/Ajax/Modificar_arbol.js"></script>
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
                    location.href = "../GaleriasAdmin/GaleriaArboles.aspx";
                });
            }
            else{
            if (valores) {
                for (var index in valores) {
                    $.ajax({
                        type: "POST",
                        url: "../../../Services/Modificar_arbol/Service_Modificar_arbol.svc/Cargar_arbol",
                        data: '{"NombreCientifico":"' + valores[index] + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        processdata: true,
                        success: function (Mensaje) {
                            var arbol = Mensaje.Cargar_arbolResult;
                            if (arbol == ',,,,,,,,,,,,,,,,,,,,,,,,,,,') {
                                swal('', 'Error al cargar los tados', 'error').then(function () {
                                    location.href = "../GaleriasAdmin/GaleriaArboles.aspx";
                                });
                            } else {
                                $("#txtNombreCientifico").val(arbol[1]);
                                $("#txtNombreComun").val(arbol[2]);
                                dominio(arbol[4]);
                                reino(arbol[4], arbol[5]);
                                division(arbol[5], arbol[6]);
                                clase(arbol[6], arbol[7]);
                                orden(arbol[7], arbol[8]);
                                familia(arbol[8], arbol[9]);
                                genero(arbol[9], arbol[10]);
                                especie(arbol[10], arbol[11]);
                                tipo(arbol[12]);
                                habito_crecimiento(arbol[13]);
                                altura_arbol(arbol[14]);
                                diametro(arbol[15]);
                                amplitud_copa(arbol[16]);
                                forma_copa(arbol[17]);
                                persistencia_Hoja(arbol[18]);
                                color_Flor(arbol[19]);
                                color_hoja(arbol[20]);
                                estacion_floracion(arbol[21]);
                                limitacion_arbol(arbol[22]);
                                limitacion_fruto(arbol[23]);
                                longevidad_arbol(arbol[24]);
                                piso_termico(arbol[25]);
                                luminocidad_arbol(arbol[26]);
                                funcion_arbol(arbol[27]);
                                $("#txaDescripcion").val(arbol[0]);




                                $.ajax({
                                    type: "POST",
                                    url: "../../../Services/Galeria_arbol/Service_Galeria_arbol.svc/Llamar_fotos_arboles",
                                    data: '{"idArbol":"' + arbol[0] + '"}',
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    async: false,
                                    processdata: true,
                                    success: function (Fotos) {
                                        var img = Fotos.Llamar_fotos_arbolesResult;

                                        $("#div").append("<output id=" + " out" + 0 + " class='out'><div id=" + " list" + 0 + " class='imagen'>  </div></output > ");
                                        $.each(img, function (index, imagen) {
                                            var input = $("#div output").length;
                                            var asa = input - 1;
                                            $("#list" + asa).append('<img class="thumb" id="im" src="' + imagen.foto_arbol + '" title="' + imagen.id_arbol + '"/> <img id="' + input + '" class="x"  src="../../../images/X-roja.png" />')
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
        <div class="modal-header"><span class="is-active"></span><span></span><span></span><span></span><span></span></div>
        <!-- Modal bodies-->
        <form class="modal-bodies">

            <div class="modal-body modal-body-step-1 is-showing">
                <ul></ul>
                <div class="title">Modificar Árbol</div>
                <div class="sub-title">Datos comunes y científicos</div>
                <div class="description">Aquí va toda la información que caracteriza a un árbol dependiendo de su tipo.</div>
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

                    <!--División:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlDivision">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>División:</span></label>
                    </div>
                    <!--Clase:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlClase">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Clase:</span></label>
                    </div>
                    <div class="text-center">
                        <a >
                            <input value="Siguiente" type="button" class="button next" /></a>
                    </div>
                </div>
            </div>

            <div class="modal-body modal-body-step-2">
                <div class="title">Datos comunes y científicos</div>
                <div class="description b">Aquí va toda la información que caracteriza a un árbol dependiendo de su tipo.</div>
                <div>
                    <!--Orden:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label b">
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
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label b">
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
                    <!--Tipo:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlTipo">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Tipo:</span></label>
                    </div>
                    <!--Estación de floracion:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlEstacionFl">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Estación de floración:</span></label>
                    </div>
                    <div class="text-center fade-in">
                        <a >
                            <input value="Atrás" type="button" class="button previous" /></a>
                        <a >
                            <input value="Siguiente" type="button" class="button next" /></a>
                    </div>
                </div>
            </div>

            <div class="modal-body modal-body-step-3">
                <div class="title">Característcas de árbol</div>
                <div class="description b">Aquí van las características comunes del árbol.</div>
                <div>
                    <!--Altura:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlAltura">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Altura:</span></label>
                    </div>
                    <!--Diámetro:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlDiametro">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Diámetro:</span></label>
                    </div>
                    <!--Amplitud copa:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlAmplitudC">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Amplitud copa:</span></label>
                    </div>
                    <!--Forma copa:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlFormaC">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Forma copa:</span></label>
                    </div>
                    <!--Habito de crecimiento:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlHabitoCrecimiento">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Hábito de crecimiento:</span></label>
                    </div>
                    <!--Persistencia hoja:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlPersistenciaH">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Persistencia hoja:</span></label>
                    </div>
                </div>
                <div class="text-center">
                    <a >
                        <input value="Atrás" type="button" class="button previous" /></a>
                    <a >
                        <input value="Siguiente" type="button" class="button next" /></a>
                </div>
            </div>

            <div class="modal-body modal-body-step-4">
                <div class="title">Característcas de árbol</div>
                <div class="description b">Aquí van las características comunes del árbol.</div>
                <div>
                    <!--Color flor:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlColorFlor">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Color flor:</span></label>
                    </div>
                    <!--Limitaciones árbol:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddLimitacionAr">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Limitaciones árbol:</span></label>
                    </div>
                    <!--Limitaciones de los frutos:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlLimitacionFru">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Limitaciones de los frutos:</span></label>
                    </div>
                    <!--Longevidad arbol:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlLongevidadA">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Longevidad arbol:</span></label>
                    </div>
                    <!--Piso térmico:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlPiso">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Piso térmico:</span></label>
                    </div>
                    <!--Funcion árbol:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlFuncionA">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Función árbol:</span></label>
                    </div>
                    <!--Color hojas:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlColorHojas">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Color hojas:</span></label>
                    </div>
                    <!--Luminocidad:-->
                    <div class="mdl-select mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlLuminocidad">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Luminocidad:</span></label>
                    </div>
                </div>
                <div class="text-center">
                    <a >
                        <input value="Atrás" type="button" class="button previous" /></a>
                    <a >
                        <input value="Siguiente" type="button" class="button next" /></a>
                </div>
            </div>

            <div class="modal-body modal-body-step-5">
                <div class="title">Cargar imágenes</div>
                <div class="description">Aquí se subirán las primeras imágenes del árbol.</div>
                <div id="div">
                </div>
                <label class="file">
                    <input type="file" class="aa" id="files" />
                    <i class=" "></i>Subir imagen
                </label>
                <div>
                    <p><span class="span">Descripción:</span></p>
                    <textarea id="txaDescripcion" name="Descripción" class="textarea"></textarea>
                </div>
                <div class="text-center">
                    <div class="button previous">Atrás</div>
                    <div class="button " id="btnGuardar">Guardar</div>
                </div>
            </div>
            
        </form>
    </div>
    <script src="../../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../../Script/pagRegist2.js"></script>
    <script src="../../../Script/icono.js"></script>
</asp:Content>
