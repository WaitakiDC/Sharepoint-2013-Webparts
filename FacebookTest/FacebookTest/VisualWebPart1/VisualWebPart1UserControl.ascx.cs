using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace FacebookTest.VisualWebPart1
{
    public partial class VisualWebPart1UserControl : UserControl
    {
        protected List<Post> fbPost;
        protected void Page_Load(object sender, EventArgs e)
        {
            DownloadFeed();
        }

        protected void DownloadFeed()
        {
            fbPost = new List<Post>();
            string json;
            using (var webClient = new System.Net.WebClient())
            {
                json = webClient.DownloadString("https://graph.facebook.com/sytleandstrokeswimschool/posts?access_token=316648978502024|yi59-SoMG9oovF7Qdt1rMIKu3vA");
            }
            LoadJson(json);
        }

        public void LoadJson(String json)
        {
            var deserializer = new JavaScriptSerializer();
            // var results = deserializer.Deserialize<Data>(json);
            IDictionary dict = deserializer.Deserialize<Dictionary<string, object>>(json);
            getPosts(dict);

            for (int i = 0; i < fbPost.Count;i++) 
                {
                    //if (fbPost[i].status_type != "shared_story" && fbPost[i].status_type != "mobile_status_update" && fbPost[i].status_type != "status_update")
                    if (fbPost[i].story.Contains("Waitaki District Council commented") || fbPost[i].story.Contains("Waitaki District Council likes"))
                    {
                        fbPost.Remove(fbPost[i]);
                    }
                  
                }


            for (int i = 0; i < 4; i++)
            {  
                addPost(fbPost[i],i);
            }
            
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
            return result;
        }


        public void getPosts(IDictionary dictionary)
        {
            

            object value = dictionary["data"];
            ArrayList myArrayList = (ArrayList)value;

            foreach (IDictionary post in myArrayList)
            {
                

                string postername = "";
                string message = "";
                string picture = "";
                string id = "";
                string postid = "";
                string link = "";
                string caption = "";
                string description = "";
                string created = "";
                string name = "";
                string type = "";
                string status_type = "";
                string story = "";
                

                IDictionary fromdic = (IDictionary)post["from"];
                postername = fromdic["name"].ToString();

                if (post.Contains("message"))
                {
                    message = addLinksToString(post["message"].ToString());
                }
                if (post.Contains("story"))
                {
                    story = post["story"].ToString();
                }
                if (post.Contains("status_type"))
                {
                    status_type = post["status_type"].ToString();
                }
                if (post.Contains("id"))
                {
                    id = post["id"].ToString().Split('_')[0];
                    postid = post["id"].ToString().Split('_')[1];
                }
                if (post.Contains("picture"))
                {
                    picture = post["picture"].ToString();
                }
                if (post.Contains("link"))
                {
                    link = post["link"].ToString();
                }
                if (post.Contains("caption"))
                {
                    caption = post["caption"].ToString();
                }
                if (post.Contains("description"))
                {
                    description = post["description"].ToString();
                }
                if (post.Contains("created_time"))
                {
                    created = post["created_time"].ToString();
                }
                if (post.Contains("name"))
                {
                    name = post["name"].ToString();
                }
                if (post.Contains("type"))
                {
                    type = post["type"].ToString();
                }

                Post myPost = new Post(message, picture, link, caption, description, id, postid,created,name,postername,type,status_type,story);
                fbPost.Add(myPost);
            }
        }


        public class Post
        {
            public Post(String message, String picture, String link, String caption, String description, String id, String postid, String created, String name, String posterName, String type, String status_type,String story)
            {
                this.posterName = posterName;
                this.message = message;
                this.picture = picture;
                this.link = link;
                this.caption = caption;
                this.description = description;
                this.id = id;
                this.postid = postid;
                this.created = created;
                this.name = name;
                this.type = type;
                this.story = story;
                this.status_type = status_type;
                string[] messagewords = this.message.Split(' ');
                for (int i = 0; i < messagewords.Length; i++)
                {
                    if (i < 7)
                    this.title += " " + messagewords[i] ;
                }
                this.title += "...";
            }
            public String posterName { get; set; }
            public String story { get; set; }
            public String message { get; set; }
            public String picture { get; set; }
            public String title { get; set; }
            public String link { get; set; }
            public String caption { get; set; }
            public String description { get; set; }
            public String id { get; set; }
            public String postid { get; set; }
            public String created { get; set; }
            public String name { get; set; }
            public String type { get; set; }
            public String status_type { get; set; }
        }

  
        protected void addPost(Post post,int postnumber)
        {
            HtmlGenericControl facebookPost = new HtmlGenericControl("div");
            facebookPost.Attributes["class"] = "facebookPost";

            HtmlGenericControl fbpostImage = new HtmlGenericControl("div");
            fbpostImage.Attributes["class"] = "fbpostImage";

            HtmlGenericControl fbpostimg = new HtmlGenericControl("img");
            fbpostimg.Attributes["alt"] = post.caption;
            fbpostimg.Attributes["src"] = post.picture;

            HtmlGenericControl fbpostText = new HtmlGenericControl("div");
            fbpostText.Attributes["class"] = "fbpostText";

            HtmlGenericControl fbpostTitle = new HtmlGenericControl("div");
            fbpostTitle.Attributes["class"] = "fbpostTitle";
            fbpostTitle.InnerHtml = post.title;

            HtmlGenericControl fbPostBody = new HtmlGenericControl("div");
            fbPostBody.Attributes["class"] = "fbPostBody";
            fbPostBody.InnerHtml = post.message;

            HtmlGenericControl fbbreak = new HtmlGenericControl("br");

            HtmlGenericControl abbr = new HtmlGenericControl("abbr");
            abbr.Attributes["class"] = "timeago timeandlink";
            abbr.Attributes["title"] = post.created;
            
            HtmlGenericControl a = new HtmlGenericControl("a");
            a.Attributes["class"] = "timeandlink";
            a.Attributes["style"] = "float:right";
            a.Attributes["href"] = "https://www.facebook.com/" + post.id + "/posts/" + post.postid;
            a.Attributes["target"] = "_blank";
            a.InnerHtml = "View on Facebook";


            //join the elements to make the post
            fbpostImage.Controls.Add(fbpostimg);
            fbpostText.Controls.Add(fbpostTitle);
            fbpostText.Controls.Add(fbPostBody);
            fbpostText.Controls.Add(fbbreak);
            fbpostText.Controls.Add(abbr);
            fbpostText.Controls.Add(a);

            facebookPost.Controls.Add(fbpostImage);
            facebookPost.Controls.Add(fbpostText);

            facebookwebpart.Controls.Add(facebookPost); 
        }
    }
}
