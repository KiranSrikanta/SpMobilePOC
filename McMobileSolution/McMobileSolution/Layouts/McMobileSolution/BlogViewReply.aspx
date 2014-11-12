<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BlogViewReply.aspx.cs" Inherits="McMobileSolution.Layouts.McMobileSolution.BlogViewReply" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>

<html dir="ltr" xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta name="WebPartPageExpansion" content="full" />
    <title>Reply</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="/_layouts/McMobileSolution/jQueryMobile/jquery.mobile-1.3.2.min.css" />
    <script type="text/javascript" src="/_layouts/McMobileSolution/jQueryMobile/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="/_layouts/McMobileSolution/jQueryMobile/jquery.mobile-1.3.2.min.js"></script>
</head>
<body>
<%--Page --%>
<div data-role="page">
    <div data-role="header">
        <a onclick="GoToBlogPage();" data-role="button" data-mini="true" data-inline="true" data-icon="arrow-l" data-theme="a">Blog</a>
        <h1>Blogs</h1>
    </div>
    <div data-role="content">
        <form runat="server">
            <asp:TextBox ID="txtReply" runat="server" TextMode="MultiLine"></asp:TextBox>
            <asp:Button runat="server"  ID="lbtnAddReply" Text="Post Reply" data-inline="true" data-mini="true" OnClick="lbtnAddReply_Click" />
            <hr style="width:100%" />
            <strong><asp:Label ID="lblReplyAuthor" runat="server"></asp:Label></strong><em> on <asp:Label ID="lblReplyCreatedOn" runat="server"></asp:Label></em>
            <p><asp:Literal ID="lblFullBody" runat="server"></asp:Literal></p>
            <asp:HiddenField ID="hfGoBack" runat="server" />
        </form>
    </div>

    <script type="text/javascript">
        setTimeout(function () {
            var commentAddedString = $("input[name*='hfGoBack']").val();
            if (commentAddedString.indexOf("True") > -1) {
                debugger;
                $.mobile.changePage("/_layouts/McMobileSolution/BlogView.aspx?BlogID=" + getQuerystring("Source"), {
                    transition: "slide",
                    reverse: true
                });
            }
        }, 1000);

        function GoToBlogPage() {
            $.mobile.changePage("/_layouts/McMobileSolution/BlogView.aspx?BlogID=" + getQuerystring("Source"), {
                transition: "slide",
                reverse: true
            });
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