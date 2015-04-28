<%@ Assembly Name="RatesDisplay, Version=1.0.0.0, Culture=neutral, PublicKeyToken=7fee33090ab1a3d2" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="RatesDisplay.VisualWebPart1.VisualWebPart1UserControl" %>
<head>
  <meta charset="utf-8">
  <title>jQuery UI Autocomplete - Default functionality</title>
  <link rel="stylesheet" href="/_catalogs/masterpage/scripts/jquery-ui-1.11.1.wdc/jquery-ui.css">
  <script src="/_catalogs/masterpage/scripts/jquery-ui-1.11.1.wdc/external/jquery/jquery.js"></script>
  <script src="/_catalogs/masterpage/scripts/jquery-ui-1.11.1.wdc/jquery-ui.min.js"></script>
  <link rel="stylesheet" href="/_catalogs/masterpage/scripts/resources/demos/style.css">
  
  <script>
      var searchValidator = ""
      $(function () {
          $("#RatesAddress").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      url: "http://api.waitaki.govt.nz/Rates/IdentiferFromAddress?Address=" + request.term + "&prefix=true&singleResult=false&autocomplete=true",
                      dataType: "jsonp",
                      data: {
                          q: request.term
                      },
                      success: function (data) {
                          response(data);
                      }
                  });
              },
              minLength: 4,
              response: function (event, ui) {
                  if (ui.content.length == 1) {
                      $("#RatesAddress").val(ui.content[0].value);
                      searchValidator = ui.content[0].value;
                  }
              },
              select: function (event, ui) {
                  $("#RatesAddress").val(ui.item.value);
                  searchValidator = ui.item.value;
                  redirectToAssessment();
              },
              open: function () {
                  $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
              },
              close: function () {
                  $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
              }
          });
          $("#Valuation").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      url: "http://api.waitaki.govt.nz/Rates/IdentiferFromValuationNum?valuationNum=" + request.term + "&prefix=true&singleResult=false&autocomplete=true",
                      dataType: "jsonp",
                      data: {
                          q: request.term
                      },
                      success: function (data) {
                          response(data);
                      }
                  });
              },
              minLength: 4,
              response: function (event, ui) {
                  if (ui.content.length == 1) {
                      $("#Valuation").val(ui.content[0].value);
                      searchValidator = ui.content[0].value;
                  }
              },
              select: function (event, ui) {
                  $("#Valuation").val(ui.item.value);
                  searchValidator = ui.item.value;
                  redirectToAssessment();
              },
              open: function () {
                  $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
              },
              close: function () {
                  $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
              }
          });
          $("#Assessment").autocomplete({
              source: function (request, response) {
                  $.ajax({
                      url: "http://api.waitaki.govt.nz/Rates/IdentiferFromAssessmentNum?assessmentNum=" + request.term + "&prefix=true&singleResult=false&autocomplete=true",
                      dataType: "jsonp",
                      data: {
                          q: request.term
                      },
                      success: function (data) {
                          
                          response(data);
                      }
                  });
              },
              minLength: 4,
              response: function (event, ui) {
                  if (ui.content.length == 1)
                  {
                      $("#Assessment").val(ui.content[0].value);
                      searchValidator = ui.content[0].value;
                  }
              },
              select: function (event, ui) {
                  $("#Assessment").val(ui.item.value);
                  searchValidator = ui.item.value;
                  redirectToAssessment();
              },
              open: function () {
                  $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
              },
              close: function () {
                  $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
              }
          });
      });
  </script>

    <!-- Google maps -->
    <style>
       #map-canvas {
        height: 100%;
        margin: 0px;
        padding: 0px
      }
    </style>
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyA8mkSJuFC-FUrXGJE9mebBBOx4HcbKdmk"></script>
    
    <script>
        $("Panel1").submit(function(e) {
            e.preventDefault();
        });
        $("btnFind").submit(function(e) {
            e.preventDefault();
        });

        var stylesArray = [
      {
          "featureType": "road.highway",
          "elementType": "geometry",
          "stylers": [
            { "visibility": "simplified" },
            { "color": "#878079" }
          ]
      }, {
          "featureType": "road.highway",
          "elementType": "labels.text.fill",
          "stylers": [
            { "weight": 0.1 },
            { "color": "#000000" }
          ]
      }, {
          "featureType": "water",
          "stylers": [
            { "color": "#7299ae" }
          ]
      }, {
          "featureType": "poi.park",
          "stylers": [
            { "color": "#a2b11e" }
          ]
      }, {
          "featureType": "road.local",
          "elementType": "geometry",
          "stylers": [
            { "color": "#ba4c34" }
          ]
      }, {
          "featureType": "road.arterial",
          "elementType": "geometry",
          "stylers": [
            { "color": "#ba4c34" }
          ]
      }, {
          "featureType": "road.local",
          "elementType": "labels.text.fill",
          "stylers": [
            { "color": "#ffffff" }
          ]
      }, {
          "featureType": "poi.park",
          "elementType": "labels.text.stroke",
          "stylers": [
            { "weight": 1.6 },
            { "color": "#2b2f32" }
          ]
      }, {
          "featureType": "road.local",
          "elementType": "labels.text.stroke",
          "stylers": [
            { "visibility": "on" },
            { "color": "#2b2f32" }
          ]
      }, {
          "featureType": "poi.park",
          "elementType": "labels.text.fill",
          "stylers": [
            { "color": "#ffffff" }
          ]
      }, {
          "featureType": "road.arterial",
          "elementType": "labels.text",
          "stylers": [
            { "color": "#2b2f32" }
          ]
      }, {
          "featureType": "road.arterial",
          "elementType": "labels.text.fill",
          "stylers": [
            { "color": "#ffffff" }
          ]
      }, {
          "featureType": "road.highway",
          "elementType": "labels.text.fill",
          "stylers": [
            { "color": "#ffffff" }
          ]
      }, {
          "featureType": "poi.park",
          "elementType": "labels",
          "stylers": [
            { "visibility": "off" }
          ]
      }, {
          "featureType": "administrative.land_parcel",
          "elementType": "geometry",
          "stylers": [
            { "visibility": "on" },
            { "color": "#2b2f32" }
          ]
      }, {
          "featureType": "administrative.land_parcel",
          "stylers": [
            { "color": "#2b2f32" }
          ]
      }
        ]



        var Address;
        var map;
        var geocoder;
        var sv;
        var panorama;
        var image;
        var center;
        var marker


        function initialize() {
            setAddress();
            image = '/SiteAssets/image/marker.png';
            panorama = new google.maps.StreetViewPanorama(document.getElementById('pano'));
            sv = new google.maps.StreetViewService();
            geocoder = new google.maps.Geocoder();
            var mapOptions = {
                panControls: false,
                draggable: false,
                scrollwheel: true,
                disableDefaultUI: true,
                overviewMapControl: false,
                scaleControl: false,
                streetViewControl: false,
                zoomControl: true,
                disableDoubleClickZoom: false,
                styles: stylesArray,
                mapTypeId: google.maps.MapTypeId.ROADMAP,

                zoom: 14,
                center: new google.maps.LatLng(-45.0842, 170.9806)
            };
            codeAddress();
            map = new google.maps.Map(document.getElementById('map-canvas'),
                mapOptions);


        }

        function processSVData(data, status) {
            if (status == google.maps.StreetViewStatus.OK) {
                $("#pano").css("display", "block");
                $("#map-canvas").css("width", "50%");
                google.maps.event.trigger(map, "resize");
                map.setCenter(center);
                panorama.setPano(data.location.pano);
                panorama.setPov({
                    heading: 270,
                    pitch: 0
                });
                panorama.setVisible(true);


                var markerPanoID = data.location.pano;
                // Set the Pano to use the passed panoID
                panorama.setPano(markerPanoID);
                panorama.setPov({
                    heading: 270,
                    pitch: 0
                });
                panorama.setVisible(true);

            } 
        }

        function toggleBounce() {
            if (marker !== "undefined")
            if (marker.getAnimation() != null) {
                marker.setAnimation(google.maps.Animation.BOUNCE);
            } else {
                marker.setAnimation(google.maps.Animation.BOUNCE);
            }
        }


        function codeAddress() {
            $("#ratesInformationHolder").css("display", "block");
            geocoder.geocode({ 'address': Address }, function (results, status) {
                if (status == google.maps.GeocoderStatus.OK) {
                    
                    center = results[0].geometry.location;
                    $("#map-canvas").css("display", "block");
                    $("#map-canvas").css("width", "100%");
                   // $("#map-canvas").css("width", "100%");
                    sv.getPanoramaByLocation(results[0].geometry.location, 50, processSVData);
                    google.maps.event.trigger(map, "resize");
                    map.setCenter(center);
                    map.setZoom(18);
                    marker = new google.maps.Marker({
                        icon: image,
                        animation: google.maps.Animation.BOUNCE,
                        title: Address,
                        map: map,
                        position: results[0].geometry.location
                    });

                }
            });
            
        }


        google.maps.event.addDomListener(window, 'load', initialize);
        if ($("#map-canvas").css("display") == "block")
        toggleBounce();

        function setAddress()
        {
            var element = $("#hiddenAddress");
            element = element.children(":first")
            Address = element[0].innerHTML;
        }

        function vaildate(textboxvalue)
        {
            if (textboxvalue == searchValidator)
            {
                return true;
            }
            else
            {
                alert("Please enter a valid search");
                return false;
            }
        }

        //Script for the lookup columns
        function redirectToAssessment()
        {

          
            var assessmentNumberDirect = "";
            if (!!$("#Assessment").val())
            {
                if (vaildate($("#Assessment").val())) {
                    var temp = $("#Assessment").val();
                    temp = temp.split(", ");
                    assessmentNumberDirect = temp[0];
                }
                else
                {
                    $("#Assessment").val("");
                }
            }
            else if (!!$("#RatesAddress").val())
            {
                if (vaildate($("#RatesAddress").val())) {
                    var temp = $("#RatesAddress").val();
                    temp = temp.split("Assessment Number:");
                    assessmentNumberDirect = temp[1];
                }
                else {
                    $("#RatesAddress").val("");
                }
            }
            else if (!!$("#Valuation").val())
            {
                if (vaildate($("#Valuation").val())) {
                    var temp = $("#Valuation").val();
                    temp = temp.split("Assessment Number:");
                    assessmentNumberDirect = temp[1];
                }
                else {
                    $("#Valuation").val("");
                }
            }

            if(!!assessmentNumberDirect)
            window.location.replace(window.location.pathname + "?AssessmentNumber=" + assessmentNumberDirect);
        }


        function clearSearchForm(currentList) {
            if (currentList == "RatesAddress")
            {
                $("#Assessment").val('');
                $("#Valuation").val('');

            }
            else if (currentList == "Assessment")
            {
                $("#RatesAddress").val('');
                $("#Valuation").val('');
            }
            else if (currentList == "Valuation") {
                $("#RatesAddress").val('');
                $("#Assessment").val('');
            }
        }

        
        
    </script>


    <style>
  .ui-autocomplete-loading {
    background: white url("/SiteAssets/image/loading.gif") right center no-repeat;
    width:50%;
  }
  #city { width: 25em; }

  .propertylabel{
      padding:10px;
      font-weight:bold;
      font-family:arial;

  }

  #ratesLevied table tr:first-child
  {
      font-weight:bold;
      font-size:large;
      background:none;
  }

    #RatesInformation table tr td:first-child
  {
      font-weight:bold;
      background:rgba(162, 177, 30, 0.34);
      width:25%;
  }

    #RatesInformation tr td:first-child
    {
        width:25%;
    }

           #ratesLevied tr td
    {
        text-align:right;
    }

        #ratesLevied tr td:first-child
    {
        text-align:left;
    }


        #RatesInformation > div
        {
            margin-left:auto;
            margin-right:auto;
            width:100%;
        }
        #RatesInformation table
        {
            width:100%;
            border:1px solid black;
        }
 
        #ratesLevied td
        {
            width:25%;
        }

        .formItemHolder
        {
            display:block;
            width:100%;
            height:40px;
            padding:10px;
        }
        .searchWidth{
            min-width:170px;
            width:30%;
            line-height:30px;
            font-size:16px;
            font-weight:bold;
        }

        .searchWidth::-ms-clear {
        display: none;
        }

        #ratesInformationHolder
        {
            display: none;
        }

        #ratesDisclaimer p
        {
             font-size:8px;   
        }
        
        #ratePrintButton{
            margin: 10px;
        }

    </style>

    <style>
        @media print 
        {
            .ui-widget
            {
                display:none;
            }

            #ratePrintButton
            {
                display:none;
            }

            #imgOfProperty, #map-canvas, #pano
            {
                display:none !important;
            }

            #RatesInformation td
            {
               font-size:9px;
            }
                    #ratesDisclaimer p
        {
             font-size:6px;   
        }


        }
    </style>

