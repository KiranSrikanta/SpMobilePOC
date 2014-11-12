using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McMobileEntity
{
    public class BlogEntity
    {
        #region private variables
        private string title;
        private string id;
        private string body;
        private string author;
        private DateTime modifiedDate;
        #endregion

        /// <summary>
        /// Blog last modification date
        /// </summary>
        public DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }

        /// <summary>
        /// Blog creator
        /// </summary>
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        /// <summary>
        /// Entire body of the blog
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        /// <summary>
        /// Blog Sharepoint list item body
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Blog Title
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }

    public class BlogReply
    {
        #region private variables
        private string title;
        private string id;
        private string replyBody;
        private string author;
        private DateTime modifiedDate;
        private string fullBody;
        #endregion

        /// <summary>
        /// Entire mail chain text
        /// </summary>
        public string FullBody
        {
            get { return fullBody; }
            set { fullBody = value; }
        }

        /// <summary>
        /// Reply Date
        /// </summary>
        public DateTime ModifiedDate
        {
            get { return modifiedDate; }
            set { modifiedDate = value; }
        }

        /// <summary>
        /// Creator of the reply
        /// </summary>
        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        /// <summary>
        /// The newly added text in the reply
        /// </summary>
        public string ReplyBody
        {
            get { return replyBody; }
            set { replyBody = value; }
        }

        /// <summary>
        /// Reply list item ID
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Blog Title
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}
