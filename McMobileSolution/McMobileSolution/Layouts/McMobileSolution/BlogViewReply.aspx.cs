using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using McMobileUtilities;
using McMobileEntity;
using McMobileRepository;

namespace McMobileSolution.Layouts.McMobileSolution
{
    public partial class BlogViewReply : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //Get Discussion reply Item ID
                    int blogId = Convert.ToInt32(Request.QueryString["BlogID"]);
                    BlogReply reply = new BlogRepository().GetBlogReply(this.Web, McMobileUtilities.Constants.BlogListName, blogId);

                    if (reply != null)
                    {
                        //Bind controls for the Discussion reply Item
                        lblReplyAuthor.Text = reply.Author;
                        lblReplyCreatedOn.Text = reply.ModifiedDate.ToString();
                        lblFullBody.Text = reply.FullBody;
                    }
                }
                catch
                {
                    //Log Error
                }
            }
            hfGoBack.Value = "False";
        }

        public void lbtnAddReply_Click(object sender, EventArgs e)
        {
            try
            {
                //Get Discussion reply Item ID
                int blogId = Convert.ToInt32(Request.QueryString["BlogID"]);
                string replyText = txtReply.Text;
                //Add new reply
                if ((!String.IsNullOrEmpty(replyText)) && (new BlogRepository().AddReply(SPContext.Current.Web, McMobileUtilities.Constants.BlogListName, blogId, replyText)))
                {
                    //Re-bind data
                    BlogReply reply = new BlogRepository().GetBlogReply(this.Web, McMobileUtilities.Constants.BlogListName, blogId);
                    if (reply != null)
                    {
                        lblReplyAuthor.Text = reply.Author;
                        lblReplyCreatedOn.Text = reply.ModifiedDate.ToString();
                        lblFullBody.Text = reply.FullBody;
                    }
                    hfGoBack.Value = "True";
                }
            }
            catch
            {
                //Log Error
            }
        }
    }
}
