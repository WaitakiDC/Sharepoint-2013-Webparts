using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace MailToService.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public class VisualWebPart1 : WebPart
    {
        private string _relatedTo;

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
         System.Web.UI.WebControls.WebParts.WebDisplayName("RelatedTo"),
         System.Web.UI.WebControls.WebParts.WebDescription(""),
         System.Web.UI.WebControls.WebParts.Personalizable(
         System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
         System.ComponentModel.Category("Settings"),
        System.ComponentModel.DefaultValue("")]
        public string _RelatedTo
        {
            get { return _relatedTo; }
            set { _relatedTo = value; }
        }

        private string _emailTo;

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
         System.Web.UI.WebControls.WebParts.WebDisplayName("EmailTo"),
         System.Web.UI.WebControls.WebParts.WebDescription(""),
         System.Web.UI.WebControls.WebParts.Personalizable(
         System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
         System.ComponentModel.Category("Settings"),
        System.ComponentModel.DefaultValue("")]
        public string _EmailTo
        {
            get { return _emailTo; }
            set { _emailTo = value; }
        }


        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/MailToService/VisualWebPart1/VisualWebPart1UserControl.ascx";

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            Controls.Add(control);
            VisualWebPart1UserControl control2 = (VisualWebPart1UserControl)control;
            control2.relatedTo = _RelatedTo;
            control2.emailTo = _EmailTo;
        }
    }
}
