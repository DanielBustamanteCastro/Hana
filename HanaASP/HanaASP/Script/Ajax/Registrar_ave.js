

$(document).ready(function () {
    $("input").focusout(function () {
        var campo = $(this).val();
        if (campo.length == 0) {
            mensajCampoVacio($(this).attr("name"));
        }
    });
    $("textarea").focusout(function () {
        var campo = $(this).val();
        if (campo.length == 0) {
            mensajCampoVacio($(this).attr("name"));
        }
    });


    var datos;

    $("#files").change(function (evt) {
        var input = $("#div output").length;
        if (input == 5) {
            swal(' ', 'No puedes agregar mas de 5 imagen!', 'info');
        } else {

            var tipo = 0;
            var file = $(this).val();
            var ext = file.substring(file.lastIndexOf("."));
            if (ext != ".jpg" && ext != ".png" && ext != ".jpeg") {
                swal('Oops...', 'No es una imagen!', 'error');
                tipo = 2;
                $(this).get(0).value = '';
                $(this).get(0).type = '';
                $(this).get(0).type = 'file';
            } else {
                tipo = 1;
            }
            if (tipo == 1) {
                var input = $("#div output").length;
                var files = evt.target.files;
                for (var i = 0, f; f = files[i]; i++) {
                    if (!f.type.match('image.*')) {
                        continue;
                    }
                    var reader = new FileReader();
                    reader.onload = (function (theFile) {
                        return function (e) {
                            // Insertamos la imagen
                            document.getElementById("list" + input).innerHTML = ['<img class="thumb" id="im" src="', e.target.result, '" title="', escape(theFile.name), '"/> <img id="' + input + '" class="x"  src="../../../images/X-roja.png" />'].join('');
                            document.getElementById(input).addEventListener("click", function () {
                                swal({
                                    title: 'Esta seguro que desea eliminar esta imagen?',
                                    type: 'warning',
                                    showCancelButton: true,
                                    confirmButtonColor: '#3085d6',
                                    cancelButtonColor: '#d33',
                                    confirmButtonText: 'Si, eliminar'
                                }).then(function () {
                                    $("#out" + input).remove();
                                    $("#files").get(0).value = '';
                                    $("#files").get(0).type = '';
                                    $("#files").get(0).type = 'file';
                                })
                            });
                        };
                    })(f);

                    reader.readAsDataURL(f);
                    input = input + 1;
                    $("#div").append("<output id=" + " out" + input + " class='out'><div id=" + " list" + input + " class='imagen'>  </div></output > ");


                }
            }


        }
    });

    $("#btnGuardar").click(function () {
        var permiso = 0;
        var input = $("#div output").length;
        if (input == 0) {
            swal('Oops...', 'Por favor ingresa almenos una foto', 'error');
        }
        else {
            var nombreCientifico = $("#txtNombreCientifico").val();
            var nombreComun = $("#txtNombreComun").val();
            var dominio = $("#ddlEspecie").val();
            var reino = $("#ddlReino").val();
            var division = $("#ddlFilum").val();
            var clase = $("#ddlClase").val();
            var orden = $("#ddlOrden").val();
            var familia = $("#ddlFamilia").val();
            var origen_ave = $("#ddlOrigen").val();
            var genero = $("#ddlGenero").val();
            var especie = $("#ddlEspecie").val();
            var tipo = $("#ddlTipo").val();
            var clase_dieta = $("#ddClase_dieta").val();
            var dieta = $("#ddlDieta").val();
            var comportamiento_ave = $("#ddlComportamiento_ave").val();
            var habitat = $("#ddlHabitat").val();
            var reproduccion = $("#ddlReproduccion").val();
            var colorplumaje = $("#ddlColorplumaje").val();
            var tamaño_ave = $("#ddlTamaño_ave").val();
            var descripcion = $("#txaDescripcion").val();
            if (nombreCientifico.length == 0 || nombreComun.length == 0 || dominio == 0 || reino == 0 || division == 0 || clase == 0 || orden == 0 || familia == 0 || genero == 0 || especie == 0
                || tipo == 0 || clase_dieta == 0 || dieta == 0 || comportamiento_ave == 0 || habitat == 0 || reproduccion == 0 || colorplumaje == 0 || tamaño_ave == 0 || descripcion.length == 0) {
                swal('Ooops...', 'Ningun campo puede estar vacio y/o no determinado', 'error');
            }
            else {
                $.ajax({
                    type: "POST",
                    url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Buscar_ave_con_nombreCientifico",
                    data: '{"nombreCientifico":"' + nombreCientifico + '"}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    processdata: true,
                    success: function (Mensaje) {
                        var mensaje = Mensaje.Buscar_ave_con_nombreCientificoResult;
                        if (mensaje == "Correcto") {
                            permiso = 1;
                        } else {
                            permiso = 0;
                            swal('Oops...', mensaje, 'error');
                        }

                    },
                    error: function (Mensaje) {
                        alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                    }

                });
                if (permiso == 1) {
                    alert("en el ajax con permiso");
                    alert(origen_ave);
                     $.ajax({
                        type: "POST",
                        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Insertar_ave",
                        data: '{"nombreComun":"' + nombreComun + '","nombreCientifico":"' + nombreCientifico + '","descripcion":"' + descripcion + '","tipo":"' + tipo + '","dieta":"' + dieta + '","clase_dieta":"' + clase_dieta + '","comportamiento":"' + comportamiento_ave + '","habitat":"' + habitat + '","reproduccion":"' + reproduccion + '","origen":"' + origen_ave + '","especie":"' + especie + '","color_plumaje":"' + colorplumaje + '","tamaño_ave":"' + tamaño_ave + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        processdata: true,
                        success: function (Mensaje) {
                            if (Mensaje.Insertar_arbolResult == "Insertado correctamente") {
                                permiso = permiso + 1;
                            }

                        },
                        error: function (Mensaje) {
                            alert('Error al llamar el servicion : ' + Mensaje.status + ' ' + Mensaje.statusText);
                        }

                    });
                    var image = [];
                    for (var i = 1; i < input + 1; i++) {
                        image[image.length] = $("#out" + i + " img").attr("src") + "~";

                    }



                    var jk = nombreCientifico;
                    var jka = nombreComun;
                    $.ajax({
                        type: "POST",
                        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Insertar_imagen_arbol",
                        data: '{"imagen":"' + image + '","nombreCientifico":"' + nombreCientifico + '","nombreComun":"' + nombreComun + '","especie":"' + especie + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        processdata: true,
                        success: function (Mensaje) {
                            if (Mensaje.Insertar_imagen_arbolResult == "Insertado correctamente" && permiso == 2) {
                                swal('', Mensaje.Insertar_imagen_arbolResult, 'success');
                                $("select").val(0);
                                $("input:text").val("");
                                $("textarea").val("");
                                $("output").remove();
                                $("#files").get(0).value = '';
                                $("#files").get(0).type = '';
                                $("#files").get(0).type = 'file';
                            } else {
                                swal('', 'Error al registrar', 'error')
                            }
                        },
                        error: function (Mensaje) {
                            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                        }

                    });
                }

            }

        }
    });
});
function mensajCampoVacio(campo) {
    //PNotify.prototype.options.styling = "bootstrap3";
    new PNotify({
        title: 'Advertencia!',
        text: 'El campo ' + campo + ' no puede estar vacío',
        type: 'info',
        delay: 2000,
        autoOpen: false,

    });
}

