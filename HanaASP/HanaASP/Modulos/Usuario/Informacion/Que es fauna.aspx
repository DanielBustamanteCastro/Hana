<%@ Page Title="¿Qué es fauna?" Language="C#" MasterPageFile="~/Modulos/MenuUsuario.master" AutoEventWireup="true" CodeBehind="Que es fauna.aspx.cs" Inherits="HanaASP.Modulos.Usuario.Informacion.Que_es_fauna" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Style/informacion.css" rel="stylesheet" />
    <link href="../../../Style/informacion.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery-3.1.1.js"></script>
    <script src="../../../Script/Sweetalert/sweetalert2.js"></script>
    <link href="../../../Style/Sweetalert/sweetalert2.css" rel="stylesheet" />
    <script>

        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "../../../Services/Iniciar_sesion/Service_Iniciar_sesion.svc/Validar_sesion",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                processdata: true,
                success: function (Fotos) {
                    var img = Fotos.Validar_sesionResult;
                    if (img == "No iniciado") {
                        swal({
                            allowOutsideClick: false,
                            title: 'Inicia sesión para poder ingresar aquí',
                            type: 'error'
                        }).then(function () { location.href = "../index.aspx" });
                    }
                }
                });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contInfo">
        <div class="info">
            <div class="titleInfo">¿QU&Eacute; ES FAUNA?</div>
            <div class="itemInfo">
                <div class="descInfo">La fauna es el conjunto de especies animales que habitan en una región geográfica, que son propias de un período geológico. Esta depende tanto de factores abióticos como de factores bióticos. Entre éstos sobresalen las relaciones posibles de competencia o de depredación entre las especies. Los animales suelen ser sensibles a las perturbaciones que alteran su hábitat; por ello, un cambio en la fauna de un ecosistema indica una alteración en uno o varios de los factores de este.</div>
            </div>
            <div class="itemInfo">
                <div class="subTitleInfo">Fauna silvestre o salvaje</div>
                <div class="descInfo">La fauna se divide en distintos tipos de acuerdo al origen geográfico de donde provienen las especies que habitan un ecosistema o biotopo. La fauna silvestre o salvaje es aquella que vive y no ha sido domesticada.</div>
            </div>
            <div class="itemInfo">
                <div class="subTitleInfo">Fauna en proceso de domesticación</div>
                <div class="descInfo">La fauna en proceso de domesticación, está integrada por aquellos animales silvestres, sean autóctonos, exóticos o importados, criados zootécnicamente bajo el dominio del hombre en zoo criaderos bajo condiciones de cautiverio o semicautiverio, que a través de las generaciones van perdiendo su carácter de salvajes para convertirse en domésticos y ser explotados con iguales fines que estos últimos. Se encuentran en este grupo poblaciones de coipo o nutria criolla, chinchilla, zorro plateado, visón, etc. Debido al hecho de que aún no pueden ser consideradas especies domésticas, tienen que ser encuadradas para su gestión como variedades de poblaciones silvestres manejadas mediante la zoocría y, por lo tanto, manejadas como especies silvestres de una determinada zona geográfica.</div>
            </div>
        </div>
    </div>
    <script src="../../../../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../../../../Script/icono.js"></script>
</asp:Content>
