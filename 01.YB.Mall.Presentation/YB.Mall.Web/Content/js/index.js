$.fn.removeClassPrefix = function (prefix) {
    this.each(function (i, el) {
        var classes = el.className.split(" ").filter(function (c) {
            return c.lastIndexOf(prefix, 0) !== 0;
        });
        el.className = classes.join(" ");
    });
    return this;
};
$(function ($) {
    $('#config-tool-cog').on('click', function () {
        $('#config-tool').toggleClass('closed');
    });
    $('#config-fixed-header').on('change', function () {
        var fixedHeader = '';
        if ($(this).is(':checked')) {
            $('body').addClass('fixed-header'); fixedHeader = 'fixed-header';
        }
        else {
            $('body').removeClass('fixed-header');
            if ($('#config-fixed-sidebar').is(':checked')) {
                $('#config-fixed-sidebar').prop('checked', false);
                $('#config-fixed-sidebar').trigger('change'); location.reload();
            }
        }
    });
});
$(function ($) {
    $("#content-wrapper").find('.mainContent').height($(window).height() - 100);
    $(window).resize(function (e) {
        $("#content-wrapper").find('.mainContent').height($(window).height() - 100);
    });
    $.index.loadMenu();
    $('#sidebar-nav,#nav-col-submenu').on('click', '.dropdown-toggle', function (e) {
        e.preventDefault();
        var $item = $(this).parent();
        if (!$item.hasClass('open')) {
            $item.parent().find('.open .submenu').slideUp('fast');
            $item.parent().find('.open').toggleClass('open');
        }
        $item.toggleClass('open');
        if ($item.hasClass('open')) {
            $item.children('.submenu').slideDown('fast', function () {
                var height1 = $(window).height() - 92 - $item.position().top;
                var height2 = $item.find('ul.submenu').height() + 10;
                var height3 = height2 > height1 ? height1 : height2;
                $item.find('ul.submenu').css({
                    overflow: "auto",
                    height: height3
                });
            });
        }
        else {
            $item.children('.submenu').slideUp('fast');
        }
    });
    $('body').on('mouseenter', '#page-wrapper.nav-small #sidebar-nav .dropdown-toggle', function (e) {
        if ($(document).width() >= 992) {
            var $item = $(this).parent();
            if ($('body').hasClass('fixed-leftmenu')) {
                var topPosition = $item.position().top;
                if ((topPosition + 4 * $(this).outerHeight()) >= $(window).height()) {
                    topPosition -= 6 * $(this).outerHeight();
                }
                $('#nav-col-submenu').html($item.children('.submenu').clone());
                $('#nav-col-submenu > .submenu').css({ 'top': topPosition });
            }
            $item.addClass('open');
            $item.children('.submenu').slideDown('fast');
        }
    });
    $('body').on('mouseleave', '#page-wrapper.nav-small #sidebar-nav > .nav-pills > li', function (e) {
        if ($(document).width() >= 992) {
            var $item = $(this);
            if ($item.hasClass('open')) {
                $item.find('.open .submenu').slideUp('fast');
                $item.find('.open').removeClass('open');
                $item.children('.submenu').slideUp('fast');
            }
            $item.removeClass('open');
        }
    });
    $('body').on('mouseenter', '#page-wrapper.nav-small #sidebar-nav a:not(.dropdown-toggle)', function (e) {
        if ($('body').hasClass('fixed-leftmenu')) {
            $('#nav-col-submenu').html('');
        }
    });
    $('body').on('mouseleave', '#page-wrapper.nav-small #nav-col', function (e) {
        if ($('body').hasClass('fixed-leftmenu')) {
            $('#nav-col-submenu').html('');
        }
    });
    $('body').find('#make-small-nav').click(function (e) {
        $('#page-wrapper').toggleClass('nav-small');
    });
    $('body').find('.mobile-search').click(function (e) {
        e.preventDefault();
        $('.mobile-search').addClass('active');
        $('.mobile-search form input.form-control').focus();
    });
    $(document).mouseup(function (e) {
        var container = $('.mobile-search');
        if (!container.is(e.target) && container.has(e.target).length === 0) {
            container.removeClass('active');
        }
    });
    $(window).load(function () {
        window.setTimeout(function () {
            $('#ajax-loader').fadeOut();
        }, 300);
    });
});
(function ($) {
    $.index = {
        loadMenu: function () {
            $.ajax({
                url: "/System/GetRoleMenu",
                type: "get",
                dataType: "json",
                async: false,
                success: function (data) {
                    if (data) {
                        var html = "";
                        $.each(data, function (i, row) {
                            html += '<li>';
                            html += '<a data-id="' + row.MenuId + '" href="#" class="dropdown-toggle"><i class="' + row.Icon + '"></i><span>' + row.MenuName + '</span><i class="fa fa-angle-right drop-icon"></i></a>';
                            html += '<ul class="submenu">';
                            $.each(row.ChildrenNodes, function (i, subrow) {
                                html += '<li>';
                                html += '<a class="menuItem" data-id="' + subrow.MenuId + '" href="' + subrow.UrlPath + '">' + subrow.MenuName + '</a>';
                                html += '</li>';
                            });
                            html += '</ul>';
                            html += '</li>';
                        });
                        $("#sidebar-nav ul").prepend(html);
                    }
                }
            });
        }
    };
})(jQuery);