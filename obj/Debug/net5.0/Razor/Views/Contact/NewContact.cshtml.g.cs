#pragma checksum "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6caea83345d7bec3bc7cc0a09a9849f1ecc7bc96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contact_NewContact), @"mvc.1.0.view", @"/Views/Contact/NewContact.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6caea83345d7bec3bc7cc0a09a9849f1ecc7bc96", @"/Views/Contact/NewContact.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6372c5bd4dcff32bd9f84536dfd76204e26492ea", @"/Views/_ViewImports.cshtml")]
    public class Views_Contact_NewContact : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Contact>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
  
    var ContactGroups = ViewBag.ContactGroups != null ? ViewBag.ContactGroups as SelectList : null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"update-container\">\r\n    <div class=\"update-header\">\r\n        <h4><span class=\"icon-update-header fa fa-user-plus\" style=\"color: #008080\"> Kişi Oluşturma</span></h4>\r\n    </div>\r\n    <br />\r\n    <div id=\"newContactViewBag\">\r\n");
#nullable restore
#line 12 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
         if (ViewBag.Message != null)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <br /><span style=\"color:red;\">");
#nullable restore
#line 14 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                                      Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n");
#nullable restore
#line 15 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n    <br />\r\n    <div class=\"row\">\r\n        <div class=\"col-md-4\">\r\n            <div class=\"update-box\">\r\n");
#nullable restore
#line 21 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                 using (Html.BeginForm("NewContact", "Contact", FormMethod.Post, new { @id = "newContact" }))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"form-group \">\r\n                        ");
#nullable restore
#line 24 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                   Write(Html.LabelFor(n => n.Name, "İsim", new { @class = "mb-1 text-color" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 25 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                   Write(Html.TextBoxFor(n => n.Name, new { @class = "form-control", placeholder = "İsim giriniz", required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 28 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                   Write(Html.LabelFor(n => n.LastName, "Soyisim", new { @class = "mb-1 text-color" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 29 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                   Write(Html.TextBoxFor(n => n.LastName, new { @class = "form-control", placeholder = "Soyisim giriniz", required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 32 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                   Write(Html.LabelFor(n => n.Birthday, "Doğum Tarihi", new { @class = "mb-1 text-color" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <input type=\"date\" name=\"birthday\" id=\"birthday\" class=\"form-control date-time-picker\" required>\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 36 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                   Write(Html.LabelFor(n => n.EMail, "Mail", new { @class = "mb-1 text-color" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 37 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                   Write(Html.TextBoxFor(n => n.EMail, new { @class = "form-control", placeholder = "example@example.com", required = "required", type = "email" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                    <div class=\"form-group\">\r\n                        ");
#nullable restore
#line 40 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                   Write(Html.LabelFor(n => n.GroupId, "Grup", new { @class = "mb-1 text-color" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <div class=\"d-flex\">\r\n                            ");
#nullable restore
#line 42 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                       Write(Html.DropDownList("ContactGroups", new SelectList(ViewBag.ContactGroups, "GroupId", "Name"), "Grup Seçiniz...", new { @class = "form-control", required = "required" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            <button type=""button"" id=""newGroupBtn"" class=""ml-5 text-color"" data-toggle=""modal"" data-target=""#addGroupModal""><i class=""fa fa-plus mr-2"" aria-hidden=""true""></i> Yeni Grup</button>
                        </div>
                    </div>
                    <div class=""d-flex justify-content-between mt-2rem"">
                        <button type=""button"" class=""goBack btn"">Geri Dön</button>
                        <button class=""addNewContact btn"" type=""submit"">Kaydet</button>
                    </div>
");
#nullable restore
#line 50 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
    </div>
</div>

<div class=""modal fade"" id=""addGroupModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLabel"" style=""color: #008080"">Yeni Grup</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>

");
#nullable restore
#line 66 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
             using (Html.BeginForm("AddNewGroup", "Contact", FormMethod.Post, new { @id = "addNewGroup" }))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""modal-body"">
                    <div class=""form-group"">
                        <label for=""exampleInputEmail1"" style=""color: #008080"">Grup İsmi</label>
                        <input type=""text"" class=""form-control"" id=""name"" name=""name"" aria-describedby=""emailHelp"" placeholder=""Brolar.."">
                        <small id=""emailHelp"" class=""form-text text-muted"">Kendine özel grubunu oluştur.</small>
                    </div>
                </div>
                <div class=""modal-footer d-flex justify-content-between"">
                    <button type=""button"" class=""btn btn-sm"" data-dismiss=""modal"">Kapat</button>
                    <button type=""submit"" class=""btn btn-sm"">Kaydet</button>
                </div>
");
#nullable restore
#line 79 "C:\Users\Fatih\Desktop\projeyedek\Yeni klasör\MailBox.Web\MailBox.Web\Views\Contact\NewContact.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Contact> Html { get; private set; }
    }
}
#pragma warning restore 1591
