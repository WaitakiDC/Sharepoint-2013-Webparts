<%@ Assembly Name="FacebookTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=c4788cad1c8f499a" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="FacebookTest.VisualWebPart1.VisualWebPart1UserControl" %>
<head>
<meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
<title>Untitled 1</title>
<style type="text/css">
.facebook_post
{
	width:100%;
	background:#EEEEEE;
	display:inline-block;
	margin-bottom:20px;
	
}
.post_picture
{
    
	display:inline-block;
	float:left;
    height:100%;
}
.post_picture img
{
    max-width:100px;
	padding:10px;
	width:auto;
	max-height:100px;
}

.facebook_text_container
{
	display:inline-block;
	float:right;
    width:300px;
}

.fb_text_container
{
    position:relative;
}

.fb_text_container h1
{
	font-family:Arial, Helvetica, sans-serif;
	font-size:14px;
	margin:10px;
	color:#BA4C34;
	margin-bottom:2px;
    
}



.facebook_link 
{
	font-family:Arial, Helvetica, sans-serif;
	color:#7E7E7E;
	font-size:10px;
    	font-family:Arial, Helvetica, sans-serif;
	margin:10px;

	
}
.facebook_link_desc p
{
		font-family:Arial, Helvetica, sans-serif;
	color:#7E7E7E;
	font-size:12px;

}
.facebook_message_header
{
	border-top:thin;
	border-style:solid;
	height:50px;
	
}
.facebook_message_header_image
{
	display:inline-block;
	float:left;
	padding:5px;
}
.facebook_message_header_text
{
	font-family:Arial, Helvetica, sans-serif;
	font-weight:bold;
	color:#BA4C34;
	line-height:65px;
	vertical-align:middle;
	font-size:16px;
}

.fb_message
{
	font-family:Arial, Helvetica, sans-serif;
	font-size:12px;
	margin: 5px;
	
}

.post
{
display:inline-block;
display: table-cell;
width:50%;
	border-style:solid;
	border:none;

background: -moz-linear-gradient(left,  rgba(255,255,255,0) 0%, rgba(255,255,255,0.47) 73%, rgba(196,196,196,0.65) 100%); /* FF3.6+ */
background: -webkit-gradient(linear, left top, right top, color-stop(0%,rgba(255,255,255,0)), color-stop(73%,rgba(255,255,255,0.47)), color-stop(100%,rgba(196,196,196,0.65))); /* Chrome,Safari4+ */
background: -webkit-linear-gradient(left,  rgba(255,255,255,0) 0%,rgba(255,255,255,0.47) 73%,rgba(196,196,196,0.65) 100%); /* Chrome10+,Safari5.1+ */
background: -o-linear-gradient(left,  rgba(255,255,255,0) 0%,rgba(255,255,255,0.47) 73%,rgba(196,196,196,0.65) 100%); /* Opera 11.10+ */
background: -ms-linear-gradient(left,  rgba(255,255,255,0) 0%,rgba(255,255,255,0.47) 73%,rgba(196,196,196,0.65) 100%); /* IE10+ */
background: linear-gradient(to right,  rgba(255,255,255,0) 0%,rgba(255,255,255,0.47) 73%,rgba(196,196,196,0.65) 100%); /* W3C */
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#00ffffff', endColorstr='#a6c4c4c4',GradientType=1 ); /* IE6-9 */






}

#facebooklogo
{
    border-right:thick solid #43609C;
	background:#43609C;
	font-family:Arial, Helvetica, sans-serif;
	font-weight:bold;
	color:white;
	font-size:16px;
	width:100%;
	height:40px;
	
}
#facebooklogo div
{
	margin-top:12px;
	display:inline-block;
}
#facebooklogo img
{
	float:left;
	display:inline-block;
	padding:5px;
	height:30px;
	width:30px;
}
.facebook_message_header_image img
{
	margin-right:20px;
}

.timeandlink
{
	font-family:Arial, Helvetica, sans-serif;
	color:#BA4C34;
	font-size:10px;
}

#postsContainer
{
     border-left:thick solid #43609C;
    border-right:thick solid #43609C;
    border-bottom:thick solid #43609C;
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

    <div id="facebookwebpart" runat="server" style="width:800px">

    </div>
</body>
