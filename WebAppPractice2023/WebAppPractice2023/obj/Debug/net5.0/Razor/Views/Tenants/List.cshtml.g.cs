#pragma checksum "D:\!Files\Documents\ProgLabsVisualStudio\Practice\WebAppPractice2023\WebAppPractice2023\Views\Tenants\List.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "febbef255656cbcc789e5023483d9c772ec26f1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tenants_List), @"mvc.1.0.view", @"/Views/Tenants/List.cshtml")]
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
#line 1 "D:\!Files\Documents\ProgLabsVisualStudio\Practice\WebAppPractice2023\WebAppPractice2023\Views\_ViewImports.cshtml"
using WebAppPractice2023.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"febbef255656cbcc789e5023483d9c772ec26f1e", @"/Views/Tenants/List.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52609d868beda76ff20d1ca88326717a7ab12074", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Tenants_List : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h1>Список всех арендаторов</h1>\r\n");
#nullable restore
#line 2 "D:\!Files\Documents\ProgLabsVisualStudio\Practice\WebAppPractice2023\WebAppPractice2023\Views\Tenants\List.cshtml"
  
    foreach(var tenant in Model.AllTenants)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div>\r\n        <h2>ФИО: ");
#nullable restore
#line 6 "D:\!Files\Documents\ProgLabsVisualStudio\Practice\WebAppPractice2023\WebAppPractice2023\Views\Tenants\List.cshtml"
            Write(tenant.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 6 "D:\!Files\Documents\ProgLabsVisualStudio\Practice\WebAppPractice2023\WebAppPractice2023\Views\Tenants\List.cshtml"
                            Write(tenant.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 6 "D:\!Files\Documents\ProgLabsVisualStudio\Practice\WebAppPractice2023\WebAppPractice2023\Views\Tenants\List.cshtml"
                                         Write(tenant.Patronymic);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n        <p>Номер телефона: ");
#nullable restore
#line 7 "D:\!Files\Documents\ProgLabsVisualStudio\Practice\WebAppPractice2023\WebAppPractice2023\Views\Tenants\List.cshtml"
                      Write(tenant.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>Почта: ");
#nullable restore
#line 8 "D:\!Files\Documents\ProgLabsVisualStudio\Practice\WebAppPractice2023\WebAppPractice2023\Views\Tenants\List.cshtml"
             Write(tenant.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n");
#nullable restore
#line 10 "D:\!Files\Documents\ProgLabsVisualStudio\Practice\WebAppPractice2023\WebAppPractice2023\Views\Tenants\List.cshtml"
    }

#line default
#line hidden
#nullable disable
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
