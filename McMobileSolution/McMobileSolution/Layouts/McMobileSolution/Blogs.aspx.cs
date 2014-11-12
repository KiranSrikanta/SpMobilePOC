using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using McMobileUtilities;
using McMobileRepository;

namespace McMobileSolution.Layouts.McMobileSolution
{
    public partial class Blogs : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Bing listview controls with list of discussions
                var blogs = new BlogRepository().GetAllBlogTitle(SPContext.Current.Web, McMobileUtilities.Constants.BlogListName);
                if (blogs != null)
                {
                    ltBlogTitles.DataSource = blogs;
                    ltBlogTitles.DataBind();
                }
            }
        }
    }
}
