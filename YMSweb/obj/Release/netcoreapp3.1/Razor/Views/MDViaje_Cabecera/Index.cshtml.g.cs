#pragma checksum "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "df1be0239732cdbe37311b5648e05a225d4b1b4a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MDViaje_Cabecera_Index), @"mvc.1.0.view", @"/Views/MDViaje_Cabecera/Index.cshtml")]
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
#line 1 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\_ViewImports.cshtml"
using YMSweb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\_ViewImports.cshtml"
using YMSweb.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\_ViewImports.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"df1be0239732cdbe37311b5648e05a225d4b1b4a", @"/Views/MDViaje_Cabecera/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"561f07006863b292c4b1ad1c4f4b063378af591d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_MDViaje_Cabecera_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<YMSweb.Models.ViewModels.VMviajes>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MDViaje_Cabecera", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-sm text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Validar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MDViaje_Detalle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
  
    ViewData["Title"] = "Viajes";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df1be0239732cdbe37311b5648e05a225d4b1b4a5968", async() => {
                WriteLiteral("\r\n\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.10.23/css/dataTables.bootstrap4.min.css\" />\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.10.23/css/jquery.dataTables.min.css\" />\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<br />
<div class=""container-fluid"">
    <div class=""div-title"">
        <h4 class=""m-0"">REGISTRO DE VIAJES</h4>
    </div>
</div>
<hr style=""color: #0056b2"" />
<br />
<br />
<div class=""container-fluid"">
    <table table id=""tblviaje"" class=""table table-striped table-bordered"" style=""width: 100%"">
        <thead>
            <tr>
                <th>
                    ");
#nullable restore
#line 27 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.id_camplacab));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 30 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.placa));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 33 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Nro_Trans));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 36 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Fec_gen));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 42 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
             foreach (var item in ViewBag.viajes)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 46 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
                   Write(item.id_camplacab);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 49 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
                   Write(item.placa);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 52 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
                   Write(item.Nro_Trans);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 55 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
                   Write(item.Fec_gen);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df1be0239732cdbe37311b5648e05a225d4b1b4a10731", async() => {
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"placa\"");
                BeginWriteAttribute("value", " value=\"", 1919, "\"", 1938, 1);
#nullable restore
#line 59 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
WriteAttributeValue("", 1927, item.placa, 1927, 11, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                            <input type=\"hidden\" name=\"id_camplacab\"");
                BeginWriteAttribute("value", " value=\"", 2012, "\"", 2038, 1);
#nullable restore
#line 60 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
WriteAttributeValue("", 2020, item.id_camplacab, 2020, 18, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("/>\r\n                            <input type=\"submit\" value=\"Escoger\" class=\"btn btn-info btn-sm\" />\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 65 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n<br />\r\n<hr style=\"color: #0056b2\" />\r\n<br />\r\n<div class=\"container-fluid\">\r\n    <div class=\"div-title\">\r\n        <h4 class=\"m-0\">REGISTRO DE TRANSPORTES</h4>\r\n    </div>\r\n    <h2>Placa: ");
#nullable restore
#line 76 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
          Write(ViewData["placa"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
</div>
<div class=""container-fluid"">
    <table table id=""tbldetalle"" class=""table table-striped table-bordered"" style=""width: 100%"">
        <thead>
            <tr>
                <th class=""d-none"">
                    Nro. Viaje
                </th>
                <th>
                    Nro. Transporte
                </th>
                <th>
                    Peso
                </th>
                <th>
                    Volumen
                </th>
                <th>
                    Tipo Transporte
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 101 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
             foreach (var item in ViewBag.viajedetalle)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td class=\"d-none\">\r\n                        ");
#nullable restore
#line 105 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
                   Write(item.id_vijcab);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 108 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
                   Write(item.campla_nrotrans);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 111 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
                   Write(item.campla_peso);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 114 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
                   Write(item.campla_volumen);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 117 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
                   Write(item.tiptran_desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df1be0239732cdbe37311b5648e05a225d4b1b4a17152", async() => {
                WriteLiteral("Validar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 120 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
                                                                                                                          WriteLiteral(item.id_vijcab);

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
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 123 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://cdn.datatables.net/1.10.23/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.10.23/css/jquery.dataTables.min.css""></script>
    <script type=""text/javascript"">
        $(document).ready(function () {
            $('#tblviaje').DataTable({
                ""language"": {
                    ""lengthMenu"": ""Mostrar _MENU_ registros por pagina"",
                    ""zeroRecords"": ""No se encontraron registros"",
                    ""info"": ""Mostrar pagina _PAGE_ de _PAGES_"",
                    ""infoEmpty"": ""No se encontraron registros"",
                    ""infoFiltered"": ""(filtrado de _MAX_ registros totales)"",
                    ""search"": ""Buscar:"",
                    ""paginate"": {
                        ""next"": ""siguiente"",
                        ""previous"": ""Anterior""
                    }

                }
            });
            $('#tbldetalle').DataTable({
                ""language"": {
                    ""lengthMenu"":");
                WriteLiteral(@" ""Mostrar _MENU_ registros por pagina"",
                    ""zeroRecords"": ""No se encontraron registros"",
                    ""info"": ""Mostrar pagina _PAGE_ de _PAGES_"",
                    ""infoEmpty"": ""No se encontraron registros"",
                    ""infoFiltered"": ""(filtrado de _MAX_ registros totales)"",
                    ""search"": ""Buscar:"",
                    ""paginate"": {
                        ""next"": ""siguiente"",
                        ""previous"": ""Anterior""
                    }

                }
            });
        });
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<YMSweb.Models.ViewModels.VMviajes> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
