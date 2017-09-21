$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "../../Services/Iniciar_sesion/Service_Iniciar_sesion.svc/Validar_sesion",
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
            } else {

    $.ajax({
        type: "POST",
        url: "../../../Services/Favoritos_ave/Service_Favoritos_ave.svc/Cargar_favoritos",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (Aves) {
            var Ave = Aves.Cargar_favoritosResult;
            var cont = 6;
            var sec = 1;
            var cant;
            var Foto;
            $.each(Ave, function (index, item) {
                $.ajax({
                    type: "POST",
                    url: "../../../Services/Galeria_ave/Service_Galeria_ave.svc/Llamar_fotos_aves",
                    data: '{"idAve":"' + item[0] + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    processdata: true,
                    success: function (Fotos) {
                        var img = Fotos.Llamar_fotos_avesResult;
                        $.each(img, function (index, item) {
                            Foto = item.Fotos_aves;
                        });
                    }
                });

                var NombreComun = item["2"];
                var Especie = item["12"];
                var Familia = item["10"];
                var Dieta = item["15"];
                var Tipo = item["14"];
                var ColorPlumaje = item["19"];
                var Origen = item["13"];
                var TamanoAve = item["20"];
                var ClaseDieta = item["21"];
                var NombreCientifico = item["1"];
                var Comportamiento = item["16"];
                var Clase = item["8"];
                var Habitat = item["17"];
                var Dominio = item["5"];
                var Reino = item["6"];
                var Reproduccion = item["18"];
                var Genero = item["11"];
                var Descripcion = item["3"];
                var Filum = item["7"];
                var Orden = item["9"];

                /*Agregar clases con sus valores*/

                $('#Item' + sec).append('<div id="' + item[0] + '" class="card card--big"><div class="card__image" style="background-image: url(' + Foto + ')"></div><h2 class="card__title">' + NombreCientifico + '</h2><p class="card__text">' + NombreComun + '</p><div class="card__action-bar"><button class="card__button mas-info" >Mas información</button></div><div class="informat"><div class="NombreComun">' + NombreComun + '</div><div class="Especie">' + Especie + '</div><div class="Familia">' + Familia + '</div><div class="Dieta">' + Dieta + '</div><div class="Tipo">' + Tipo + '</div><div class="Origen">' + Origen + '</div><div class="TamanoAve">' + TamanoAve + '</div><div class="ClaseDieta">' + ClaseDieta + '</div><div class="NombreCientifico">' + NombreCientifico + '</div><div class="Comportamiento">' + Comportamiento + '</div><div class="Clase">' + Clase + '</div><div class="Habitat">' + Habitat + '</div><div class="Dominio">' + Dominio + '</div><div class="Reino">' + Reino + '</div><div class="Reproduccion">' + Reproduccion + '</div><div class="Genero">' + Genero + '</div><div class="Descripcion">' + Descripcion + '</div><div class="Filum">' + Filum + '</div><div class="Orden">' + Orden + '</div><div class="ColorPlumaje">' + ColorPlumaje + '</div><div id="asdf">' + item[0] + '</div></div></div>');

                /*Crear seccion*/
                cant = $('.card').length;
                if (cant == cont) {
                    sec = sec + 1;
                    $('#carousel').append('<section id="Item' + sec + '" class="item"></section>');
                }
                if (cant == cont + 1) {
                    cont = cont + 6;
                    /*Crear paginacion segun numeros de secciones*/
                    $('.wrap ol').append('<li class="js-carousel-pagItem"></li>');
                    $('.pagination').css('display', 'flex');
                }
            });
            action();
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + '' + Mensaje.statusText);
        }
    });
    $("#SVGEliminar").click(function () {
        var nombreCientifico = $("#mNombreCientifico").text();
        swal({
            title: 'Esta seguro que desea eliminarlo de favoritos?',
            type: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si'
        }).then(function () {
            $.ajax({
                type: "POST",
                url: "../../../Services/Favoritos_ave/Service_Favoritos_ave.svc/Eliminar_favoritos",
                data: '{"nombreCientifico":"' + nombreCientifico + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                processdata: true,
                success: function (Mensaje) {
                    var mensaje = Mensaje.Eliminar_favoritosResult;
                    if (mensaje == "Eliminado correctamente") {
                        swal('', mensaje, 'success').then(function () {
                            location.href = "Favorito ave.aspx"; });

                    }
                    else {
                        swal('', mensaje, 'error');
                    }

                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }

            });
        })
    })
}
        }
    });
});