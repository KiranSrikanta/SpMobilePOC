using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using McMobileUtilities;
using McMobileEntity;
using McMobileRepository;

namespace McMobileSolution.Layouts.McMobileSolution
{
    public partial class GlobalNews : LayoutsPageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    //Bing listview controls with list of news articles
                    ltGlobalNews.DataSource = new GlobalNewsRepository().GetAllGlobalNews(SPContext.Current.Web, "Global News");
                    ltGlobalNews.DataBind();
                }
                catch
                {
                    //Log Error
                }
            }
        }
    }
}
