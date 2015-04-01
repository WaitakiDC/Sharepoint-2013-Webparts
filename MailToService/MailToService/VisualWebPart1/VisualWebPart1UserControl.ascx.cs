using System;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace MailToService.VisualWebPart1
{
        
    public partial class VisualWebPart1UserControl : UserControl
    {
        public string relatedTo;
        public string emailTo;
        


        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
                lblEmail.Text = "This field is required";
            else
                lblEmail.Text = "";

            if (txtFirst.Text == "")
                 lblFirst.Text = "This field is required";
            else
                lblFirst.Text = "";

            if (txtLast.Text == "")
                  lblLast.Text = "This field is required";
            else
                lblLast.Text = "";

            if (txtMessage.Text == "")
                lblMessage.Text = "This field is required";
            else
                lblMessage.Text = "";

            if (txtPhone.Text == "")
                lblPhone.Text = "This field is required";
            else
                lblPhone.Text = "";

            if (txtMessage.Text != "" && txtLast.Text != "" && txtFirst.Text != "" && txtPhone.Text != "" && txtEmail.Text != "")
            {
                try
                {
                    string uri = "http://wdcweb4:4242/Mail/sendToService?message=" + txtMessage.Text + "&relatedTo=" + relatedTo + "&firstName=" + txtFirst.Text + "&lastName=" + txtLast.Text + "&phone=" + txtPhone.Text + "&emailFrom=" + txtEmail.Text + "&emailTo="+ emailTo+"&required=" + chkRequired.Checked;
                    WebRequest webRequest = WebRequest.Create(uri);
                    webRequest.GetResponse();

                    if (chkEMailContact.Checked)
                    {
                        string uri2 = "http://wdcweb4:4242/Mail/sendToService?message=" + txtMessage.Text + "&relatedTo=" + relatedTo + "&firstName=" + txtFirst.Text + "&lastName=" + txtLast.Text + "&phone=" + txtPhone.Text + "&emailTo=" + txtEmail.Text + "&emailFrom=" + emailTo + "&required=" + chkRequired.Checked;
                        WebRequest webRequest2 = WebRequest.Create(uri2);
                        webRequest2.GetResponse();
                    }



                    mailCompleteHeader.InnerHtml = "Sending message complete";
                    mailCompletebody.InnerHtml = "Sending message was successful.";




                    txtEmail.Text = "";
                    txtFirst.Text = "";
                    txtLast.Text = "";
                    txtMessage.Text = "";
                    txtPhone.Text = "";
                }
                catch
                {
                    mailCompleteHeader.InnerHtml = "Error sending message";
                    mailCompletebody.InnerHtml = "There was an error sending this message. Please try again later or email <a href=\"mailto:service@waitaki.govt.nz\">service@waitaki.govt.nz</a>";

                }
                finally
                {
                    MailCompleteMessage.Style.Add("display", "block");
                }
            }
            
        }
    }
}