</head>
<body>
<div id="hiddenAddress" style="display:none">
    <asp:Label ID="hiddenAddressServer" runat="server" Text=""></asp:Label></div>


<div id="RatesInformation" style="width:80%;margin-left:auto;margin-right:auto">
    <div class="ui-widget" style="width:100%;">
        <asp:Panel ID="Panel1" runat="server" DefaultButton="btnFind">
            <div class="formItemHolder">
            <label for="RatesAddress" style="float:left;" class="searchWidth">Address:</label>
            <input id="RatesAddress" onclick="clearSearchForm('RatesAddress')" class="ui-autocomplete-input searchWidth" autocomplete="off" width="350"/></div>
            <div class="formItemHolder">
			<label for="Assessment" style="float:left;" class="searchWidth">Assessment Number:</label>
            <input  id="Assessment" onclick="clearSearchForm('Assessment')" class="ui-autocomplete-input searchWidth" autocomplete="off" width="300" /></div>
            <div class="formItemHolder">
            <label for="Valuation" style="float:left;" class="searchWidth">Valuation Number:</label>
            <input  id="Valuation" onclick="clearSearchForm('Valuation')" class="ui-autocomplete-input searchWidth" autocomplete="off" width="300" /></div>

            <asp:Button ID="btnFind" runat="server" OnClientClick="redirectToAssessment();  return false;" Text="Find" style="margin-left: 30%; left:10px; position:relative; padding-left:10px; width:80px;" />
            <br/>
            <asp:Label ID="PropertyName" runat="server" CssClass="propertylabel"></asp:Label>
        </asp:Panel>
    </div>
    <div id="ratesInformationHolder">
    <div id="imgOfProperty" style="display:block; height:100px">
        <div id="map-canvas" style="display:none; width: 50%; height: 350px;float:left"></div>
        <div id="pano" style="display:none; width: 50%; height: 350px;float:left"></div>
    </div>
    <div id="propertyInformation" class="hideDiv">
        <h1>Property Information:</h1><asp:GridView ID="gridPropertyInfo" runat="server" ShowHeader="False"></asp:GridView>
    </div>
    <div id="currentRates" class="hideDiv">
    <h1>Current Rates</h1>
        <asp:GridView ID="gridCurrentRates" runat="server" ShowHeader="False"></asp:GridView>
        </div>
    <div id="ratesLevied" class="hideDiv">
        <h1>Rates levied</h1>
        <asp:DataGrid ID="gridRatesLevied" runat="server" ShowHeader="False"></asp:DataGrid>
    </div>
        <input id="ratePrintButton" type="button" value="Print this Assessment" onClick="window.print()">
    <div id="ratesDisclaimer">
        <p>Disclaimer: Public Access to Name and Postal Addresses of Ratepayers: The Waitaki District Council holds information from the Ratepayer as part of its rating process. In accordance with Section 28 C of the Local Government (Rating) Act 2002, a Ratepayer can request to have their name and/or their postal address withheld from the Rating Information Database (RID). Every Ratepayer has the right to request that this information be withheld, but this request must be in writing. This can be done through the form &quot;Name Suppression Request&quot;.

The RID is regularly maintained and therefore is subject to ongoing change. 
This information is provided under Section 28 of the Local Government (Rating) Act 2002 as an online representation of our Rating Information Database (RID).
The Council Rating Information Database (RID) is freely available to the public at Waitaki District Council, in the same form as is available here.
The information presented here is current.

This information is made available in good faith but its accuracy is not guaranteed.

Waitaki District Council accepts no liability for any error.

        </p>
</div></div>
</div>

 
</body>
