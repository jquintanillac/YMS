#pragma checksum "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d7e417006ec1297af4f0b59a85544a859b039f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MDViaje_Detalle_listacanal), @"mvc.1.0.view", @"/Views/MDViaje_Detalle/listacanal.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d7e417006ec1297af4f0b59a85544a859b039f3", @"/Views/MDViaje_Detalle/listacanal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"561f07006863b292c4b1ad1c4f4b063378af591d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_MDViaje_Detalle_listacanal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MDViaje_Detalle", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Updatecanal", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-sm text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Validar", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 1 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
  
    ViewData["Title"] = "Lista Canales";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 6 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
  
    var message = ViewBag.SuccessMsg;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d7e417006ec1297af4f0b59a85544a859b039f35921", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.10.23/css/dataTables.bootstrap4.min.css\" />\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.10.23/css/jquery.dataTables.min.css\" />\r\n");
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
            WriteLiteral("\r\n<br />\r\n<!--Validacion para desplegar Mensaje despues del POST-->\r\n");
#nullable restore
#line 16 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
 if (TempData["success"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible fade show\" role=\"alert\">\r\n        <strong>Mensaje: </strong> ");
#nullable restore
#line 19 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
                              Write(Html.Encode(TempData["success"]));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <a href=\"#\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">×</span>\r\n        </a>\r\n    </div>\r\n");
#nullable restore
#line 24 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container"">
    <div class=""card"">
        <div class=""card-header"">
            <div class=""div-title"">
                <h4>CANALES - TRANSPORTES</h4>
            </div>
        </div>
        <div class=""card-body"">
            <div class=""container-fluid"">
                <table table id=""tblcanal"" class=""table table-striped table-bordered"" style=""width: 100%"">
                    <thead>
                        <tr>
                            <th class=""d-none"">
                                Codigo
                            </th>
                            <th>
                                Canal
                            </th>
                            <th>
                                Nro. Transporte
                            </th>
                            <th>
                                Activo
                            </th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 53 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
                         foreach (var item in ViewBag.Canales)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td class=\"d-none\">\r\n                                    ");
#nullable restore
#line 57 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
                               Write(item.id_canal);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 60 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
                               Write(item.can_desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 63 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
                               Write(item.can_plac);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d7e417006ec1297af4f0b59a85544a859b039f310863", async() => {
                WriteLiteral("\r\n                                        <input type=\"hidden\" name=\"mplac_desc\"");
                BeginWriteAttribute("value", " value=\"", 2570, "\"", 2601, 1);
#nullable restore
#line 67 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
WriteAttributeValue("", 2578, ViewData["mplac_desc"], 2578, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        <input type=\"hidden\" name=\"id_canal\"");
                BeginWriteAttribute("value", " value=\"", 2681, "\"", 2703, 1);
#nullable restore
#line 68 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
WriteAttributeValue("", 2689, item.id_canal, 2689, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        <input type=\"hidden\" name=\"id_vijcab\"");
                BeginWriteAttribute("value", " value=\"", 2784, "\"", 2814, 1);
#nullable restore
#line 69 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
WriteAttributeValue("", 2792, ViewData["id_vijcab"], 2792, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n                                        <input type=\"hidden\" name=\"nro_trans\"");
                BeginWriteAttribute("value", " value=\"", 2895, "\"", 2925, 1);
#nullable restore
#line 70 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
WriteAttributeValue("", 2903, ViewData["nro_trans"], 2903, 22, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 71 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
                                         if (item.can_act)
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                            <input type=\"submit\" class=\"btn-sm btn-success text-light\" value=\"Agregar\" />\r\n                                            <input type=\"submit\" class=\"btn-sm btn-danger text-light\" value=\"Liberar\" />\r\n");
#nullable restore
#line 75 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                        <input type=\"submit\" class=\"btn-sm btn-success text-light\" value=\"libre\" />\r\n");
#nullable restore
#line 79 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
                                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
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
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 83 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n        <div class=\"container-fluid\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5d7e417006ec1297af4f0b59a85544a859b039f316492", async() => {
                WriteLiteral("Regresar");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 89 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
                                                                                                              WriteLiteral(ViewData["id_vijcab"]);

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
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n<br />\r\n<br />\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 97 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Detalle\listacanal.cshtml"
Write(await Html.PartialAsync("_ValidationScriptsPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script src=""https://cdn.datatables.net/1.10.23/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.10.23/css/jquery.dataTables.min.css""></script>
    <script type=""text/javascript"">
        $(document).ready(function () {
            $('#tblcanal').DataTable({
                ""pageLength"": 50,
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
