$(document).ready(function () {
    cargarMunicipios();
    $("input").focusout(function () {
        var campo = $(this).val();
        if (campo.length == 0) {
            mensajCampoVacio($(this).attr("name"));
        }
    });

    $("#txtCorreo").focusout(function () {
        caracteresCorreoValido($(this).val());
    });

    $("#txtContraseña ,#txtConfrirmar").focusout(function () {
        compraraContraseñas();
    });
    //$("#txtFecha").glDatePicker(
    //    {
    //        prevArrow: '',
    //        nextArrow: '',
    //        selectedDate: new Date(),
    //        selectableDateRange: [
    //            {
    //                from: new Date(1900, 8, 10),
    //                to: new Date()
    //            },
    //        ]
    //    });
    $("#btnRegistrar").click(function () {
        var Nombre = $("#txtNombre").val();
        var Fecha = $("#txtFecha").val();
        var Contraseña = $("#txtContraseña").val();
        var Apellido = $("#txtApellido").val();
        var Correo = $("#txtCorreo").val();
        var Confirmar = $("#txtConfrirmar").val();
        var Municipio = $("#ddlMunicipio").val();
        if (Nombre.length == 0 || Fecha.length == 0 || Contraseña.length == 0 || Apellido.length == 0 || Correo.length == 0 || Confirmar.length == 0) {
            camposVacios();
        }
        else {
            registrarUsuario(Nombre, Apellido, Correo, Fecha, Contraseña, Municipio);
        }
    });
});
function camposVacios() {
    sweetAlert({
        title: "Ningún campo puede estar vacío",
        type: "error",
        timer: 3000,
        showConfirmButton: false,
        background: 'url(../images/Registrar/FondoI1.png)'
    });
}

function registrarUsuario(Nombre, Apellido, Correo, Fecha, Contraseña, Municipio) {
    $.ajax({
        type: "POST",
        url: "../Services/Registrar/Service_Registrar.svc/Registrar",
        data: '{"Nombre": "' + Nombre + '","Apellido":"' + Apellido + '","Correo":"' + Correo + '","Fecha":"' + Fecha + '","Contraseña":"' + Contraseña + '","Municipio":"' + Municipio + '"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensajea) {
            item = Mensajea.RegistrarResult;
            if (item.Tipo != 'success') {

                sweetAlert({
                    title: item.Mensaje,
                    type: item.Tipo,
                    timer: 3000,
                });
            } if (item.Tipo == 'success') {
                sweetAlert({
                    title: item.Mensaje,
                    type: item.Tipo,
                    timer: 3000,
                });
                $(".group input ").val('');
                $("select option[value='0']").attr("selected", true);

            }
        }
        ,
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + '' + Mensaje.statusText);
        }

    });
}

function cargarMunicipios() {
    $.ajax({
        type: "POST",
        url: "../Services/Registrar/Service_Registrar.svc/Municipios",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        processdata: true,
        success: function (Mensaje) {
            item = Mensaje.MunicipiosResult;
            $.each(item, function (index, Municipio) {
                $("#ddlMunicipio").append("<option>" + Municipio + "</option>");

            });
        },
        error: function (Mensaje) {
            alert('Error al llamar el servicio : ' + Mensaje.status + '' + Mensaje.statusText);
        }

    });
}

function compraraContraseñas() {
    var Correo = $("#txtConfrirmar").val();
    var Validacion = $("#txtContraseña").val();
    if (Correo == Validacion) {
        $("#Contraseña").html(" ");
        $("#btnRegistrar").prop("disabled", false);
        return true

    }
    if (Correo.length == 0 || Validacion.length == 0) {
        $("#Contraseña").html('');
        $("#btnRegistrar").prop("disabled", true);
    }
    if (Correo != Validacion) {
        $("#Contraseña").html("Las contraseñas no coinciden");
        $("#btnRegistrar").prop("disabled", true);

        return false
    }
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

function validarLetras(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8 || tecla == 127 || tecla == 32) {
        return true;
    }
    patron = /^[a-zA-Z]+$/;
    tecla_final = String.fromCharCode(tecla);
    return patron.test(tecla_final);
}

function caracteresCorreoValido(email) {
    var caract = new RegExp(/^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/);
    if (email.length == 0) {
        $("#Correo").html('');
    }
    else {
        if (caract.test(email) == false) {
            $("#Correo").html('Correo no valido');
            $("#btnRegistrar").prop("disabled", true);
            return false;
        } else {
            $("#Correo").html('');
            $("#btnRegistrar").prop("disabled", false);

            return true;
        }
    }
}