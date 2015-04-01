<%@ Assembly Name="Cemeteries, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5ed2b67506fa62d6" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="Cemeteries.VisualWebPart1.VisualWebPart1UserControl" %>
<script src="http://wdcdmzweb1/_catalogs/masterpage/scripts/jquery.js" type="text/javascript"></script>




<script type="text/javascript">

    var urlParams;
    (window.onpopstate = function () {
        var match,
            pl = /\+/g,  // Regex for replacing addition symbol with a space
            search = /([^&=]+)=?([^&]*)/g,
            decode = function (s) { return decodeURIComponent(s.replace(pl, " ")); },
            query = window.location.search.substring(1);

        urlParams = {};
        while (match = search.exec(query))
            urlParams[decode(match[1])] = decode(match[2]);
    })();
   
    _spBodyOnLoadFunctionNames.push("loadFromURL");

    function loadFromURL()
    {
        var first = urlParams["first"]
        var last = urlParams["last"]
        var exFirst = urlParams["exFirst"]
        var exLast = urlParams["exLast"]

        $('#txtFirstName').val(first);
        $('#txtLastName').val(last);
        if (exFirst == "true")
        {
            $('#chkbxExactFirst').prop('checked',true);
        }
        if (exLast == "true") {
            $('#chkbxExactLast').prop('checked', true);
        }

        $("#txtFirstName").keyup(function (event) {
            if (event.keyCode == 13) {
                $("#txtFirstName").click();
            }
        });

        $("#txtLastName").keyup(function (event) {
            if (event.keyCode == 13) {
                $("#txtLastName").click();
            }
        });

    }
    function searchRedirect()
    {
        var first = $('#txtFirstName').val();
        var last = $('#txtLastName').val();
        var exFirst = $('#chkbxExactFirst').prop('checked');
        var exLast = $('#chkbxExactLast').prop('checked');
        var newURL = "http://wdcdmzsp4/SitePages/Home.aspx?first=" + first + "&last=" + last + "&exFirst=" + exFirst + "&exLast=" + exLast
        window.location.href = newURL
    }



</script>

<style type="text/css">
    #CemeterySearchBox, #CemeterySearchResultsContainer
    {
        width:90% ;
        margin-left:auto;
        margin-right:auto;
    }

    .rightAlign
    {
        text-align: right;
    }



</style>
<asp:Panel ID="Panel1" runat="server" defaultbutton="searchbtn">
<div id="CemeterySearchContainer">
    <div id="CemeterySearchBox">
        <h2>Please enter the name to search</h2>
        <p>This can be part of the full name. You can also enter the surname or forename by itself.</p>
        Forename(s):<input type="text" name="FirstName" id="txtFirstName" runat="server">
        Surname:<input type="text" name="Surname" id="txtLastName" runat="server"><br/>
        Find exact match to Forename(s)?<input name="chkbxExactFirst" id="chkbxExactFirst" type="checkbox" value="false" runat="server"><br/>
        Find exact match to Surname?<input name="chkbxExactLast" id="chkbxExactLast" type="checkbox" value="false" runat="server"><br/>
        <asp:Button id="searchbtn" Text="Search"  runat="server" OnClientClick="searchRedirect()" OnClick="searchbtn_Click" />
    </div>
    <div id="CemeterySearchResultsContainer">
        <table id="CemeterySearchResultsTable" runat="server">
            <thead><tr><th style="text-align:center">Forename(s)</th><th style="text-align:center">Surname</th><th style="text-align:center">Age</th><th style="text-align:center">Burial Date</th><th style="text-align:center">Date of Death</th><th style="text-align:center">Cemetery</th><th style="text-align:center">Block</th><th style="text-align:center">Plot Number</th></tr></thead>

        </table>

    </div>

</div>
    </asp:Panel>
