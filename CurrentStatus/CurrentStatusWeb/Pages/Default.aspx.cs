using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace CurrentStatusWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Uri redirectUrl;
            switch (SharePointContextProvider.CheckRedirectionStatus(Context, out redirectUrl))
            {
                case RedirectionStatus.Ok:
                    return;
                case RedirectionStatus.ShouldRedirect:
                    Response.Redirect(redirectUrl.AbsoluteUri, endResponse: true);
                    break;
                case RedirectionStatus.CanNotRedirect:
                    Response.Write("An error occurred while processing your request.");
                    Response.End();
                    break;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // The following code gets the client context and Title property by using TokenHelper.
            // To access other properties, the app may need to request permissions on the host web.
            var spContext = SharePointContextProvider.Current.GetSharePointContext(Context);

            using (var clientContext = spContext.CreateUserClientContextForSPHost())
            {
                clientContext.Load(clientContext.Web, web => web.Title);
                clientContext.ExecuteQuery();
                Response.Write(clientContext.Web.Title);
            }
        }

        protected void loadFromList()
        {
            using (SPSite oSPsite = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb oSPWeb = oSPsite.OpenWeb())
                {
                    // Fetch using SPSiteDataQuery
                    SPSiteDataQuery query = new SPSiteDataQuery();
                    query.Lists = "<Lists ServerTemplate=\"104\" />";//104=List template ID for "Anouncements"
                    query.ViewFields = "<FieldRef Name=\"Title\" />";//Add other fields which you want to get.
                    query.Query = "";//you can add your caml query if you want to filter the list items returned
                    query.Webs = "<Webs Scope=\"SiteCollection\" />";//Scope is set to site collection to get data from all anouncement lists in that site collection.
                    DataTable dataTable = oSPWeb.GetSiteData(query);
                }
            }
        }
    }
}