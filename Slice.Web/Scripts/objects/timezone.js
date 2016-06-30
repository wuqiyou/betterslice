var SLICE = (function (parent, $, jstz) {
    var slice = parent || {};
    
    // Takes UTC date and outputs time in 12 hour clock.  Noon would be outputted as 12:00 pm
    slice.TIMEZONE_convertTime = function (dateObject) {
        var armyHour = dateObject.getHours();
        var hour = armyHour;
        var minutes = dateObject.getMinutes();
        if (minutes < 10) {
            minutes = '0' + minutes;
        }
        var amOrPm = 'am';
        if (armyHour >= 12) {
            hour = armyHour - 12;
            amOrPm = 'pm';
        }
        if (hour == 0) {
            hour = 12;
        }

        return hour + ':' + minutes + '<span>' + amOrPm + '</span>';
    }

    slice.TIMEZONE_convertDay = function (dateObject)
    {
        var weekday = new Array(7);
        weekday[0] = "Sundays";
        weekday[1] = "Mondays";
        weekday[2] = "Tuesdays";
        weekday[3] = "Wednesdays";
        weekday[4] = "Thursdays";
        weekday[5] = "Fridays";
        weekday[6] = "Saturdays";

        return weekday[dateObject.getDay()];
    }

    // Used for tune in widget: ensures it is only rendered once, and not for each instance of it in the markup.
    slice.TIMEZONE_tuneInIsRendered = false;

    // Looks for tag with class 'timezone' and writes the appropriate value.
    $(function () { 
        var timezone = jstz.determine();
        response_text = '';
        if (typeof (timezone) === 'undefined') {
            response_text = '';
        }
        else {
            response_text = timezone.name();
        }

        $('.timezone').html(response_text);
    });

    return slice;
}(SLICE || {}, jQuery, jstz));
