$(document).ready(function () {

    $('#navItem').click(function () {
        var mediaquery = window.matchMedia("(max-width: 1000px)");
        if (mediaquery.matches) {
            $('#nav-icon, .tl-menu').toggleClass('open');
            $('#slider-menu-s1').css('transition', '1s').toggleClass('slider-menu-open');
        } else {
            $('#nav-icon').toggleClass('open');
            $('#slider-menu-s1').toggleClass('slider-menu-open');
        }
    });

    /*MOSTRAR MENU AL PASAR CURSOR*/

    /*$('.container').hover(function(){
        $('#nav-icon').toggleClass('open');
        $('#slider-menu-s1').toggleClass('slider-menu-open');
    });*/

    /*active*/
    //$('.select').click(function () {
    //    $('li').removeClass('tl-current');
    //    $(this).toggleClass('tl-current');
    //});
    //$('.slider-menu a').click(function () {
    //    var oID = $(this).attr("class");
    //    $('li').removeClass('tl-current');
    //    $('.s' + oID).toggleClass('tl-current');
    //});

    /*SELECCION*/

    /*$('.slider-menu a').hover(function(){
        var oID = $(this).attr("id");
        $('.s' + oID).toggleClass('hover');
    });
    $('.select').hover(function(){
        var oID = $(this).attr("class");
        var i = oID.substr(-1);
        $('#' + i).toggleClass('hover');
    });*/

    $modal = $('#Galeria');
    $overlay = $('.modal-overlay');

    $modal.bind('webkitAnimationEnd oanimationend msAnimationEnd animationend', function (e) {
        if ($('#Galeria, #Agregar, #Favorito').hasClass('state-leave')) {
            $('#Galeria, #Agregar, #Favorito').removeClass('state-leave');
        }
    });

    $('.close').on('click', function () {
        $overlay.removeClass('state-show');
        $('#Galeria, #Agregar, #Favorito').removeClass('state-appear').addClass('state-leave');
    });

    $('.open1').on('click', function () {
        $overlay.addClass('state-show');
        $('#Galeria').removeClass('state-leave').addClass('state-appear');
    });

    $('.itemsGallery#ave').hover(function () {
        $('#ave .titleItem').css('display', 'block');
    }, function () {
        $('#ave .titleItem').css('display', 'none');
    });

    $('.itemsGallery#arbol').hover(function () {
        $('#arbol .titleItem').css('display', 'block');
    }, function () {
        $('#arbol .titleItem').css('display', 'none');
    });

    $('.open2').on('click', function () {
        $overlay.addClass('state-show');
        $('#Agregar').removeClass('state-leave').addClass('state-appear');
    });

    $('.itemsGallery#ave2').hover(function () {
        $('#ave2 .titleItem').css('display', 'block');
    }, function () {
        $('#ave2 .titleItem').css('display', 'none');
    });

    $('.itemsGallery#arbol2').hover(function () {
        $('#arbol2 .titleItem').css('display', 'block');
    }, function () {
        $('#arbol2 .titleItem').css('display', 'none');
    });

    $('.open3').on('click', function () {
        $overlay.addClass('state-show');
        $('#Favorito').removeClass('state-leave').addClass('state-appear');
    });

    $('.itemsGallery#ave3').hover(function () {
        $('#ave3 .titleItem').css('display', 'block');
    }, function () {
        $('#ave3 .titleItem').css('display', 'none');
    });

    $('.itemsGallery#arbol3').hover(function () {
        $('#arbol3 .titleItem').css('display', 'block');
    }, function () {
        $('#arbol3 .titleItem').css('display', 'none');
    });
});