#pragma checksum "C:\Users\Admin\Documents\GitHub\SecretSanta\SecretSanta\Views\Participants\showList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93f8672140c2eeb25e8fdcaafd2abcc89d09a5aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Participants_showList), @"mvc.1.0.view", @"/Views/Participants/showList.cshtml")]
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
#line 1 "C:\Users\Admin\Documents\GitHub\SecretSanta\SecretSanta\Views\_ViewImports.cshtml"
using SecretSanta;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Documents\GitHub\SecretSanta\SecretSanta\Views\_ViewImports.cshtml"
using SecretSanta.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93f8672140c2eeb25e8fdcaafd2abcc89d09a5aa", @"/Views/Participants/showList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64c616273d179cdb30bcf39567bef62689d6be9a", @"/Views/_ViewImports.cshtml")]
    public class Views_Participants_showList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SecretSanta.Models.Participants>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Admin\Documents\GitHub\SecretSanta\SecretSanta\Views\Participants\showList.cshtml"
  
    ViewData["Title"] = "List of participants";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h3>You're participants added successfully</h3>
<br />
<style>
    table {
        width: 100%;
    }

    table, th, td {
        border: 1px solid red;
        border-collapse: collapse;
    }

    th, td {
        padding: 15px;
        text-align: left;
    }

    th {
        background-color: red;
        color: white;
    }
</style>
<table>
    <tr style=""border:1px solid red; margin:5px;"">
        <th>Name</th>
        <th>Email</th>
    </tr>
");
#nullable restore
#line 34 "C:\Users\Admin\Documents\GitHub\SecretSanta\SecretSanta\Views\Participants\showList.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr style=\"border:1px solid red; margin:5px;\">\r\n            <td>");
#nullable restore
#line 37 "C:\Users\Admin\Documents\GitHub\SecretSanta\SecretSanta\Views\Participants\showList.cshtml"
           Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 38 "C:\Users\Admin\Documents\GitHub\SecretSanta\SecretSanta\Views\Participants\showList.cshtml"
           Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 40 "C:\Users\Admin\Documents\GitHub\SecretSanta\SecretSanta\Views\Participants\showList.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n<input type=\'button\' value=\'Generate Secret Santa\' id=\'myButton\' onClick=\'redirectOnClick()\' />\r\n<script>\r\n    function redirectOnClick() {\r\n        document.location = \'Generate\';\r\n    }\r\n</script>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SecretSanta.Models.Participants>> Html { get; private set; }
    }
}
#pragma warning restore 1591