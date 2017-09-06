(function () {
    'use strict';
    $(function () {
        var parent, ink, d, x, y;
        $('.sidebar .accordion-menu li .sub-menu').slideUp(0);
        $('.sidebar .accordion-menu li.open > .sub-menu').slideDown(0);
        $('.small-sidebar .sidebar .accordion-menu li.open .sub-menu').hide(0);
        $(document.body).on('click','.sidebar .accordion-menu > li.droplink > a',function () {
            if (!($('body').hasClass('small-sidebar')) && (!$('body').hasClass('page-horizontal-bar')) && (!$('body').hasClass('hover-menu'))) {
                var menu = $('.sidebar .menu'),
                    sidebar = $('.page-sidebar-inner'),
                    page = $('.page-content'),
                    sub = $(this).next(),
                    el = $(this);
                menu.find('li').removeClass('open');
                $('.sub-menu').slideUp(200, function () {
                    sidebarAndContentHeight();
                });
                sidebarAndContentHeight();

                if (!sub.is(':visible')) {
                    $(this).parent('li').addClass('open');
                    $(this).next('.sub-menu').slideDown(200, function () {
                        sidebarAndContentHeight();
                    });
                } else {
                    sub.slideUp(200, function () {
                        sidebarAndContentHeight();
                    });
                }
                return false;
            };
            if (($('body').hasClass('small-sidebar')) && ($('body').hasClass('page-sidebar-fixed'))) {
                var menu = $('.sidebar .menu'),
                    sidebar = $('.page-sidebar-inner'),
                    page = $('.page-content'),
                    sub = $(this).next(),
                    el = $(this);

                menu.find('li').removeClass('open');
                $('.sub-menu').slideUp(200, function () {
                    sidebarAndContentHeight();
                });
                sidebarAndContentHeight();
                if (!sub.is(':visible')) {
                    $(this).parent('li').addClass('open');
                    $(this).next('.sub-menu').slideDown(200, function () {
                        sidebarAndContentHeight();
                    });
                } else {
                    sub.slideUp(200, function () {
                        sidebarAndContentHeight();
                    });
                }
                return false;
            }
        });
        $('.sidebar .accordion-menu .sub-menu li.droplink > a').click(function () {
            var menu = $(this).parent().parent(),
                sidebar = $('.page-sidebar-inner'),
                page = $('.page-content'),
                sub = $(this).next(),
                el = $(this);
            menu.find('li').removeClass('open');
            sidebarAndContentHeight();
            if (!sub.is(':visible')) {
                $(this).parent('li').addClass('open');
                $(this).next('.sub-menu').slideDown(200, function () {
                    sidebarAndContentHeight();
                });
            } else {
                sub.slideUp(200, function () {
                    sidebarAndContentHeight();
                });
            }
            return false;
        });
        var sidebarAndContentHeight = function () {
            var content = $('.page-inner'),
                sidebar = $('.page-sidebar'),
                body = $('body'),
                height,
                footerHeight = $('.page-footer').outerHeight(),
                pageContentHeight = $('.page-content').height();
            content.attr('style', 'min-height:' + sidebar.height() + 'px !important');
            if (body.hasClass('page-sidebar-fixed')) {
                height = sidebar.height() + footerHeight;
            } else {
                // height = sidebar.height() + footerHeight;
                // if (height < $(window).height()) {
                //     height = $(window).height();
                // }

                height = sidebar.height();
                var navHeight = $('.navbar').outerHeight();
                if (height < ($(window).height() - navHeight)) {
                    height = ($(window).height() - navHeight);
                }
            }
            if (height >= content.height()) {
                content.attr('style', 'min-height:' + height + 'px !important');
            }
        };
        sidebarAndContentHeight();
        window.onresize = sidebarAndContentHeight;
    });
})();
