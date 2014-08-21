using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace DidYouKnow.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public partial class VisualWebPart1 : WebPart
    {

        private string _message;
        private string _tileColour;



        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
         System.Web.UI.WebControls.WebParts.WebDisplayName("Message"),
         System.Web.UI.WebControls.WebParts.WebDescription(""),
         System.Web.UI.WebControls.WebParts.Personalizable(
         System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
         System.ComponentModel.Category("Appearance"),
        System.ComponentModel.DefaultValue("")]
        public string _Message
        {
            get { return _message; }
            set { _message = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
 System.Web.UI.WebControls.WebParts.WebDisplayName("Tile Colour"),
 System.Web.UI.WebControls.WebParts.WebDescription("html colour to set the tile to be"),
 System.Web.UI.WebControls.WebParts.Personalizable(
 System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
 System.ComponentModel.Category("Appearance"),
System.ComponentModel.DefaultValue("")]
        public string _TileColour
        {
            get { return _tileColour; }
            set { _tileColour = value; }
        }
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public VisualWebPart1()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        public string addLinksToString(String myString)
        {
            string[] temp = myString.Split(' '); //split into words
            if (myString.Contains("http:") || myString.Contains("www."))
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    if (temp[i].Contains("www.") && (!temp[i].Contains("http")))
                    {
                        temp[i] = "<a href=\"http://" + temp[i] + "\">" + temp[i] + "</a>";
                    }
                    else if (temp[i].Contains("http://"))
                    {
                        temp[i] = "<a href=\"" + temp[i] + "\">" + temp[i] + "</a>";
                    }
                }

            }
            string result = "";
            foreach (string item in temp)
            {
                result += item + " ";
            }
            return result;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string message;
            string colour;
            try
            {
                 message = addLinksToString(Convert.ToString(_Message.ToString()));
                 colour = Convert.ToString(_tileColour.ToString());
            }
            catch
            {
                message = "";
                colour = "#000";
            }

            if (colour.ToLower() == "business")
                colour = "#ba4c34";
            if (colour.ToLower() == "council")
                colour = "#666280";
            if (colour.ToLower() == "services")
                colour = "#7299ae";
            if (colour.ToLower() == "living")
                colour = "#a2b11e";


            if (message == "")
            {
                message = "Please edit webpart and add a message and a colour. Default colours can be selected by typing 'Council,Living,Business or Services";
            }

            dykmessage.InnerHtml = message;
            dyksquare.Attributes.Add("Style", "background: " + colour);
            dyktop.Attributes.Add("Style", "border-bottom: 61px solid " + colour);
        }
    }
}
