using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using McMobileUtilities;
using McMobileEntity;
using McMobileRepository;

namespace McMobileSolution.Layouts.McMobileSolution
{
    public partial class NewsArticle : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //Get article Item ID
                    int articleId = Convert.ToInt32(Request.QueryString["ArticleID"]);

                    GlobalNewsEntity newsArticle = new GlobalNewsRepository().GetNewsArticle(this.Web, "Global News", articleId);

                    if (newsArticle != null)
                    {
                        //Bind controls for the news article Item
                        lblTimeStamp.Text = newsArticle.TimePublished;
                        lblTitle.Text = newsArticle.Title;
                        lBody.Text = newsArticle.Body;
                    }
                }
                catch
                {
                    //Log Error
                }
            }
            hfScrollDown.Value = "False";
        }

        public void btnAddComment_Click(object sender, EventArgs e)
        {
            try
            {
                //Get article Item ID
                int articleId = Convert.ToInt32(Request.QueryString["ArticleID"]);
                string comment = txtComment.Text;
                if ((!String.IsNullOrEmpty(comment)) && (new GlobalNewsRepository().AddComment(SPContext.Current.Web, "Global News", articleId, comment, this.Web.CurrentUser.Name)))
                {
                    //Re-bind data
                    GlobalNewsEntity newsArticle = new GlobalNewsRepository().GetNewsArticle(this.Web, "Global News", articleId);
                    if (newsArticle != null)
                    {
                        lblTimeStamp.Text = newsArticle.TimePublished;
                        lblTitle.Text = newsArticle.Title;
                        lBody.Text = newsArticle.Body;
                        txtComment.Text = string.Empty;
                    }
                    hfScrollDown.Value = "True";
                }
            }
            catch
            {
                //Log Error
            }
        }
    }
}
