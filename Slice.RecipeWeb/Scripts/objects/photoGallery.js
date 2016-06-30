(function ($) {
    "use strict";

    $.fn.photoGallery = function (options) {
        var settings = $.extend({
            index: 0
        }, options);

        return this.each(function () {
            // iOS 7 has serious memory limitations so we will avoid storing anything in memory
            // and parse the DOM whenever we need something.
            // getFlexSlider() and getSlides() replace flexObj and flexSlides vars below

            // initialize slider
            getFlexSlider().flexslider({
                startAt: settings.index,
                slideshow: false,
                smoothHeight: true,
                controlNav: false,
                directionNav: false,
                useCSS: false,

                // called once after slider initialization
                start: function () {
                    getFlexSlider().find(".slides > li:not(.flex-active-slide)").addClass("hide");
                    updateURLHash();
                    goToSlideFromURLHash();
                },

                // called on every slide nav click, before slide change
                before: function () {
                    getSlides().removeClass("hide");
                },

                // called on every slide nav click, after slide change
                after: function () {
                    getFlexSlider().find(".slides > li:not(.flex-active-slide)").addClass("hide");
                    updateURLHash();
                }
            });


            // click functions for prev/next buttons
            getFlexSlider().find(".slides > li:not(.first-slide) a.prev").on("click", function () {
                getFlexSlider().flexslider("prev");
            });
            getFlexSlider().find(".slides > li:not(.last-slide) a.next").on("click", function () {
                getFlexSlider().flexslider("next");
            });


            // click function for start-over link on last slide
            getSlides().find(".start-over").on("click", function () {
                getFlexSlider().flexslider(0);
            });


            // Update the slide when the URL hash changes.
            // This includes any time the user move back or forward in browser history
            $(window).on("hashchange", function () {
                goToSlideFromURLHash();
            });

            /************************************/
            /* FUNCTIONS
            /************************************/
            // iOS 7 has serious memory limitations so we will avoid storing anything in memory
            // and parse the DOM whenever we need the slider or slides.
            function getFlexSlider() {
                return $(".flexslider");
            }
            function getSlides() {
                return $(".flexslider .slides > li");
            }

            // Update the current URL hash to reflect the key of the currently active slide
            // ie. make a unique URL for each slide
            function updateURLHash() {
                var activeSlide = getFlexSlider().find(".slides > li.flex-active-slide");
                var key = activeSlide.attr("data-key");
                location.hash = "!" + key;
            }

            // Go to the slide corresponding to the current hash value in the URL
            function goToSlideFromURLHash() {
                // get key from url
                var slideKey = location.hash.replace("#!", "");

                if (slideKey != "") {
                    // find the index of the slide with matching data-key attribute
                    var matchingSlideIndex = parseInt(getFlexSlider().find('.slides > li[data-key="' + slideKey + '"]').attr("data-index"));

                    // find the index of the active slide
                    var activeSlideIndex = parseInt(getFlexSlider().find(".slides > li.flex-active-slide").attr("data-index"));

                    // if matchingSlideIndex is a number and is not the index of the currently active slide, then go to that slide
                    if (!isNaN(matchingSlideIndex) && matchingSlideIndex != activeSlideIndex) {
                        getFlexSlider().flexslider(matchingSlideIndex);
                    }
                }
            }
        });
    };
}(jQuery));