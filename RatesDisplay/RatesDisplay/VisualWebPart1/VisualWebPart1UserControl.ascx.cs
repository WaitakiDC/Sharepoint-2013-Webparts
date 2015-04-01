using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace RatesDisplay.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        protected RatesObject ratingInfo;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string assessmentNumber = Request.QueryString["AssessmentNumber"];

            if (assessmentNumber != null)
            {
                //download rates info from api 
                ratingInfo = TransformRatesInfoIntoObject(GetRatesInfo(assessmentNumber));

                //convert into string
                PropertyInfoForList propInfo = new PropertyInfoForList(ratingInfo);

                hiddenAddressServer.Text = propInfo.formatedAddress;

                Dictionary<string, string> propertyItems = new Dictionary<string, string>();
                propertyItems.Add("Assessment Number", propInfo.assessmentNumber.ToString());
                propertyItems.Add("Valuation Number", propInfo.valuationNumber.ToString());
                propertyItems.Add("Property Address", propInfo.formatedAddress.ToString());
                propertyItems.Add("Ratepayer Name(s)", propInfo.owners.ToString());
                propertyItems.Add("Postal Address for this Assessment", propInfo.postal.ToString());
                propertyItems.Add("Land Zone", propInfo.zones.ToString());

                gridPropertyInfo.DataSource = propertyItems;
                gridPropertyInfo.DataBind();


                Dictionary<string, string> currentRatesItems = new Dictionary<string, string>();
                currentRatesItems.Add("Current Rating Year", propInfo.ratingYear.ToString());
                currentRatesItems.Add("Rateability", propInfo.rateable.ToString());
                currentRatesItems.Add("Legal Description", propInfo.qvLegalDescription.ToString());
                currentRatesItems.Add("Area", propInfo.landArea.ToString());
                currentRatesItems.Add("Land Value", propInfo.landValue.ToString());
                currentRatesItems.Add("Capital Value", propInfo.capitalValue.ToString());
                gridCurrentRates.DataSource = currentRatesItems;
                gridCurrentRates.DataBind();


                decimal total = 0;

                List<LeviedDetailForList> leviedList = new List<LeviedDetailForList>();
                leviedList.Add(new LeviedDetailForList("Description", "Factor", "Rate or Charge", "Amount"));

                foreach (RatesLevyDetail item in ratingInfo.levyDetails)
                {
                    leviedList.Add(new LeviedDetailForList(item.levyDescription, item.rate, item.basis, item.levied));
                    total += item.levied;
                }
                leviedList.Add(new LeviedDetailForList("Total", total));

                gridRatesLevied.DataSource = leviedList;
                gridRatesLevied.DataBind();
            }
        }



        protected string GetRatesInfo(string assessmentNum)
        {
            string uri = "http://wdcweb4/Rates/GetRatesInfo/?assessmentNum=" + assessmentNum;
            WebRequest webRequest = WebRequest.Create(uri);
            webRequest.Method = "GET";
            webRequest.ContentType = "application/json; charset=utf-8";

            HttpWebResponse webResponce = (HttpWebResponse)webRequest.GetResponse();
            string responceResult;
            using (var sr = new StreamReader(webResponce.GetResponseStream()))
            {
                responceResult = sr.ReadToEnd();
            }
            return responceResult;
        }

        protected RatesObject TransformRatesInfoIntoObject(string json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            RatesObject ratesObject = jss.Deserialize<RatesObject>(json);
            if (ratesObject.formatedAddress != null)
            PropertyName.Text = ratesObject.formatedAddress;
            return ratesObject;
        }

        



    }
}