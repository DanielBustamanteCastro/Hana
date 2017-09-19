$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "../../../Services/Favoritos_arbol/Service_Favoritos_arbol.svc/Cargar_favoritos",
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
                    url: "../../../Services/Galeria_arbol/Service_Galeria_arbol.svc/Llamar_fotos_arboles",
                    data: '{"idArbol":"' + item[29] + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    processdata: true,
                    success: function (Fotos) {
                        var img = Fotos.Llamar_fotos_arbolesResult;
                        $.each(img, function (index, item) {
                            Foto = item.foto_arbol;
                        });
                    },
                    error: function (Mensaje) {
                        alert('Error al llamar el servicio : ' + Mensaje.status + '' + Mensaje.statusText);

                    }
                });
                /*Definicion de Valores*/
                var NombreComun = item[1];
                var Especie = item[11];
                var Familia = item[9];
                var Tipo = item[12];
                var ColorHojas = item[20];
                var Altura = item[14];
                var NombreCientifico = item[2];
                var Clase = item[7];
                var Dominio = item[4];
                var Reino = item[5];
                var Genero = item[10];
                var Division = item[6];
                var Orden = item[8];
                var LongevidadArbol = item[24];
                var LimitacionesFrutos = item[23];
                var FormaCopa = item[17];
                var AmplitudCopa = item[16];
                var Diametro = item[15];
                var PersistenciaHoja = item[18];
                var EstacionFloracion = item[21];
                var LimitacionesArbol = item[22];
                var PisoTermico = item[25];
                var Luminocidad = item[26];
                var ColorFlor = item[19];
                var HabitoCrecimiento = item[13];
                var Descripcion = item[0];
                var FuncionArbol = item[27];
                /*Agregar clases con sus valores*/

                $('#Item' + sec).append('<div id="' + item[29] + '" class="card card--big"><div class="card__image" style="background-image: url(' + Foto + '"></div><h2 class="card__title">' + NombreCientifico + '</h2><p class="card__text">' + NombreComun + '</p><div class="card__action-bar"><button class="card__button mas-info" >Mas información</button></div><div class="informat"><div class="NombreComun">' + NombreComun + '</div><div class="Especie">' + Especie + '</div><div class="Familia">' + Familia + '</div><div class="Tipo">' + Tipo + '</div><div class="ColorHojas">' + ColorHojas + '</div><div class="Altura">' + Altura + '</div><div class="NombreCientifico">' + NombreCientifico + '</div><div class="Clase">' + Clase + '</div><div class="Dominio">' + Dominio + '</div><div class="Reino">' + Reino + '</div><div class="Genero">' + Genero + '</div><div class="Division">' + Division + '</div><div class="Orden">' + Orden + '</div><div class="LongevidadArbol">' + LongevidadArbol + '</div><div class="LimitacionesFrutos">' + LimitacionesFrutos + '</div><div class="FormaCopa">' + FormaCopa + '</div><div class="AmplitudCopa">' + AmplitudCopa + '</div><div class="Diametro">' + Diametro + '</div><div class="PersistenciaHoja">' + PersistenciaHoja + '</div><div class="EstacionFloracion">' + EstacionFloracion + '</div><div class="LimitacionesArbol">' + LimitacionesArbol + '</div><div class="PisoTermico">' + PisoTermico + '</div><div class="Luminocidad">' + Luminocidad + '</div><div class="ColorFlor">' + ColorFlor + '</div><div class="HabitoCrecimiento">' + HabitoCrecimiento + '</div><div class="Descripcion">' + Descripcion + '</div><div class="FuncionArbol">' + FuncionArbol + '</div></div></div>');

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
                url: "../../../Services/Favoritos_arbol/Service_Favoritos_arbol.svc/Eliminar_favoritos",
                data: '{"nombreCientifico":"' + nombreCientifico + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                processdata: true,
                success: function (Mensaje) {
                    var mensaje = Mensaje.Eliminar_favoritosResult;
                    if (mensaje == "Eliminado correctamente") {
                        swal('', mensaje, 'success');

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
});