<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1.ascx.cs" Inherits="AlertWebpart.VisualWebPart1.VisualWebPart1" %>
<head><title>Alerts</title>
<style type="text/css">

    .timestamp {
        font-style:italic;
        font-size:10px;
    }

#AlertContainer
{
	width:350px;
}

#AlertBanner
{
	padding-left:20px;
	background: #d20202;
	font-family:Arial, Helvetica, sans-serif;
	font-size:20px;
	font-weight:bold;
	color:white;
}

#AlertsList
{
	font-family:Arial, Helvetica, sans-serif;
	font-size:8px;
	padding:0;
	margin:0;
}

#AlertsList p
{
	font-family:Arial, Helvetica, sans-serif;
	font-size:10px;
}

#AlertsList li
{
	display:block;
	width:100%;
	background-color:#F2F2F2;
}

.AlertsText
{
	vertical-align:text-top;
	position:static;
	padding-right:20px;
    color:black;
	margin:0;
	margin-top:-40px;
	margin-left:45px;
	padding-top:0px;
	display: block;	
}

.AlertsText h1
{
    color:black;
}


.AlertsImage
{
	width:20px;
	padding:10px;
}

.green
{
	width: 25px;
	height: 25px;
	background: #669900;
}

.yellow
{
	width: 25px;
	height: 25px;
	background: #ff9900;
}

.red
{
	width: 25px;
	height: 25px;
	background: #d20202;
}

.AlertItem
{
	width:100%;
	display: table-row;
}

