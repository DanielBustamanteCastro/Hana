
function action(){
    $('.mas-info').attr('data-tilt', '');
    /*Abrir mas info*/
    $('.mas-info').click(function() {
        /*Reconocer el contenedor*/
        var idItem = '#' + $(this).parents('.card').attr('id');
        /*Combirtiendo imagen y reemplazando*/
        var bg = $(idItem + ' .card__image').css('background-image');
        bg = bg.replace('url(','').replace(')','').replace(/\"/gi, "");
        $('#imagen').attr('src', bg);
        /*Reemplazando valores directamente*/
        $(idItem + ' .informat div').each(function(){
            var idVal = '#m' + $(this).attr('class');
            var valor = $(this).text();
            $(idVal).text(valor);
        });

        /*Ocultando fondo*/
        setTimeout(function(){
            $('.carousel').css('display', 'none');
        }, 500);
        $('.modal').fadeIn().addClass('open');
    });

    /*Cerrar mas info*/
    $('.closebtn').click(function() {
        $('.carousel').css('display', '');
        $('.modal').fadeOut().removeClass('open');
    });

    /*Activar función de botones*/
    $('.card__button').click(function(){
        boton();
    });
    /*Paginacion de siguiente y ataras*/
    Numpag();
}

function Numpag(){
    $('.wrap ol li a, .wrap ol .space').remove();
    var valor = $('.wrap ol li a').length;
    var contPagina = 8;
    var contPagina2 = 9;
    if(valor == 0){
        $('.wrap li').each(function (ind, e) {
            $(e).append('<a class="pag">' + (ind + 1) + '</a>');
        });
        /*CON LAS FLECHAS*/
        $('.wrap ol').append('<li class="space btnprev"><a class="fa fa-arrow-left arrow"></a></li>');
        $('.wrap ol').append('<li class="space btnnext"><a class="fa fa-arrow-right arrow"></a></li>');
        actionPag();
    }
}

function actionPag(){
    var pos = 0;

    var renderPagination = function (pos) {
        var quantity = 8;
        var min = pos * quantity;
        var max = min + quantity;
        var $items = $('.wrap li:not(.space)');
        var $spaces = $('.space');

        $items.each(function (ind, e) {
            $(e).toggleClass('disabled', !((ind === 0 || ind === $items.length - 1) || min <= ind && ind < max));
        });

        $spaces.first()
            .toggleClass('disabled', pos == 0)
            .insertAfter($items.find(':visible').first().addClass('antes'));

        $spaces.last()
            .toggleClass('disabled', max >= $items.length)
            .insertBefore($items.find(':visible').last().addClass('fin'));
    }

    var contPagina = 8;
    var $carousel = $('.carousel');
    var $carouselList = $('.list');
    var $carouselItem = $('.item');

    var $nav = $('.js-carousel-nav');

    var $btnNext = $('.next');
    var $btnPrev = $('.prev');

    var $pagItem = $('.js-carousel-pagItem');
    var $btnPag = $('.pag');

    var activeIndex = 0;
    var maxIndex = $carouselItem.length - 1;

    var KEY = {
        LEFT: 37,
        UP: 38,
        RIGHT: 39,
        DOWN: 40,
        TAB: 9
    };

    // Layout function
    var layout = function() { 
        $carouselItem.attr('aria-hidden', 'true').hide();
        $carouselItem.eq(activeIndex).attr('aria-hidden', 'false').show();

        $btnPag.attr('aria-selected', 'false').attr('tabindex', '-1');
        $btnPag.eq(activeIndex).attr('aria-selected', 'true').removeAttr('tabindex');
    }

    // Event functions
    var onClickNext = function() {
        advance();
    }

    var onClickPrev = function() {
        rewind();
    }

    var onClickPag = function(event) {
        element = event.currentTarget;
        activeIndex = $btnPag.index(element);
        layout();
    }

    var onKeyNav = function(event) {
        if (event.keyCode === KEY.RIGHT || event.keyCode === KEY.DOWN) {
            advance();
        } else if (event.keyCode === KEY.LEFT || event.keyCode === KEY.UP) {
            rewind();
        }
    }

    var onKeyPag = function(event) {
        var currentElement = $(event.target).eq(0);
        var currentIndex = $btnPag.index(currentElement);

        if (event.keyCode === KEY.RIGHT || event.keyCode === KEY.DOWN) {
            if (currentIndex === undefined) {
                currentIndex = 0;
            } else if (currentIndex === maxIndex) {
                return this;
            } else {
                currentIndex = currentIndex + 1;
            }
        } else if (event.keyCode === KEY.LEFT || event.keyCode === KEY.UP) {
            if (currentIndex === null || currentIndex === 0) {
                currentIndex = 0;
            } else {
                currentIndex = currentIndex - 1;
            }
        } else if (event.keyCode === KEY.TAB) {
            currentIndex = activeIndex;
        }
        $btnPag.attr('tabindex', '-1');
        $btnPag.eq(currentIndex).removeAttr('tabindex').focus();
    }

    // Helper functions
    var advance = function() {
        if (activeIndex !== maxIndex) {
            activeIndex ++;
            layout();
        }
    }

    var rewind = function() {
        if (activeIndex !== 0) {
            activeIndex --;
            layout();
        }
    }

    // Event handlers
    $btnNext.on('click', onClickNext);
    $btnPrev.on('click', onClickPrev);
    $btnPag.on('click', onClickPag);
    $nav.on('keydown', onKeyNav);
    $btnPag.on('keydown', onKeyPag);

    // initiate
    layout();

    /****************************************************************************************************************************************/

    renderPagination(0);
    contPag1 = 8;
    contPag2 = 16; 

    $('.prev, .next, .pag').click(function(){
        contPag1 = 8 * (pos + 1);
        contPag2 = 8 * (pos + 2);
        if(activeIndex == contPag1 - 1 || activeIndex == contPag1 - 9){
            $('.p1').css('display', 'flex');
            $('.a1').css('display', 'none');
        }else{
            $('.p1').css('display', 'none');
            $('.a1').css('display', 'flex');
        }
        if(activeIndex == contPag2 - 8 || activeIndex == contPag2 - 16){
            $('.p2').css('display', 'flex');
            $('.a2').css('display', 'none');
        }else{
            $('.p2').css('display', 'none');
            $('.a2').css('display', 'flex');
        }
    });

    $('.btnnext').click(function () {
        renderPagination(++pos);
    });
    $('.fin').click(function () {
        renderPagination(pos = $('.wrap li:not(.space)').length/8);
    });

    $('.antes').click(function () {
        renderPagination(pos = 0);
    });

    $('.btnprev').click(function () {
        renderPagination(--pos);
    });
}