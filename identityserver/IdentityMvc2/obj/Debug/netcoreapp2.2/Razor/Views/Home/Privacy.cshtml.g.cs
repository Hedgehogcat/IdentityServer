#pragma checksum "C:\Users\LCB\source\repos\IdentityMvc2\Views\Home\Privacy.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce64d3bc24f0627153f294086311d076445179de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Privacy), @"mvc.1.0.view", @"/Views/Home/Privacy.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Privacy.cshtml", typeof(AspNetCore.Views_Home_Privacy))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\LCB\source\repos\IdentityMvc2\Views\_ViewImports.cshtml"
using IdentityMvc2;

#line default
#line hidden
#line 2 "C:\Users\LCB\source\repos\IdentityMvc2\Views\_ViewImports.cshtml"
using IdentityMvc2.Models;

#line default
#line hidden
#line 4 "C:\Users\LCB\source\repos\IdentityMvc2\Views\Home\Privacy.cshtml"
using Microsoft.AspNetCore.Authentication;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce64d3bc24f0627153f294086311d076445179de", @"/Views/Home/Privacy.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"193a4e8726b0951a58f9d5769bc6f73e48abc201", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Privacy : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\LCB\source\repos\IdentityMvc2\Views\Home\Privacy.cshtml"
  
    ViewData["Title"] = "Privacy Policy";

#line default
#line hidden
            BeginContext(94, 48, true);
            WriteLiteral("<div>\r\n    <strong>id_token</strong>\r\n    <span>");
            EndContext();
            BeginContext(143, 55, false);
#line 7 "C:\Users\LCB\source\repos\IdentityMvc2\Views\Home\Privacy.cshtml"
     Write(await ViewContext.HttpContext.GetTokenAsync("id_token"));

#line default
#line hidden
            EndContext();
            BeginContext(198, 69, true);
            WriteLiteral("</span>\r\n</div>\r\n<div>\r\n    <strong>access_token</strong>\r\n    <span>");
            EndContext();
            BeginContext(268, 59, false);
#line 11 "C:\Users\LCB\source\repos\IdentityMvc2\Views\Home\Privacy.cshtml"
     Write(await ViewContext.HttpContext.GetTokenAsync("access_token"));

#line default
#line hidden
            EndContext();
            BeginContext(327, 70, true);
            WriteLiteral("</span>\r\n</div>\r\n<div>\r\n    <strong>refresh_token</strong>\r\n    <span>");
            EndContext();
            BeginContext(398, 60, false);
#line 15 "C:\Users\LCB\source\repos\IdentityMvc2\Views\Home\Privacy.cshtml"
     Write(await ViewContext.HttpContext.GetTokenAsync("refresh_token"));

#line default
#line hidden
            EndContext();
            BeginContext(458, 21, true);
            WriteLiteral("</span>\r\n</div>\r\n<h1>");
            EndContext();
            BeginContext(480, 17, false);
#line 17 "C:\Users\LCB\source\repos\IdentityMvc2\Views\Home\Privacy.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(497, 75, true);
            WriteLiteral("</h1>\r\n\r\n<p>Use this page to detail your site\'s privacy policy.</p>\r\n<dl>\r\n");
            EndContext();
#line 21 "C:\Users\LCB\source\repos\IdentityMvc2\Views\Home\Privacy.cshtml"
     foreach (var claim in User.Claims)
    {

#line default
#line hidden
            BeginContext(620, 12, true);
            WriteLiteral("        <dt>");
            EndContext();
            BeginContext(633, 10, false);
#line 23 "C:\Users\LCB\source\repos\IdentityMvc2\Views\Home\Privacy.cshtml"
       Write(claim.Type);

#line default
#line hidden
            EndContext();
            BeginContext(643, 19, true);
            WriteLiteral("</dt>\r\n        <dd>");
            EndContext();
            BeginContext(663, 11, false);
#line 24 "C:\Users\LCB\source\repos\IdentityMvc2\Views\Home\Privacy.cshtml"
       Write(claim.Value);

#line default
#line hidden
            EndContext();
            BeginContext(674, 7, true);
            WriteLiteral("</dd>\r\n");
            EndContext();
#line 25 "C:\Users\LCB\source\repos\IdentityMvc2\Views\Home\Privacy.cshtml"
    }

#line default
#line hidden
            BeginContext(688, 5, true);
            WriteLiteral("</dl>");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591