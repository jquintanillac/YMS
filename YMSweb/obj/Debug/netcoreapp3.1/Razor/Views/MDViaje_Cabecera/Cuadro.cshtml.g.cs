#pragma checksum "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c1d69e4a02fb8e0d963b76c98931ec751a25bc43"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MDViaje_Cabecera_Cuadro), @"mvc.1.0.view", @"/Views/MDViaje_Cabecera/Cuadro.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1d69e4a02fb8e0d963b76c98931ec751a25bc43", @"/Views/MDViaje_Cabecera/Cuadro.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"561f07006863b292c4b1ad1c4f4b063378af591d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_MDViaje_Cabecera_Cuadro : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
  
    ViewData["Title"] = "Cuadro";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c1d69e4a02fb8e0d963b76c98931ec751a25bc433638", async() => {
                WriteLiteral(@"
    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.10.23/css/dataTables.bootstrap4.min.css"" />
    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/1.10.23/css/jquery.dataTables.min.css"" />
    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.datatables.net/buttons/1.7.0/css/buttons.bootstrap4.min.css"" />
");
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

<div class=""container"">
    <div class=""card"">
         <div class=""card-header"">
            <div class=""div-title"">
                <h4 class=""m-0"">PLACAS EN TRATAMIENTO</h4>
            </div>
        </div>
        <div class=""card-body"">
             <div class=""container"">
                <table table id=""tblcuaddet"" class=""table table-striped table-bordered"" style=""width: 100%"">
                    <thead>
                        <tr>
                            <th>
                               EMPRESA TRANSPORTE
                            </th>
                            <th>
                               NRO. TRANSPORTE
                            </th>
                            <th>
                               PLACA
                            </th>
                            <th>
                               PESO
                            </th>
                            <th>
                               VOLUMEN
                            </th>
   ");
            WriteLiteral(@"                         <th>
                               CANAL
                            </th>
                            <th>
                               TIPO DE TRANSPORTE
                            </th>
                            <th>
                               OBSERVACION
                            </th>                            
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 51 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
                         foreach (var item in ViewBag.cuaddetalle)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 55 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
                               Write(item.transp_desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 58 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
                               Write(item.campla_nrotrans);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 61 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
                               Write(item.plac_desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 64 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
                               Write(item.campla_peso);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 67 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
                               Write(item.campla_volumen);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 70 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
                               Write(item.canal);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 73 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
                               Write(item.tiptran_desc);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 76 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
                               Write(item.campla_obse);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 79 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
#nullable restore
#line 88 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDViaje_Cabecera\Cuadro.cshtml"
Write(await Html.PartialAsync("_ValidationScriptsPartial"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <script src=""https://cdn.datatables.net/1.10.23/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.10.23/css/jquery.dataTables.min.css""></script>
    <script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/jszip/2.5.0/jszip.min.js""></script>
    <script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/pdfmake.min.js""></script>
    <script type=""text/javascript"" src=""https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.1.36/vfs_fonts.js""></script>    
    <script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/1.7.0/js/dataTables.buttons.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/1.7.0/js/buttons.bootstrap4.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/1.7.0/js/buttons.html5.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.datatables.net/buttons/1.7.0/js/buttons.print.min.js""></script>");
                WriteLiteral(@"
    <script type=""text/javascript"">
        $(document).ready(function () {
            $('#tblcuaddet').DataTable({
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
                },
                ""scrollX"": true,
                ""responsive"": true,
                ""dom"": 'Bfrtilp',
                ""buttons"": [
                    {
                        ""extend"": 'excelHtml5',
                        ""text"": '<i class=""fas fa-file-excel""></i");
                WriteLiteral(@">',
                        ""titleAttr"": 'Exportar a excel',
                        ""className"": 'btn btn-success'
                    },
                    //{
                    //    ""extend"": 'pdfHtml5',
                    //    ""text"": '<i class=""fas fa-file-pdf""></i>',
                    //    ""titleAttr"": 'Exportar a PDF',
                    //    ""className"": 'btn btn-danger'
                    //},
                ]
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
