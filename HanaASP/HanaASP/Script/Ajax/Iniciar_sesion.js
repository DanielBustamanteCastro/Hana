$(document).ready(function () {
    $('#btnIniciarS').on('click', function () {
        var Correo1 = $('#txtCorreo').val();
        var Contraseña1 = $('#txtContraseña').val();
        if (Correo1.length == 0 || Contraseña1.length==0) {
            camposVacio();
        } else {
            ajax(Correo1,Contraseña1);
        }

    });
    $("#txtCorreo").focusout(function () {
        caracteresCorreoValido($(this).val());
    });


    $("input").focusout(function () {
        var campo = $(this).val();
        if (campo.length == 0) {
            mensajCampoVacio($(this).attr("name"));
        }
    });
});

function ajax(Correo1,Contraseña1) {
    $.ajax({
        type: "POST",
        url: "../Services/Iniciar_sesion/Service_Iniciar_sesion.svc/Iniciar_sesion",
        data: '{"Correo": "' + Correo1 + '","Contraseña":"' + Contraseña1 + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.Iniciar_sesionResult;
            $('#txtContraseña').val('');
            if (item=="Usuario") {
                location.href = "indexUsuario.aspx";
            }
            if (item == "Administrador") {
                location.href = "indexAdmin.aspx";
            }

            swal(item);
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + ' ' + Mensaje.statusText);
        }

    });
}

function camposVacio(){
        sweetAlert("Oops...", "Ningún puede estar vacío", "error");
        sweetAlert({
            title: "Ningún campo puede estar vacío",
            type:"error",
            timer: 3000,
            showConfirmButton: false
        });
    }

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

function caracteresCorreoValido(email) {
    var caract = new RegExp(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/);
    if (email.length == 0) {
        $("#correo").html('');
    }
    else {
        if (caract.test(email) == false) {
            $("#correo").html('Correo no valido');
            $("#btnIniciarS").prop("disabled", true);
            return false;
        } else {
            $("#correo").html('');
            $("#btnIniciarS").prop("disabled", false);

            return true;
        }
    }
}