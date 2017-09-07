<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/MenuAdmin.master" AutoEventWireup="true" CodeBehind="RegistrarAve.aspx.cs" Inherits="HanaASP.Modulos.Admin.Registrar.RegistrarAve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro Ave</title>
    <link href="../../../Style/formsAveArbol.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery-3.1.1.js"></script>
    <script src="../../../Script/Sweetalert/sweetalert2.js"></script>
    <script src="../../../Script/PNotify/pnotify.custom.min.js"></script>
    <link href="../../../Style/PNotify/pnotify.custom.min.css" rel="stylesheet" />
    <link href="../../../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <style>
        #mainheader {
            margin-top: -35px;
        }
    </style>
    <script src="../../../Script/Ajax/Registrar_ave.js"></script>
    <script>
       
    </script>
    <style>
    

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <form class="form" runat="server">
            <h1>REGISTRO AVE</h1>

            <br />
            <div id="div">
            </div>


            <label class="file">
                <input type="file" class="aa" id="files" />
                <i class=" "></i>Subir imagen
            </label>
            <p class="file-return"></p>
            <div class="cont">
                <!--Nombre Científico:-->
                <div class="group a b">
                    <input id="txtNombreCientifico" class="input" required="required" name="Nombre cientifico" onkeypress="return validarLetras(event)" />
                    <span class="highlight"></span>
                    <span class="bar"></span>
                    <label class="label">Nombre Científico:</label>
                </div>
                <!--Nombre Común:-->
                <div class="group a">
                    <input id="txtNombreComun" class="input" required="required" name="Nombre comun" onkeypress="return validarLetras(event)" />
                    <span class="highlight"></span>
                    <span class="bar"></span>
                    <label class="label">Nombre Común:</label>
                </div>
                <!--Dominio:-->
                <div class="sel b" align="left">
                    <span class="span">Dominio:</span>
                    <select id="ddlDominio">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Reino:-->
                <div class="sel b" align="left">
                    <span class="span">Reino:</span>
                    <select id="ddlReino">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Filum:-->
                <div class="sel b" align="left">
                    <span class="span">Filum:</span>
                    <select id="ddlFilum">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Clase:-->
                <div class="sel b" align="left">
                    <span class="span">Clase:</span>
                    <select id="ddlClase">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Orden:-->
                <div class="sel b" align="left">
                    <span class="span">Orden:</span>
                    <select id="ddlOrden">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Familia:-->
                <div class="sel b" align="left">
                    <span class="span">Familia:</span>
                    <select id="ddlFamilia">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Género:-->
                <div class="sel b" align="left">
                    <span class="span">Género:</span>
                    <select id="ddlGenero">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Especie:-->
                <div class="sel b" align="left">
                    <span class="span">Especie:</span>
                    <select id="ddlEspecie">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Origen:-->
                <div class="sel b" align="left">
                    <span class="span">Origen:</span>
                    <select id="ddlOrigen">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Tipo:-->
                <div class="sel b" align="left">
                    <span class="span">Tipo:</span>
                    <select id="ddlTipo">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Clase de dieta:-->
                <div class="sel b" align="left">
                    <span class="span">Clase de dieta:</span>
                    <select id="ddClase_dieta">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Dieta:-->
                <div class="sel" align="left">
                    <span class="span">Dieta:</span>
                    <select id="ddlDieta">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Comportamiento:-->
                <div class="sel" align="left">
                    <span class="span">Comportamiento:</span>
                    <select id="ddlComportamiento_ave">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Habitat:-->
                <div class="sel" align="left">
                    <span class="span">Habitat:</span>
                    <select id="ddlHabitat">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Reproduccion:-->
                <div class="sel" align="left">
                    <span class="span">Reproducción:</span>
                    <select id="ddlReproduccion">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Color plumaje:-->
                <div class="sel" align="left">
                    <span class="span">Color plumaje:</span>
                    <select id="ddlColorplumaje">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Tamaño ave:-->
                <div class="sel" align="left">
                    <span class="span">Tamaño ave:</span>
                    <select id="ddlTamaño_ave">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <

                <!--Descripción:-->
                <div class="sel textarea">
                    <p align="left"><span class="span">Descripción:</span></p>
                    <textarea type="text" id="txaDescripcion" name="Descripción" class="textarea"></textarea>
                </div>
                <input type="button" class="button-three" value="Guardar" id="btnGuardar" />
            </div>
        </form>
    </div>
    <script src="../../Frameworks/js/jquery-3.1.1.min.js"></script>
    <script src="../../Script/regis.js"></script>
    <script src="../../Script/file.js"></script>
</asp:Content>
