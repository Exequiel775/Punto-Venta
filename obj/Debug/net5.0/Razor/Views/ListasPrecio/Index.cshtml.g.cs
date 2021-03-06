#pragma checksum "C:\Users\User\XCommerce\Views\ListasPrecio\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e4ed4cf6429763d18ebdb5ea962c7ba64c1e55f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ListasPrecio_Index), @"mvc.1.0.view", @"/Views/ListasPrecio/Index.cshtml")]
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
#line 1 "C:\Users\User\XCommerce\Views\_ViewImports.cshtml"
using XCommerce;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\User\XCommerce\Views\_ViewImports.cshtml"
using XCommerce.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e4ed4cf6429763d18ebdb5ea962c7ba64c1e55f", @"/Views/ListasPrecio/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"325c1b545832da488087bde214fef11f873f8846", @"/Views/_ViewImports.cshtml")]
    public class Views_ListasPrecio_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/javascript"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/ListaPrecio/Index.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\User\XCommerce\Views\ListasPrecio\Index.cshtml"
  
    ViewData["Title"] = "Listas de Precio";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-4"">
        <div class=""bg-white contenedor-nueva-lista"">
            <div class=""titulo-nuevo"">
                <h4 style=""font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"">NUEVA LISTA DE PRECIOS</h4>
            </div>
            <div class=""formulario"">
                <label>Descripcion</label>
                <input type=""text"" class=""form-control"" id=""txtDescripcion"">
                <br>
                <label>Porcentaje Ganancia</label>
                <input type=""number"" class=""form-control"" id=""porcentaje"">
            </div>
            <hr>
            <div class=""guardar"">
                <button type=""button"" class=""btn btn-primary"" id=""btnGrabar"">GRABAR</button>
            </div>
        </div>
    </div>
    <div class=""col-8"">
        <div class=""bg-danger titulo"">
            <h4>Listas de precio cargadas</h4>
        </div>
        <div class=""contenedor-tabla"">
            <div class=""table-responsive"">
      ");
            WriteLiteral(@"      <table class=""table table-sm table-bordered"">
                <thead class=""thead-dark text-center"">
                    <tr>
                        <th>Descripci??n</th>
                        <th>Porcentaje</th>
                    </tr>
                </thead>
                <tbody class=""text-center"" id=""body-tabla"">
                </tbody>
            </table>
        </div>
        </div>
    </div>
</div>

<style type=""text/css"">
body{
    background-color: rgba(222, 222, 222);
}

.contenedor-nueva-lista{
    padding: 10px 10px 10px 10px;
    margin-top: 10px;
}

.titulo-nuevo{
    text-align: center;
    padding-top: 10px;
    padding-bottom: 10px;
}

.guardar{
    padding-top: 5px;
    padding-bottom: 5px;
}

.contenedor-tabla{
    margin-top: 10px;
    background-color: white;
    color:black;
}

.titulo{
    padding-top: 15px;
    padding-bottom: 15px;
    text-align: center;
    font-family: 'Franklin Gothic Medium', 'Arial Narrow', Arial, sa");
            WriteLiteral("ns-serif;\r\n    text-decoration: none;\r\n    font-size: 22px;\r\n    color:white;\r\n}\r\n</style>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3e4ed4cf6429763d18ebdb5ea962c7ba64c1e55f6203", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
