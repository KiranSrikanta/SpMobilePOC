using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using McMobileEntity;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;

namespace McMobileRepository
{
    public class BlogRepository
    {
        /// <summary>
        /// Convert all discussion board folder items and transform to BlogEntity type
        /// </summary>
        /// <param name="spWeb">SPWeb object of the current site</param>
        /// <param name="listName">Name of the list used for Blog</param>
        /// <returns>List of Blog Entity objects</returns>
        public List<BlogEntity> GetAllBlogTitle(SPWeb spWeb, string listName)
        {

            List<BlogEntity> blogTitles = new List<BlogEntity>();
            try
            {
                foreach (SPListItem spfolderItem in spWeb.Lists[listName].Folders)
                {
                    blogTitles.Add(new BlogEntity
                    {
                        Title = spfolderItem["Name"].ToString(),
                        ID = spfolderItem.ID.ToString()
                    });
                }
            }
            catch
            {
                //Log Error
            }

            return blogTitles;
        }

        /// <summary>
        /// Convert a discussion board folder item and transform it to the BlogEntity type
        /// </summary>
        /// <param name="spWeb">SPWeb object of the current site</param>
        /// <param name="listName">Name of the list used for Blog</param>
        /// <param name="listItemID">ID of the discussion board folder item</param>
        /// <returns>Blog Entity object</returns>
        public BlogEntity GetBlogData(SPWeb spWeb, string listName, int listItemID)
        {
            try
            {
                SPListItem spBlogItem = spWeb.Lists[listName].GetItemById(listItemID);
                BlogEntity blogData = new BlogEntity();
                blogData.Title = spBlogItem.Name;
                blogData.Body = spBlogItem["Body"].ToString();
                blogData.Author = spBlogItem["Author"].ToString().Split('#')[1];
                blogData.ModifiedDate = Convert.ToDateTime(spBlogItem["Modified"]);
                return blogData;
            }
            catch
            {
                //Log Error
                return null;
            }
        }

        /// <summary>
        /// Get all replies for a discussion
        /// </summary>
        /// <param name="spWeb">SPWeb object of the current site</param>
        /// <param name="listName">Name of the list used for Blog</param>
        /// <param name="listItemID">ID of the discussion board folder item</param>
        /// <returns>List of Blog Reply Entity objects</returns>
        public List<BlogReply> GetBlogReplies(SPWeb spWeb, string listName, int listItemID)
        {
            List<BlogReply> replies = new List<BlogReply>();

            try
            {
                SPList spBlogList = spWeb.Lists[listName];
                SPQuery query = new SPQuery();
                query.Folder = spBlogList.GetItemById(listItemID).Folder;
                foreach (SPListItem reply in spBlogList.GetItems(query))
                {
                    replies.Add(new BlogReply
                    {
                        Author = reply["Author"].ToString().Split('#')[1],
                        ID = reply["ID"].ToString(),
                        ModifiedDate = Convert.ToDateTime(reply["Modified"]),
                        ReplyBody = reply["Trimmed Body"].ToString(),
                        FullBody = reply["Body"].ToString()
                    });
                }
            }
            catch
            {
                //Log Error
                return null;
            }

            return replies.OrderByDescending(x => x.ModifiedDate).ToList();
        }

        /// <summary>
        /// Convert a discussion board reply item and transform it to the Blog Reply Entity type
        /// </summary>
        /// <param name="spWeb">SPWeb object of the current site</param>
        /// <param name="listName">Name of the list used for Blog</param>
        /// <param name="listItemID">ID of the discussion board reply item</param>
        /// <returns>Blog Reply Entity object</returns>
        public BlogReply GetBlogReply(SPWeb spWeb, string listName, int listItemID)
        {
            try
            {
                SPListItem replyItem = spWeb.Lists[listName].GetItemById(listItemID);
                return new BlogReply
                    {
                        Author = replyItem["Author"].ToString().Split('#')[1],
                        ID = replyItem["ID"].ToString(),
                        ModifiedDate = Convert.ToDateTime(replyItem["Modified"]),
                        ReplyBody = replyItem["Trimmed Body"].ToString(),
                        FullBody = replyItem["Body"].ToString()
                    };
            }
            catch
            {
                //Log Error
                return null;
            }
        }

        /// <summary>
        /// Add a reply to a discussion
        /// </summary>
        /// <param name="spWeb">SPWeb object of the current site</param>
        /// <param name="listName">Name of the list used for Blogs</param>
        /// <param name="itemId">ID of the discussion board folder item</param>
        /// <param name="reply">Reply text</param>
        /// <returns>True/False - success/failure</returns>
        public bool AddReply(SPWeb spWeb, string listName, int listItemID, string reply)
        {
            try
            {
                SPList spBlogList = spWeb.Lists[listName];
                SPListItem parentItem = spBlogList.GetItemById(listItemID);
                SPListItem replyItem = SPUtility.CreateNewDiscussionReply(spBlogList.GetItemById(listItemID));
                replyItem["Body"] = reply + @"<br><br><hr class='ms-disc-quotedtext'>
                                            <b>From: </b>" + parentItem["Author"].ToString().Split('#')[1] + @"<br>
                                            <b>Posted: </b>" + Convert.ToDateTime(parentItem["Modified"]).ToString("dd/MM/yyyy hh:mm tt") + @"<br>
                                            <b>Subject: </b>" + spBlogList.GetItemById(Convert.ToInt32(parentItem["Parent Folder Id"]))["Title"] + "<br><div class=\"ExternalClassFCEE674F82B64F1B820CDB6B8494598F\"><p>&nbsp;</p>"
                    + parentItem["Body"].ToString();
                replyItem["Trimmed Body"] = reply;

                spWeb.AllowUnsafeUpdates = true;

                replyItem.Update();
                spBlogList.Update();
            }
            catch
            {
                //error handeling
                return false;
            }
            finally
            {
                spWeb.AllowUnsafeUpdates = false;
            }
            return true;
        }
    }
}
