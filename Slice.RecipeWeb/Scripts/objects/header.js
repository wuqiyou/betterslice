var SLICE = (function (parent, $) {
    var slice = parent || {};

    //init reponsive navigation
    HEADER_navigation = responsiveNav('#nav', {
        label: "",
        insert: "before",
        animate: false
    });

    $(function () {
        $('#nav-mobileMenuClose').click(function (e) {
            e.stopPropagation();
            // close menu
            HEADER_navigation.toggle();
            // scroll to top
            document.body.scrollTop = document.documentElement.scrollTop = 0;
        });

        // dynamically size feature bar.
        //enquire.register(SLICE.GLOBAL_bp_mediumAndLarge, {
        //    match : function() {
        //        var totalWidthPercentage = 88;
        //        var minWidthPixels = 90;
        //        var sum = 0;
        //        var conversionRate = 0;
        //        var newWidth = 0;
        //        // get sum of the widths of each <a>
        //        $('#feature-nav .nav-featureItems a').each(function () {
        //            if ($(this).innerWidth() < minWidthPixels) {
        //                sum += minWidthPixels;
        //            }
        //            else {
        //                sum += $(this).innerWidth();
        //            }
        //        });
        //        // calc conversionRate
        //        conversionRate = totalWidthPercentage / sum;
        //        // set widths of the parent <li> using the conversion rate
        //        $('#feature-nav .nav-featureItems a').each(function () {
        //            if ($(this).innerWidth() < minWidthPixels) {
        //                newWidth = minWidthPixels * conversionRate;
        //            }
        //            else {
        //                newWidth = $(this).innerWidth() * conversionRate;
        //            }
        //            $(this).parent().outerWidth(newWidth + '%');
        //        });
        //    },
        //    unmatch : function() {
        //        $('#feature-nav .nav-featureItems').each(function () {
        //            $(this).outerWidth('');
        //        });
        //    }
        //});

        // dropdown show/hide
        //enquire.register(SLICE.GLOBAL_bp_mediumAndLarge, {
        //    match: function () {
        //        $('.nav-dropdownArrow').click(function (e) {
        //            var targetDiv = $(this).attr('id').replace('toggle-', '#dropdown-');
        //            var dropdownParent = $(this).parent();

        //            $('.nav-mainItems').not(dropdownParent).removeClass('active');
        //            $('.dropdown-container').not(targetDiv).hide();
        //            $(targetDiv).slideToggle({
        //                queue: true,
        //                duration: 200
        //            });

        //            if ($(dropdownParent).hasClass('active')) {
        //                $(dropdownParent).removeClass('active');
        //            }
        //            else {$(dropdownParent).addClass('active') }
        //        });
        //    },
        //    unmatch: function () {
        //        $('.nav-dropdownArrow').unbind('click');
        //        $('.nav-mainItems').removeClass('active');
        //        $('.dropdown-container').hide();
        //    }
        //});

    });

    return slice;
}(SLICE || {}, jQuery));

var SearchBar = function (settings, webURL) {
    _Init = function (settings) {

        this.settings = settings;

        this.searchForm = $('#js-searchForm');
        this.searchInputObj = $("#js-searchField");
        this.searchButtonObj = $("#js-searchButton");

        this.InitEvents();
    };

    InitEvents = function () {
        var that = this;

        function SearchAction() {
            var searchTerm = that.searchInputObj.val();
            if (that.searchInputObj.width() === 0) {
                that.searchInputObj.trigger("focus");
            }
            if ($('.searchResults-query').length) {
                if ($(".searchResults-query").html() != searchTerm && searchTerm) {
                    document.location.href = webURL + "/search/?q=" + searchTerm;
                } else {
                    //don't search for the term you already searched for from the search page
                    return;
                }
            } else {
                if (searchTerm) {
                    document.location.href = webURL + "/search/?q=" + searchTerm;
                }
            }
        }
        that.searchForm.on("submit.SearchAction", function (e) {
            e.preventDefault();
            SearchAction();
        });
        that.searchInputObj.keypress(function (e) {
            if (e.which == 13) {
                SearchAction();
            }
        });
    };
    _Init(settings);
};
