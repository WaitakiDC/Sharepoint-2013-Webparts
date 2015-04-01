<%@ Assembly Name="BuildingConsents, Version=1.0.0.0, Culture=neutral, PublicKeyToken=d36c0d3342203c03" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="BuildingConsents.VisualWebPart1.VisualWebPart1UserControl" %>
<style type="text/css">
    #bcSearchContainer table
    {
        width:100%;
        padding:20px,20px,20px,20px;
    }

    .bcRed
    {
        height:20px;
        width:20px;
        background:#d20202;
        display:inline-block;

    }
        .bcYellow
    {
        height:20px;
        width:20px;
        background:#ff9900;
        display:inline-block;

    }
            .bcGreen
    {
        height:20px;
        width:20px;
        background:#669900;
        display:inline-block;

    }
            #bcLegend
            {
                display:inline-block;
                padding: 20px;
            }

</style>
<asp:Panel ID="BuildingConsentsContainer" runat="server">
    <div id="bcSearchContainer">
        <div id="bcNotice">Council accredited procedures allow up to three working days to carry out job allocation and administration functions prior to the 20 day processing clock commencing.</div>
        <div id="bcLegend"><div class="bcGreen"></div>  Completed, <div class="bcYellow"></div>  In process, <div class="bcRed"></div>  Waiting on customer</div>

        <div id="bcSearchCon">
            <h2>Please enter your consent number:</h2>
            <input id="txtBcSearch" type="text" runat="server"/>eg. 2000/150<br />
            <asp:Button ID="bcSearch" runat="server" Text="Search" OnClick="bcSearch_Click" />
        </div>

        <div id="bcError" runat="server" style="display:none" >A consent with that number could not be found. Please try again</div>

        <div id="bcResults" runat="server" style="display:none">
        <h2>Building consent summary</h2>
        <table id="bcTableBCSum" runat="server">
            <thead>
                <tr><th>Consent Number</th><th>Description</th><th>Status</th><th>Estimated Due Date</th></tr>
            </thead>
        </table>
                <h2>Building consent status</h2>
        <table id="bcTableBCStat" runat="server">
            <thead>
                <tr><th>Task</th><th>Status</th><th>Date Started</th></tr>
            </thead>
        </table>
                <h2>Current required information</h2>
        <table id="bcTableCRInfo" runat="server">
           
        </table>
    </div>
        </div>

    
</asp:Panel>