</style>
<script>
    (function (factory) {
        if (typeof define === 'function' && define.amd) {
            // AMD. Register as an anonymous module.
            define(['jquery'], factory);
        } else {
            // Browser globals
            factory(jQuery);
        }
    }(function ($) {
        $.timeago = function (timestamp) {
            if (timestamp instanceof Date) {
                return inWords(timestamp);
            } else if (typeof timestamp === "string") {
                return inWords($.timeago.parse(timestamp));
            } else if (typeof timestamp === "number") {
                return inWords(new Date(timestamp));
            } else {
                return inWords($.timeago.datetime(timestamp));
            }
        };
        var $t = $.timeago;

        $.extend($.timeago, {
            settings: {
                refreshMillis: 60000,
                allowPast: true,
                allowFuture: false,
                localeTitle: false,
                cutoff: 0,
                strings: {
                    prefixAgo: null,
                    prefixFromNow: null,
                    suffixAgo: "ago",
                    suffixFromNow: "from now",
                    inPast: 'any moment now',
                    seconds: "less than a minute",
                    minute: "about a minute",
                    minutes: "%d minutes",
                    hour: "about an hour",
                    hours: "about %d hours",
                    day: "a day",
                    days: "%d days",
                    month: "about a month",
                    months: "%d months",
                    year: "about a year",
                    years: "%d years",
                    wordSeparator: " ",
                    numbers: []
                }
            },

            inWords: function (distanceMillis) {
                if (!this.settings.allowPast && !this.settings.allowFuture) {
                    throw 'timeago allowPast and allowFuture settings can not both be set to false.';
                }

                var $l = this.settings.strings;
                var prefix = $l.prefixAgo;
                var suffix = $l.suffixAgo;
                if (this.settings.allowFuture) {
                    if (distanceMillis < 0) {
                        prefix = $l.prefixFromNow;
                        suffix = $l.suffixFromNow;
                    }
                }

                if (!this.settings.allowPast && distanceMillis >= 0) {
                    return this.settings.strings.inPast;
                }

                var seconds = Math.abs(distanceMillis) / 1000;
                var minutes = seconds / 60;
                var hours = minutes / 60;
                var days = hours / 24;
                var years = days / 365;

                function substitute(stringOrFunction, number) {
                    var string = $.isFunction(stringOrFunction) ? stringOrFunction(number, distanceMillis) : stringOrFunction;
                    var value = ($l.numbers && $l.numbers[number]) || number;
                    return string.replace(/%d/i, value);
                }

                var words = seconds < 45 && substitute($l.seconds, Math.round(seconds)) ||
                  seconds < 90 && substitute($l.minute, 1) ||
                  minutes < 45 && substitute($l.minutes, Math.round(minutes)) ||
                  minutes < 90 && substitute($l.hour, 1) ||
                  hours < 24 && substitute($l.hours, Math.round(hours)) ||
                  hours < 42 && substitute($l.day, 1) ||
                  days < 30 && substitute($l.days, Math.round(days)) ||
                  days < 45 && substitute($l.month, 1) ||
                  days < 365 && substitute($l.months, Math.round(days / 30)) ||
                  years < 1.5 && substitute($l.year, 1) ||
                  substitute($l.years, Math.round(years));

                var separator = $l.wordSeparator || "";
                if ($l.wordSeparator === undefined) { separator = " "; }
                return $.trim([prefix, words, suffix].join(separator));
            },

            parse: function (iso8601) {
                var s = $.trim(iso8601);
                s = s.replace(/\.\d+/, ""); // remove milliseconds
                s = s.replace(/-/, "/").replace(/-/, "/");
                s = s.replace(/T/, " ").replace(/Z/, " UTC");
                s = s.replace(/([\+\-]\d\d)\:?(\d\d)/, " $1$2"); // -04:00 -> -0400
                s = s.replace(/([\+\-]\d\d)$/, " $100"); // +09 -> +0900
                return new Date(s);
            },
            datetime: function (elem) {
                var iso8601 = $t.isTime(elem) ? $(elem).attr("datetime") : $(elem).attr("title");
                return $t.parse(iso8601);
            },
            isTime: function (elem) {
                // jQuery's `is()` doesn't play well with HTML5 in IE
                return $(elem).get(0).tagName.toLowerCase() === "time"; // $(elem).is("time");
            }
        });

        // functions that can be called via $(el).timeago('action')
        // init is default when no action is given
        // functions are called with context of a single element
        var functions = {
            init: function () {
                var refresh_el = $.proxy(refresh, this);
                refresh_el();
                var $s = $t.settings;
                if ($s.refreshMillis > 0) {
                    this._timeagoInterval = setInterval(refresh_el, $s.refreshMillis);
                }
            },
            update: function (time) {
                var parsedTime = $t.parse(time);
                $(this).data('timeago', { datetime: parsedTime });
                if ($t.settings.localeTitle) $(this).attr("title", parsedTime.toLocaleString());
                refresh.apply(this);
            },
            updateFromDOM: function () {
                $(this).data('timeago', { datetime: $t.parse($t.isTime(this) ? $(this).attr("datetime") : $(this).attr("title")) });
                refresh.apply(this);
            },
            dispose: function () {
                if (this._timeagoInterval) {
                    window.clearInterval(this._timeagoInterval);
                    this._timeagoInterval = null;
                }
            }
        };

        $.fn.timeago = function (action, options) {
            var fn = action ? functions[action] : functions.init;
            if (!fn) {
                throw new Error("Unknown function name '" + action + "' for timeago");
            }
            // each over objects here and call the requested function
            this.each(function () {
                fn.call(this, options);
            });
            return this;
        };

        function refresh() {
            var data = prepareData(this);
            var $s = $t.settings;

            if (!isNaN(data.datetime)) {
                if ($s.cutoff == 0 || Math.abs(distance(data.datetime)) < $s.cutoff) {
                    $(this).text(inWords(data.datetime));
                }
            }
            return this;
        }

        function prepareData(element) {
            element = $(element);
            if (!element.data("timeago")) {
                element.data("timeago", { datetime: $t.datetime(element) });
                var text = $.trim(element.text());
                if ($t.settings.localeTitle) {
                    element.attr("title", element.data('timeago').datetime.toLocaleString());
                } else if (text.length > 0 && !($t.isTime(element) && element.attr("title"))) {
                    element.attr("title", text);
                }
            }
            return element.data("timeago");
        }

        function inWords(date) {
            return $t.inWords(distance(date));
        }

        function distance(date) {
            return (new Date().getTime() - date.getTime());
        }

        // fix for IE6 suckage
        document.createElement("abbr");
        document.createElement("time");
    }));
</script>


<script type="text/javascript">
    jQuery(document).ready(function () {
        jQuery("abbr.timeago").timeago();
    });
</script>




</head>
<body>
<div id="AlertContainer">
<div id="AlertBanner">Alerts</div>
	<ul id="AlertsList">
        <div id="AlertItemsHere" runat="server">

        </div>
    </ul>
</div>


</body>
<script type="text/javascript">
    findWorstAlert();
    function findWorstAlert() {
        domList = document.getElementById("AlertsList");
        if ((domList.innerHTML.toString()).indexOf("class=\"red\"") > -1) {
            AlertBanner = document.getElementById("AlertBanner");
            AlertBanner.style.backgroundColor = "#d20202";
        }
        else if ((domList.innerHTML.toString()).indexOf("class=\"yellow\"") > -1) {
            AlertBanner = document.getElementById("AlertBanner");
            AlertBanner.style.backgroundColor = "#ff9900";
        }
        else {
            AlertBanner = document.getElementById("AlertBanner");
            AlertBanner.style.backgroundColor = "#669900";
            if ((domList.innerHTML.toString()).indexOf("li") == -1) {
                domList.innerHTML = "<li><div class=\"AlertItem\"><div class=\"AlertsImage\"><div class=\"green\"></div></div><div class=\"AlertsText\"><h1>No current alerts</h1><p>All is well in the district</p><p class=\"timestamp\">Now</p></div></div></li>"
            }
        }
    }


</script>

