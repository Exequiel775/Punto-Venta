#pragma checksum "C:\Users\User\XCommerce\Views\Clientes\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a46dca69567fb1feb83d188287314837b89f3e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Clientes_Index), @"mvc.1.0.view", @"/Views/Clientes/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a46dca69567fb1feb83d188287314837b89f3e9", @"/Views/Clientes/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"325c1b545832da488087bde214fef11f873f8846", @"/Views/_ViewImports.cshtml")]
    public class Views_Clientes_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Servicios.Interface.Cliente.Cliente>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\XCommerce\Views\Clientes\Index.cshtml"
  
    ViewData["Title"] = "Clientes";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<button type=\"button\" class=\"btn btn-danger cargarCombo\">CARGAR</button>\r\n\r\n<div class=\"col-6 border\" style=\"margin-left: 50%; transform:translateX(-50%);\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a46dca69567fb1feb83d188287314837b89f3e94024", async() => {
                WriteLiteral(@"
        <div style=""padding:15px;"">

            <div class=""alert alert-success alert-dismissible fade show"" role=""alert"" id=""msj-exito"" style=""display: none;"">
                <strong>Exito!</strong> El cliente fue registrado exitosamente
                <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            
            <label>Nombre</label>
            ");
#nullable restore
#line 21 "C:\Users\User\XCommerce\Views\Clientes\Index.cshtml"
       Write(Html.ValidationMessageFor(x => x.Nombre));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            <input type=\"text\" class=\"form-control\" name=\"Nombre\" placeholder=\"Nombre...\">\r\n\r\n            <label>Apellido</label>\r\n            ");
#nullable restore
#line 25 "C:\Users\User\XCommerce\Views\Clientes\Index.cshtml"
       Write(Html.ValidationMessageFor(x => x.Apellido));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
            <input type=""text"" class=""form-control"" name=""Apellido"">

            <label>Dni</label>
            <input type=""number"" class=""form-control"" name=""Dni"">

            <div class=""row"">
                <div class=""col"">
                    <label>Provincia</label>
                    <select class=""form-control"" id=""cmbProvincia"" name=""Provincia"">
");
#nullable restore
#line 35 "C:\Users\User\XCommerce\Views\Clientes\Index.cshtml"
                         foreach (var item in ViewBag.Provincias as
                        IEnumerable<Servicios.Interface.Provincias.Provincia>)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a46dca69567fb1feb83d188287314837b89f3e96190", async() => {
#nullable restore
#line 38 "C:\Users\User\XCommerce\Views\Clientes\Index.cshtml"
                                                Write(item.Descripcion);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 38 "C:\Users\User\XCommerce\Views\Clientes\Index.cshtml"
                               WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 39 "C:\Users\User\XCommerce\Views\Clientes\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                    </select>
                </div>
                <div class=""col pr-1"">
                    <label>Localidad</label>
                    <select class=""form-control"" name=""LocalidadId"" id=""cmbLocalidad"">

                    </select>
                </div>
            </div>
            <div class=""pt-1 pb-1"">
                <label>Direcci??n</label>
                ");
#nullable restore
#line 51 "C:\Users\User\XCommerce\Views\Clientes\Index.cshtml"
           Write(Html.ValidationMessageFor(x => x.Direccion));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                <input type=""text"" class=""form-control"" name=""Direccion"" placeholder=""Direcci??n..."">
            </div>

            <div class=""pt-1 pb-1"">
                <h4 class=""text-center"" style=""font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"">CUENTA
                </h4>
                <hr>

                <input data-val=""true"" data-val-required=""The ActivarCtaCte field is required."" id=""cuenta""
                    name=""ActivarCtaCte"" type=""checkbox"" value=""true"">
                <label>Activar Cuenta Corriente</label>

                <input data-val=""true"" data-val-required=""The TieneLimite field is required."" id=""actLimite""
                    name=""TieneLimite"" type=""checkbox"" value=""true"">
                <label>??Tiene limite de monto?</label>

                <label>Limite</label>
                <input type=""number"" class=""form-control"" style=""display:none;"" id=""txtLimite"" name=""LimiteMonto"">
            </div>

            <input type=""submit"" class=""b");
                WriteLiteral("tn btn-success enviarFormulario\" value=\"ENVIAR FORMULARIO\">\r\n        </div>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>

<div class=""row"">
    <div class=""col-6"">
        <div style=""padding:12px; text-align:center;"">
            <h3>NUEVO CLIENTE</h3>
        </div>
        <div class=""pt-3 pb-3"">
            <label>Nombre</label>
            <input type=""text"" class=""form-control"" id=""txtNombre"">
            <div class=""row"">
                <div class=""col-5"">
                    <label>Provincia</label>
                    <select class=""form-control"" id=""cmbDatos""></select>
                </div>
                <div class=""col-5"">
                    <label>Localidad</label>
                    <select class=""form-control"">
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a46dca69567fb1feb83d188287314837b89f3e911800", async() => {
                WriteLiteral("Las Talitas");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a46dca69567fb1feb83d188287314837b89f3e912788", async() => {
                WriteLiteral("Tafi Viejo");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </select>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-8 border pt-5 pb-5"">
    </div>
</div>

<script type=""text/javascript"">

    document.addEventListener('DOMContentLoaded', () => {
        CargarLocalidades(document.getElementById('cmbProvincia').value);
    });

    document.getElementById('cmbProvincia').addEventListener('change', (e) => {
        CargarLocalidades(e.target.value);
    });

    document.getElementById('actLimite').addEventListener('change', (e) => {
        const checkeado = e.currentTarget.checked;
        const inpLimite = document.getElementById('txtLimite');

        if (checkeado){
            inpLimite.style.display = 'block';
        }else{
            inpLimite.style.display = 'none';
        }
    });

    const formulario = document.getElementById('form');

    formulario.addEventListener('submit', (e) => {
        e.preventDefault();

        const formData = new FormData(form");
            WriteLiteral(@"ulario);

        fetch('/Clientes/AgregarCliente', {
            method: 'POST',
            body: formData
        })
            .then(response => {
                if (response.status === 200) {
                    response.json()
                        .then(json => {
                            if (json.finalizado) {
                                document.getElementById('msj-exito').style.display = 'block';
                                formulario.reset();
                            } else {
                                alert(""Error"");
                            }
                        })
                }
            })
    });

    function CargarLocalidades(provincia) {

        const data = new FormData();
        data.append('provincia', provincia);

        const select = document.getElementById('cmbLocalidad');
        select.innerHTML = '';

        fetch('/Localidades/JsonLocalidadesProvincia', {
            method: 'POST',
            body: data
    ");
            WriteLiteral(@"    })
            .then(response => {
                if (response.status === 200) {
                    response.json()
                        .then(json => {
                            json.localidades.forEach((indice) => {
                                let option = document.createElement('option');

                                option.text = indice.descripcion;
                                option.value = indice.id;

                                select.add(option);
                            });
                        })
                } else {
                    alert(""No se pudieron obtener las localidades"");
                }
            })
            .catch((er) => {
                console.log(er.message);
            });
    }

    document.querySelector('.cargarCombo').addEventListener('click', () => { CargarCmb(); });

    function CargarCmb() {
        let combo = document.getElementById('cmbDatos');

        let array = [""Rodrigo Exequiel, Gonzalez"", ");
            WriteLiteral(@"""Chaves Jessica Fernanda"", ""Maria Cristina, Reinoso""];
        // Me ordena alfabeticamente el array
        array.sort();

        array.forEach((indice) => {
            let option = document.createElement('option');

            option.text = indice;
            combo.add(option);
        });
        /*
        for(let value in array)
        {
            let option = document.createElement('option');

            option.text = array[value];
            combo.add(option);
        }*/
    }

    function enviar() {

        let obj = {
            LocalidadId: 01,
            Nombre: '',
            Apellido: '',
            Dni: 00,
            Direccion: ''
        }

        let data = new FormData();
        data.append('cliente', obj);

        fetch('/Clientes/AgregarCliente', {
            method: 'POST',
            body: data
        })
            .then(response => response.json())
            .then(json => {
                if (!json.formCorrecto) {
      ");
            WriteLiteral("              alert(\"Error!!!\");\r\n                    console.log(json.campoRequerido);\r\n                    return;\r\n                }\r\n            });\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Servicios.Interface.Cliente.Cliente> Html { get; private set; }
    }
}
#pragma warning restore 1591