$(document).ready(function () {
    dominio();
    tipo();
    origen();
    clase_dieta();
    Comportamiento_ave();
    habitat_ave();
    reproducccion_ave();
    color_plumaje();
    tamaño_ave();


    $("#ddlDominio").on("change", function () {
        reino($(this).val());
    });
    $("#ddlReino").on("change", function () {
        filum($(this).val());
    });
    $("#ddlFilum").on("change", function () {
        clase($(this).val());
    });
    $("#ddlClase").on("change", function () {
        orden($(this).val());
    });
    $("#ddlOrden").on("change", function () {
        familia($(this).val());
    });
    $("#ddlFamilia").on("change", function () {
        genero($(this).val());
    });
    $("#ddlGenero").on("change", function () {
        especie($(this).val());
    });
    $("#ddClase_dieta").on("change", function () {
        dieta($(this).val());
    });
});

function dominio() {
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Dominio",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.DominioResult;
            $.each(item, function (index, Dominio) {
                $("#ddlDominio").append("<option value=" + Dominio.id_Dominio_ave + ">" + Dominio.Dominio_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }

    });
}
function reino(id_dominio) {
    $('#ddlReino').empty();
    $('#ddlReino').append("<option value='0'>No determinado</option>");
    $('#ddlFilum').empty();
    $('#ddlFilum').append("<option value='0'>No determinado</option>");
    $('#ddlClase').empty();
    $('#ddlClase').append("<option value='0'>No determinado</option>");
    $('#ddlOrden').empty();
    $('#ddlOrden').append("<option value='0'>No determinado</option>");
    $('#ddlFamilia').empty();
    $('#ddlFamilia').append("<option value='0'>No determinado</option>");
    $('#ddlGenero').empty();
    $('#ddlGenero').append("<option value='0'>No determinado</option>");
    $('#ddlEspecie').empty();
    $('#ddlEspecie').append("<option value='0'>No determinado</option>");
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Reino",
        data: '{"id_dominio": "' + id_dominio + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.ReinoResult;
            $.each(item, function (index, Reino) {
                $("#ddlReino").append("<option value=" + Reino.id_Reino_ave + ">" + Reino.Reino_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }

    });
}

