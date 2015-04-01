<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1UserControl.ascx.cs" Inherits="MailToService.VisualWebPart1.VisualWebPart1UserControl" %>
<script type="text/javascript">
    function hidePopup()
    {
        $('.popup').hide();
    }
</script>
<style type="text/css">
.popup
{
    text-align:center;
    padding:20px;
    position: fixed;
    left: 50%;
    top: 50%;
    background-color: whitesmoke;
    z-index: 15;
    display:none;
    height: 100px;
    margin-top: -50px;
    border: 3px solid grey;
    width: 300px;
    margin-left: -150px;
}

    .reqred
    {
        color:red;
        font-size:10px;

    }
</style>
<asp:Panel ID="MailFormPanel" runat="server" DefaultButton="btnSubmit">
<div id="MailForm">
    <h2>Your details</h2>

    <table id="mailYourDetails">
        <tr><td>First name (<em>required</em>)</td><td>Last name (<em>required</em>)</td></tr>
        <tr><td><asp:TextBox ID="txtFirst" runat="server"></asp:TextBox><asp:Label ID="lblFirst" runat="server" CssClass="reqred"></asp:Label></td><td><asp:TextBox ID="txtLast" runat="server"></asp:TextBox><asp:Label ID="lblLast" runat="server" CssClass="reqred"></asp:Label></td></tr>
                <tr><td>Phone number (<em>required</em>)</td><td>Email address (<em>required</em>)</td></tr>
        <tr><td><asp:TextBox ID="txtPhone" runat="server"></asp:TextBox><asp:Label ID="lblPhone" runat="server" CssClass="reqred"></asp:Label></td><td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:Label ID="lblEmail" runat="server" CssClass="reqred"></asp:Label></td></tr>
    </table>

    <table id="mailYourMessage">
        <tr><td>Your message (<em>required</em>)</td></tr>
        <tr><td class="auto-style1"><asp:TextBox ID="txtMessage" runat="server" Rows="6" TextMode="MultiLine" MaxLength="512"></asp:TextBox><asp:Label ID="lblMessage" runat="server" CssClass="reqred"></asp:Label></td></tr>
                <tr><td>Would you like a response to your message?<asp:CheckBox ID="chkRequired" runat="server" Text=" " /></td></tr>
        <tr><td>Email a copy to me?<asp:CheckBox ID="chkEMailContact" runat="server" Text=" " /></td></tr>
        <tr><td>
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td></tr>
        
            
    </table>

</div></asp:Panel>
<div id="MailCompleteMessage" class="popup" runat="server" >
    <h2 id="mailCompleteHeader" runat="server"></h2>
    <p id="mailCompletebody" runat="server"></p>
    <button type="button" onclick="hidePopup()" >OK</button>
</div>
