using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Web.UI.WebControls.WebParts;

namespace FacebookFeed.VisualWebPart1
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
            DownloadFeed();
        }

        protected void DownloadFeed()
        {
            string url = "https://graph.facebook.com/WaitakiDistrictCouncil/posts?access_token=316648978502024|yi59-SoMG9oovF7Qdt1rMIKu3vA";
            HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(url);
            
            // Get the response from the web service
            HttpWebResponse response = (HttpWebResponse)wr.GetResponse();
            Stream r_stream = response.GetResponseStream();

            //convert it
            StreamReader response_stream = new StreamReader(r_stream, System.Text.Encoding.GetEncoding("utf-8"));

            string jSon = response_stream.ReadToEnd();

            //clean up your stream
            response_stream.Close();
        }
    }
}
