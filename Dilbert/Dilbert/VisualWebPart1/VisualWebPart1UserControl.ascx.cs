using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Dilbert.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string dilbert;
            using (var webClient = new System.Net.WebClient())
            {
                dilbert = webClient.DownloadString("http://www.dilbert.com/");
                dilbert = ExtractBetweenTwoStrings(dilbert, "http://dilbert.com/dyn/str_strip/", ".gif", true, true);
               
                    Dilbert_Webpart.InnerHtml = "<img src=\"" + dilbert + "\" alt=\"Dilbert\"/>";
               
            }
          
        }

        public static string ExtractBetweenTwoStrings(string FullText, string StartString, string EndString, bool IncludeStartString, bool IncludeEndString) { try { int Pos1 = FullText.IndexOf(StartString) + StartString.Length; int Pos2 = FullText.IndexOf(EndString, Pos1); return ((IncludeStartString) ? StartString : "") + FullText.Substring(Pos1, Pos2 - Pos1) + ((IncludeEndString) ? EndString : ""); } catch (Exception ex) { return ex.ToString(); } } //return ""; }
        
    }
}
