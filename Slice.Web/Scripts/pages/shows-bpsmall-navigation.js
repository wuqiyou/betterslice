var SLICE = (function (parent, $) {
    var slice = parent || {};

    $(function () {
        $("#sub-navigation-toggle a").click(function (e) {
            e.preventDefault();
            $(".bp-small-subnav").slideToggle(function () {
                if ($(".bp-small-subnav").is(':hidden')) {
                    $("#sub-navigation-toggle a span").removeClass('icon-caret-up');
                    $("#sub-navigation-toggle a span").addClass('icon-caret-down');
                } else {
                    $("#sub-navigation-toggle a span").removeClass('icon-caret-down');
                    $("#sub-navigation-toggle a span").addClass('icon-caret-up');
                }
            });
        });
    });

    return slice;
}(SLICE || {}, jQuery));
