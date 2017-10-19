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
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Manage/SetPassword.cshtml")]
    public partial class _Views_Manage_SetPassword_cshtml : System.Web.Mvc.WebViewPage<MyBlog.Web.Models.SetPasswordViewModel>
    {
        public _Views_Manage_SetPassword_cshtml()
        {
        }
        public override void Execute()
        {
            
            #line 2 "..\..\Views\Manage\SetPassword.cshtml"
  
    ViewBag.Title = "Create Password";

            
            #line default
            #line hidden
WriteLiteral("\r\n\r\n<h2>");

            
            #line 6 "..\..\Views\Manage\SetPassword.cshtml"
Write(ViewBag.Title);

            
            #line default
            #line hidden
WriteLiteral(".</h2>\r\n<p");

WriteLiteral(" class=\"text-info\"");

WriteLiteral(">\r\n    You do not have a local username/password for this site. Add a local\r\n    " +
"account so you can log in without an external login.\r\n</p>\r\n\r\n");

            
            #line 12 "..\..\Views\Manage\SetPassword.cshtml"
 using (Html.BeginForm("SetPassword", "Manage", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
{
    
            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Manage\SetPassword.cshtml"
Write(Html.AntiForgeryToken());

            
            #line default
            #line hidden
            
            #line 14 "..\..\Views\Manage\SetPassword.cshtml"
                            


            
            #line default
            #line hidden
WriteLiteral("    <h4>Create Local Login</h4>\r\n");

WriteLiteral("    <hr />\r\n");

            
            #line 18 "..\..\Views\Manage\SetPassword.cshtml"
    
            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Manage\SetPassword.cshtml"
Write(Html.ValidationSummary("", new { @class = "text-danger" }));

            
            #line default
            #line hidden
            
            #line 18 "..\..\Views\Manage\SetPassword.cshtml"
                                                               

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 20 "..\..\Views\Manage\SetPassword.cshtml"
   Write(Html.LabelFor(m => m.NewPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 22 "..\..\Views\Manage\SetPassword.cshtml"
       Write(Html.PasswordFor(m => m.NewPassword, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

            
            #line 26 "..\..\Views\Manage\SetPassword.cshtml"
   Write(Html.LabelFor(m => m.ConfirmPassword, new { @class = "col-md-2 control-label" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        <div");

WriteLiteral(" class=\"col-md-10\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 28 "..\..\Views\Manage\SetPassword.cshtml"
       Write(Html.PasswordFor(m => m.ConfirmPassword, new { @class = "form-control" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n        </div>\r\n    </div>\r\n");

WriteLiteral("    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-md-offset-2 col-md-10\"");

WriteLiteral(">\r\n            <input");

WriteLiteral(" type=\"submit\"");

WriteLiteral(" value=\"Set password\"");

WriteLiteral(" class=\"btn btn-default\"");

WriteLiteral(" />\r\n        </div>\r\n    </div>\r\n");

            
            #line 36 "..\..\Views\Manage\SetPassword.cshtml"
}

            
            #line default
            #line hidden
DefineSection("Scripts", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

            
            #line 38 "..\..\Views\Manage\SetPassword.cshtml"
Write(Scripts.Render("~/bundles/jqueryval"));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

});

        }
    }
}
#pragma warning restore 1591
