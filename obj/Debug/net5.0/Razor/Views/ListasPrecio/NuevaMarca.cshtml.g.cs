#pragma checksum "C:\Users\User\XCommerce\Views\ListasPrecio\NuevaMarca.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c506faafbd81503ea622c7b79ca62d905675312"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ListasPrecio_NuevaMarca), @"mvc.1.0.view", @"/Views/ListasPrecio/NuevaMarca.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c506faafbd81503ea622c7b79ca62d905675312", @"/Views/ListasPrecio/NuevaMarca.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"325c1b545832da488087bde214fef11f873f8846", @"/Views/_ViewImports.cshtml")]
    public class Views_ListasPrecio_NuevaMarca : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Servicios.Interface.Marca.Marca>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\XCommerce\Views\ListasPrecio\NuevaMarca.cshtml"
  
    ViewData["Title"] = "Marquilla";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-8 contenedor-form\">\r\n");
#nullable restore
#line 8 "C:\Users\User\XCommerce\Views\ListasPrecio\NuevaMarca.cshtml"
     using (Html.BeginForm("NuevaMarca", "ListasPrecio", FormMethod.Post, htmlAttributes: new { id ="form-marca" }))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <label>Descripci??n</label>\r\n        <label style=\"color:red\">");
#nullable restore
#line 11 "C:\Users\User\XCommerce\Views\ListasPrecio\NuevaMarca.cshtml"
                            Write(Html.ValidationMessageFor(x => x.Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n");
#nullable restore
#line 12 "C:\Users\User\XCommerce\Views\ListasPrecio\NuevaMarca.cshtml"
   Write(Html.TextBoxFor(x => x.Descripcion, htmlAttributes: new { @class ="form-control", placeholder="Descripcion..." }));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <label>Nombre</label>\r\n        <label style=\"color:red\">");
#nullable restore
#line 15 "C:\Users\User\XCommerce\Views\ListasPrecio\NuevaMarca.cshtml"
                            Write(Html.ValidationMessageFor(x => x.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n");
#nullable restore
#line 16 "C:\Users\User\XCommerce\Views\ListasPrecio\NuevaMarca.cshtml"
   Write(Html.TextBoxFor(x => x.Nombre, htmlAttributes: new { @class ="form-control", placeholder="Nombre..." }));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"mt-4\">\r\n            <input type=\"submit\" class=\"btn btn-primary\" value=\"AGREGAR\">\r\n        </div>\r\n");
#nullable restore
#line 21 "C:\Users\User\XCommerce\Views\ListasPrecio\NuevaMarca.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</div>

<style type=""text/css"">
.contenedor-form{
    margin-left: 50%;
    transform: translateX(-50%);
}
</style>

<script type=""text/javascript"">
const form = document.getElementById('form-marca');

form.addEventListener('submit', (e)  => {

});
</script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Servicios.Interface.Marca.Marca> Html { get; private set; }
    }
}
#pragma warning restore 1591
