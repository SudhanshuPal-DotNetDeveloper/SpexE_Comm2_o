#pragma checksum "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2442b29ad194dc9fc82a184793155e95f50851d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#nullable restore
#line 1 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\_ViewImports.cshtml"
using SpexE_Comm.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\_ViewImports.cshtml"
using SpexE_Comm.Admin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d2442b29ad194dc9fc82a184793155e95f50851d", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"81bcb72c38c407a443cfa1f3c4b9cb8ed76c4286", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SpexE_Comm.Data.Data.Products>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-warning bold-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>



:root {
    --font1: 'Heebo', sans-serif;
    --font2: 'Fira Sans Extra Condensed', sans-serif;
    --font3: 'Roboto', sans-serif;

    --btnbg: #ffcc00;
    --btnfontcolor: rgb(61, 61, 61);
    --btnfontcolorhover: rgb(255, 255, 255);
    --btnbghover: #ffc116;
    --btnactivefs: rgb(241, 195, 46);


    --label-index: #960796;
    --danger-index: #5bc257;
/* PAGINATE */
    --link-color: #000;
    --link-color-hover: #fff;
    --bg-content-color: #ffcc00;

}

.container-fluid {
    max-width: 1400px;

}

.card {
    background: #fff;
    box-shadow: 0 6px 10px rgba(0, 0, 0, .08), 0 0 6px rgba(0, 0, 0, .05);
    transition: .3s transform cubic-bezier(.155, 1.105, .295, 1.12), .3s box-shadow, .3s -webkit-transform cubic-bezier(.155, 1.105, .295, 1.12);
    border: 0;
    border-radius: 1rem;
}

.card-img,
.card-img-top {
    border-top-left-radius: calc(1rem - 1px);
    border-top-right-radius: calc(1rem - 1px);
}


