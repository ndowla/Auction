#pragma checksum "C:\Users\ndowla\source\repos\Auction\Auction.Web\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "83909eccb025f4c7903c910400ed5eb39dd4b267"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "C:\Users\ndowla\source\repos\Auction\Auction.Web\Views\_ViewImports.cshtml"
using Auction;

#line default
#line hidden
#line 2 "C:\Users\ndowla\source\repos\Auction\Auction.Web\Views\_ViewImports.cshtml"
using Auction.Models;

#line default
#line hidden
#line 1 "C:\Users\ndowla\source\repos\Auction\Auction.Web\Views\Home\Index.cshtml"
using Auction.Service.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83909eccb025f4c7903c910400ed5eb39dd4b267", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d48aafa155944a2cbfa352e55b0966fdaeaa49ac", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ProductBidViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(67, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\ndowla\source\repos\Auction\Auction.Web\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(114, 138, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    <div class=\"col-md-12\">\r\n        <h2>Auction Site</h2>\r\n        <h3>Featured Items</h3>\r\n        <br />\r\n        ");
            EndContext();
            BeginContext(253, 64, false);
#line 14 "C:\Users\ndowla\source\repos\Auction\Auction.Web\Views\Home\Index.cshtml"
   Write(await Html.PartialAsync("../Product/_ProductList.cshtml", Model));

#line default
#line hidden
            EndContext();
            BeginContext(317, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ProductBidViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591