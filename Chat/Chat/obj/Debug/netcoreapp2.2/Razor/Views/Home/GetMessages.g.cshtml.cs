#pragma checksum "F:\Git\Chat\Chat\Chat\Views\Home\GetMessages.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "378974c22b07380fb795aa66192f850d79e7052f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_GetMessages), @"mvc.1.0.view", @"/Views/Home/GetMessages.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/GetMessages.cshtml", typeof(AspNetCore.Views_Home_GetMessages))]
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
#line 1 "F:\Git\Chat\Chat\Chat\Views\_ViewImports.cshtml"
using Chat;

#line default
#line hidden
#line 2 "F:\Git\Chat\Chat\Chat\Views\_ViewImports.cshtml"
using Chat.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"378974c22b07380fb795aa66192f850d79e7052f", @"/Views/Home/GetMessages.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae0d8c26f1bac4ebadd6a59a67055e7526028212", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_GetMessages : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Chat.Models.PrivateMessage>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 61, true);
            WriteLiteral("\r\n<div id=\"privateChatroom\" class=\"form-control\">\r\n    <ul>\r\n");
            EndContext();
#line 5 "F:\Git\Chat\Chat\Chat\Views\Home\GetMessages.cshtml"
         foreach(var mes in Model)
        {

#line default
#line hidden
            BeginContext(156, 19, true);
            WriteLiteral("            <li><b>");
            EndContext();
            BeginContext(176, 16, false);
#line 7 "F:\Git\Chat\Chat\Chat\Views\Home\GetMessages.cshtml"
              Write(mes.FromUserName);

#line default
#line hidden
            EndContext();
            BeginContext(192, 6, true);
            WriteLiteral(": </b>");
            EndContext();
            BeginContext(199, 8, false);
#line 7 "F:\Git\Chat\Chat\Chat\Views\Home\GetMessages.cshtml"
                                     Write(mes.Text);

#line default
#line hidden
            EndContext();
            BeginContext(207, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 8 "F:\Git\Chat\Chat\Chat\Views\Home\GetMessages.cshtml"
        }

#line default
#line hidden
            BeginContext(225, 17, true);
            WriteLiteral("    </ul>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Chat.Models.PrivateMessage>> Html { get; private set; }
    }
}
#pragma warning restore 1591
