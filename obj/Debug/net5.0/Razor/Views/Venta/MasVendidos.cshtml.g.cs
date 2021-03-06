#pragma checksum "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7135263422ed70a994d9efa555f7f92033703b53"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Venta_MasVendidos), @"mvc.1.0.view", @"/Views/Venta/MasVendidos.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7135263422ed70a994d9efa555f7f92033703b53", @"/Views/Venta/MasVendidos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"325c1b545832da488087bde214fef11f873f8846", @"/Views/_ViewImports.cshtml")]
    public class Views_Venta_MasVendidos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Servicios.Interface.DetalleComprobante.DetalleComprobante>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
  
    ViewData["Title"] = "Productos Mas Vendidos";
    var _empleados = ViewBag.Empleados as IEnumerable<Servicios.Interface.Comprobante.Comprobante>;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""row"">
    <div class=""col-lg-4 col-sm-12 col-md-4 contenedores"">
        <div class=""contenedores"">
            <div class=""mensaje"">
                <h5>
                    <svg xmlns=""http://www.w3.org/2000/svg"" width=""22"" height=""19"" fill=""currentColor""
                        class=""bi bi-grid-3x3-gap-fill"" viewBox=""0 0 16 16"">
                        <path
                            d=""M1 2a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1V2zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1V2zM1 7a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V7zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1V7zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1V7zM1 12a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1v-2zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1v-2zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 ");
            WriteLiteral(@"1h-2a1 1 0 0 1-1-1v-2z"" />
                    </svg>
                    PRODUCTOS MAS VENDIDOS LA ULTIMA SEMANA
                </h5>
                <hr class=""linea"">
            </div>
            <div class=""contenedor-tabla"">
                <div class=""table-responsive"">
                    <table class=""table table-sm"">
                        <thead>
                            <tr>
                                <th>Articulo</th>
                                <th>Cantidad</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 32 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>");
#nullable restore
#line 35 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                                   Write(item.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td>");
#nullable restore
#line 36 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                                   Write(item.TotalVendido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 38 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
        </div>

    </div>
    <div class=""col-lg-4 col-sm-12 col-md-4 contenedores"">
        <div class=""contenedores"">
            <div class=""mensaje"">
                <h5>
                    <svg xmlns=""http://www.w3.org/2000/svg"" width=""22"" height=""19"" fill=""currentColor""
                        class=""bi bi-grid-3x3-gap-fill"" viewBox=""0 0 16 16"">
                        <path
                            d=""M1 2a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1V2zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1V2zM1 7a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V7zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1V7zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1V7zM1 12a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1v-2zm5");
            WriteLiteral(@" 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1v-2zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1v-2z"" />
                    </svg>
                    EMPLEADOS QUE MAS VENDIERON LA ULTIMA SEMANA
                </h5>
                <hr class=""linea"">
            </div>
            <div class=""contenedor-tabla"">
                <div class=""table-responsive"">
                    <table class=""table table-sm"">
                        <thead>
                            <tr>
                                <th>Empleado</th>
                                <th>Cantidad</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 69 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                             foreach (var item in _empleados)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        <a href=\"#\">");
#nullable restore
#line 73 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                                               Write(item.ApyNomEmpleado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n                                    </td>\r\n                                    <td>");
#nullable restore
#line 75 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                                   Write(item.CantidadVendida);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                </tr>\r\n");
#nullable restore
#line 77 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-lg-4 col-sm-12 col-md-4 contenedores"">
        <div class=""mensaje"">
            <h5>
                <svg xmlns=""http://www.w3.org/2000/svg"" width=""22"" height=""19"" fill=""currentColor""
                    class=""bi bi-grid-3x3-gap-fill"" viewBox=""0 0 16 16"">
                    <path
                        d=""M1 2a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1V2zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1V2zM1 7a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V7zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H7a1 1 0 0 1-1-1V7zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1V7zM1 12a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1v-2zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1H7a1 1 0 0 1-1");
            WriteLiteral(@"-1v-2zm5 0a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1v-2z"" />
                </svg>
                EMPLEADOS QUE MAS VENDIERON LA ULTIMA SEMANA
            </h5>
            <hr class=""linea"">
        </div>
        <div class=""contenedor-tabla"">
            <div class=""table-responsive"">
                <table class=""table table-sm"">
                    <thead>
                        <tr>
                            <th>Articulo</th>
                            <th>Cantidad</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 106 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 109 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                               Write(item.Descripcion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 110 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                               Write(item.TotalVendido);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 112 "C:\Users\User\XCommerce\Views\Venta\MasVendidos.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    </tbody>
                </table>
            </div>
        </div>
    </div>
</div>

<style type=""text/css"">
    .linea {
        border: 2px solid rgba(50, 153, 255, 0.83);
    }

    .contenedor-tabla {
        width: 100%;
    }

    .mensaje h5 {
        font-weight: bold;
        font-size: 18px;
    }

    body {
        background-color: rgb(223, 224, 224)
    }

    .contenedores {
        background: #fff;
    }
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Servicios.Interface.DetalleComprobante.DetalleComprobante>> Html { get; private set; }
    }
}
#pragma warning restore 1591
