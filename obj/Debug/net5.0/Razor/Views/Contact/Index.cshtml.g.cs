#pragma checksum "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dc657dfc583d77ed7ef872c9374672d925f7d211"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_Index), @"mvc.1.0.view", @"/Views/Contact/Index.cshtml")]
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
#line 1 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\_ViewImports.cshtml"
using MailBox.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\_ViewImports.cshtml"
using MailBox.Web.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\_ViewImports.cshtml"
using MailBoxEntity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dc657dfc583d77ed7ef872c9374672d925f7d211", @"/Views/Contact/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6372c5bd4dcff32bd9f84536dfd76204e26492ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<MailBoxEntity.Contact>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Contact/NewContact"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("urlList"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control ml-3 w-auto"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc657dfc583d77ed7ef872c9374672d925f7d2114919", async() => {
                WriteLiteral("<i class=\"fa fa-user-plus\"></i> Yeni Kişi Oluştur");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n<button type=\"button\" class=\"btn btn-sm\"");
            BeginWriteAttribute("onclick", " onclick=\"", 183, "\"", 267, 2);
#nullable restore
#line 4 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
WriteAttributeValue("", 193, "window.location.href='"+Url.Action("SendMailToContact","Contact")+"'", 193, 73, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 266, ";", 266, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-envelope\"></i> Yeni Mail</button>\r\n<br />\r\n<br />\r\n<div class=\"d-flex mb-3\">\r\n");
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dc657dfc583d77ed7ef872c9374672d925f7d2116810", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
#nullable restore
#line 9 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = (new SelectList(@ViewBag.Groups,"GroupId","Name"));

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<div class=""list-table"">
    <table class=""contact-table table"" id=""contactTable"">
        <thead>
            <tr role=""row"">
                <th class=""sorting"" tabindex=""0"" aria-controls=""tbl1"" aria-sort=""ascending"" aria-label=""Ad"">Ad</th>
                <th class=""sorting"" tabindex=""0"" aria-controls=""tbl1"" aria-sort=""ascending"" aria-label=""Soyad"">Soyad</th>
                <th class=""sorting"" tabindex=""0"" aria-controls=""tbl1"" aria-sort=""ascending"" aria-label=""DogumGunu"">Doğum Günü</th>
                <th class=""sorting"" tabindex=""0"" aria-controls=""tbl1"" aria-sort=""ascending"" aria-label=""EMail"">E-Mail</th>
                <th></th>
                <th></th>
            </tr>
        </thead>
        <tbody id=""search_Input"">
");
#nullable restore
#line 24 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
             if (Model != null)
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr role=\"row\">\r\n                        <td>");
#nullable restore
#line 29 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 30 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
                       Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 31 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
                       Write(item.Birthday.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 32 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
                       Write(item.EMail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td style=\"text-align:center\"><button class=\"btn btn-sm\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1778, "\"", 1890, 1);
#nullable restore
#line 33 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
WriteAttributeValue("", 1788, "window.location.href='" + @Url.Action("Update", "Contact", new {contactId =item.ContactId})  + "'", 1788, 102, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-edit\"></i> Güncelle</button></td>\r\n                        <td style=\"text-align:center\"><button type=\"button\" data-model-id=\"");
#nullable restore
#line 34 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
                                                                                      Write(item.ContactId);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"deleteRecord btn btn-sm\"><i class=\"fa fa-trash-o\"></i> Sil</button></td>\r\n                    </tr>\r\n");
#nullable restore
#line 36 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\Index.cshtml"
                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<MailBoxEntity.Contact>> Html { get; private set; }
    }
}
#pragma warning restore 1591