function filum(id_reino) {
    $('#ddlFilum').empty();
    $('#ddlFilum').append("<option value='0'>No determinado</option>");
    $('#ddlClase').empty();
    $('#ddlClase').append("<option value='0'>No determinado</option>");
    $('#ddlOrden').empty();
    $('#ddlOrden').append("<option value='0'>No determinado</option>");
    $('#ddlFamilia').empty();
    $('#ddlFamilia').append("<option value='0'>No determinado</option>");
    $('#ddlGenero').empty();
    $('#ddlGenero').append("<option value='0'>No determinado</option>");
    $('#ddlEspecie').empty();
    $('#ddlEspecie').append("<option value='0'>No determinado</option>");
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Filum",
        data: '{"id_reino": "' + id_reino + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.FilumResult;
            $.each(item, function (index, Filum) {
                $("#ddlFilum").append("<option value=" + Filum.id_Filum_ave + ">" + Filum.Filum_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }

    });
}

function clase(id_filum) {
    $('#ddlClase').empty();
    $('#ddlClase').append("<option value='0'>No determinado</option>");
    $('#ddlOrden').empty();
    $('#ddlOrden').append("<option value='0'>No determinado</option>");
    $('#ddlFamilia').empty();
    $('#ddlFamilia').append("<option value='0'>No determinado</option>");
    $('#ddlGenero').empty();
    $('#ddlGenero').append("<option value='0'>No determinado</option>");
    $('#ddlEspecie').empty();
    $('#ddlEspecie').append("<option value='0'>No determinado</option>");
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Clase",
        data: '{"id_filum": "' + id_filum+'"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.ClaseResult;
            $.each(item, function (index, Clase) {
                $("#ddlClase").append("<option value=" + Clase.id_Clase_ave + ">" + Clase.Clase_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }

    });
}

function orden(id_clase) {
    $('#ddlOrden').empty();
    $('#ddlOrden').append("<option value='0'>No determinado</option>");
    $('#ddlFamilia').empty();
    $('#ddlFamilia').append("<option value='0'>No determinado</option>");
    $('#ddlGenero').empty();
    $('#ddlGenero').append("<option value='0'>No determinado</option>");
    $('#ddlEspecie').empty();
    $('#ddlEspecie').append("<option value='0'>No determinado</option>");
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Orden",
        data: '{"id_clase": "' + id_clase + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.OrdenResult;
            $.each(item, function (index, Orden) {
                $("#ddlOrden").append("<option value=" + Orden.id_Orden_ave + ">" + Orden.Orden_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }

    });
}

function familia(id_orden) {
    $('#ddlFamilia').empty();
    $('#ddlFamilia').append("<option value='0'>No determinado</option>");
    $('#ddlGenero').empty();
    $('#ddlGenero').append("<option value='0'>No determinado</option>");
    $('#ddlEspecie').empty();
    $('#ddlEspecie').append("<option value='0'>No determinado</option>");
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Familia",
        data: '{"id_orden": "' + id_orden + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.FamiliaResult;
            $.each(item, function (index, Familia) {
                $("#ddlFamilia").append("<option value=" + Familia.id_Familia_ave + ">" + Familia.Familia_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }

    });
}

