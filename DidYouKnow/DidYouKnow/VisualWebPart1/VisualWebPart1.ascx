<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1.ascx.cs" Inherits="DidYouKnow.VisualWebPart1.VisualWebPart1" %>
<head>
    <title>Did you know</title>
<style type="text/css">
/*CSS to House */
.dyktop {
	position:absolute;
    width: 0;
	height: 0;
	margin-top:30px;
	margin-left:35px;
	
	border-left: 61px solid transparent;


}

.dyksquare {
	  margin-top:22px;
  margin-left:7px;
  position: absolute;
  content: '';
  width: 86px;
  height: 46px;
  background: #554d89;
  -ms-transform: rotate(-45deg); /* IE 9 */
    -webkit-transform: rotate(-45deg); /* Chrome, Safari, Opera */
     transform: rotate(-45deg);
}

.dyktext {
	color:white;
	position:absolute;
	margin-left:8px;
	margin-top:25px;
	width:86px;
		font-family:Arial, Helvetica, sans-serif;
        font-size:16px;
font-weight:600;
    -ms-transform: rotate(-45deg); /* IE 9 */
    -webkit-transform: rotate(-45deg); /* Chrome, Safari, Opera */
     transform: rotate(-45deg);
	 text-align:center;
}



.dykmessage
{
	padding-top:30px;
	margin-left:100px;
	font-family:Arial, Helvetica, sans-serif;
	font-size:12px;
}

			
</style>

</head>

<body>
    <div style="min-height:80px;">
		<div id="dyktop" class="dyktop" runat="server"></div>
		<div id="dyksquare" class="dyksquare" runat="server"></div>
		<div class='dyktext'>DID YOU KNOW?</div>
        <div id="dykmessage" class="dykmessage" runat="server"></div>
        </div>
</body>

