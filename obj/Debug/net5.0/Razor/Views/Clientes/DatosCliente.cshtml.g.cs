#pragma checksum "C:\Users\User\XCommerce\Views\Clientes\DatosCliente.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "472fc87342440fdbc8d87addfd2710a4428fbbea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clientes_DatosCliente), @"mvc.1.0.view", @"/Views/Clientes/DatosCliente.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"472fc87342440fdbc8d87addfd2710a4428fbbea", @"/Views/Clientes/DatosCliente.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"325c1b545832da488087bde214fef11f873f8846", @"/Views/_ViewImports.cshtml")]
    public class Views_Clientes_DatosCliente : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Servicios.Interface.Persona.ClienteDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\XCommerce\Views\Clientes\DatosCliente.cshtml"
  
    ViewData["Title"] = Model.ApyNom;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"border\">\r\n    <div class=\"m-3\">\r\n        <h5>Apellido y Nombre: <strong>");
#nullable restore
#line 9 "C:\Users\User\XCommerce\Views\Clientes\DatosCliente.cshtml"
                                  Write(Model.ApyNom);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></h5>\r\n        <h5>Dni: <strong>");
#nullable restore
#line 10 "C:\Users\User\XCommerce\Views\Clientes\DatosCliente.cshtml"
                    Write(Model.Dni);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></h5>\r\n        <h5>Dire: <strong>");
#nullable restore
#line 11 "C:\Users\User\XCommerce\Views\Clientes\DatosCliente.cshtml"
                     Write(Model.Direccion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong></h5>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Servicios.Interface.Persona.ClienteDto> Html { get; private set; }
    }
}
#pragma warning restore 1591