function genero(id_familia) {
    $('#ddlGenero').empty();
    $('#ddlGenero').append("<option value='0'>No determinado</option>");
    $('#ddlEspecie').empty();
    $('#ddlEspecie').append("<option value='0'>No determinado</option>");
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Genero",
        data: '{"id_familia": "' + id_familia + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.GeneroResult;
            $.each(item, function (index, Genero) {
                $("#ddlGenero").append("<option value=" + Genero.id_Genero_ave + ">" + Genero.Genero_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }

    });
}

function especie(id_genero) {
    $('#ddlEspecie').empty();
    $('#ddlEspecie').append("<option value='0'>No determinado</option>");
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Especie",
        data: '{"id_genero": "' + id_genero + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.EspecieResult;
            $.each(item, function (index, Especie) {
                $("#ddlEspecie").append("<option value=" + Especie.id_Especie_ave + ">" + Especie.Especie_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }

    });
}

function origen() {
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Origen",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.OrigenResult;
            $.each(item, function (index, Origen) {
                $("#ddlOrigen").append("<option value=" + Origen.id_Origen_ave + ">" + Origen.Origen_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }

    });
}

function tipo() {
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Tipo",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.TipoResult;
            $.each(item, function (index, Tipo) {
                $("#ddlTipo").append("<option value=" + Tipo.id_Tipo_ave + ">" + Tipo.Tipo_ave + "</option>");
            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }

    });
}

function clase_dieta() {
    $('#ddlDieta').empty();
    $('#ddlDieta').append("<option value='0'>No determinado</option>");
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Clase_dieta",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.Clase_dietaResult;
            $.each(item, function (index, Clase_dieta) {
                $("#ddClase_dieta").append("<option value=" + Clase_dieta.id_Clase_dieta + ">" + Clase_dieta.Clase_dieta + "</option>");
            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }
    });
}

function dieta(idClase_dieta) {
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Dieta",
        data: '{"idClase_dieta":"' + idClase_dieta +'"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.DietaResult;
            $.each(item, function (index, Dieta) {
                $("#ddlDieta").append("<option value=" + Dieta.id_Dieta + ">" + Dieta.Dieta + "</option>");
            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }
    });
}
function Comportamiento_ave() {
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Comportamiento_ave",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.Comportamiento_aveResult;
            $.each(item, function (index, Comportamiento_ave) {
                $("#ddlComportamiento_ave").append("<option value=" + Comportamiento_ave.id_Comportamiento_ave + ">" + Comportamiento_ave.Comportamiento_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }
    });
}

function habitat_ave() {

    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Habitat_ave",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.Habitat_aveResult;
            $.each(item, function (index, Habitat_ave) {
                $("#ddlHabitat").append("<option value=" + Habitat_ave.id_Habitat_ave+ ">" + Habitat_ave.Habitat_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }
    });
}

function reproducccion_ave() {

    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Reproduccion_ave",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.Reproduccion_aveResult;
            $.each(item, function (index, Reproduccion_ave) {
                $("#ddlReproduccion").append("<option value=" + Reproduccion_ave.id_Reproduccion_ave + ">" + Reproduccion_ave.Reproduccion_ave + "</option>");
            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }
    });
}
function color_plumaje() {
    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Color_plumaje",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.Color_plumajeResult;
            $.each(item, function (index, Color_plumaje) {
                $("#ddlColorplumaje").append("<option value=" + Color_plumaje.id_Color_plumaje + ">" + Color_plumaje.Color_plumaje + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }
    });
}

function tamaño_ave() {

    $.ajax({
        type: "POST",
        url: "../../../Services/Registrar_ave/Service_Registrar_ave.svc/Tamaño_ave",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.Tamaño_aveResult;
            $.each(item, function (index, Tamaño_ave) {
                $("#ddlTamaño_ave").append("<option value=" + Tamaño_ave.id_Tamaño_ave + ">" + Tamaño_ave.Tamaño_ave + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }
    });

}


function validarLetras(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8 || tecla == 127 || tecla == 32) {
        return true;
    }
    patron = /^[a-zA-Z]+$/;
    tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);
}