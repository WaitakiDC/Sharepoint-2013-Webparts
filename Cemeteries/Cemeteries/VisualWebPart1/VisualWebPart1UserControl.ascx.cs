using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;

namespace Cemeteries.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        string firstname;
        string lastname;
        string exFirst;
        string exLast;

        protected void Page_Load(object sender, EventArgs e)
        {
             firstname = Request.QueryString["first"];
             lastname = Request.QueryString["last"];
             exFirst = Request.QueryString["exFirst"];
             exLast = Request.QueryString["exLast"];

             findInDatabase();


        }

        protected void findInDatabase()
        {
            if (firstname != null & lastname != null & exFirst != null & exLast != null)
            {
                string uri = "http://api.waitaki.govt.nz/Cemeteries/GetRecords?firstName=" + firstname + "&lastName=" + lastname + "&exFirst=" + exFirst + "&exLast=" + exLast;
                WebRequest webRequest = WebRequest.Create(uri);
                webRequest.Method = "GET";
                webRequest.ContentType = "application/json; charset=utf-8";

                HttpWebResponse webResponce = (HttpWebResponse)webRequest.GetResponse();
                string responceResult;
                using (var sr = new StreamReader(webResponce.GetResponseStream()))
                {
                    responceResult = sr.ReadToEnd();
                }

                RecordHolder results = TransformCemRecordsInfoIntoObject(responceResult);
                bool even = false;
                foreach(cemRecord record in results.records)
                {
                    if (even)
                        even = false;
                    else
                        even = true;

                    writeToHTML(record,even);
                }

            }
        }



        protected RecordHolder TransformCemRecordsInfoIntoObject(string json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            RecordHolder records = jss.Deserialize<RecordHolder>(json);

            return records;
        }

        protected void writeToHTML(cemRecord person, bool even)
        {
            HtmlTableRow tr = new HtmlTableRow();

            if (even)
            {
                tr.Style.Add("background", "#eee");
            }

            HtmlTableCell tdForename = new HtmlTableCell();
            HtmlTableCell tdSurname = new HtmlTableCell();
            HtmlTableCell tdAge = new HtmlTableCell();
            HtmlTableCell tdBurialDate = new HtmlTableCell();
            HtmlTableCell tdDateOfDeath = new HtmlTableCell();
            HtmlTableCell tdCemetery = new HtmlTableCell();
            HtmlTableCell tdBlock = new HtmlTableCell();
            HtmlTableCell tdPlotNumber = new HtmlTableCell();

            tdForename.InnerHtml = person.rFirstName;
            tdSurname.InnerHtml = person.rLastName;
            tdAge.InnerHtml = person.rAge;
            tdAge.Attributes.Add("class", "rightAlign");
            tdBurialDate.InnerHtml = person.rBurialDate;
            tdBurialDate.Attributes.Add("class", "rightAlign");
            tdDateOfDeath.InnerHtml = person.rDateOfDeath;
            tdDateOfDeath.Attributes.Add("class", "rightAlign");
            tdCemetery.InnerHtml = person.rCemetery;
            tdBlock.InnerHtml = person.rBlock;
            tdBlock.Attributes.Add("class", "rightAlign");
            tdPlotNumber.InnerHtml = person.rPlotNumber;
            tdPlotNumber.Attributes.Add("class", "rightAlign");

            tr.Controls.Add(tdForename);
            tr.Controls.Add(tdSurname);
            tr.Controls.Add(tdAge);
            tr.Controls.Add(tdBurialDate);
            tr.Controls.Add(tdDateOfDeath);
            tr.Controls.Add(tdCemetery);
            tr.Controls.Add(tdBlock);
            tr.Controls.Add(tdPlotNumber);

            CemeterySearchResultsTable.Controls.Add(tr);


        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            string first = txtFirstName.Value;
            string last = txtLastName.Value;
            string exFirst = chkbxExactFirst.Checked.ToString();
            string exLast = chkbxExactLast.Checked.ToString();



            Response.Redirect("/services/Pages/cemeteries.aspx?first=" + first + "&last=" + last + "&exFirst=" + exFirst + "&exLast=" + exLast);


                  
        }

    }
}
