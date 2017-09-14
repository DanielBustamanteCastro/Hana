<%@ Page Title="Galeria de aves" Language="C#" MasterPageFile="~/Modulos/MenuAdmin.master" AutoEventWireup="true" CodeBehind="GaleriaAves.aspx.cs" Inherits="HanaASP.Modulos.GaleriaAves" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Style/galeria/gallery.css" rel="stylesheet" />
    <link href="../../../Style/galeria/tooltip.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel='stylesheet prefetch' href='https://maxcdn.bootstrapcdn.com/font-awesome/4.6.3/css/font-awesome.min.css' />
    <script src="../../../Scripts/jquery-3.1.1.js"></script>
    <script src="../../../Script/Ajax/GaleriaAve.js"></script>
    <script>
        $(document).ready(function () {
            $("#imgModificar").click(function () {
                location.href = "../Modificar/ModificarAve.aspx?av=" + $("#mNombreCientifico").text() + "";
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <div>
        <input type="number" id="valor" placeholder="agregue cantidad" value="1000" />
        <button id="agregarAve">agregar ave</button>
    </div>--%>

    <!--PAGINACION-->
    <div class="carousel">
        <div id="carousel" class="list">
            <section id="Item1" class="item">

                <!--<div class="card card--big">
<div class="card__image" style="background-image: url(https://placeimg.com/640/480/nature)"></div>
<h2 class="card__title">Nombre cientifico</h2>
<p class="card__text">Nombre Comun</p>
<div class="card__action-bar">
<button class="card__button mas-info" >Mas información</button>
</div>
<div class="NombreComun"></div>
<div class="Especie"></div>
<div class="Familia"></div>
<div class="Dieta"></div>
<div class="Tipo"></div>
<div class="ColorPlumas"></div>
<div class="ColorPico"></div>
<div class="TamanoAve"></div>
<div class="Altura"></div>
<div class="NombreCientifico"></div>
<div class="Envergadura"></div>
<div class="Clase"></div>
<div class="Endemica"></div>
<div class="Dominio"></div>
<div class="Reino"></div>
<div class="TemporadaApareamiento"></div>
<div class="Genero"></div>
<div class="TemporadaMigración"></div>
<div class="Filo"></div>
<div class="Orden"></div>
<div class="Longevidad"></div>
<div class="stadoConservacion"></div>
<div class="HabitadAmenazado"></div>
</div>-->
            </section>
        </div>

        <nav class="pagination">
            <nav class="buttons">
                <a aria-controls="carousel" class="prev a2"></a>
                <a aria-controls="carousel" class="next a1"></a>
                <a aria-controls="carousel" class="next btnnext p1"></a>
                <a aria-controls="carousel" class="prev btnprev p2"></a>

            </nav>
            <section class="wrap">
                <div align="center">
                    <ol>
                        <li class="js-carousel-pagItem"></li>
                    </ol>
                </div>
            </section>
        </nav>
    </div>

    <div class="modal todo">
        <div class="w50 bg">
            <div class="contImage">
                <img id="imagen" src="">
            </div>
            <div class="hi-icon-wrap hi-icon-effect-8">
                <div class="contIcon" tooltip="Galeria" flow="down">
                    <div id="SVGgaleria" class="hi-icon">
                        <%--<object data="../../../images/svg/galeria.svg"></object>--%>
                        <img src="../../../images/svg/galeria.png" alt="Galeria" />
                    </div>
                </div>
                <div class="contIcon" tooltip="Favorito" flow="down">
                    <div id="SVGfavorito" class="hi-icon">
                        <%--<object data="../../../images/svg/estrella.svg"></object>--%>
                        <img src="../../../images/svg/estrella.png" alt="Estrella" />
                    </div>
                </div>
                <div class="contIcon" tooltip="Modificar" flow="down">
                    <div id="SVGmodificar" class="hi-icon" >
                        <%--<object data="../../../images/svg/editar.svg" ></object>--%>
                        <img src="../../../images/svg/Editar.png" alt="Editar" id="imgModificar" />
                    </div>
                </div>
                <div class="contIcon" tooltip="Ubicacion" flow="down">
                    <div id="SVGubicacion" class="hi-icon">
                        <%--<object data="../../../images/svg/ubicacion.svg"></object>--%>
                        <img src="../../../images/svg/Ubicacion.png" alt="Ubicación" />
                    </div>
                </div>
            </div>
        </div>
        <div class="w50 info">
            <!--Datos comunes-->
            <div class="tarjet">
                <span class="title">Datos Comunes</span>
                <div class="data">
                    <table>
                        <tr>
                            <td>
                                <span>Nombre Común:</span><div id="mNombreComun"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Especie:</span><div id="mEspecie"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Familia:</span><div id="mFamilia"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Clase de dieta:</span><div id="mClaseDieta"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Dieta:</span><div id="mDieta"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Tipo:</span><div id="mTipo"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Origen:</span><div id="mOrigen"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Havbitat:</span><div id="mHabitat"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Descripción:</span><div id="mDescripcion"></div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

            <!--Caracteristicas-->
            <div class="tarjet">
                <span class="title">Caracteristicas</span>
                <div class="data">
                    <table>
                        <tr>
                            <td>
                                <span>Color de plumas:</span><div id="mColorPlumaje"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Tamaño ave:</span><div id="mTamanoAve"></div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <!--Datos cientificos-->
            <div class="tarjet tar1">
                <span class="title">Datos Cientificos</span>
                <div class="data">
                    <table>
                        <tr>
                            <td>
                                <span>Nombre Científico:</span><div id="mNombreCientifico"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Filum:</span><div id="mFilum"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Clase:</span><div id="mClase"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Dominio:</span><div id="mDominio"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Reino:</span><div id="mReino"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Género:</span><div id="mGenero"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Orden:</span><div id="mOrden"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Comportamiento:</span><div id="mComportamiento"></div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <span>Reproducción:</span><div id="mReproduccion"></div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <div class="closebtn fa fa-times"></div>
    </div>
    <script src="../../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../../Script/icono.js"></script>
    <script src="../../../Script/galeria/gallery.js"></script>
    <script src="../../../Script/galeria/boton(ajax).js"></script>
    <script src="../../../Script/galeria/OndulationButton.js"></script>
</asp:Content>
