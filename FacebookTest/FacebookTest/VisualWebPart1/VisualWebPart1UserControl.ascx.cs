using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.UI;
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
                json = webClient.DownloadString("https://graph.facebook.com/WaitakiDistrictCouncil/posts?access_token=316648978502024|yi59-SoMG9oovF7Qdt1rMIKu3vA");
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
                    if (fbPost[i].type != "link" && fbPost[i].type != "status" && fbPost[i].status_type == "mobile_status_update" || fbPost[i].status_type != "status_update")
                    {
                        fbPost.Remove(fbPost[i]);
                    }
                }
            


            createHeader();
            for (int i = 0; i<2; i++)
            {
                addPost(fbPost[i],i);
            }
            
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

                

                IDictionary fromdic = (IDictionary)post["from"];
                postername = fromdic["name"].ToString();
                //   try
                //  {
                if (post.Contains("message"))
                {
                    message = post["message"].ToString();
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

                Post myPost = new Post(message, picture, link, caption, description, id, postid,created,name,postername,type,status_type);
                fbPost.Add(myPost);
            }
            facebookwebpart.InnerHtml += "</div>";

        }


        public class Post
        {
            public Post(String message, String picture, String link, String caption, String description, String id, String postid, String created, String name, String posterName, String type, String status_type)
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
                this.status_type = status_type;
            }
            public String posterName { get; set; }
            public String message { get; set; }
            public String picture { get; set; }
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

        protected void createHeader()
        {
            facebookwebpart.InnerHtml += "<div id=\"facebooklogo\"><img src=\"http://www.grkdesign.net/site/wp-content/uploads/2012/02/fb.png\" alt=\"Facebook\"/><div>Our Facebook Feed</div></div><div id=\"postsContainer\"style=\"display: table; width:100%\">";

        }
        protected void addPost(Post post,int postnumber)
        {
            string newPost = "";
            if (postnumber == 0)
            {
                newPost = "<div class=\"post\" style=\"border-right:thin solid #43609C;\">" +
                                   "<div class=\"fb_message_header\">" +
                                   "<div class=\"facebook_message_header_image\"><img src=\"http://graph.facebook.com/" + post.id + "/picture?type=square\"alt=\"Waitaki District Council Logo\"/></div>" +
                                   "<div class=\"facebook_message_header_text\">" + post.posterName + "</div>" +
                                   "</div>" +
                                    "<div style=\"float:left;margin-left:20px; margin-top:-5px; display:inline-block\"><abbr class=\"timeago timeandlink\" title=\"" + post.created + "\"></abbr></div>" +
                                    "<div class=\"timeandlink\" style=\"float:right;margin-right:20px; display:inline-block\"><a href=\"https://www.facebook.com/" + post.id + "/posts/" + post.postid + "\">View on facebook</a></div><br/>"+
                "<div class=\"fb_message\">" + post.message + "</div>";
                    if (post.link != "")
                {
                    newPost += "<a href=\"" + post.link + "\"><div class=\"facebook_post\">";
                    if (post.picture != "")
                    {
                        newPost += "<div class=\"post_picture\">" +
                        "<img alt=\"" + post.caption + "\" src=\"" + post.picture + "\"/></div>";
                    }
                    newPost += "<div class=\"fb_text_container\">" +
                    "<div class=\"facebook_header\"><h1>" + post.name + "</h1></div>" +
                    "<div class=\"facebook_link\">" + post.caption + "</div>" +
                    "<div class=\"facebook_link_desc\"><p>" + post.description + "</p></div>" +
                    "</div>" +
                "</div></a>";
                }
                newPost += "</div>";
            }
            else
            {
                newPost = "<div class=\"post\">" +
                                    "<div class=\"fb_message_header\">" +
                                    "<div class=\"facebook_message_header_image\"><img src=\"http://graph.facebook.com/" + post.id + "/picture?type=square\"alt=\"Waitaki District Council Logo\"/></div>" +
                                    "<div class=\"facebook_message_header_text\">" + post.posterName + "</div>" +
                                    "</div>" +
                                    "<div style=\"float:left;margin-left:20px; margin-top:-5px; display:inline-block\"><abbr class=\"timeago timeandlink\" title=\"" + post.created + "\"></abbr></div>" +
                                    "<div class=\"timeandlink\" style=\"float:right;margin-right:20px; display:inline-block\"><a href=\"https://www.facebook.com/" + post.id + "/posts/" + post.postid + "\">View on facebook</a></div><br/>" +
                                    "<div class=\"fb_message\">" + post.message + "</div>";
                                    if (post.link != "")
                                    {                   
                                    newPost +="<a href=\"" + post.link + "\"><div class=\"facebook_post\">";
                                    if (post.picture != "")
                                    {
                                        newPost += "<div class=\"post_picture\">" +
                                        "<img alt=\"" + post.caption + "\" src=\"" + post.picture + "\"/></div>";
                                    }
                                    newPost +=         "<div class=\"fb_text_container\">" +
                                    "<div class=\"facebook_header\"><h1>" + post.name + "</h1></div>" +
                                    "<div class=\"facebook_link\">" + post.caption + "</div>" +
                                    "<div class=\"facebook_link_desc\"><p>" + post.description + "</p></div>" +
                                    "</div>" +
                                    "</div></a>";
                                    }
                                    newPost += "</div>";
           
            }
                
                facebookwebpart.InnerHtml += newPost;
        }
    }
}
