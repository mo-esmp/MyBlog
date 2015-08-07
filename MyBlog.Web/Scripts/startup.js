/*!
 * Clean Blog v1.0.0 (http://startbootstrap.com)
 * Copyright 2014 Start Bootstrap
 * Licensed under Apache 2.0 (https://github.com/IronSummitMedia/startbootstrap/blob/gh-pages/LICENSE)
 */

// Contact Form Scripts

// Floating label headings for the contact form
$(function () {
    $("body").on("input propertychange", ".floating-label-form-group", function (e) {
        $(this).toggleClass("floating-label-form-group-with-value", !!$(e.target).val());
    }).on("focus", ".floating-label-form-group", function () {
        $(this).addClass("floating-label-form-group-with-focus");
    }).on("blur", ".floating-label-form-group", function () {
        $(this).removeClass("floating-label-form-group-with-focus");
    });

    var mql = 1170;

    //primary navigation slide-in effect
    if ($(window).width() > mql) {
        var headerHeight = $('.navbar-custom').height();
        $(window).on('scroll', {
            previousTop: 0
        }, function () {
            var currentTop = $(window).scrollTop();
            //check if user is scrolling up
            if (currentTop < this.previousTop) {
                //if scrolling up...
                if (currentTop > 0 && $('.navbar-custom').hasClass('is-fixed')) {
                    $('.navbar-custom').addClass('is-visible');
                } else {
                    $('.navbar-custom').removeClass('is-visible is-fixed');
                }
            } else {
                //if scrolling down...
                $('.navbar-custom').removeClass('is-visible');
                if (currentTop > headerHeight && !$('.navbar-custom').hasClass('is-fixed')) $('.navbar-custom').addClass('is-fixed');
            }
            this.previousTop = currentTop;
        });
    }

    var windowHeight = $(window).height();
    var bodyHeight = $('body').height();
    if (windowHeight > bodyHeight) {
        $('footer').css({ 'bottom': '0', 'position': 'absolute', 'width': '100%' });
    }

    $('img.lazy').lazyload({
        effect: 'fadeIn'
    });

    typeDirection();
    autoSize();
});

function typeDirection() {
    var inputs = $('.type-direction');
    if (inputs.length > 0) {
        inputs.bind('keyup', function () {
            var inputValue = $(this).val();
            if ($.trim(inputValue).length === 0) {
                $(this).css({ 'direction': 'rtl', 'text-align': 'right' });
                return;
            }

            var rtl = inputValue.match(/^[^a-z]*[^\x00-\x7E]/ig);
            $(this).css({ 'direction': rtl ? 'rtl' : 'ltr', 'text-align': rtl ? 'right' : 'left' });
        });
    }
}

function autoSize() {
    var autoGrow = $('.auto-size');
    if (autoGrow.length > 0) {
        $(autoGrow).autosize();
    }
}