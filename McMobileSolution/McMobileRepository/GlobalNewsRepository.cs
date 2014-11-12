using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using McMobileEntity;
using Microsoft.SharePoint;

namespace McMobileRepository
{
    public class GlobalNewsRepository
    {
        /// <summary>
        /// Convert all list items and transform to GlobalNewsEntity type
        /// </summary>
        /// <param name="spWeb">SPWeb object of the current site</param>
        /// <param name="listName">Name of the list used for Global News</param>
        /// <returns>List of Global News Entity objects</returns>
        public List<GlobalNewsEntity> GetAllGlobalNews(SPWeb spWeb, string listName)
        {
            List<GlobalNewsEntity> AllGlobalNews = new List<GlobalNewsEntity>();

            try
            {
                SPList spList = spWeb.Lists[listName];

                foreach (SPListItem spItem in spList.Items)
                {
                    AllGlobalNews.Add(new GlobalNewsEntity
                    {
                        Comment = "Test",
                        ID = spItem["ID"].ToString(),
                        Title = spItem["Title"].ToString(),
                        Body = spItem["Body"].ToString(),
                        TimePublishedUnFormatted = Convert.ToDateTime(spItem["Created"])
                    });
                }
            }
            catch
            {                 
                //Log error
            }

            return AllGlobalNews;
        }

        /// <summary>
        /// Get the list item from the ID and transform to GlobalNewsEntity type
        /// </summary>
        /// <param name="spWeb">SPWeb object of the current site</param>
        /// <param name="listName">Name of the list used for Global News</param>
        /// <param name="itemId">ID of the new article item</param>
        /// <returns>Global News Entity object</returns>
        public GlobalNewsEntity GetNewsArticle(SPWeb spWeb, string listName, int itemId)
        {
            try
            {
                SPListItem newsArticleItem = spWeb.Lists[listName].GetItemById(itemId);
                return new GlobalNewsEntity
                {
                    ID = newsArticleItem["ID"].ToString(),
                    Title = newsArticleItem["Title"].ToString(),
                    Body = newsArticleItem["Body"].ToString(),
                    TimePublishedUnFormatted = Convert.ToDateTime(newsArticleItem["Created"])
                };
            }
            catch
            {
                //Log Error
                return null;
            }
        }

        /// <summary>
        /// Append comment to a new article
        /// </summary>
        /// <param name="spWeb">SPWeb object of the current site</param>
        /// <param name="listName">Name of the list used for Global News</param>
        /// <param name="itemId">ID of the news article item</param>
        /// <param name="comment">Comment Text</param>
        /// <param name="userName">User Name</param>
        /// <returns>True/False - success/failure</returns>
        public bool AddComment(SPWeb spWeb, string listName, int itemId, string comment, string userName)
        {
            try
            {
                SPList spList = spWeb.Lists[listName];
                SPListItem spListItem = spList.GetItemById(itemId);

                string body = spListItem["Body"].ToString() + "<hr style='width:100%' /><b>" + userName + "</b><i> on " + DateTime.Now.ToShortDateString() + "</i><br />" + comment + "";

                spWeb.AllowUnsafeUpdates = true;


                spListItem["Body"] = body;
                spListItem.Update();
                spList.Update();
            }
            catch
            {
                return false;
                //Log error
            }
            finally
            {
                spWeb.AllowUnsafeUpdates = false;
            }

            return true;
        }
    }
}
