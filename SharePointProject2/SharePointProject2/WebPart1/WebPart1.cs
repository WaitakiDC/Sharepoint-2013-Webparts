using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace SharePointProject2.WebPart1
{
    [ToolboxItemAttribute(false)]
    
    public class WebPart1 : WebPart
    {
        
        private string customMessage = "Hello, world!";

        public string DisplayMessage
        {
            get { return customMessage; }
            set { customMessage = value; }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();
            LiteralControl message = new LiteralControl();
            message.Text = DisplayMessage;
            Controls.Add(message);
        }
    }
}
