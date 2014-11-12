<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MobileHome.aspx.cs" Inherits="McMobileSolution.Layouts.McMobileSolution.MobileHome" %>

<html dir="ltr" xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta name="WebPartPageExpansion" content="full" />
    <title>Home</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="/_layouts/McMobileSolution/jQueryMobile/jquery.mobile-1.3.2.min.css" />
    <script type="text/javascript" src="/_layouts/McMobileSolution/jQueryMobile/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="/_layouts/McMobileSolution/jQueryMobile/jquery.mobile-1.3.2.min.js"></script>
    <style type="text/css"> 
      html, body {
      /* get rid of default spacing on the edges */
      margin: 0;
      padding: 0;
 
      /* get rid of that 2px window border in Internet Explorer 6 */
      border: 0;
 
      /* fill the height of the browser */
      height: 100%;
 
      /* no more scroll bar */
      overflow: hidden;
    }
    </style>
</head>
<body style="height:100%">
<div data-role="page" style="height:100%;width:100%"></div>
<table style="width:100%;height:100%">
<tr><td valign="middle" style="height:100%;width:100%">
    <%--Responsive Grid--%>
    <div class="ui-grid-a ui-responsive" style="vertical-align:middle">
        <%--Grid Cell--%>
        <div class="ui-block-a">
            <div class="ui-bar" style="text-align:center;BACKGROUND-COLOR: #ffe6d5" onmouseup="this.style.backgroundColor='#FFE6D5'" onmouseout="this.style.backgroundColor='#FFE6D5'" onmousedown="this.style.backgroundColor='#EFD6C5'" onclick="$.mobile.changePage( '/_layouts/McMobileSolution/Blogs.aspx', { transition: 'flip' });">
                <div style="margin:15px">
                    <img src="/_layouts/McMobileSolution/jQueryMobile/images/BlogTransperent.gif" alt="Blog" style="height:100px;width:100px" /><br />
                    <span style="color: #ff8f45;font-family:Verdana;font-size:x-large">Blog</span>
                </div>
            </div>
        </div>
        <%--Grid Cell--%>
        <div class="ui-block-b">
            <div class="ui-bar" style="text-align:center;BACKGROUND-COLOR: #c7dcf1" onmouseup="this.style.backgroundColor='#c7dcf1'" onmouseout="this.style.backgroundColor='#c7dcf1'" onmousedown="this.style.backgroundColor='#b7cce1'" onclick="$.mobile.changePage( '/_layouts/McMobileSolution/GlobalNews.aspx', { transition: 'flip' });">
                <div style="margin:15px">
                    <img src="/_layouts/McMobileSolution/jQueryMobile/images/NewsTransparent.gif" alt="Global News" style="height:100px;width:100px" /><br />
                    <span style="color: #336080;font-family:Verdana;font-size:x-large">Global News</span>
                </div>
            </div>
        </div>
    </div>
</td></tr>
</table>
</body>
</html>
