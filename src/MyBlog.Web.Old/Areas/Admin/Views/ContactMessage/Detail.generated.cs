﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASP
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Optimization;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using MyBlog.Common.Extensions;
    using MyBlog.Common.Helpers;
    using MyBlog.Web;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Areas/Admin/Views/ContactMessage/Detail.cshtml")]
    public partial class _Areas_Admin_Views_ContactMessage_Detail_cshtml : System.Web.Mvc.WebViewPage<MyBlog.Domain.ContactMessageEntity>
    {
        public _Areas_Admin_Views_ContactMessage_Detail_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Areas\Admin\Views\ContactMessage\Detail.cshtml"
  
    ViewBag.Title = "پیام";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n\r\n");

DefineSection("ContentHeader", () => {

WriteLiteral("\r\n");

});

WriteLiteral("\r\n<div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"box box-success\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"box-header\"");

WriteLiteral(">\r\n            <i");

WriteLiteral(" class=\"fa fa-comment-o\"");

WriteLiteral("></i>\r\n            <small");

WriteLiteral(" class=\"text-muted pull-left\"");

WriteLiteral(" style=\"padding: 12px 10px;\"");

WriteLiteral("><i");

WriteLiteral(" class=\"fa fa-clock-o\"");

WriteLiteral("></i> ");

            
            #line 15 "..\..\Areas\Admin\Views\ContactMessage\Detail.cshtml"
                                                                                                     Write(Model.CreateDate.TimeAgo());

            
            #line default
            #line hidden
WriteLiteral("</small>\r\n            <h3");

WriteLiteral(" class=\"box-title\"");

WriteLiteral(">پیام</h3>\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"box-body chat\"");

WriteLiteral(" id=\"chat-box\"");

WriteLiteral(">\r\n            <!-- chat item -->\r\n            <div");

WriteLiteral(" class=\"item\"");

WriteLiteral(" style=\"display: inline-block\"");

WriteLiteral(">\r\n                <p");

WriteLiteral(" class=\"message\"");

WriteLiteral(" style=\"margin: 0\"");

WriteLiteral(">\r\n                    <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"name\"");

WriteLiteral(" style=\"margin-bottom: 5px\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

            
            #line 23 "..\..\Areas\Admin\Views\ContactMessage\Detail.cshtml"
                   Write(Model.Name);

            
            #line default
            #line hidden
WriteLiteral(" - ");

            
            #line 23 "..\..\Areas\Admin\Views\ContactMessage\Detail.cshtml"
                                 Write(Model.Email);

            
            #line default
            #line hidden
WriteLiteral("\r\n                    </a>\r\n");

WriteLiteral("                    ");

            
            #line 25 "..\..\Areas\Admin\Views\ContactMessage\Detail.cshtml"
               Write(Model.Message);

            
            #line default
            #line hidden
WriteLiteral("\r\n                </p>\r\n            </div><!-- /.item -->\r\n        </div><!-- /.c" +
"hat -->\r\n        <div");

WriteLiteral(" class=\"box-footer\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"input-group\"");

WriteLiteral(">\r\n                ");

WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    \r\n    <div>\r\n");

WriteLiteral("        ");

            
            #line 40 "..\..\Areas\Admin\Views\ContactMessage\Detail.cshtml"
   Write(Html.ActionLink("بازگشت به لیست", "Index"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591