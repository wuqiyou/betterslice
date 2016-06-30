(function ($) {
    "use strict";

    $.fn.rotator = function (options) {
        var settings = $.extend({
            rotatorId: "",
        }, options);

        return this.each(function () {
            var rotator = $("#" + settings.rotatorId + " .flexslider");
            var slides = rotator.find(".slides > li");
            var numSlides = slides.length;

            // initialize rotator
            rotator.flexslider({
                controlNav: true,
                directionNav: false,
                manualControls: ".rotator-control li",
                slideshow: true,
                smoothHeight: false,
                useCSS: false,

                animation: "fade",
                animationLoop: true,
                animationSpeed: 350,
                slideshowSpeed: 5000,

                // called once after slider initialization
                start: function () {
                    rotator.find(".slides > li:not(.flex-active-slide)").addClass("hide");
                },

                // called on every slide nav click, before slide change
                before: function () {
                    slides.removeClass("hide");
                },

                // called on every slide nav click, after slide change
                after: function () {
                    rotator.find(".slides > li:not(.flex-active-slide)").addClass("hide");
                }
            });

            // click functions for prev/next buttons
            rotator.find(".rotator-prev").on("click", function () {
                rotator.flexslider("prev");
                rotator.flexslider("play");
            });
            rotator.find(".rotator-next").on("click", function () {
                rotator.flexslider("next");
                rotator.flexslider("play");
            });
        });
    };
}(jQuery));