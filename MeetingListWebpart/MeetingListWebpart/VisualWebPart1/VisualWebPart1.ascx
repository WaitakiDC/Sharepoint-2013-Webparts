<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1.ascx.cs" Inherits="MeetingListWebpart.VisualWebPart1.VisualWebPart1" %>
<head>
    <link rel="stylesheet" href="/_catalogs/masterpage/scripts/MeetingsScripts/footable.core.css" />
    		    <script src="/_catalogs/masterpage/scripts/MeetingsScripts/footable.js" type="text/javascript"></script>
    <script src="/_catalogs/masterpage/scripts/MeetingsScripts/footable.paginate.js" type="text/javascript"></script>


  

<title>Meetings Webpart</title>

<style>
.MeetingContainer 
{
	text-align:center;
	font-family:Arial;
	width:100%;
}

.MeetingContainer table tr
{

	margin-top:5px;
}
.MeetingContainer table 
{
    border: 1px solid #666280;
	width:100%;
    max-width:700px;
	border-collapse:separate;
    margin-left:auto;
    margin-right:auto;


}
.MeetingContainer .edges
	{
		margin:0;
		padding:0;
		text-align:center;
		font-size:10px;
		color:white;
		width:22%;
		height:150px;
		background: rgb(102,98,128); 

	}
.MeetingContainer .edges h1,.MeetingContainer .edges h2
	{
        color:white;
		padding:0;
		margin:0;
	}
.MeetingContainer .middlecell
	{
    padding-left:5px;
    padding-right:5px;
		text-align:left;
		width:56%;
		border-width:1px;
		border-style:solid;
		border-color:rgb(102,98,128);
		border-bottom-width:1px;
		border-bottom-style:solid;
		border-bottom-color:rgb(102,98,128);

	}

.ui-widget-header, .ui-state-default
{
    background:#666280!important;
}

.ui-tabs-active
{
    background:white!important;
}

#MeetingContainer, #ArchiveMeetingContainer
{
    width:100%;
    padding:0;
}

.ui-widget-content
{
    border:none;
}

#tabs
{
    width:700px;
}
	
	.MeetingContainer table tr > td
{
  margin-bottom: 1em;
}
.MeetingContainer a
{
	font-size:8px;
}
.MeetingContainer .center
{
	font-weight:normal;
	line-height:80px;
}

.meeting-location-popup {
    width: 600px;
    height: 450px;
    background: white;
    position: absolute;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    margin: auto;
}

.meeting-location-container-popup {
    display:none;
    position: fixed;
    top: 0;
    right: 0;
    bottom: 0;
    left: 0;
    background: rgba(0,0,0,.8);
}

.MeetingContainer h3
{
    color:white;
    font-weight:bold;
}
.middlecell h1
{
    color:black;
    font-size: 20px !important;
}

.MeetingContainer a
{
    font-size:10px;
}

.MeetingContainer li
{
    display:inline-block;
    width:20px;
    height:20px;
    font-size:12px;
    background-color:#2b2f32;
    line-height:20px;
    color:white;
    padding:5px;
    margin-left:1px;
    margin-right:1px;
}


.MeetingContainer li a,.MeetingContainer li a:visited
{
        width:20px;
    height:20px;
    font-size:18px;
    background-color:#2b2f32;
    color:white;
}

.MeetingContainer .active
{
    background-color:#878079;

}
.MeetingContainer .active a
{
    background-color:#878079;

}
.MeetingContainer .active a
{
    color:black;

}

.hoverpointer { cursor: pointer; }

</style>

</head>

<body>
    <div id="tabs">
        <ul>
            <li><a href="#MeetingContainer">Current Meetings</a></li>
            <li><a href="#ArchiveMeetingContainer">Archived Meetings</a></li>
        </ul>

	    <div class="MeetingContainer" id="MeetingContainer">
		    <table runat="server" class="meetingTable" id="meetingTable" data-page-size="5"> 

		    </table>
	    </div>

        <div class="MeetingContainer" id="ArchiveMeetingContainer">
            <table runat="server" class="meetingTable" id="archiveMeetingTable" data-page-size="5">
            </table>
        </div>

        <div id="meeting-location-container-popup" class="meeting-location-container-popup" onclick="hidelocationpopup()">
            <div id="meeting-location-popup" class="meeting-location-popup"></div>
        </div>
    </div>
    <script type="text/javascript">

        document.getElementsByClassName("meetingTable")[0].innerHTML = document.getElementsByClassName("meetingTable")[0].innerHTML + "<tfoot><tr><td colspan=\"3\"><div class=\"pagination pagination-centered\"></div></td></tr></tfoot>";
        document.getElementsByClassName("meetingTable")[1].innerHTML = document.getElementsByClassName("meetingTable")[1].innerHTML + "<tfoot><tr><td colspan=\"3\"><div class=\"pagination pagination-centered\"></div></td></tr></tfoot>";

          $(function () {
              $('.meetingTable').footable();
          });

          function displayMeetingLocation(iframeCode) {
              //$("meeting-location-popup").html(iframeCode).text();
              var popuplocation = document.getElementById("meeting-location-popup");
              popuplocation.innerHTML = iframeCode;

              var popupcontainer = document.getElementById("meeting-location-container-popup");
              popupcontainer.style.display = 'block';
          }
          function hidelocationpopup() {
              var lpop = document.getElementById("meeting-location-container-popup");
              lpop.style.display = 'none';
          }

          $(function () {
              $("#tabs").tabs();



          });




</script>

</body>