var SLICE = (function (parent, $) {
    var slice = parent || {};

     //setting up low and high breakpoints in em.  Modify this.
    slice.GLOBAL_bp_lowEm = 45;
    slice.GLOBAL_bp_medEm = 60;
    slice.GLOBAL_bp_highEm = 71;
    
    //converting to pixels.  Don't modify this.
    slice.GLOBAL_bp_lowPx = 16 * slice.GLOBAL_bp_lowEm;
    slice.GLOBAL_bp_medPx = 16 * slice.GLOBAL_bp_medEm;
    slice.GLOBAL_bp_highPx = 16 * slice.GLOBAL_bp_highEm;

    //setting up breakpoint variables for enquire
    slice.GLOBAL_bp_small = "(min-width: 0) and (max-width: "+ slice.GLOBAL_bp_lowEm + "em)";
    slice.GLOBAL_bp_medium = "(min-width: " + slice.GLOBAL_bp_lowEm + "em) and (max-width: " + slice.GLOBAL_bp_medEm + "em)";
    slice.GLOBAL_bp_large = "(min-width: " + slice.GLOBAL_bp_medEm + "em) and (max-width: " + slice.GLOBAL_bp_highEm + "em)";
    slice.GLOBAL_bp_extraLarge = "(min-width: " + slice.GLOBAL_bp_highEm + "em)";
    
    slice.GLOBAL_bp_smallAndMedium = "(min-width: 0) and (max-width: " + slice.GLOBAL_bp_medEm + "em)";
    slice.GLOBAL_bp_mediumAndLarge = "(min-width: " + slice.GLOBAL_bp_lowEm + "em) and (max-width: " + slice.GLOBAL_bp_highEm + "em)";
    slice.GLOBAL_bp_largeAndExtraLarge = "(min-width: " + slice.GLOBAL_bp_medEm + "em)";
    slice.GLOBAL_bp_mediumToExtraLarge = "(min-width: " + slice.GLOBAL_bp_lowEm + "em)";

    return slice;
}(SLICE || {}, jQuery));
