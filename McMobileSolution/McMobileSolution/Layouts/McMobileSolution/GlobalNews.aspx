<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GlobalNews.aspx.cs" Inherits="McMobileSolution.Layouts.McMobileSolution.GlobalNews" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>

<html dir="ltr" xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta name="WebPartPageExpansion" content="full" />
    <title>Global News</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="/_layouts/McMobileSolution/jQueryMobile/jquery.mobile-1.3.2.min.css" />
    <script type="text/javascript" src="/_layouts/McMobileSolution/jQueryMobile/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="/_layouts/McMobileSolution/jQueryMobile/jquery.mobile-1.3.2.min.js"></script>
</head>
<body>
<%--Page --%>
<div data-role="page">

<%--Page Header--%>
<div data-role="header">
    <a onclick="$.mobile.changePage( '/_layouts/McMobileSolution/MobileHome.aspx', { transition: 'flip', reverse: true });" data-role="button" data-mini="true" data-inline="true" data-icon="home" data-theme="a">Home</a>
    <h1>Global News</h1>
</div>

<%--List of New Article Titles--%>
<asp:ListView runat="server" ID="ltGlobalNews">
    <LayoutTemplate>
        <ul data-role="listview">
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
        </ul>
    </LayoutTemplate>
    <ItemTemplate>
    <li>
        <a onclick="SlideToURL('/_layouts/McMobileSolution/NewsArticle.aspx?ArticleID=<%#Eval("ID") %>')" data-rel="popup" data-position-to="window" data-transition="pop">
            <h2><%#Eval("Title") %></h2>
            <p><%#Eval("Preview") %></p>
            <p class="ui-li-aside"><%#Eval("TimePublished") %></p>
        </a>
    </li>
    </ItemTemplate>
</asp:ListView>
<script type="text/javascript">
        function SlideToURL(URL) {
            debugger;
            $.mobile.changePage(URL, { transition: 'slide' });
        }
</script>

</div>
</body>
</html>
