﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AccordionDivs.VisualWebPart1 {
    using System.Web.UI.WebControls.Expressions;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.Text;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.SharePoint.WebPartPages;
    using System.Web.SessionState;
    using System.Configuration;
    using Microsoft.SharePoint;
    using System.Web;
    using System.Web.DynamicData;
    using System.Web.Caching;
    using System.Web.Profile;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System;
    using Microsoft.SharePoint.Utilities;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint.WebControls;
    using System.CodeDom.Compiler;
    
    
    public partial class VisualWebPart1 {
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebPartCodeGenerator", "12.0.0.0")]
        public static implicit operator global::System.Web.UI.TemplateControl(VisualWebPart1 target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControlTree(global::AccordionDivs.VisualWebPart1.VisualWebPart1 @__ctrl) {
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n<head>\r\n  <meta charset=\"utf-8\">\r\n  <title>jQuery UI Accordion</title>\r\n    <sc" +
                        "ript src=\"/_catalogs/masterpage/scripts/jquery-ui-1.11.1.wdc/external/jquery/jqu" +
                        "ery.js\"></script>\r\n  <link rel=\"stylesheet\" href=\"/_catalogs/masterpage/scripts/" +
                        "jquery-ui-1.11.1.wdc/jquery-ui.css\">\r\n  <script src=\"/_catalogs/masterpage/scrip" +
                        "ts/jquery-ui-1.11.1.wdc/jquery-ui.js\"></script>\r\n  <script>\r\n\r\n  $(function() {\r" +
                        "\n    var icons = {\r\n      header: \"ui-icon-circle-arrow-e\",\r\n      activeHeader:" +
                        " \"ui-icon-circle-arrow-s\"\r\n    };\r\n    $( \"#accordion\" ).accordion({\r\n        ic" +
                        "ons: icons,\r\n        heightStyle: \"content\"\r\n\r\n    });\r\n\r\n  });\r\n  </script>\r\n</" +
                        "head>\r\n<body>\r\n    <div id=\"accordion\"> \r\n   <h3 class=\"ui-accordion-header ui-s" +
                        "tate-default ui-accordion-header-active ui-state-active ui-corner-top ui-accordi" +
                        "on-icons\" id=\"ui-id-1\" role=\"tab\" aria-expanded=\"true\" aria-selected=\"true\" aria" +
                        "-controls=\"ui-id-2\"> \r\n      <span class=\"ui-accordion-header-icon ui-icon ui-ic" +
                        "on-circle-arrow-s\"></span> \r\n      <span class=\"ui-accordion-header-icon ui-icon" +
                        " ui-icon-circle-arrow-s\"></span> \r\n      <span class=\"ui-accordion-header-icon u" +
                        "i-icon ui-icon-circle-arrow-s\"></span> \r\n      <span class=\"ui-accordion-header-" +
                        "icon ui-icon ui-icon-circle-arrow-s\"></span>New connection</h3>\r\n   <div class=\"" +
                        "ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom ui-accor" +
                        "dion-content-active\" id=\"ui-id-2\" role=\"tabpanel\" aria-hidden=\"false\" aria-label" +
                        "ledby=\"ui-id-1\" style=\"height: 315.34px; display: block;\">\r\n      <p> All  appli" +
                        "cations for new water connections need to be made using this form: [insert form " +
                        "pdf here]. \r\n         <br/> Once  Council has received your application, we will" +
                        " either:</p>\r\n      <ul>\r\n         <li>Approve it and then inform you of the typ" +
                        "e of  supply you will get, the level of service, the size of the connection, and" +
                        " any  particular conditions applicable, \r\n            <strong>or</strong></li>\r\n" +
                        "         <li>Refuse the application and notify you of the  decision, giving reas" +
                        "ons for refusal.</li>\r\n      </ul>\r\n      <p>Once the connection is  approved, C" +
                        "ouncil will determine the sizes of all pipes, fittings and any other  equipment," +
                        " up to the \r\n         <u>point of supply</u>.<br/> Council will supply and  inst" +
                        "all the service pipe up to the point of supply, or may allow the supply and  ins" +
                        "tallation of the service pipe to be carried out by approved contractors,  which " +
                        "will be at your cost. \r\n         <br/> Installations must be in  accordance with" +
                        " the design and instructions approved by Council.<br/> Fee and charges for new  " +
                        "applications can be viewed \r\n         <u>here</u>. Note that \r\n         <u>Devel" +
                        "opment Contributions</u> will also apply.</p>\r\n      <h3> Time limit</h3>\r\n     " +
                        " <p> Once the application has been approved by Council, you  will need to accept" +
                        " the conditions of, and pay for, the new connection within 30  days of the date " +
                        "of approval (unless a time extension has been approved).&#160; Any refund of app" +
                        "lication fees and charges is  at Council’s discretion.</p>\r\n   </div>\r\n   <h3 ta" +
                        "bindex=\"-1\" class=\"ui-accordion-header ui-state-default ui-corner-all ui-accordi" +
                        "on-icons\" id=\"ui-id-3\" role=\"tab\" aria-expanded=\"false\" aria-selected=\"false\" ar" +
                        "ia-controls=\"ui-id-4\"> \r\n      <span class=\"ui-accordion-header-icon ui-icon ui-" +
                        "icon-circle-arrow-e\"></span>\r\n      <span class=\"ui-accordion-header-icon ui-ico" +
                        "n ui-icon-circle-arrow-e\"></span>\r\n      <span class=\"ui-accordion-header-icon u" +
                        "i-icon ui-icon-circle-arrow-e\"></span>\r\n      <span class=\"ui-accordion-header-i" +
                        "con ui-icon ui-icon-circle-arrow-e\"></span>More water/ change of  use</h3>\r\n   <" +
                        "div class=\"ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bott" +
                        "om\" id=\"ui-id-4\" role=\"tabpanel\" aria-hidden=\"true\" aria-labelledby=\"ui-id-3\" st" +
                        "yle=\"height: 315.34px; display: none;\">\r\n      <p> If  you require more water, o" +
                        "r change how you use the water on your property (ie  from \r\n         <u>ordinary" +
                        " use</u> to \r\n         <u>extraordinary use</u>, or vice versa), you must  submi" +
                        "t the same application as for a \r\n         <u>new connection</u>. </p>\r\n   </div" +
                        ">\r\n   <h3 tabindex=\"-1\" class=\"ui-accordion-header ui-state-default ui-corner-al" +
                        "l ui-accordion-icons\" id=\"ui-id-5\" role=\"tab\" aria-expanded=\"false\" aria-selecte" +
                        "d=\"false\" aria-controls=\"ui-id-6\"> \r\n      <span class=\"ui-accordion-header-icon" +
                        " ui-icon ui-icon-circle-arrow-e\"></span> \r\n      <span class=\"ui-accordion-heade" +
                        "r-icon ui-icon ui-icon-circle-arrow-e\"></span> \r\n      <span class=\"ui-accordion" +
                        "-header-icon ui-icon ui-icon-circle-arrow-e\"></span> \r\n      <span class=\"ui-acc" +
                        "ordion-header-icon ui-icon ui-icon-circle-arrow-e\"></span>Relocating the point  " +
                        "of supply</h3>\r\n   <div class=\"ui-accordion-content ui-helper-reset ui-widget-co" +
                        "ntent ui-corner-bottom\" id=\"ui-id-6\" role=\"tabpanel\" aria-hidden=\"true\" aria-lab" +
                        "elledby=\"ui-id-5\" style=\"height: 315.34px; display: none;\">\r\n      <p> If  you a" +
                        "re planning to change the location of the \r\n         <u>point of supply</u> on y" +
                        "our  property, you will need to make an application to Council the same as for a" +
                        " \r\n         <u>new  connection</u>.</p>\r\n   </div>\r\n   <h3 tabindex=\"-1\" class=\"" +
                        "ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons\" id=\"ui-id" +
                        "-7\" role=\"tab\" aria-expanded=\"false\" aria-selected=\"false\" aria-controls=\"ui-id-" +
                        "8\"> \r\n      <span class=\"ui-accordion-header-icon ui-icon ui-icon-circle-arrow-e" +
                        "\"></span>\r\n      <span class=\"ui-accordion-header-icon ui-icon ui-icon-circle-ar" +
                        "row-e\"></span>\r\n      <span class=\"ui-accordion-header-icon ui-icon ui-icon-circ" +
                        "le-arrow-e\"></span>\r\n      <span class=\"ui-accordion-header-icon ui-icon ui-icon" +
                        "-circle-arrow-e\"></span>Use of fire hydrant</h3>\r\n   <div class=\"ui-accordion-co" +
                        "ntent ui-helper-reset ui-widget-content ui-corner-bottom\" id=\"ui-id-8\" role=\"tab" +
                        "panel\" aria-hidden=\"true\" aria-labelledby=\"ui-id-7\" style=\"height: 315.34px; dis" +
                        "play: none;\">\r\n      <p> To apply for use of a fire hydrant, please  complete th" +
                        "is application for [insert form pdf here]</p>\r\n   </div>\r\n   <h3 tabindex=\"-1\" c" +
                        "lass=\"ui-accordion-header ui-state-default ui-corner-all ui-accordion-icons\" id=" +
                        "\"ui-id-9\" role=\"tab\" aria-expanded=\"false\" aria-selected=\"false\" aria-controls=\"" +
                        "ui-id-10\"> \r\n      <span class=\"ui-accordion-header-icon ui-icon ui-icon-circle-" +
                        "arrow-e\"></span>\r\n      <span class=\"ui-accordion-header-icon ui-icon ui-icon-ci" +
                        "rcle-arrow-e\"></span>\r\n      <span class=\"ui-accordion-header-icon ui-icon ui-ic" +
                        "on-circle-arrow-e\"></span>\r\n      <span class=\"ui-accordion-header-icon ui-icon " +
                        "ui-icon-circle-arrow-e\"></span>New water main line/subdivision connection</h3>\r\n" +
                        "   <div class=\"ui-accordion-content ui-helper-reset ui-widget-content ui-corner-" +
                        "bottom\" id=\"ui-id-10\" role=\"tabpanel\" aria-hidden=\"true\" aria-labelledby=\"ui-id-" +
                        "9\" style=\"height: 315.34px; display: none;\">\r\n      <p> [insert form pdf here]</" +
                        "p>\r\n      <p>This application is to be used when a new  main or subdivision is t" +
                        "o be connected to the Waitaki District Council water  supply network. This form " +
                        "will not be accepted unless all details are fully  completed<br/> This applicati" +
                        "on must be made at least one  month prior to connecting to Council’s supply netw" +
                        "ork.</p>\r\n   </div>\r\n</div>\r\n</body>"));
        }
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}
