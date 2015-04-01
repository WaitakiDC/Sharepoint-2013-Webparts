using System;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Workflow;

namespace ContractsSiteCreationList.EventReceiver2
{
    /// <summary>
    /// List Item Events
    /// </summary>
    public class EventReceiver2 : SPItemEventReceiver
    {
        /// <summary>
        /// An item was added.
        /// </summary>
        public override void ItemAdded(SPItemEventProperties properties)
        {
            try
            {
                var siteUrl = properties.Site.Url;
                var siteId = properties.SiteId;


                using (SPSite site = new SPSite(siteId))
                {

                    var projectSite = site.SelfServiceCreateSite(
                        siteUrl + "/projects/" + properties.ListItemId,
                        properties.AfterProperties["Title"].ToString(),
                        string.Empty,
                        1033,
                        "STS#1",
                        properties.UserLoginName,
                        properties.UserDisplayName,
                        properties.Web.CurrentUser.Email,
                        properties.UserLoginName,
                        properties.UserDisplayName,
                        properties.Web.CurrentUser.Email);

                    properties.AfterProperties["PplProjectName"] = projectSite.Url + ","
                                                                   + properties.AfterProperties["Title"];



                    base.ItemAdded(properties);
                }
            }
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