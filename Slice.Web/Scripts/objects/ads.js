var SLICE = (function (parent, $) {
    var slice = parent || {};


    $(function () {

        var responsiveAd = {
            desktopAdRendered: false,
            tabletAdRendered: false,
            mobileAdRendered: false,
            writeAd: function (deviceClass) {
                $(deviceClass).each(function () {
                    var gptDiv = $(this);
                    var adString = 'googletag.cmd.push(function() { googletag.display("' + $(gptDiv).attr('id') + '"); });';
                    var target = $(gptDiv).get(0);
                    var injectAd = '<script>';
                    injectAd += adString;
                    injectAd += '</';
                    injectAd += 'script>';
                    $(target).append(injectAd);
                });
            }
        }

        enquire
            .register(SLICE.GLOBAL_bp_extraLarge, function () {
                if (!responsiveAd.desktopAdRendered) {
                    responsiveAd.writeAd('.gpt-desktop');
                    responsiveAd.desktopAdRendered = true;
                }
            }, true)
            .register(SLICE.GLOBAL_bp_mediumAndLarge, function () {
                if (!responsiveAd.tabletAdRendered) {
                    responsiveAd.writeAd('.gpt-tablet');
                    responsiveAd.tabletAdRendered = true;
                }
            })
            .register(SLICE.GLOBAL_bp_small, function () {
                if (!responsiveAd.mobileAdRendered) {
                    responsiveAd.writeAd('.gpt-mobile')
                    responsiveAd.mobileAdRendered = true;
                }
            })


    });

    return slice;
}(SLICE || {}, jQuery));
