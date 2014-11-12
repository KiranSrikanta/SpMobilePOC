<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlogView.aspx.cs" Inherits="McMobileSolution.Layouts.McMobileSolution.BlogView" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>

<html dir="ltr" xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta name="WebPartPageExpansion" content="full" />
    <title>Blog</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="/_layouts/McMobileSolution/jQueryMobile/jquery.mobile-1.3.2.min.css" />
    <script type="text/javascript" src="/_layouts/McMobileSolution/jQueryMobile/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="/_layouts/McMobileSolution/jQueryMobile/jquery.mobile-1.3.2.min.js"></script>
</head>
<body>
<%--Page --%>
<div data-role="page">
    <div data-role="header">
        <a onclick="$.mobile.changePage( '/_layouts/McMobileSolution/Blogs.aspx', { transition: 'slide', reverse: true });" data-role="button" data-mini="true" data-inline="true" data-icon="arrow-l" data-theme="a">Blogs</a>
        <h1>Blog</h1>
    </div>

    <div data-role="content">
    <h2><asp:Label ID="lblTitle" runat="server"></asp:Label></h2>
    <strong><asp:Label ID="lblAuthor" runat="server"></asp:Label></strong><em> on <asp:Label ID="lblBlogCreatedOn" runat="server"></asp:Label></em>
    <p><asp:Literal ID="lBody" runat="server"></asp:Literal></p>
    <hr style="width:100%" />
    <asp:ListView ID="lvReplies" runat="server">
        <LayoutTemplate>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate>
            <div>
                <strong><asp:Label ID="lblReplyAuthor" runat="server" Text='<%#Eval("Author") %>'></asp:Label></strong><em> on <asp:Label ID="lblReplyCreatedOn" runat="server" Text='<%#Eval("ModifiedDate") %>'></asp:Label></em>
                <%#Eval("ReplyBody") %>
                <a onclick="SlideToURL('/_layouts/McMobileSolution/BlogViewReply.aspx?BlogID=<%#Eval("ID") %>&Source=')" data-role="button" data-inline="true" data-mini="true">View/Reply</a>
            </div>
            <hr style="width:100%" />
        </ItemTemplate>
    </asp:ListView>
    </div>

    <script type="text/javascript">
        function SlideToURL(URL) {
            debugger;
            URL = URL + getQuerystring("BlogID");
            $.mobile.changePage(URL, { transition: 'slide' });
        }

        function getQuerystring(QID) {
            // Fetch the query string.
            var QStringOriginal = window.location.search.substring(1);

            // Change the case as querystring id values normally case insensitive.
            QString = QStringOriginal.toLowerCase();
            var qsValue = '';

            // QueryString ID.
            QID = QID.toLowerCase();
            // Start & end point of the QueryString Value.
            var qsStartPoint = QString.indexOf(QID);
            if (qsStartPoint != -1) {
                qsValue = QStringOriginal.substring(qsStartPoint + QID.length + 1);
                // Search for '&' in the query string;
                var qsEndPoint = qsValue.indexOf('&');
                if (qsEndPoint != -1) {
                    // retrive the QueryString value & Return it.
                    qsValue = qsValue.substring(0, qsEndPoint);
                }
                else if (qsValue.indexOf('#') != -1) {
                    // Search for '#' in the query string;
                    qsEndPoint = qsValue.indexOf('&');
                    // retrive the QueryString value & Return it.
                    qsValue = qsValue.substring(0, qsEndPoint);
                }
                else {
                    qsValue = qsValue.substring(0);
                }
            }
            return qsValue;
        }
    </script>
</div>
</body>
</html>
