$(document).ready(function(){

    var cont = 6;
    var sec = 1;
    var cant;

    /*GALERIA AEVES*/
    $('#agregarAve').click(function(){
        var cantidad = $('#valor').val();
        var i;
        for(i = 1; i <= cantidad; i++){

            /*Definicion de Valores*/
            var Foto = 'https://placeimg.com/640/480/nature';
            var NombreComun = '1' + i;
            var Especie = '2'+ i;
            var Familia = '3'+ i;
            var Dieta = '4'+ i;
            var Tipo = '5'+ i;
            var ColorPlumaje = '6'+ i;
            var Origen = '7'+ i;
            var TamanoAve = '8'+ i;
            var ClaseDieta = '9'+ i;
            var NombreCientifico = '10'+ i;
            var Comportamiento = '11'+ i;
            var Clase = '12'+ i;
            var Habitat = '13'+ i;
            var Dominio = '14'+ i;
            var Reino = '15';
            var Reproduccion = '16'+ i;
            var Genero = '17'+ i;
            var Descripcion = '18'+ i;
            var Filum = '19'+ i;
            var Orden = '20'+ i;

            /*Agregar clases con sus valores*/

            $('#Item' + sec).append('<div id="' + i + '" class="card card--big"><div class="card__image" style="background-image: url(https://placeimg.com/640/480/nature)"></div><h2 class="card__title">' + NombreCientifico + '</h2><p class="card__text">' + NombreComun + '</p><div class="card__action-bar"><button class="card__button mas-info" >Mas información</button></div><div class="informat"><div class="NombreComun">' + NombreComun + '</div><div class="Especie">' + Especie + '</div><div class="Familia">' + Familia + '</div><div class="Dieta">' + Dieta + '</div><div class="Tipo">' + Tipo + '</div><div class="Origen">' + Origen + '</div><div class="TamanoAve">' + TamanoAve + '</div><div class="ClaseDieta">' + ClaseDieta + '</div><div class="NombreCientifico">' + NombreCientifico + '</div><div class="Comportamiento">' + Comportamiento + '</div><div class="Clase">' + Clase + '</div><div class="Habitat">' + Habitat + '</div><div class="Dominio">' + Dominio + '</div><div class="Reino">' + Reino + '</div><div class="Reproduccion">' + Reproduccion + '</div><div class="Genero">' + Genero + '</div><div class="Descripcion">' + Descripcion + '</div><div class="Filum">' + Filum + '</div><div class="Orden">' + Orden + '</div><div class="ColorPlumaje">' + ColorPlumaje + '</div></div></div>');

            /*Crear seccion*/
            cant = $('.card').length;
            if(cant == cont){
                sec = sec + 1;
                $('#carousel').append('<section id="Item' + sec + '" class="item"></section>');
            }
            if(cant == cont + 1){
                cont = cont + 6;
                /*Crear paginacion segun numeros de secciones*/
                $('.wrap ol').append('<li class="js-carousel-pagItem"></li>');
                $('.pagination').css('display','flex');
            }
        }
        action();
    });

    /*GALERIA ARBOLES*/
    $('#agregarArbol').click(function(){
        var cantidad = $('#valor').val();
        var i;
        for(i = 1; i <= cantidad; i++){

            /*Definicion de Valores*/
            var Foto = 'https://placeimg.com/640/480/nature';
            var NombreComun = '1' + i;
            var Especie = '2' + i;
            var Familia = '3' + i;
            var Tipo = '4' + i;
            var ColorHojas = '5' + i;
            var Altura = '6' + i;
            var NombreCientifico = '7' + i;
            var Clase = '8' + i;
            var Dominio = '9' + i;
            var Reino = '10' + i;
            var Genero = '11' + i;
            var Division = '12' + i;
            var Orden = '13' + i;
            var LongevidadArbol = '14' + i;
            var LimitacionesFrutos = '15' + i;
            var FormaCopa = '16' + i;
            var AmplitudCopa = '17' + i;
            var Diametro = '18' + i;
            var PersistenciaHoja = '19' + i;
            var EstacionFloracion = '20' + i;
            var LimitacionesArbol = '21' + i;
            var PisoTermico = '22' + i;
            var Luminocidad = '23' + i;
            var ColorFlor = '24' + i;
            var HabitoCrecimiento = '25' + i;
            var Descripcion = '26' + i;
            var FuncionArbol = '27' + i;

            /*Agregar clases con sus valores*/

            $('#Item' + sec).append('<div id="' + i + '" class="card card--big"><div class="card__image" style="background-image: url(' + Foto +'"></div><h2 class="card__title">' + NombreCientifico + '</h2><p class="card__text">' + NombreComun + '</p><div class="card__action-bar"><button class="card__button mas-info" >Mas información</button></div><div class="informat"><div class="NombreComun">' + NombreComun + '</div><div class="Especie">' + Especie + '</div><div class="Familia">' + Familia + '</div><div class="Tipo">' + Tipo + '</div><div class="ColorHojas">' + ColorHojas + '</div><div class="Altura">' + Altura + '</div><div class="NombreCientifico">' + NombreCientifico + '</div><div class="Clase">' + Clase + '</div><div class="Dominio">' + Dominio + '</div><div class="Reino">' + Reino + '</div><div class="Genero">' + Genero + '</div><div class="Division">' + Division + '</div><div class="Orden">' + Orden + '</div><div class="LongevidadArbol">' + LongevidadArbol + '</div><div class="LimitacionesFrutos">' + LimitacionesFrutos + '</div><div class="FormaCopa">' + FormaCopa + '</div><div class="AmplitudCopa">' + AmplitudCopa + '</div><div class="Diametro">' + Diametro + '</div><div class="PersistenciaHoja">' + PersistenciaHoja + '</div><div class="EstacionFloracion">' + EstacionFloracion + '</div><div class="LimitacionesArbol">' + LimitacionesArbol + '</div><div class="PisoTermico">' + PisoTermico + '</div><div class="Luminocidad">' + Luminocidad + '</div><div class="ColorFlor">' + ColorFlor + '</div><div class="HabitoCrecimiento">' + HabitoCrecimiento + '</div><div class="Descripcion">' + Descripcion + '</div><div class="FuncionArbol">' + FuncionArbol + '</div></div></div>');

            /*Crear seccion*/
            cant = $('.card').length;
            if(cant == cont){
                sec = sec + 1;
                $('#carousel').append('<section id="Item' + sec + '" class="item"></section>');
            }
            if(cant == cont + 1){
                cont = cont + 6;
                /*Crear paginacion segun numeros de secciones*/
                $('.wrap ol').append('<li class="js-carousel-pagItem"></li>');
                $('.pagination').css('display','flex');
            }
        }
        action();
    });
});