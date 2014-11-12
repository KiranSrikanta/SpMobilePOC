using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace McMobileEntity
{
    public class GlobalNewsEntity
    {
        #region privateData
        private string id;
        private string title;
        private string body;
        private DateTime timePublished;
        private const int previewLength = 200;
        private string comment;
        #endregion

        /// <summary>
        /// SharePoint ListItem ID
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// News article title
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        /// <summary>
        /// New article content
        /// </summary>
        public string Body
        {
            get { return body; }
            set { body = value; }
        }

        /// <summary>
        /// Shows 200 Charecters of Body without any HTML formatting. Read Only.
        /// </summary>
        public string Preview
        {
            get
            {
                string plainText = Regex.Replace(Body, @"<[^>]*>", "").Trim();
                if (plainText.Length > previewLength) return (plainText.Substring(0, previewLength - 1) + "...");
                else return plainText + "...";
            }
        }

        /// <summary>
        /// News Article Date.
        /// </summary>
        public DateTime TimePublishedUnFormatted
        {
            get { return timePublished; }
            set { timePublished = value; }
        }

        /// <summary>
        /// Formatted News Article Date, Read Only.
        /// </summary>
        public string TimePublished
        {
            get { return TimePublishedUnFormatted.ToShortDateString(); }
        }

        /// <summary>
        /// User input comment
        /// </summary>
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
    }
}
