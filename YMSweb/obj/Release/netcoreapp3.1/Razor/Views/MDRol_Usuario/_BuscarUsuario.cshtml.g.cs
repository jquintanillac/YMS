#pragma checksum "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "38b9653ba79f5c1eb68a49ccb66c409cb002f691"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MDRol_Usuario__BuscarUsuario), @"mvc.1.0.view", @"/Views/MDRol_Usuario/_BuscarUsuario.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38b9653ba79f5c1eb68a49ccb66c409cb002f691", @"/Views/MDRol_Usuario/_BuscarUsuario.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"561f07006863b292c4b1ad1c4f4b063378af591d", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_MDRol_Usuario__BuscarUsuario : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<YMSweb.Data.Entities.MDUsuario>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-sm text-white"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<!-- Modal Usuario-->
<div class=""modal fade"" id=""modlUser"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""usuario"">Buscar Usuario</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">
                <div class=""container-fluid"">
                    <h1>Lista de Usuarios</h1>
                    <table id=""tbluser"" class=""table table-striped table-bordered"" style=""width: 100%"">
                        <thead>
                            <tr>
                                <th>
                                    ");
#nullable restore
#line 20 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                               Write(Html.DisplayNameFor(model => model.Usua_user));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 23 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                               Write(Html.DisplayNameFor(model => model.Usua_nombres));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 26 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                               Write(Html.DisplayNameFor(model => model.Usua_apellidos));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 29 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                               Write(Html.DisplayNameFor(model => model.Usua_email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 32 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                               Write(Html.DisplayNameFor(model => model.Usua_pass));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th>\r\n                                    ");
#nullable restore
#line 35 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                               Write(Html.DisplayNameFor(model => model.Usua_act));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </th>\r\n                                <th></th>\r\n                            </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
#nullable restore
#line 41 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                             foreach (var item in ViewBag.Usuario)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 45 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                                   Write(item.Usua_user);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 48 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                                   Write(item.Usua_nombres);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 51 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                                   Write(item.Usua_apellidos);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 54 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                                   Write(item.Usua_email);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 57 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                                   Write(item.Usua_pass);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 60 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                                   Write(item.Usua_act);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "38b9653ba79f5c1eb68a49ccb66c409cb002f69110533", async() => {
                WriteLiteral("Elegir");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 63 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                                                                                                      WriteLiteral(item.IdUsuario);

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
            WriteLiteral(" |                                        \r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 66 "D:\Proyectos Personales\PatioCamiones\YMSweb\YMSweb\YMSweb\Views\MDRol_Usuario\_BuscarUsuario.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>
                </div>
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                <button type=""button"" class=""btn btn-primary"">Save changes</button>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<YMSweb.Data.Entities.MDUsuario> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591