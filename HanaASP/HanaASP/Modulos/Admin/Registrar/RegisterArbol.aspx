<%@ Page Title="" Language="C#" MasterPageFile="~/Modulos/MenuAdmin.master" AutoEventWireup="true" CodeBehind="RegisterArbol.aspx.cs" Inherits="HanaASP.Modulos.Admin.RegisterAve" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registro Arbol</title>
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
    <script src="../../../Script/Ajax/Registrar_arbol.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div align="center">
        <form class="form" runat="server">
            <h1>REGISTRO ARBOL</h1>
            
            <br />
    <div id="div">
         </div>
 
   
     <label class="file">
    <input type="file" class="aa"  id="files"/>
    <i class=" "></i> Subir imagen
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
                    <input id="txtNombreComun" class="input" required="required" name="Nombre comun" onkeypress="return validarLetras(event)"/>
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
                <!--Division:-->
                <div class="sel b" align="left">
                    <span class="span">División:</span>
                    <select id="ddlDivision">
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
                <!--Tipo:-->
                <div class="sel b" align="left">
                    <span class="span">Tipo:</span>
                    <select id="ddlTipo">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Habito de crecimiento:-->
                <div class="sel b" align="left">
                    <span class="span">Habito de crecimiento:</span>
                    <select id="ddlHabitoCrecimiento">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Altura:-->
                <div class="sel b" align="left">
                    <span class="span">Altura:</span>
                    <select id="ddlAltura">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Diámetro:-->
                <div class="sel" align="left">
                    <span class="span">Diámetro:</span>
                    <select id="ddlDiametro">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                 <!--Amplitud copa:-->
                <div class="sel" align="left">
                    <span class="span">Amplitud copa:</span>
                    <select id="ddlAmplitudC">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                 <!--Forma copa:-->
                <div class="sel" align="left">
                    <span class="span">Forma copa:</span>
                    <select id="ddlFormaC">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Persistencia hoja:-->
                <div class="sel" align="left">
                    <span class="span">Persistencia hoja:</span>
                    <select id="ddlPersistenciaH">
                        <option value="0">No determinado</option>
                    </select>
                </div>     
                <!--Color flor:-->
                <div class="sel" align="left">
                    <span class="span">Color flor:</span>
                    <select id="ddlColorFlor">
                        <option value="0">No determinado</option>
                    </select>
                </div>   
                <!--Estacion de floracion:-->
                <div class="sel" align="left">
                    <span class="span">Estación de floracion:</span>
                    <select id="ddlEstacionFl">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Limitaciones arbol:-->
                <div class="sel" align="left">
                    <span class="span">Limitaciones árbol:</span>
                    <select id="ddLimitacionAr">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Limitaciones de los frutos:-->
                <div class="sel" align="left">
                    <span class="span">Limitaciones  frutos:</span>
                    <select id="ddlLimitacionFru">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Longevidad arbol:-->
                <div class="sel" align="left">
                    <span class="span">Longevidad árbol:</span>
                    <select id="ddlLongevidadA">
                        <option value="0">No determinado</option>
                    </select>
                </div>                
                <!--Piso térmico:-->
                <div class="sel" align="left">
                    <span class="span">Piso térmico:</span>
                    <select id="ddlPiso">
                        <option value="0">No determinado</option>
                    </select>
                </div>
                <!--Funcion arbol:-->
                <div class="sel b" align="left">
                    <span class="span">Funcion árbol:</span>
                    <select id="ddlFuncionA">
                        <option value="0">No determinado</option>
                    </select>
                </div>      
                <!--Color hojas:-->
                <div class="sel" align="left">
                    <span class="span">Color hojas:</span>
                    <select id="ddlColorHojas">
                        <option value="0">No determinado</option>
                    </select>
                </div>

            
                <!--Luminocidad:-->
                <div class="sel" align="left">
                    <span class="span">Luminocidad:</span>
                    <select id="ddlLuminocidad">
                        <option value="0">No determinado</option>
                    </select>
                </div>
        
      
                <!--Descripción:-->
                <div class="sel textarea">
                    <p align="left"><span class="span">Descripción:</span></p>
                    <textarea type="text" id="txaDescripcion" class="textarea"></textarea>
                </div>
                <input type="button" class="button-three"  value="Guardar" id="btnGuardar" />
            </div>
        </form>
    </div>
    <script src="../../Frameworks/js/jquery-3.1.1.min.js"></script>
    <script src="../../Script/regis.js"></script>
    <script src="../../Script/file.js"></script>
</asp:Content>
