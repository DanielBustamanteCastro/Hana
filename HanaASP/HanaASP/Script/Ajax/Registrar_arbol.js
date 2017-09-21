
 
$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "../../../../../../Services/Iniciar_sesion/Service_Iniciar_sesion.svc/Validar_sesion",
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
                }).then(function () { location.href = "../../index.aspx" });
            } if (img == "Usuario") {
                swal({
                    allowOutsideClick: false,
                    title: 'Tu rol no tiene acceso a esta seccion',
                    type: 'info'
                }).then(function () { location.href = "../../indexUsuario.aspx" });
            } else {
                $("input").focusout(function () {
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
                        if (ext != ".jpg" && ext != ".png" && ext != ".jpeg" && ext != ".JPG" && ext != ".PNG" && ext != ".JPEG") {
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
                        var dominio = $("#ddlDominio").val();
                        var reino = $("#ddlReino").val();
                        var division = $("#ddlDivision").val();
                        var clase = $("#ddlClase").val();
                        var orden = $("#ddlOrden").val();
                        var familia = $("#ddlFamilia").val();
                        var genero = $("#ddlGenero").val();
                        var especie = $("#ddlEspecie").val();
                        var tipo = $("#ddlTipo").val();
                        var habitoC = $("#ddlHabitoCrecimiento").val();
                        var altura = $("#ddlAltura").val();
                        var diametro = $("#ddlDiametro").val();
                        var amplitudC = $("#ddlAmplitudC").val();
                        var formaC = $("#ddlFormaC").val();
                        var persistenciaH = $("#ddlPersistenciaH").val();
                        var colorF = $("#ddlColorFlor").val();
                        var estacionFl = $("#ddlEstacionFl").val();
                        var limitacionAr = $("#ddLimitacionAr").val();
                        var limitacionFru = $("#ddlLimitacionFru").val();
                        var longevidadA = $("#ddlLongevidadA").val();
                        var piso = $("#ddlPiso").val();
                        var funcionA = $("#ddlFuncionA").val();
                        var colorH = $("#ddlColorHojas").val();
                        var luminocidad = $("#ddlLuminocidad").val();
                        var descripcion = $("#txaDescripcion").val();
                        if (nombreCientifico.length == 0 || nombreComun.length == 0 || dominio == 0 || reino == 0 || division == 0 || clase == 0 || orden == 0 || familia == 0 || genero == 0 || especie == 0
                            || tipo == 0 || habitoC == 0 || altura == 0 || diametro == 0 || amplitudC == 0 || formaC == 0 || persistenciaH == 0 || colorF == 0 || estacionFl == 0 || limitacionAr == 0 || limitacionFru == 0
                            || longevidadA == 0 || piso == 0 || funcionA == 0 || colorH == 0 || luminocidad == 0 || descripcion.length == 0) {
                            swal('Ooops...', 'Ningun campo puede estar vacio y/o no determinado', 'error');
                        }
                        else {
                            $.ajax({
                                type: "POST",
                                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Buscar_arbol",
                                data: '{"nombreCientifico":"' + nombreCientifico + '"}',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                async: false,
                                processdata: true,
                                success: function (Mensaje) {
                                    var mensaje = Mensaje.Buscar_arbolResult;
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

                                $.ajax({
                                    type: "POST",
                                    url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Insertar_arbol",
                                    data: '{"nombreComun":"' + nombreComun + '","nombreCientifico":"' + nombreCientifico + '","dominio":"' + dominio + '","reinio":"' + reino + '","division":"' + division + '","clase":"' + clase + '","orden":"' + orden + '","familia":"' + familia + '","genero":"' + genero + '","especie":"' + especie + '","tipo":"' + tipo + '","habitoC":"' + habitoC + '","altura":"' + altura + '","diametro":"' + diametro + '","amplitudC":"' + amplitudC + '","formaC":"' + formaC + '","persistenciaH":"' + persistenciaH + '","colorF":"' + colorF + '","estacionFl":"' + estacionFl + '","limitacionAr":"' + limitacionAr + '","limitacionFru":"' + limitacionFru + '","longevidad":"' + longevidadA + '","piso":"' + piso + '","funcionA":"' + funcionA + '","colorH":"' + colorH + '","luminocidad":"' + luminocidad + '","descripcion":"' + descripcion + '"}',
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
                                        alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
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
                                    url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Insertar_imagen_arbol",
                                    data: '{"imagen":"' + image + '","nombreCientifico":"' + nombreCientifico + '","nombreComun":"' + nombreComun + '","especie":"' + especie + '"}',
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    async: false,
                                    processdata: true,
                                    success: function (Mensaje) {
                                        if (Mensaje.Insertar_imagen_arbolResult == "Insertado correctamente" && permiso == 2) {
                                            swal('', Mensaje.Insertar_imagen_arbolResult, 'success').then(function () { location.href = "ResgistroArbol.aspx" });
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
            habito_crecimiento();
            altura_arbol();
            diametro();
            amplitud_copa();
            forma_copa();
            persistencia_Hoja();
            color_Flor();
            estacion_floracion();
            limitacion_arbol();
            limitacion_fruto();
            longevidad_arbol();
            piso_termico();
            luminocidad_arbol();
            funcion_arbol();
            color_hoja();

            

            $("#ddlDominio").on("change", function () {
                reino($(this).val());
            });
            $("#ddlReino").on("change", function () {
                division($(this).val());
            });
            $("#ddlDivision").on("change", function () {
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
        });

        function dominio() {
            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Dominio",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.DominioResult;
                    $.each(item, function (index, Dominio) {
                        $("#ddlDominio").append("<option value=" + Dominio.id_dominio_arbol + ">" + Dominio.dominio_arbol + "</option>");

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
            $('#ddlDivision').empty();
            $('#ddlDivision').append("<option value='0'>No determinado</option>");
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
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Reino",
                data: '{"id_dominio": "' + id_dominio + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.ReinoResult;
                    $.each(item, function (index, Reino) {
                        $("#ddlReino").append("<option value=" + Reino.id_reino_arbol + ">" + Reino.reino_arbol + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }

            });
        }

        function division(id_reino) {

            $('#ddlDivision').empty();
            $('#ddlDivision').append("<option value='0'>No determinado</option>");
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
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Division",
                data: '{"id_reino": "' + id_reino + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.DivisionResult;
                    $.each(item, function (index, Division) {
                        $("#ddlDivision").append("<option value=" + Division.id_division_arbol + ">" + Division.division_arbol + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }

            });
        }

        function clase(id_division) {
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
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Clase",
                data: '{"id_division": "' + id_division + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.ClaseResult;
                    $.each(item, function (index, Clase) {
                        $("#ddlClase").append("<option value=" + Clase.id_clase_arbol + ">" + Clase.clase_arbol + "</option>");

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
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Orden",
                data: '{"id_clase": "' + id_clase + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.OrdenResult;
                    $.each(item, function (index, Orden) {
                        $("#ddlOrden").append("<option value=" + Orden.id_Orden_arbol + ">" + Orden.Orden_arbol + "</option>");

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
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Familia",
                data: '{"id_orden": "' + id_orden + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.FamiliaResult;
                    $.each(item, function (index, Familia) {
                        $("#ddlFamilia").append("<option value=" + Familia.id_Familia_arbol + ">" + Familia.Familia_arbol + "</option>");

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
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Genero",
                data: '{"id_familia": "' + id_familia + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.GeneroResult;
                    $.each(item, function (index, Genero) {
                        $("#ddlGenero").append("<option value=" + Genero.id_Genero_arbol + ">" + Genero.Genero_arbol + "</option>");

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
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Especie",
                data: '{"id_genero": "' + id_genero + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.EspecieResult;
                    $.each(item, function (index, Especie) {
                        $("#ddlEspecie").append("<option value=" + Especie.id_especie_arbol + ">" + Especie.especie_arbol + "</option>");

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
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Tipo",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.TipoResult;
                    $.each(item, function (index, Tipo) {
                        $("#ddlTipo").append("<option value=" + Tipo.id_tipo_arbol + ">" + Tipo.Tipo_arbol + "</option>");
                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }

            });
        }

        function habito_crecimiento() {
            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Habito_crecimiento",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Habito_crecimientoResult;
                    $.each(item, function (index, Habito_crecimiento) {
                        $("#ddlHabitoCrecimiento").append("<option value=" + Habito_crecimiento.id_habito_crecimiento + ">" + Habito_crecimiento.habito_crecimiento + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });
        }

        function altura_arbol() {

            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Altura_arbol",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Altura_arbolResult;
                    $.each(item, function (index, Altura_arbol) {
                        $("#ddlAltura").append("<option value=" + Altura_arbol.id_altura_arbol + ">" + Altura_arbol.altura_arbol + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });
        }
        function diametro() {

            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Diametro_arbol",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Diametro_arbolResult;
                    $.each(item, function (index, Diametro_arbol) {
                        $("#ddlDiametro").append("<option value=" + Diametro_arbol.id_diametro_arbol + ">" + Diametro_arbol.diametro_arbol + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });
        }

        function amplitud_copa() {

            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Amplitud",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.AmplitudResult;
                    $.each(item, function (index, Amplitud) {
                        $("#ddlAmplitudC").append("<option value=" + Amplitud.id_amplitud + ">" + Amplitud.amplitud + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });
        }

        function forma_copa() {

            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Forma_copa",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Forma_copaResult;
                    $.each(item, function (index, forma) {
                        $("#ddlFormaC").append("<option value=" + forma.id_forma_copa + ">" + forma.forma_copa + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });
        }
        function persistencia_Hoja() {
            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Persistencia_Hoja",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Persistencia_HojaResult;
                    $.each(item, function (index, Persistencia_Hoja) {
                        $("#ddlPersistenciaH").append("<option value=" + Persistencia_Hoja.id_persistencia_hoja + ">" + Persistencia_Hoja.persistencia_hoja + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });
        }

        function color_Flor() {

            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Color_Flor",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Color_FlorResult;
                    $.each(item, function (index, Color_Flor) {
                        $("#ddlColorFlor").append("<option value=" + Color_Flor.id_clolor_flor + ">" + Color_Flor.color_flor + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });

        }
        function estacion_floracion() {

            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Estacion_floracion",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Estacion_floracionResult;
                    $.each(item, function (index, Estacion_floracion) {
                        $("#ddlEstacionFl").append("<option value=" + Estacion_floracion.id_estacion_floracion + ">" + Estacion_floracion.estacion_floracion + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });

        }
        function limitacion_arbol() {
            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Limitacion_arbol",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Limitacion_arbolResult;
                    $.each(item, function (index, Limitacion_arbol) {
                        $("#ddLimitacionAr").append("<option value=" + Limitacion_arbol.id_limitacion_arbol + ">" + Limitacion_arbol.limitacion_arbol + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });
        }
        function limitacion_fruto() {
            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Limitacion_fruto",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Limitacion_frutoResult;
                    $.each(item, function (index, Limitacion_fruto) {
                        $("#ddlLimitacionFru").append("<option value=" + Limitacion_fruto.id_limitacioin_fruto + ">" + Limitacion_fruto.limitacion_fruto + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });
        }
        function longevidad_arbol() {
            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Longevidad_arbol",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Longevidad_arbolResult;
                    $.each(item, function (index, Longevidad_arbol) {
                        $("#ddlLongevidadA").append("<option value=" + Longevidad_arbol.id_longevidad_arbol + ">" + Longevidad_arbol.longevidad_arbol + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });
        }

        function piso_termico() {
            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Piso_termico",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Piso_termicoResult;
                    $.each(item, function (index, Piso_termico) {
                        $("#ddlPiso").append("<option value=" + Piso_termico.id_piso_termico + ">" + Piso_termico.piso_termico + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });
        }

        function luminocidad_arbol() {

            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Luminocidad_arbol",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Luminocidad_arbolResult;
                    $.each(item, function (index, Luminocidad_arbol) {
                        $("#ddlLuminocidad").append("<option value=" + Luminocidad_arbol.id_luminocidad_arbol + ">" + Luminocidad_arbol.luminocidad_arbol + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });

        }

        function funcion_arbol() {

            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Funcion_arbol",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Funcion_arbolResult;
                    $.each(item, function (index, Funcion_arbol) {
                        $("#ddlFuncionA").append("<option value=" + Funcion_arbol.id_funcion_arbol + ">" + Funcion_arbol.funcion_arbol + "</option>");

                    });
                },
                error: function (Mensaje) {
                    alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
                }
            });
        }
        function color_hoja() {
            $.ajax({
                type: "POST",
                url: "../../../Services/Registrar_arbol/Service_Registrar_arbol.svc/Color_hoja",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                processdata: true,
                success: function (Mensaje) {
                    item = Mensaje.Color_hojaResult;
                    $.each(item, function (index, Color_hoja) {
                        $("#ddlColorHojas").append("<option value=" + Color_hoja.id_color_hoja + ">" + Color_hoja.color_hoja + "</option>");

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