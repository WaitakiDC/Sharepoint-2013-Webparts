using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Popular_Links.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public partial class VisualWebPart1 : WebPart
    {
        private string _libraryName;
        private string _altField;
        private string _linkField;
        private string _imageWidth;
        private string _imageHeight;
        private string _imageSpacing;


        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
 System.Web.UI.WebControls.WebParts.WebDisplayName("Picture Library Name"),
 System.Web.UI.WebControls.WebParts.WebDescription(""),
 System.Web.UI.WebControls.WebParts.Personalizable(
 System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
 System.ComponentModel.Category("Popular Properties"),
System.ComponentModel.DefaultValue("")]
        public string _LibraryName
        {
            get { return _libraryName; }
            set { _libraryName = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
System.Web.UI.WebControls.WebParts.WebDisplayName("Alt Text Field"),
System.Web.UI.WebControls.WebParts.WebDescription(""),
System.Web.UI.WebControls.WebParts.Personalizable(
System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
System.ComponentModel.Category("Popular Properties"),
System.ComponentModel.DefaultValue("")]
        public string _AltField
        {
            get { return _altField; }
            set { _altField = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
System.Web.UI.WebControls.WebParts.WebDisplayName("Link Field"),
System.Web.UI.WebControls.WebParts.WebDescription(""),
System.Web.UI.WebControls.WebParts.Personalizable(
System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
System.ComponentModel.Category("Popular Properties"),
System.ComponentModel.DefaultValue("")]
        public string _LinkField
        {
            get { return _linkField; }
            set { _linkField = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
System.Web.UI.WebControls.WebParts.WebDisplayName("Image Width"),
System.Web.UI.WebControls.WebParts.WebDescription(""),
System.Web.UI.WebControls.WebParts.Personalizable(
System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
System.ComponentModel.Category("Popular Properties"),
System.ComponentModel.DefaultValue("")]
        public string _ImageWidth
        {
            get { return _imageWidth; }
            set { _imageWidth = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
System.Web.UI.WebControls.WebParts.WebDisplayName("Image Height"),
System.Web.UI.WebControls.WebParts.WebDescription(""),
System.Web.UI.WebControls.WebParts.Personalizable(
System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
System.ComponentModel.Category("Popular Properties"),
System.ComponentModel.DefaultValue("")]
        public string _ImageHeight
        {
            get { return _imageHeight; }
            set { _imageHeight = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
System.Web.UI.WebControls.WebParts.WebDisplayName("Image Spacing"),
System.Web.UI.WebControls.WebParts.WebDescription(""),
System.Web.UI.WebControls.WebParts.Personalizable(
System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
System.ComponentModel.Category("Popular Properties"),
System.ComponentModel.DefaultValue("")]
        public string _ImageSpacing
        {
            get { return _imageSpacing; }
            set { _imageSpacing = value; }
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

        protected void Page_Load(object sender, EventArgs e)
        {
            getLinks();
        }

        protected void getLinks()
        {
            popularContainer.InnerHtml = "";
            SPWeb thisWeb = SPContext.Current.Web;
            try
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPPictureLibrary lists = (SPPictureLibrary)web.Lists[_LibraryName.ToString()];
                        //
                        for (int i = 0; i < lists.ItemCount; i++)
                        {
                            string image = lists.Items[i].Url;
                            string link = Convert.ToString(lists.Items[i][_LinkField.ToString()]);
                            string alt = Convert.ToString(lists.Items[i][_AltField.ToString()]);
                            link = link.Split(',')[0];

                            addItem(image, link, alt);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Label lblError = new Label();
                this.Controls.Add(lblError);
                if (e.InnerException != null )
                lblError.Text = "An error has occured reading from the selected list. Please check the promotions properties." + e.InnerException.ToString() ;
            }
        
        }
        protected void addItem(string image, string link,string alt)
        {
            string width = "100";
            string height = "100";
            string padding = "10";

            try
            {
                width = _ImageWidth.ToString();
                height = _ImageHeight.ToString();
                padding = _ImageSpacing.ToString();
            }
               catch
            {
                width = "100";
                height = "100";
                padding = "10";
            }

            popularContainer.InnerHtml += "<a href=\" " + link + "\"><div><img width=\"" + width + "px\" height=\"" + height + "px\" style=\"padding:" +padding + "px;\" src=\"/" + image + "\" alt=\"" + alt + "\"/></div></a>";
          //  popularContainer.InnerHtml =  "<a href=\"" + link + "\"><div><img src=/" + image + "\" alt=\"" + alt + "\"</div></a>";
        }
    }
}
