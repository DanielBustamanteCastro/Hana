﻿$(document).ready(function () {
    $.ajax({
        type: "POST",
        url: "../../../Services/Perfil/Service_Perfil.svc/Cargar_perfil",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: false,
        processdata: true,
        success: function (Fotos) {
            var img = Fotos.Cargar_perfilResult;
            $("#lblNombre").text(img[3]);
            $("#lblApellido").text(img[4]);
            $("#lblFechaNacimiento").text(img[5]);
            $("#lblCorreo").text(img[7]);
            $("#lblMunicipio").text(img[8]);
        }
    });

    $("#aCambioContraseña").click(function () {
        
            swal.setDefaults({
                input: 'password',
                confirmButtonText: 'Siguiente &rarr;',
                showCancelButton: true,
                animation: false,
                progressSteps: ['1', '2', '3']
            })

            var steps = [
                {
                    title: 'Ingresa la antigua contraseña'
                },
                'Ingresa la nueva contraseña',
                'Repite la nueva contraseña'
            ]

            swal.queue(steps).then(function (result) {
                swal.resetDefaults();
                alert(result[0] + " " + result[1] + " " + result[2] + " ");
                if (result[1] == result[2]) {
                    $.ajax({
                        type: "POST",
                        url: "../../../Services/Perfil/Service_Perfil.svc/Validar_usuario",
                        data: '{"Contraseña":"' + result[0] + '","Correo":"' + $("#lblCorreo").html() + '"}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        async: false,
                        processdata: true,
                        showLoaderOnConfirm: true,
                        success: function (Fotos) {
                            var img = Fotos.Validar_usuarioResult;
                            if (img=="Existe") {
                                $.ajax({
                                    type: "POST",
                                    url: "../../../Services/Perfil/Service_Perfil.svc/Cambiar_contraseña",
                                    data: '{"Antigua":"' + result[0] + '","Nueva":"' + result[1] + '"}',
                                    contentType: "application/json; charset=utf-8",
                                    dataType: "json",
                                    async: false,
                                    processdata: true,
                                    success: function (Fotos) {
                                        var img = Fotos.Cambiar_contraseñaResult;
                                        if (img =="Modificado correctamenre") {
                                            swal('',img,'success')
                                        }
                                        else {
                                            swal('', img, 'error');
                                        }
                                    }
                                });
                            }
                            else {
                                swal('', img, 'error');
                            }
                        }
                    });
                } if (result[1]!=result[2]) {
                    swal({
                        title: 'La nueva contraseña no coinciden',
                        confirmButtonText: 'Okay!',
                        type: 'error',
                    });
                }
            }, function () {
                swal.resetDefaults();
                alert();
            })
        
    });
    
});