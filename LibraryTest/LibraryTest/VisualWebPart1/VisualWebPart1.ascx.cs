using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace LibraryTest.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public partial class VisualWebPart1 : WebPart
    {

        List<NaviItem> NaviItemList;

        private string _libraryName;
        private string _titleValue;
        private string _linkValue;
        private string _orderValue;
        private string _colourValue;


        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
         System.Web.UI.WebControls.WebParts.WebDisplayName("Picture Library Name"),
         System.Web.UI.WebControls.WebParts.WebDescription(""),
         System.Web.UI.WebControls.WebParts.Personalizable(
         System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
         System.ComponentModel.Category("Navi Properties"),
        System.ComponentModel.DefaultValue("")]
        public string _LibraryName
        {
            get { return _libraryName; }
            set { _libraryName = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
         System.Web.UI.WebControls.WebParts.WebDisplayName("Order Field Name"),
         System.Web.UI.WebControls.WebParts.WebDescription(""),
         System.Web.UI.WebControls.WebParts.Personalizable(
         System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
         System.ComponentModel.Category("Navi Properties"),
        System.ComponentModel.DefaultValue("")]
        public string _OrderValue
        {
            get { return _orderValue; }
            set { _orderValue = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
         System.Web.UI.WebControls.WebParts.WebDisplayName("Colour Of Cells"),
         System.Web.UI.WebControls.WebParts.WebDescription(""),
         System.Web.UI.WebControls.WebParts.Personalizable(
         System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
         System.ComponentModel.Category("Navi Properties"),
        System.ComponentModel.DefaultValue("")]
        public string _ColourValue
        {
            get { return _colourValue; }
            set { _colourValue = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
 System.Web.UI.WebControls.WebParts.WebDisplayName("Title Field Name"),
 System.Web.UI.WebControls.WebParts.WebDescription(""),
 System.Web.UI.WebControls.WebParts.Personalizable(
 System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
 System.ComponentModel.Category("Navi Properties"),
System.ComponentModel.DefaultValue("")]
        public string _TitleValue
        {
            get { return _titleValue; }
            set { _titleValue = value; }
        }


        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
 System.Web.UI.WebControls.WebParts.WebDisplayName("Link Field Name"),
 System.Web.UI.WebControls.WebParts.WebDescription(""),
 System.Web.UI.WebControls.WebParts.Personalizable(
 System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
 System.ComponentModel.Category("Navi Properties"),
System.ComponentModel.DefaultValue("Link")]
        public string _LinkValue
        {
            get { return _linkValue; }
            set { _linkValue = value; }
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
            NaviItemList = new List<NaviItem>();
            addStyle();
            getList();
        }

        protected void addStyle()
        {
            navilistyle.InnerHtml = "#panelsHolder li:hover { background-color:" + _colourValue + "}";
        }



        protected void getList()
        {
            SPWeb thisWeb = SPContext.Current.Web;
            String url = HttpContext.Current.Request.Url.ToString();
            if (url.Contains("SitePages"))
            {
                url = url.Split(new string[] { "SitePages" }, StringSplitOptions.None)[0];
            }


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
                            string pic = lists.Items[i].Url;
                            string title = Convert.ToString(lists.Items[i][_TitleValue.ToString()]);
                            string link = Convert.ToString(lists.Items[i][_LinkValue.ToString()]);
                            string order = Convert.ToString(lists.Items[i][_OrderValue.ToString()]);
                            string modDate = Convert.ToString(lists.Items[i]["Modified".ToString()]);
                            link = link.Split(',')[0];

                            NaviItemList.Add(new NaviItem(pic, title, link, order));


                        }

                        NaviItemList.Sort((a, b) => a.ToString().CompareTo(b.ToString()));
                        foreach (NaviItem item in NaviItemList)
                        {
                            item.addLi(naviItems, url);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Label lblError = new Label();
                this.Controls.Add(lblError);
                if (e.InnerException != null)
                    lblError.Text = "An error has occured reading from the selected list. Please check the Navi properties. " + e.InnerException.ToString();
            }
        }

        protected class NaviItem
        {
            protected string pic;
            protected string title;
            protected string link;
            protected string order;

            public NaviItem(string pic, string title, string link, string order)
            {
                this.pic = pic;
                this.title = title;
                this.link = link;
                this.order = order;
            }

            public override string ToString()
            {
                return this.order;
            }

            public void addLi(HtmlGenericControl naviDiv, string url)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                li.Style.Add("BACKGROUND-IMAGE", "url(\"" + url + pic + "\")");
                naviDiv.Controls.Add(li);
                HtmlGenericControl anchor = new HtmlGenericControl("a");
                anchor.Attributes.Add("href", link);
                anchor.InnerText = title;
                li.Controls.Add(anchor);
            }
        }
    }
}
