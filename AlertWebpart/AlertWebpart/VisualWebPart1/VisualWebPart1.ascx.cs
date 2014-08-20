using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace AlertWebpart.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public partial class VisualWebPart1 : WebPart
    {
        
        public Button createList;
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
            getList();
        }



        protected void getList()
        {
            List<AlertItem> AlertItems = new List<AlertItem>();
            try
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList list = (SPList)web.Lists["AlertsList"];

                        for (int i = 0; i < list.ItemCount; i++)
                        {
                            string title = Convert.ToString(list.Items[i]["Title"]);
                            string impact = Convert.ToString(list.Items[i]["Impact"]);
                            string desc = Convert.ToString(list.Items[i]["Description"]);
                            string pintotop = Convert.ToString(list.Items[i]["Pin to top"]);
                            string modifyedDate = Convert.ToString(list.Items[i]["Modified"]);
                            AlertItem myItem = new AlertItem(title, desc, impact, pintotop, modifyedDate);
                            AlertItems.Add(myItem);

                        }
                        AlertItems.Sort((x, y) => DateTime.Compare(x.Created, y.Created));
                        AlertItems.Reverse();
                
                        //AlertItems.Sort((a, b) => a.ToString().CompareTo(b.ToString()));
                        foreach (AlertItem item in AlertItems)
                        {
                            if (item.pinToTop)
                            item.addLi(AlertItemsHere);
                        }
                        //do red ones
                        foreach (AlertItem item in AlertItems)
                        {
                            if (!item.pinToTop)
                                if (item.impact == "High")
                                    item.addLi(AlertItemsHere);
                        }
                        //do yellow ones
                        foreach (AlertItem item in AlertItems)
                        {
                            if (!item.pinToTop)
                                if (item.impact == "Medium")
                                item.addLi(AlertItemsHere);
                        }
                        //do green ones
                        foreach (AlertItem item in AlertItems)
                        {
                            if (!item.pinToTop)
                                if (item.impact == "Low")
                                item.addLi(AlertItemsHere);
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

        protected class AlertItem
        {
            protected string title;
            protected string desc;
            public string impact;
            protected string dateTime;
            public DateTime Created;
            public bool pinToTop;

            

            public AlertItem(string title, string desc, string impact, string pintotop,string dateTime)
            {
                this.title = title;
                desc = addLinksToString(desc);
                //if (desc.Contains("http:"))
                //{
                //    string link = desc.Split(new string[] { "http://" }, StringSplitOptions.None)[1];
                //    link = link.Split(' ')[0];
                //    link = "http://" + link;
                //    desc = desc.Replace(link, "<a target=\"_blank\" href=\"" + link + "\">" + link + "</a>");
                //}
                //else if (desc.Contains("www."))
                //{
                //    string link = desc.Split(new string[] { "www." }, StringSplitOptions.None)[1];
                //    link = link.Split(' ')[0];
                //    link = "www." + link;
                //    desc = desc.Replace(link, "<a target=\"_blank\" href=\"http://" + link + "\">" + link + "</a>");
                //}
                this.desc = desc;
                this.impact = impact;
                this.dateTime = dateTime;
                if (pintotop == "False")
                {
                    this.pinToTop = false;
                }
                else
                {
                    this.pinToTop = true;
                }

                this.Created = this.getSortableTime();
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
                return result ;
            }

           

            public string getImpact()
            {
                if (this.impact == "High")
                    return "red";
                else if (this.impact == "Medium")
                    return "yellow";
                else
                    return "green";

            }

            public string getAmericanTime()
            {
                // orginal time 7/31/2014 12:20:30 PM

                string month = this.dateTime.Split('/')[0];
                string day = this.dateTime.Split('/')[1];
                string year = this.dateTime.Split('/')[2];

                return month + "/" + day + "/" + year;
            }

            protected DateTime getSortableTime()
            {
                string month = this.dateTime.Split('/')[0];
                string day = this.dateTime.Split('/')[1];
                string year = this.dateTime.Split('/')[2];
                string time = year.Split(' ')[1];
                string ampm = year.Split(' ')[2];
                year = year.Split(' ')[0];
                string hour = time.Split(':')[0];
                string minute = time.Split(':')[1];
                string seconds = time.Split(':')[2];

                if (ampm == "PM")
                {
                    if (hour == "12")
                        hour = "0";
                    else
                    {
                        hour = (int.Parse(hour) + 12).ToString();
                    }
                }






                DateTime myTime = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day),Int32.Parse(hour),Int32.Parse(minute),Int32.Parse(seconds));
                return myTime;
            }


            public void addLi(HtmlGenericControl alertListDiv)
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                     
                //create alerts image                
                HtmlGenericControl divAlertItem = new HtmlGenericControl("div");
                divAlertItem.Attributes["class"] = "AlertItem";

                HtmlGenericControl divAlertImage = new HtmlGenericControl("div");
                divAlertImage.Attributes["class"] = "AlertsImage";

                HtmlGenericControl divAlertStatusImage = new HtmlGenericControl("div");
                divAlertStatusImage.Attributes["class"] = this.getImpact();

                //add image to the image div
                divAlertImage.Controls.Add(divAlertStatusImage);
                //add image div to the alert item
                divAlertItem.Controls.Add(divAlertImage);


                //create alerts text
                HtmlGenericControl divAlertsText = new HtmlGenericControl("div");
                divAlertsText.Attributes["class"] = "AlertsText";

                HtmlGenericControl h1AlertsHeader = new HtmlGenericControl("h1");
                h1AlertsHeader.InnerHtml = this.title;

                HtmlGenericControl pAlertsDesc = new HtmlGenericControl("p");
                pAlertsDesc.InnerHtml = this.desc;

                HtmlGenericControl abbrAlertsTime = new HtmlGenericControl("abbr");
                abbrAlertsTime.Attributes["class"] = "timeago timeandlink timestamp";
                abbrAlertsTime.Attributes["title"] = this.getAmericanTime();

                //add header desc and time to the alert text
                divAlertsText.Controls.Add(h1AlertsHeader);
                divAlertsText.Controls.Add(pAlertsDesc);
                divAlertsText.Controls.Add(abbrAlertsTime);

                //add text to the item
                divAlertItem.Controls.Add(divAlertsText);



                li.Controls.Add(divAlertItem);
                //add li to div
                alertListDiv.Controls.Add(li);
            }
        }



        protected void CreateList()
        {
            try
            {
                // choose your site
                SPWeb web = SPContext.Current.Web;
                SPListCollection lists = web.Lists;

                // create new Generic list called "AlertsList"
                lists.Add("AlertsList", "List to control the alerts for this webpart. Don't change the columns", SPListTemplateType.GenericList);

                SPList list = web.Lists["AlertsList"];

                StringCollection categories = new StringCollection();
                categories.AddRange(new string[] { "High", "Medium", "Low" });
                // create Text type new column called "My Column" 
                list.Fields.Add("Description", SPFieldType.Text, true);
                list.Fields.Add("Impact", SPFieldType.Choice, true, false, categories);
                list.Fields.Add("Pin to top", SPFieldType.Boolean, true);

                //get the newly added choice field instance
                SPFieldChoice fieldImpact = (SPFieldChoice)list.Fields["Impact"];

                //set field format type i.e. radio/dropdown

                fieldImpact.EditFormat = SPChoiceFormatType.Dropdown;



                list.Update();

                // make new column visible in default view
                SPView view = list.DefaultView;
                view.ViewFields.Add("Description");
                view.ViewFields.Add("Impact");
                view.ViewFields.Add("Pin to top");
                view.Update();

                Label myLabel = new Label();
                myLabel.Text = "AlertsList Created. Please go to site contents to add items for the alerts";
                this.Controls.Add(myLabel);
 

            }
            catch (Exception e)
            {
            }
        }
    }
}
