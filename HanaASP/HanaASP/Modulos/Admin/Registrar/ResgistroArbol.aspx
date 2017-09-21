<%@ Page Title="Registro Arbol" Language="C#" MasterPageFile="~/Modulos/MenuAdmin.master" AutoEventWireup="true" CodeBehind="ResgistroArbol.aspx.cs" Inherits="HanaASP.Modulos.Admin.Registrar.ResgistroAve2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../../Style/formsAveArbol3.css" />
    <script src="../../../Scripts/jquery-3.1.1.js"></script>
    <script src="../../../Script/Sweetalert/sweetalert2.js"></script>
    <script src="../../../Script/PNotify/pnotify.custom.min.js"></script>
    <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css' />
    <link href="../../../Style/PNotify/pnotify.custom.min.css" rel="stylesheet" />
    <link href="../../../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <script src="https://storage.googleapis.com/code.getmdl.io/1.0.1/material.min.js"></script>
    <script src="../../../Script/Ajax/Registrar_arbol.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="modal-wrap">
        <!-- Modal header - contains the pagination-->
        <div class="modal-header"><span class="is-active"></span><span></span><span></span><span></span><span></span></div>
        <!-- Modal bodies-->
        <form class="modal-bodies">

            <div class="modal-body modal-body-step-1 is-showing">
                <ul></ul>
                <div class="title">Registro Árbol</div>
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
                        <a href="#">
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
                        <a href="#">
                            <input value="Atrás" type="button" class="button previous" /></a>
                        <a href="#">
                            <input value="Siguiente" type="button" class="button next" /></a>
                    </div>
                </div>
            </div>

            <div class="modal-body modal-body-step-3">
                <div class="title">Características de árbol</div>
                <div class="description b">Aquí van las características comunes del ábol.</div>
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
                        <label class="mdl-select__label"><span>Habito de crecimiento:</span></label>
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
                    <a href="#">
                        <input value="Atrás" type="button" class="button previous" /></a>
                    <a href="#">
                        <input value="Siguiente" type="button" class="button next" /></a>
                </div>
            </div>

            <div class="modal-body modal-body-step-4">
                <div class="title">Características de árbol</div>
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
                        <label class="mdl-select__label"><span>Longevidad árbol:</span></label>
                    </div>
                    <!--Piso térmico:-->
                    <div class="mdl-select b mdl-js-select mdl-select--floating-label">
                        <select class="mdl-select__input" id="ddlPiso">
                            <option value="0">No determinado</option>
                        </select>
                        <label class="mdl-select__label"><span>Piso térmico:</span></label>
                    </div>
                    <!--Funcion arbol:-->
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
                        <label class="mdl-select__label"><span>Luminosidad:</span></label>
                    </div>
                </div>
                <div class="text-center">
                    <a href="#">
                        <input value="Atrás" type="button" class="button previous" /></a>
                    <a href="#">
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
