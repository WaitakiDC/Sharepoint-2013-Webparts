using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.Administration;

namespace Site_Creation_From_List.EventReceiver1
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EventReceiver1 : SPItemEventReceiver
    {
        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            SPSite site = new SPSite("http://wdcdmzsp4");
            SPWebApplication webApp = site.WebApplication;
            if (webApp.SelfServiceSiteCreationEnabled)
            {
                string siteName = "testsitecol";

                SPWeb web = site.OpenWeb();
                web.AllowUnsafeUpdates = true;
                SPSiteCollection spSites = webApp.Sites;
                SPSite newSite = spSites[0].SelfServiceCreateSite(
                "/sites/" + siteName,
                "Test Site collection",
                string.Empty,
                1033,
                "STS#0",
                "waitakidmz\\Sp_Admin",
                "Admin",
                "smilne@waitaki.govt.nz",
                "waitakidmz\\Sp_Admin",
                "Admin",
                "smilne@waitaki.govt.nz");
            }

            base.ItemAdded(properties);
        }

        /// <summary>
        /// An item was deleted.
        /// </summary>
        public override void ItemDeleted(SPItemEventProperties properties)
        {
            base.ItemDeleted(properties);
        }


    }
}