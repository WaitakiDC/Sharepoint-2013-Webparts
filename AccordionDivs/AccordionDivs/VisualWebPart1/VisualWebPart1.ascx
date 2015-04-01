<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VisualWebPart1.ascx.cs" Inherits="AccordionDivs.VisualWebPart1.VisualWebPart1" %>
<head>
  <meta charset="utf-8">
  <title>jQuery UI Accordion</title>
    <script src="/_catalogs/masterpage/scripts/jquery-ui-1.11.1.wdc/external/jquery/jquery.js"></script>
  <link rel="stylesheet" href="/_catalogs/masterpage/scripts/jquery-ui-1.11.1.wdc/jquery-ui.css">
  <script src="/_catalogs/masterpage/scripts/jquery-ui-1.11.1.wdc/jquery-ui.js"></script>
  <script>

  $(function() {
    var icons = {
      header: "ui-icon-circle-arrow-e",
      activeHeader: "ui-icon-circle-arrow-s"
    };
    $( "#accordion" ).accordion({
        icons: icons,
        heightStyle: "content"

    });

  });
  </script>
</head>
<body>
    <div id="accordion"> 
   <h3 class="ui-accordion-header ui-state-default ui-accordion-header-active ui-state-active ui-corner-top ui-accordion-icons" id="ui-id-1" role="tab" aria-expanded="true" aria-selected="true" aria-controls="ui-id-2"> 
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-s"></span> 
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-s"></span> 
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-s"></span> 
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-s"></span>New connection</h3>
   <div class="ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom ui-accordion-content-active" id="ui-id-2" role="tabpanel" aria-hidden="false" aria-labelledby="ui-id-1" style="height: 315.34px; display: block;">
      <p> All  applications for new water connections need to be made using this form: [insert form pdf here]. 
         <br/> Once  Council has received your application, we will either:</p>
      <ul>
         <li>Approve it and then inform you of the type of  supply you will get, the level of service, the size of the connection, and any  particular conditions applicable, 
            <strong>or</strong></li>
         <li>Refuse the application and notify you of the  decision, giving reasons for refusal.</li>
      </ul>
      <p>Once the connection is  approved, Council will determine the sizes of all pipes, fittings and any other  equipment, up to the 
         <u>point of supply</u>.<br/> Council will supply and  install the service pipe up to the point of supply, or may allow the supply and  installation of the service pipe to be carried out by approved contractors,  which will be at your cost. 
         <br/> Installations must be in  accordance with the design and instructions approved by Council.<br/> Fee and charges for new  applications can be viewed 
         <u>here</u>. Note that 
         <u>Development Contributions</u> will also apply.</p>
      <h3> Time limit</h3>
      <p> Once the application has been approved by Council, you  will need to accept the conditions of, and pay for, the new connection within 30  days of the date of approval (unless a time extension has been approved).&#160; Any refund of application fees and charges is  at Council’s discretion.</p>
   </div>
   <h3 tabindex="-1" class="ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" id="ui-id-3" role="tab" aria-expanded="false" aria-selected="false" aria-controls="ui-id-4"> 
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>More water/ change of  use</h3>
   <div class="ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" id="ui-id-4" role="tabpanel" aria-hidden="true" aria-labelledby="ui-id-3" style="height: 315.34px; display: none;">
      <p> If  you require more water, or change how you use the water on your property (ie  from 
         <u>ordinary use</u> to 
         <u>extraordinary use</u>, or vice versa), you must  submit the same application as for a 
         <u>new connection</u>. </p>
   </div>
   <h3 tabindex="-1" class="ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" id="ui-id-5" role="tab" aria-expanded="false" aria-selected="false" aria-controls="ui-id-6"> 
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span> 
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span> 
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span> 
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>Relocating the point  of supply</h3>
   <div class="ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" id="ui-id-6" role="tabpanel" aria-hidden="true" aria-labelledby="ui-id-5" style="height: 315.34px; display: none;">
      <p> If  you are planning to change the location of the 
         <u>point of supply</u> on your  property, you will need to make an application to Council the same as for a 
         <u>new  connection</u>.</p>
   </div>
   <h3 tabindex="-1" class="ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" id="ui-id-7" role="tab" aria-expanded="false" aria-selected="false" aria-controls="ui-id-8"> 
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>Use of fire hydrant</h3>
   <div class="ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" id="ui-id-8" role="tabpanel" aria-hidden="true" aria-labelledby="ui-id-7" style="height: 315.34px; display: none;">
      <p> To apply for use of a fire hydrant, please  complete this application for [insert form pdf here]</p>
   </div>
   <h3 tabindex="-1" class="ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons" id="ui-id-9" role="tab" aria-expanded="false" aria-selected="false" aria-controls="ui-id-10"> 
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>
      <span class="ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e"></span>New water main line/subdivision connection</h3>
   <div class="ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom" id="ui-id-10" role="tabpanel" aria-hidden="true" aria-labelledby="ui-id-9" style="height: 315.34px; display: none;">
      <p> [insert form pdf here]</p>
      <p>This application is to be used when a new  main or subdivision is to be connected to the Waitaki District Council water  supply network. This form will not be accepted unless all details are fully  completed<br/> This application must be made at least one  month prior to connecting to Council’s supply network.</p>
   </div>
</div>
</body>