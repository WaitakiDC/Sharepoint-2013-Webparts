using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace PromotionsApp.PromotionsWebpart
{
    [ToolboxItemAttribute(false)]
    public partial class PromotionsWebpart : WebPart
    {
        private string _libraryName;
        private string _titleValue;
        private string _descValue;
        private string _linkValue;
        
        
        Label lblResult;
        Button btnClick;

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
         System.Web.UI.WebControls.WebParts.WebDisplayName("Picture Library Name"),
         System.Web.UI.WebControls.WebParts.WebDescription(""),
         System.Web.UI.WebControls.WebParts.Personalizable(
         System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
         System.ComponentModel.Category("Promotions Properties"),
        System.ComponentModel.DefaultValue("")]
        public string _LibraryName
        {
            get { return _libraryName; }
            set { _libraryName = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
 System.Web.UI.WebControls.WebParts.WebDisplayName("Title Field Name"),
 System.Web.UI.WebControls.WebParts.WebDescription(""),
 System.Web.UI.WebControls.WebParts.Personalizable(
 System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
 System.ComponentModel.Category("Promotions Properties"),
System.ComponentModel.DefaultValue("")]
        public string _TitleValue
        {
            get { return _titleValue; }
            set { _titleValue = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
 System.Web.UI.WebControls.WebParts.WebDisplayName("Description Field Name"),
 System.Web.UI.WebControls.WebParts.WebDescription(""),
 System.Web.UI.WebControls.WebParts.Personalizable(
 System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
 System.ComponentModel.Category("Promotions Properties"),
System.ComponentModel.DefaultValue("Description")]
        public string _DescValue
        {
            get { return _descValue; }
            set { _descValue = value; }
        }

        [System.Web.UI.WebControls.WebParts.WebBrowsable(true),
 System.Web.UI.WebControls.WebParts.WebDisplayName("Link Field Name"),
 System.Web.UI.WebControls.WebParts.WebDescription(""),
 System.Web.UI.WebControls.WebParts.Personalizable(
 System.Web.UI.WebControls.WebParts.PersonalizationScope.Shared),
 System.ComponentModel.Category("Promotions Properties"),
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
        public PromotionsWebpart()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void getList()
        {
           // PromoItemsContainer.InnerHtml = "<div id=\"owl-example\" class=\"owl-carousel promoBox\" style=\"width:580px\"><div runat=\"server\" ID=\"PromoItems\" >";


            PromoItemsContainer.InnerHtml = "<div id=\"owl-example\" class=\"owl-carousel promoBox\" style=\"width:800px;\">" ;


            


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
                            string pic = lists.Items[i].Url;
                            string title = Convert.ToString(lists.Items[i][_TitleValue.ToString()]);
                            string desc = Convert.ToString(lists.Items[i][_DescValue.ToString()]);
                            string link = Convert.ToString(lists.Items[i][_LinkValue.ToString()]);
                            link = link.Split(',')[0];

                            addItemToPromo(title, desc, pic, link);

                        }

                        PromoItemsContainer.InnerHtml += "</div><script type=\"text/javascript\">$(document).ready(function() {   $(\"#owl-example\").owlCarousel();});</script>";
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

    protected void addItemToPromo(String title, String desc,String pic, String link)
    {
        PromoItemsContainer.InnerHtml = PromoItemsContainer.InnerHtml + "<a href=\"" + link + "\"><div class=\"promoItem\">  	<img src=\"/" + pic + "\" alt=\"" + title + "\">    <div class=\"textdiv\">    <h3>" + title + "</h3>    <h4>" + desc + "</h4>     </div>    </div></a>";
       // PromoItemsContainer.InnerHtml = PromoItemsContainer.InnerHtml + "<div style=\"width: 193px;\" class=\"owl-item\"><a href=\"" + link + "\"><div class=\"promoItem\"><img alt=\"" + title + "\" src=\"/"+ pic +"\"><div class=\"textdiv\"><h3>" + title + "</h3><h4>" + desc + "</h4></div></div></a></div>";
    }
    

        protected void Page_Load(object sender, EventArgs e)
        {
            //lblResult = new Label();
            //btnClick = new Button();
            //btnClick.Text = "Click";
            //btnClick.Click += new EventHandler(btnClick_Click);
           // this.Controls.Add(lblResult);
            //this.Controls.Add(btnClick);
            getList();
        }

        protected void btnClick_Click(object sender, EventArgs e)
        {
            
           // lblResult.Text = _Value.ToString();
        }       
    }
}
