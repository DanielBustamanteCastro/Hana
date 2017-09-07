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
            if (item.Tipo !='success') {
                
            sweetAlert({
                    title: item.Mensaje,
                    type: item.Tipo,
                    timer: 3000,
                });
            } if (item.Tipo == 'success') {
                alert();
            // -------------------------
            // Random key for the "Activation Key" field
            // -------------------------
            var key = (Math.random() + 1).toString(36).substring(7);

            // Set a fake link to the user account
            $('.modal-body-step-7 label').html('<a href="https://example.com/account?user=' + key + '" target="_blank">https://example.com/account?user=' + key + '</a>');




    // -------------------------
    // NEXT STEP button
    // -------------------------

    $('.next').click(function () {
        var $btn = $(this),
            $step = $btn.parents('.modal-body'),
            stepIndex = $step.index(),
            $pag = $('.modal-header span').eq(stepIndex);

        if (stepIndex === 5) {
            var value = $('#activation').val();
            if (value == '') {
                error($step, $pag);
            }
            else {
                nextStep($step, $pag);
            }
        }
        else {
            nextStep($step, $pag);
        }
    });



    // -------------------------
    // PREVIOUS STEP button
    // -------------------------
    $('.previous').click(function () {
        var $btn = $(this),
            $step = $btn.parents('.modal-body'),
            stepIndex = $step.index(),
            $pag = $('.modal-header span').eq(stepIndex);

        previousStep($step, $pag);
    });




    // -------------------------
    // NEXT STEP function
    // -------------------------
    function nextStep($step, $pag) {
        // animate the step out
        $step.addClass('animate-out-to-left');

        // animate the step in
        setTimeout(function () {
            $step.removeClass('animate-out-to-left is-showing')
                .next().addClass('animate-in-from-right');
            $pag.removeClass('is-active is-invalid').addClass('is-valid')
                .next().addClass('is-active');
        }, 600);

        // after the animation, adjust the classes
        setTimeout(function () {
            $step.next().removeClass('animate-in-from-right')
                .addClass('is-showing');
        }, 1200);
    }




    // -------------------------
    // PREVIOUS STEP function
    // -------------------------
    function previousStep($step, $pag) {
        // animate the step out
        $step.addClass('animate-out-to-right');

        // animate the step in
        setTimeout(function () {
            $step.removeClass('animate-out-to-right is-showing')
                .prev().addClass('animate-in-from-left');
            $pag.removeClass('is-active is-valid is-invalid')
                .prev().removeClass('is-valid is-invalid').addClass('is-active');
        }, 600);

        // after the animation, adjust the classes
        setTimeout(function () {
            $step.prev().removeClass('animate-in-from-left')
                .addClass('is-showing');
        }, 1200);
    }




    // -------------------------
    // ERROR function
    // -------------------------
    function error($step, $pag) {
        $('#activation').addClass('input-error shake');
        $pag.addClass('is-invalid');

        // after the animation, adjust the classes
        setTimeout(function () {
            $('#activation').removeClass('shake');
        }, 500);
    }




    // -------------------------
    // Activate popover
    // -------------------------
    $(document).ready(function () {
        $('[data-toggle="popover"]').popover();
    });


    /*************************************************************************************************************************************************************/

    function MaterialSelect(element) {
        'use strict';

        this.element_ = element;
        this.maxRows = this.Constant_.NO_MAX_ROWS;
        // Initialize instance.
        this.init();
    }

    MaterialSelect.prototype.Constant_ = {
        NO_MAX_ROWS: -1,
        MAX_ROWS_ATTRIBUTE: 'maxrows'
    };

    MaterialSelect.prototype.CssClasses_ = {
        LABEL: 'mdl-textfield__label',
        INPUT: 'mdl-select__input',
        IS_DIRTY: 'is-dirty',
        IS_FOCUSED: 'is-focused',
        IS_DISABLED: 'is-disabled',
        IS_INVALID: 'is-invalid',
        IS_UPGRADED: 'is-upgraded'
    };

    MaterialSelect.prototype.onKeyDown_ = function (event) {
        'use strict';

        var currentRowCount = event.target.value.split('\n').length;
        if (event.keyCode === 13) {
            if (currentRowCount >= this.maxRows) {
                event.preventDefault();
            }
        }
    };

    MaterialSelect.prototype.onFocus_ = function (event) {
        'use strict';

        this.element_.classList.add(this.CssClasses_.IS_FOCUSED);
    };

    MaterialSelect.prototype.onBlur_ = function (event) {
        'use strict';

        this.element_.classList.remove(this.CssClasses_.IS_FOCUSED);
    };

    MaterialSelect.prototype.updateClasses_ = function () {
        'use strict';
        this.checkDisabled();
        this.checkValidity();
        this.checkDirty();
    };

    MaterialSelect.prototype.checkDisabled = function () {
        'use strict';
        if (this.input_.disabled) {
            this.element_.classList.add(this.CssClasses_.IS_DISABLED);
        } else {
            this.element_.classList.remove(this.CssClasses_.IS_DISABLED);
        }
    };

    MaterialSelect.prototype.checkValidity = function () {
        'use strict';
        if (this.input_.validity.valid) {
            this.element_.classList.remove(this.CssClasses_.IS_INVALID);
        } else {
            this.element_.classList.add(this.CssClasses_.IS_INVALID);
        }
    };

    MaterialSelect.prototype.checkDirty = function () {
        'use strict';
        if (this.input_.value && this.input_.value.length > 0) {
            this.element_.classList.add(this.CssClasses_.IS_DIRTY);
        } else {
            this.element_.classList.remove(this.CssClasses_.IS_DIRTY);
        }
    };

    MaterialSelect.prototype.disable = function () {
        'use strict';

        this.input_.disabled = true;
        this.updateClasses_();
    };

    MaterialSelect.prototype.enable = function () {
        'use strict';

        this.input_.disabled = false;
        this.updateClasses_();
    };

    MaterialSelect.prototype.change = function (value) {
        'use strict';

        if (value) {
            this.input_.value = value;
        }
        this.updateClasses_();
    };

    MaterialSelect.prototype.init = function () {
        'use strict';

        if (this.element_) {
            this.label_ = this.element_.querySelector('.' + this.CssClasses_.LABEL);
            this.input_ = this.element_.querySelector('.' + this.CssClasses_.INPUT);

            if (this.input_) {
                if (this.input_.hasAttribute(this.Constant_.MAX_ROWS_ATTRIBUTE)) {
                    this.maxRows = parseInt(this.input_.getAttribute(
                        this.Constant_.MAX_ROWS_ATTRIBUTE), 10);
                    if (isNaN(this.maxRows)) {
                        this.maxRows = this.Constant_.NO_MAX_ROWS;
                    }
                }

                this.boundUpdateClassesHandler = this.updateClasses_.bind(this);
                this.boundFocusHandler = this.onFocus_.bind(this);
                this.boundBlurHandler = this.onBlur_.bind(this);
                this.input_.addEventListener('input', this.boundUpdateClassesHandler);
                this.input_.addEventListener('focus', this.boundFocusHandler);
                this.input_.addEventListener('blur', this.boundBlurHandler);

                if (this.maxRows !== this.Constant_.NO_MAX_ROWS) {
                    // TODO: This should handle pasting multi line text.
                    // Currently doesn't.
                    this.boundKeyDownHandler = this.onKeyDown_.bind(this);
                    this.input_.addEventListener('keydown', this.boundKeyDownHandler);
                }

                this.updateClasses_();
                this.element_.classList.add(this.CssClasses_.IS_UPGRADED);
            }
        }
    };

    MaterialSelect.prototype.mdlDowngrade_ = function () {
        'use strict';
        this.input_.removeEventListener('input', this.boundUpdateClassesHandler);
        this.input_.removeEventListener('focus', this.boundFocusHandler);
        this.input_.removeEventListener('blur', this.boundBlurHandler);
        if (this.boundKeyDownHandler) {
            this.input_.removeEventListener('keydown', this.boundKeyDownHandler);
        }
    };

    // The component registers itself. It can assume componentHandler is available
    // in the global scope.
    componentHandler.register({
        constructor: MaterialSelect,
        classAsString: 'MaterialSelect',
        cssClass: 'mdl-js-select',
        widget: true
    });
        }
            if (item.Tipo == "success") {
                $("#txtNombre").val('');
                $("#txtFecha").val('');
                $("#txtContraseña").val('');
                $("#txtApellido").val('');
                $("#txtCorreo").val('');
                $("#txtConfrirmar").val('');
                $("#ddlMunicipio").val(1);
            }
            if (item.Tipo == "info" || item.Tipo == "error") {
                $("#txtContraseña").val('');
                $("#txtConfrirmar").val('');
            }


        },
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