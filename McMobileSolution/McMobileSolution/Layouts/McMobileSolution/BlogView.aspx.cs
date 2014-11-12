using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using McMobileUtilities;
using McMobileEntity;
using McMobileRepository;

namespace McMobileSolution.Layouts.McMobileSolution
{
    public partial class BlogView : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //Get Discussion Item ID
                    int blogItemID = Convert.ToInt32(Request.QueryString["BlogID"]);
                    BlogEntity blog = new BlogRepository().GetBlogData(SPContext.Current.Web, McMobileUtilities.Constants.BlogListName, blogItemID);
                    if (blog != null)
                    {
                        //Bind controls for the Discussion Item
                        lblTitle.Text = blog.Title;
                        lBody.Text = blog.Body;
                        lblAuthor.Text = blog.Author;
                        lblBlogCreatedOn.Text = blog.ModifiedDate.ToShortDateString();
                    }

                    //Bind listview having controls for the Discussion replies
                    lvReplies.DataSource = new BlogRepository().GetBlogReplies(SPContext.Current.Web, McMobileUtilities.Constants.BlogListName, blogItemID);
                    lvReplies.DataBind();
                }
                catch
                {
                    //Log Error
                }
            }
        }
    }
}
