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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/MailService/Contact.cshtml")]
    public partial class _Views_MailService_Contact_cshtml : System.Web.Mvc.WebViewPage<dynamic>
    {
        public _Views_MailService_Contact_cshtml()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" style=\"position: relative; margin-bottom: 20px; background-color: #ffffff; borde" +
"r-radius: 2px;\"");

WriteLiteral(">\r\n\r\n    <!-- header -->\r\n    <div");

WriteLiteral(@" style=""font-family: tahoma; font-size: 11px;position: relative; height: 40px; line-height: 36px; color: #ffffff; background-color: #37bc9b; border-color: #37bc9b; font-size: 13px; font-weight: 600; padding: 0 8px; border: 1px solid #e7e7e7; border-top-right-radius: 1px; border-top-left-radius: 1px;""");

WriteLiteral(">\r\n        <span");

WriteLiteral(" class=\"panel-title\"");

WriteLiteral("> پیام ارسالی از سایت</span>\r\n    </div>\r\n\r\n    <!-- info  -->\r\n    <div");

WriteLiteral(" style=\"position: relative; text-align: center; padding: 9px; color: #AAA; backgr" +
"ound-color: transparent; border-left: 2px dashed #d9d9d9; border-right: 2px dash" +
"ed #d9d9d9; border-bottom: 1px solid #ddd;padding: 12px 9px;\"");

WriteLiteral(">\r\n        <p");

WriteLiteral(" style=\"font-family: tahoma; font-size: 11px; overflow: auto;\"");

WriteLiteral(">\r\n            <span");

WriteLiteral(" style=\"float: right\"");

WriteLiteral(">نام: ");

            
            #line 11 "..\..\Views\MailService\Contact.cshtml"
                                       Write(ViewBag.Name);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            <span");

WriteLiteral(" style=\"direction:ltr; float: left\"");

WriteLiteral(">Email: ");

            
            #line 12 "..\..\Views\MailService\Contact.cshtml"
                                                       Write(ViewBag.Email);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n        </p>\r\n    </div>\r\n\r\n    <!-- body -->\r\n    <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(" style=\"background-color: #fafafa; border: 1px solid #e7e7e7; border-top: 0; posi" +
"tion: relative; padding: 15px; display: block;\"");

WriteLiteral(">\r\n        <p");

WriteLiteral(" style=\"font-family: tahoma; font-size: 11px\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 19 "..\..\Views\MailService\Contact.cshtml"
       Write(ViewBag.Message);

            
            #line default
            #line hidden
WriteLiteral("\r\n        </p>\r\n    </div>\r\n\r\n</div>\r\n\r\n");

        }
    }
}
#pragma warning restore 1591
