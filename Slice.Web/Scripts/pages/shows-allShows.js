var SLICE = (function (parent, $) {
    var slice = parent || {};

    $(function () {
        enquire.register(SLICE.GLOBAL_bp_largeAndExtraLarge, {
            match: function () {
                if ($('html').hasClass('no-csscolumns')) {
                    var numOfCols = 2;
                    var colSize = Math.floor($('#allShowsList li').length / numOfCols);
                    var col2Height = 0;
                    var col2MarginLeft = '50%';

                    $('#allShowsList li:lt(' + colSize + ')').each(function () {
                        col2Height += $(this).outerHeight(true);
                    });
                    $('#allShowsList li:eq(' + colSize + ')').css('margin-top', -col2Height);
                    $('#allShowsList li:gt(' + (colSize - 1) + ')').css('margin-left', col2MarginLeft);

                }
            },
            unmatch: function () { }
        });
    });

    return slice;
}(SLICE || {}, jQuery));
