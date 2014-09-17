<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1.ascx.cs" Inherits="NavigationTiles.VisualWebPart1.VisualWebPart1" %>
<style type="text/css">
#panelsHolder 
{
	width:100%;
}

#panelsHolder ul 
{
    margin-top:40px;
}

#panelsHolder li > a > ul 
{
    margin-top: 0px;
}

#panelsHolder li > a > ul > li 
{
    font-size: 12px;    
    font-weight: normal;
    margin-top: -7px;
}

#panelsHolder div > li
{
	font-family:Arial, Helvetica, sans-serif;
	font-weight:bold;
	height: 200px;
	width: 360px;
    background-position: center;
	background-position-x: center;
	background-origin: padding-box;
	margin:0px;
	padding:0px;
	float: left;
	overflow: hidden;
	background-position-y: center;
	display:inline-block;
line-height: 21.99px;
	background-color: rgb(240, 236, 233);
	color:black;
	background-repeat: no-repeat;
	border-bottom: 1px dotted #999;
	border-right: 1px dotted #999;
}

#panelsHolder div > li a
{
	font-size: 20px;
	width: 360px;
	height: 200px;
	display: block;
	overflow: hidden;
	line-height: 1.1;
	font-weight: bold;
	padding: 15px 22px 7px 30px;
	text-decoration: none;
	color: black;
}

#panelsHolder div > li a:hover
{
	color:white;
}

#panelsHolder div > li:hover
{
	color:white;
	
}



</style>

<style type="text/css" id="navilistyle" runat="server">
    </style>

<div id="panelsHolder">
<ul>
<div id="naviItems" runat="server">
</div>
</ul>
</div>