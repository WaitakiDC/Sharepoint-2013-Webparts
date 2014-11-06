<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1.ascx.cs" Inherits="MeetingListWebpart.VisualWebPart1.VisualWebPart1" %>
<head>
    <script src="http://wdcdmzsp4/business/SiteAssets/jquery.js"></script>
<title>Meetings Webpart</title>
    <script type="text/javascript">
        function displayMeetingLocation(iframeCode)
        {
            //$("meeting-location-popup").html(iframeCode).text();
            var popuplocation = document.getElementById("meeting-location-popup");
            popuplocation.innerHTML = iframeCode;

            var popupcontainer = document.getElementById("meeting-location-container-popup");
            popupcontainer.style.display =    'block';
        }
        function hidelocationpopup()
        {
            var lpop = document.getElementById("meeting-location-container-popup");
            lpop.style.display = 'none';
        }
    </script>
<style>
#MeetingContainer 
{
	text-align:center;
	font-family:Arial;
	width:100%;
}

#MeetingContainer table tr
{

	margin-top:5px;
}
#MeetingContainer table 
{
    border: 1px solid #666280;
	width:100%;
    max-width:700px;
	border-collapse:separate;
    margin-left:auto;
    margin-right:auto;


}
#MeetingContainer .edges
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
#MeetingContainer .edges h1,#MeetingContainer .edges h2
	{
        color:white;
		padding:0;
		margin:0;
	}
#MeetingContainer .middlecell
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
	
	#MeetingContainer table tr > td
{
  margin-bottom: 1em;
}
#MeetingContainer a
{
	font-size:8px;
}
#MeetingContainer .center
{
	font-weight:normal;
	line-height:80px;
}

.meeting-location-popup {
    width: 50%;
    height: 50%;
    background: #1abcb9;
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
</style>

</head>

<body>
	<div id="MeetingContainer">
		<table runat="server" id="meetingTable">

        
        
        </table>
	</div>
    <div id="meeting-location-container-popup" class="meeting-location-container-popup" onclick="hidelocationpopup()'>
    <div id="meeting-location-popup" class="meeting-location-popup"></div>
</div>
</body>