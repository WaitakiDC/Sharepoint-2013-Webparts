using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace BuildingConsents.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        string consentNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            consentNumber = Request.QueryString["ConsentNumber"];
            
            findInDatabase();
        }

        protected void findInDatabase()
        {
            try
            {
                if (consentNumber != null)
                {
                    bcResults.Style.Add("display", "block");
                    string uri = "http://api.waitaki.govt.nz/BuildingConsents/GetConsent?ConsentNumber=" + consentNumber;
                    WebRequest webRequest = WebRequest.Create(uri);
                    webRequest.Method = "GET";
                    webRequest.ContentType = "application/json; charset=utf-8";

                    HttpWebResponse webResponce = (HttpWebResponse)webRequest.GetResponse();
                    string responceResult;
                    using (var sr = new StreamReader(webResponce.GetResponseStream()))
                    {
                        responceResult = sr.ReadToEnd();
                    }

                    BuildingConsent results = TransformConsentInfoIntoObject(responceResult);
                    if (results.consentNumber != null)
                    writeToHTML(results);
                    else
                    {
                        bcResults.Style.Add("display", "none");
                        bcError.Style.Add("display", "block");
                    }
                }
            }
            catch(Exception e)
            {

            }
        }

        protected void writeToHTML(BuildingConsent consent)
        {
            HtmlTableRow bcsum = new HtmlTableRow();

            HtmlTableCell conNum = new HtmlTableCell();
            HtmlTableCell desc = new HtmlTableCell();
            HtmlTableCell status = new HtmlTableCell();
            HtmlTableCell estdurdate = new HtmlTableCell();

            conNum.InnerHtml = consent.consentNumber;
            desc.InnerHtml = consent.description;
            status.InnerHtml = consent.status;
            estdurdate.InnerHtml = consent.estimatedDueDate.Split(' ')[0];

            bcsum.Controls.Add(conNum);
            bcsum.Controls.Add(desc);
            bcsum.Controls.Add(status);
            bcsum.Controls.Add(estdurdate);

            bcTableBCSum.Controls.Add(bcsum);

            foreach (BuildingConsentTask task in consent.tasks)
            {
                HtmlTableRow bctask = new HtmlTableRow();

                HtmlTableCell tasktask = new HtmlTableCell();
                HtmlTableCell taskstatus = new HtmlTableCell();
                HtmlTableCell taskdate = new HtmlTableCell();

                tasktask.InnerHtml = task.task;
                taskstatus.InnerHtml = task.Status;
                taskdate.InnerHtml = task.dateStarted.Split(' ')[0];

                if (taskstatus.InnerHtml == "Completed")
                {
                    taskstatus.InnerHtml =  "<div class=\"bcGreen\"></div>" + taskstatus.InnerHtml; 
                }
                else if (taskstatus.InnerHtml == "In Process")
                {
                    taskstatus.InnerHtml = "<div class=\"bcYellow\"></div>" + taskstatus.InnerHtml;
                }

                if (tasktask.InnerHtml == "Request Info   " && task.Status == "In Process")
                {
                    taskstatus.InnerHtml = "<div class=\"bcRed\"></div>" + task.Status;
                }

                bctask.Controls.Add(tasktask);
                bctask.Controls.Add(taskstatus);
                bctask.Controls.Add(taskdate);

                bcTableBCStat.Controls.Add(bctask);
            }

            HtmlTableRow bcRequiredInfo = new HtmlTableRow();
            HtmlTableCell bcReqInfo = new HtmlTableCell();
            bcReqInfo.InnerHtml = consent.currentRequiredInfo;

            bcRequiredInfo.Controls.Add(bcReqInfo);
            bcTableCRInfo.Controls.Add(bcRequiredInfo);

        }

        protected BuildingConsent TransformConsentInfoIntoObject(string json)
        {
            try
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                BuildingConsent consent = jss.Deserialize<BuildingConsent>(json);

                return consent;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        protected void bcSearch_Click(object sender, EventArgs e)
        {
            string num = txtBcSearch.Value;
            Response.Redirect("/business/building/Pages/consent.aspx?ConsentNumber=" + num);
        }
    }

    public class BuildingConsent
    {
        public string consentNumber;
        public string description;
        public string status;
        public string estimatedDueDate;
        public string currentRequiredInfo;
        public List<BuildingConsentTask> tasks;
    }

    public class BuildingConsentTask
    {
        public string task;
        public string Status;
        public string dateStarted;
    }
}
