#pragma checksum "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c650d20ca03cd7031bee55e99e8ee0e305daaf2c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PedidoRestaurantes_Index), @"mvc.1.0.view", @"/Views/PedidoRestaurantes/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PedidoRestaurantes/Index.cshtml", typeof(AspNetCore.Views_PedidoRestaurantes_Index))]
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
#line 1 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\_ViewImports.cshtml"
using ZeroWaste;

#line default
#line hidden
#line 2 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\_ViewImports.cshtml"
using ZeroWaste.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c650d20ca03cd7031bee55e99e8ee0e305daaf2c", @"/Views/PedidoRestaurantes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"063a56890a38ccac65026f3adc083f89ed0cdfc7", @"/Views/_ViewImports.cshtml")]
    public class Views_PedidoRestaurantes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ZeroWaste.Models.PedidoRestaurante>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(56, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(99, 29, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(128, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81e6a04244b94328beb00dbec6c2971b", async() => {
                BeginContext(151, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(165, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(258, 46, false);
#line 16 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantidade));

#line default
#line hidden
            EndContext();
            BeginContext(304, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(360, 49, false);
#line 19 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.EstadoEntrega));

#line default
#line hidden
            EndContext();
            BeginContext(409, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(465, 47, false);
#line 22 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DataEntrega));

#line default
#line hidden
            EndContext();
            BeginContext(512, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(568, 44, false);
#line 25 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Familias));

#line default
#line hidden
            EndContext();
            BeginContext(612, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(668, 48, false);
#line 28 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Instituicoes));

#line default
#line hidden
            EndContext();
            BeginContext(716, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(772, 56, false);
#line 31 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.RefeicoesRestaurante));

#line default
#line hidden
            EndContext();
            BeginContext(828, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(884, 47, false);
#line 34 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Voluntarios));

#line default
#line hidden
            EndContext();
            BeginContext(931, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 40 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(1049, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1098, 45, false);
#line 43 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Quantidade));

#line default
#line hidden
            EndContext();
            BeginContext(1143, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1199, 48, false);
#line 46 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.EstadoEntrega));

#line default
#line hidden
            EndContext();
            BeginContext(1247, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1303, 46, false);
#line 49 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DataEntrega));

#line default
#line hidden
            EndContext();
            BeginContext(1349, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1405, 49, false);
#line 52 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Familias.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1454, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1510, 53, false);
#line 55 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Instituicoes.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1563, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1619, 60, false);
#line 58 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.RefeicoesRestaurante.Nome));

#line default
#line hidden
            EndContext();
            BeginContext(1679, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1735, 52, false);
#line 61 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Voluntarios.Email));

#line default
#line hidden
            EndContext();
            BeginContext(1787, 57, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n\r\n                ");
            EndContext();
            BeginContext(1844, 169, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1a11c96a3d64ed3abdbfdc3e24a71ad", async() => {
                BeginContext(1906, 103, true);
                WriteLiteral("\r\n                    <input type=\"button\" value=\"Alterar\" class=\"btn btn-warning\" />\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 65 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
                                       WriteLiteral(item.IDPedidoRestaurante);

#line default
#line hidden
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
            EndContext();
            BeginContext(2013, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(2031, 170, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0c72281cd949404c86195136111595f0", async() => {
                BeginContext(2096, 101, true);
                WriteLiteral("\r\n                    <input type=\"button\" value=\"Detalhes\" class=\"btn btn-info\" />\r\n                ");
                EndContext();
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
#line 68 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
                                          WriteLiteral(item.IDPedidoRestaurante);

#line default
#line hidden
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
            EndContext();
            BeginContext(2201, 18, true);
            WriteLiteral("\r\n                ");
            EndContext();
            BeginContext(2219, 171, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "88b100c6088f44cbba8486069d04d54f", async() => {
                BeginContext(2283, 103, true);
                WriteLiteral("\r\n                    <input type=\"button\" value=\"Eliminar\" class=\"btn btn-danger\" />\r\n                ");
                EndContext();
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
#line 71 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
                                         WriteLiteral(item.IDPedidoRestaurante);

#line default
#line hidden
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
            EndContext();
            BeginContext(2390, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 76 "C:\Users\rober\Desktop\Nova pasta\ZeroWaste\ZeroWaste\Views\PedidoRestaurantes\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2429, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ZeroWaste.Models.PedidoRestaurante>> Html { get; private set; }
    }
}
#pragma warning restore 1591
