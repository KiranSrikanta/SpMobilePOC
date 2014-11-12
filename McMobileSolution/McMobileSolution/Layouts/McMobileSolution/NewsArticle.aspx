<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsArticle.aspx.cs" Inherits="McMobileSolution.Layouts.McMobileSolution.NewsArticle" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>

<html dir="ltr" xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta name="WebPartPageExpansion" content="full" />
    <title>Article</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="/_layouts/McMobileSolution/jQueryMobile/jquery.mobile-1.3.2.min.css" />
    <script type="text/javascript" src="/_layouts/McMobileSolution/jQueryMobile/jquery-1.9.1.min.js"></script>
    <script type="text/javascript">
        $(document).bind("mobileinit", function () {
            $.mobile.ajaxEnabled = false;
        });
    </script>
    <script type="text/javascript" src="/_layouts/McMobileSolution/jQueryMobile/jquery.mobile-1.3.2.min.js"></script>
</head>
<body>
<%--Page--%>
<div data-role="page" id="jQueryMobilePage">

<%--Page Header--%>
<div data-role="header">
    <a onclick="$.mobile.changePage( '/_layouts/McMobileSolution/GlobalNews.aspx', { transition: 'slide', reverse: true });" data-role="button" data-mini="true" data-inline="true" data-icon="arrow-l" data-theme="a">News</a>
    <h1>Article</h1>
</div>

<div data-role="content">
    <p class="ui-li-aside"><asp:Label ID="lblTimeStamp" runat="server"></asp:Label></p>
    <h2><asp:Label id="lblTitle" runat="server"></asp:Label></h2>
    <asp:Literal ID="lBody" runat="server"></asp:Literal>
    <hr style="width:100%" />
    <form runat="server">
    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" cols="40" rows="8" name="textarea"></asp:TextBox>
    <asp:Button runat="server" ID="btnAddComment" Text="Add Comment" data-role="button" data-inline="true" OnClick="btnAddComment_Click" />
    <asp:HiddenField ID="hfScrollDown" runat="server" />
    </form>
</div>
    <script type="text/javascript">
        $(document).ready(function () {
            setTimeout(function () {
                var commentAddedString = $("input[name*='hfScrollDown']").val();
                if (commentAddedString.indexOf("True") > -1) {
                    $.mobile.silentScroll($(document).height());
                }
            }, 1000);
        });
    </script>
</div>
</body>
</html>
