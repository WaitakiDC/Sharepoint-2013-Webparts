using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RatesTest2.VisualWebPart1
{
    [ToolboxItemAttribute(false)]
    public class VisualWebPart1 : WebPart
    {
                public List<String> AddressList;
        protected List<int> AssessmentList;
        protected List<String> ValuationList;
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/RatesTest2/VisualWebPart1/VisualWebPart1UserControl.ascx";

        protected override void CreateChildControls()
        {
            Control control = Page.LoadControl(_ascxPath);
            Controls.Add(control);
            {
                AddressList = new List<string>();
                AssessmentList = new List<int>();
                ValuationList = new List<string>();


                String connectionString = "Server=wdcsql2;Database=authlive;User Id=web;Password=N0tUpload";

                //using (SqlConnection con = new SqlConnection(connectionString))
                //{
                //    //
                //    // Open the SqlConnection.
                //    //
                //    con.Open();
                //    //
                //    // The following code uses an SqlCommand based on the SqlConnection.
                //    //
                //    using (SqlCommand command = new SqlCommand("Use authlive SELECT distinct RTRIM(fmt_add) as Address, Valuation_Number, DVR as Assessment_Number, str_nme FROM WDC_Rates_DVR_Data order by str_nme, Address", con))
                //    using (SqlDataReader reader = command.ExecuteReader())
                //    {
                //        while (reader.Read())
                //        {
                //            AddressList.Add(reader.GetString(0));
                //            ValuationList.Add(reader.GetString(1));
                //            AssessmentList.Add(reader.GetInt32(2));
                //        }
                //    }


                //}
                SetAddress();
            }
        }


        public void SetAddress()
        {
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "myAlertScript", "alert('hello!')", true);
        }
    }
}