.card h5 {
    overflow: hidden;
 ");
            WriteLiteral(@"   font-weight: 300;
}


.card-img-top {
    width: 100%;
    min-height: 250px;
    max-height: 250px;
    object-fit: contain;
    padding: 30px;
}

.card h2 {
    font-size: 1rem;
}


.card:hover {
    transform: scale(1.02);
    box-shadow: 0 10px 20px rgba(0, 0, 0, .12), 0 4px 8px rgba(0, 0, 0, .06);
}

/* Centered text */
.label-top {
    position: absolute;
    background-color: var(--label-index);
    color: #fff;
    top: 8px;
    right: 8px;
    padding: 5px 10px 5px 10px;
    font-size: .7rem;
    font-weight: 600;
    border-radius: 3px;
    text-transform: uppercase;
}

.top-right {
    position: absolute;
    top: 24px;
    left: 24px;

    width: 90px;
    height: 90px;
    border-radius: 50%;
    font-size: 1rem;
    font-weight: 900;
    background: #8bc34a;
    line-height: 90px;
    text-align: center;
    color: white;
}

.top-right span {
    display: inline-block;
    vertical-align: middle;
    /* line-height: normal; */
    /* pad");
            WriteLiteral(@"ding: 0 25px; */
}

.aff-link {
    /* text-decoration: overline; */
    font-weight: 500;
}

.over-bg {
    background: rgba(53, 53, 53, 0.85);
    box-shadow: 0 8px 32px 0 rgba(31, 38, 135, 0.37);
    backdrop-filter: blur(0.0px);
    -webkit-backdrop-filter: blur(0.0px);
    border-radius: 10px;
}
.bold-btn {

    font-size: 1rem;
    font-weight: 500;
    text-transform: uppercase;
    padding: 5px 50px 5px 50px;
}
.box .btn {
    font-size: 1.5rem;
}

");
            WriteLiteral("@media (max-width: 1025px) {\r\n    .btn {\r\n        padding: 5px 40px 5px 40px;\r\n    }\r\n}\r\n");
            WriteLiteral(@"@media (max-width: 250px) {
    .btn {
        padding: 5px 30px 5px 30px;
    }
}

/* START BUTTON */
.btn-warning {
    background: var(--btnbg);
    color: var(--btnfontcolor);
    fill: #ffffff;
    border: none;
    text-decoration: none;
    outline: 0;
    /* box-shadow: -1px 6px 19px rgba(247, 129, 10, 0.25); */
    border-radius: 100px;
}
.btn-warning:hover {
    background: var(--btnbghover);
    color: var(--btnfontcolorhover);
    /* box-shadow: -1px 6px 13px rgba(255, 150, 43, 0.35); */
}
.btn-check:focus + .btn-warning, .btn-warning:focus {
    background: var(--btnbghover);
    color: var(--btnfontcolorhover);
    /* box-shadow: -1px 6px 13px rgba(255, 150, 43, 0.35); */
}
.btn-warning:active:focus {
    box-shadow: 0 0 0 0.25rem var(--btnactivefs);
}
.btn-warning:active {
    background: var(--btnbghover);
    color: var(--btnfontcolorhover);
    /* box-shadow: -1px 6px 13px rgba(255, 150, 43, 0.35); */
}

/* END BUTTON */

.bg-success {
    font-size: 1r");
            WriteLiteral(@"em;
    background-color: var(--btnbg)!important;
    color: var(--btnfontcolor)!important;
}
.bg-danger {
    font-size: 1rem;
}


.price-hp {
    font-size: 1rem;
    font-weight: 600;
    color: darkgray;
}

.amz-hp {
    font-size: .7rem;
    font-weight: 600;
    color: darkgray;
}

.fa-question-circle:before {
    /* content: ""\f059""; */
    color: darkgray;
}

.fa-heart:before {
    color:crimson;
}
.fa-chevron-circle-right:before {
    color: darkgray;
}
</style>
<div class=""container-fluid bg-trasparent my-4 p-3"" style=""position: relative"">
    <div class=""row row-cols-1 row-cols-xs-2 row-cols-sm-2 row-cols-lg-4 g-3"">
");
#nullable restore
#line 215 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""col hp"">
                <div class=""card h-100 shadow-sm"">
                    <a href=""#"">
                        <img src=""https://m.media-amazon.com/images/I/81gK08T6tYL._AC_SL1500_.jpg"" class=""card-img-top"" alt=""product.title"" />
                    </a>

                    <div class=""label-top shadow-sm"">
                        <a class=""text-white"" href=""#"">
                            ");
#nullable restore
#line 225 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.BrandName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </a>
                    </div>
                    <div class=""card-body"">
                        <div class=""clearfix mb-3"">
                            <span class=""float-start badge rounded-pill bg-success"">
                                ");
#nullable restore
#line 231 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ProductPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </span>\r\n");
#nullable restore
#line 233 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
                             if (item.IsAssured == true)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"float-end\"><a href=\"#\" class=\"small text-muted text-uppercase aff-link\"><i class=\"fa-regular fa-thumbs-up\"></i>&nbsp; Assured</a></span>\r\n");
#nullable restore
#line 236 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"float-end\"><a href=\"#\" class=\"small text-muted text-uppercase aff-link\"><i class=\"fa-regular fa-thumbs-down\"></i>&nbsp; Not Assured</a></span>\r\n");
#nullable restore
#line 240 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </div>\r\n                        <h5 class=\"card-title\">\r\n                            ");
#nullable restore
#line 243 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h5>\r\n                        <h6>\r\n                            ");
#nullable restore
#line 246 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </h6>\r\n\r\n                        <div class=\"d-grid gap-2 my-4\">\r\n\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2442b29ad194dc9fc82a184793155e95f50851d12682", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 251 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
                                                   WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                        </div>\r\n                        <div class=\"clearfix mb-1\">\r\n\r\n                            <span class=\"float-start\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2442b29ad194dc9fc82a184793155e95f50851d15075", async() => {
                WriteLiteral("<i class=\"fa-regular fa-circle-info\" style=\"cursor:pointer;\"></i>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 256 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
                                                                                WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</span>\r\n\r\n                            <span class=\"float-end\">\r\n                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d2442b29ad194dc9fc82a184793155e95f50851d17425", async() => {
                WriteLiteral("\r\n                                    <i class=\"fa-solid fa-trash\" style=\"cursor:pointer;\"></i>\r\n                                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 259 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
                                                         WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </span>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 267 "E:\SpexE_Comm\SpexE_CommMater\SpexE_Comm.Admin\Views\Product\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SpexE_Comm.Data.Data.Products>> Html { get; private set; }
    }
}
#pragma warning restore 1591
