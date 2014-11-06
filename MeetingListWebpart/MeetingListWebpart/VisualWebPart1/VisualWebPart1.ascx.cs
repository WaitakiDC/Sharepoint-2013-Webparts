using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MeetingListWebpart.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public partial class VisualWebPart1 : WebPart
    {
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
            CreateList();

            addItemsToPage(getList());
        }

        protected void CreateList()
        {
            try
            {
                // choose your site
                SPWeb web = SPContext.Current.Web;
                SPSite site = SPContext.Current.Site;
                web.AllowUnsafeUpdates = true;
                SPListCollection lists = web.Lists;

                // create new Generic list called "AlertsList"
                lists.Add("Meetings List", "List to control the meetings for this webpart. Don't change the columns", SPListTemplateType.GenericList);

                SPList list = web.Lists["Meetings List"];
                SPList locationsList = web.Lists["Locations"];
                // create Text type new column called "My Column" 
                list.Fields.Add("Description", SPFieldType.Text, true);
                list.Fields.AddLookup("Locations", locationsList.ID, true);
                SPField locationsCol = list.Fields.GetField("Locations");
                locationsCol.SchemaXml = locationsCol.SchemaXml.Replace("Type=\"Lookup\"", "Type=\"Lookup\" ShowField=\"Title\" ");

                list.Fields.AddFieldAsXml("<Field Type=\"DateTime\" DisplayName=\"Event DateTime\" Required=\"TRUE\" EnforceUniqueValues=\"FALSE\" Indexed=\"FALSE\" Format=\"DateTime\" Name=\"EventDateTime\" />");

                list.Update();

                // make new column visible in default view
                SPView view = list.DefaultView;
                view.ViewFields.Add("Description");
                view.ViewFields.Add("Locations");
                view.ViewFields.Add("Event DateTime");
                view.Update();

                Label myLabel = new Label();
                myLabel.Text = "Meeting List Created. Please go to site contents to add items for the Meetings";
                this.Controls.Add(myLabel);


            }
            catch (Exception e)
            {
            }
        }

        protected void addItemsToPage(List<MeetingItem> listOfMeetings)
        {
            //add a new row for each item in the meetings list
            foreach (MeetingItem item in listOfMeetings)
            {
                meetingTable.Controls.Add(returnRow(item));
            }

        }

        protected HtmlTableRow returnRow(MeetingItem item)
        {
            HtmlTableRow tr = new HtmlTableRow();

            //first cell 
            HtmlTableCell tdfirst = new HtmlTableCell("td");
            tdfirst.Attributes["class"] = "edges";
     

            HtmlGenericControl h1datefirst = new HtmlGenericControl("h1");
            h1datefirst.Attributes["class"] = "top";
            h1datefirst.InnerHtml = item.dateTime.Day.ToString() + "/" + item.dateTime.Month.ToString();

            HtmlGenericControl h2timefirst = new HtmlGenericControl("h2");
            h2timefirst.Attributes["class"] = "center";
            h2timefirst.InnerHtml = item.dateTime.ToString("hh:mm tt"); 

            HtmlGenericControl h1yearfirst = new HtmlGenericControl("h1");
            h1yearfirst.Attributes["class"] = "bottom";
            h1yearfirst.InnerHtml = item.dateTime.Year.ToString();

            tdfirst.Controls.Add(h1datefirst);
            tdfirst.Controls.Add(h2timefirst);
            tdfirst.Controls.Add(h1yearfirst);

            //second cell
            HtmlTableCell tdsecond = new HtmlTableCell("td");
            tdsecond.Attributes["class"] = "middlecell";
            tdsecond.InnerHtml = "<h1>" + item.title + "</h1>" + item.desc + "<br /><br />";

            foreach (string[] attitem in item.attachments)
            {
                HtmlGenericControl linkToAtt = new HtmlGenericControl("a");
                linkToAtt.Attributes["href"] = attitem[0];
                linkToAtt.InnerHtml = attitem[1] + "<br />";

                tdsecond.Controls.Add(linkToAtt);
            }



            //third cell
            HtmlTableCell tdthird = new HtmlTableCell("td");
            tdthird.Attributes["class"] = "edges";
            tdthird.Attributes["onclick"] = "displayMeetingLocation('" + item.location.link + "')";

            HtmlGenericControl locationName = new HtmlGenericControl("h3");
            locationName.InnerHtml = item.location.title;
            HtmlGenericControl locationAddress = new HtmlGenericControl("p");
            locationAddress.InnerHtml = item.location.address;
            HtmlGenericControl locationContact = new HtmlGenericControl("p");
            locationContact.InnerHtml = item.location.contact;

            tdthird.Controls.Add(locationName);
            tdthird.Controls.Add(locationAddress);
            tdthird.Controls.Add(locationContact);

                        
	        //put cells in a row
            tr.Controls.Add(tdfirst);
            tr.Controls.Add(tdsecond);
            tr.Controls.Add(tdthird);

            return tr;
        }

        protected List<MeetingItem> getList()
        {
            List<MeetingItem> MeetingItems = new List<MeetingItem>();
            try
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList list = (SPList)web.Lists["Meetings List"];

                        for (int i = 0; i < list.ItemCount; i++)
                        {
                            string title = Convert.ToString(list.Items[i]["Title"]);
                            string desc = Convert.ToString(list.Items[i]["Description"]);
                            string location = Convert.ToString(list.Items[i]["Locations"]);
                            DateTime dateTime = Convert.ToDateTime(list.Items[i]["Event DateTime"]);
                            SPAttachmentCollection attachments = list.Items[i].Attachments;


                            MeetingItem myItem = new MeetingItem(title,desc,getLocation(location),dateTime,attachments);
                            MeetingItems.Add(myItem);

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
            return MeetingItems;
        }

        protected LocationItem getLocation(string locationTitle)
        {
            LocationItem myLocation = null;
            try
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {
                    int locationId = Convert.ToInt32(locationTitle.Split(';')[0]);

                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList list = (SPList)web.Lists["Locations"];
                        SPListItem location = list.GetItemById(locationId);
                        
                        string title = Convert.ToString(location["Title"]);
                        string address = Convert.ToString(location["Address"]);
                        string contact = Convert.ToString(location["Contact"]);
                        string link = Convert.ToString(location["Link"]);

                        myLocation = new LocationItem(title,address,contact,link);
                    }
                }
            }
            catch (Exception e)
            {
                Label lblError = new Label();
                this.Controls.Add(lblError);
                if (e.InnerException != null)
                    lblError.Text = "No Address found" + e.InnerException.ToString();
            }
            return myLocation; 
        }
    }

        public class MeetingItem
        {
            public string title;
            public string desc;
            public LocationItem location;
            public DateTime dateTime;
            public List<String[]> attachments;

            public MeetingItem(string title,string desc, LocationItem location, DateTime dateTime,SPAttachmentCollection attachmentsCollection)
            {
                this.title = title;
                this.desc = desc;
                this.location = location;
                this.dateTime = dateTime;
                attachments = new List<string[]>();

                foreach (string fileName in attachmentsCollection)
                {
                    String[] array = new String[2];
                    array[0] = attachmentsCollection.UrlPrefix + fileName;
                    array[1] = fileName;
                    attachments.Add(array);
                }

            }







        }
        public class LocationItem
        {
            public string title;
            public string address;
            public string contact;
            public string link;

            public LocationItem(string title, string address, string contact, string link)
            {
                this.title = title;
                this.address = address;
                this.contact = contact;
                this.link = link;
            }
        }


}
