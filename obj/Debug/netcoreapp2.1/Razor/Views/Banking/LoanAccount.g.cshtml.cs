#pragma checksum "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\Banking\LoanAccount.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd9596c6cffe314f5e2aa7fe8ff34ae7a90f20aa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Banking_LoanAccount), @"mvc.1.0.view", @"/Views/Banking/LoanAccount.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Banking/LoanAccount.cshtml", typeof(AspNetCore.Views_Banking_LoanAccount))]
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
#line 1 "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\_ViewImports.cshtml"
using NetBankDB;

#line default
#line hidden
#line 2 "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\_ViewImports.cshtml"
using NetBankDB.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd9596c6cffe314f5e2aa7fe8ff34ae7a90f20aa", @"/Views/Banking/LoanAccount.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef3947caf98c4a75bb9326966da7ebf184ba7f4e", @"/Views/_ViewImports.cshtml")]
    public class Views_Banking_LoanAccount : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NetBankDB.Models.Accounts>
    {
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(34, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\Banking\LoanAccount.cshtml"
  
    ViewBag.Title = "New Loan Account";

#line default
#line hidden
            BeginContext(84, 47, true);
            WriteLiteral("\r\n<h2>Opening Your New Loan Account...</h2>\r\n\r\n");
            EndContext();
#line 9 "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\Banking\LoanAccount.cshtml"
 using (Html.BeginForm("LoanAccount", "Banking", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
{
    

#line default
#line hidden
            BeginContext(258, 23, false);
#line 11 "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\Banking\LoanAccount.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(283, 344, true);
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-md-4"">
            <p align=""justify"">
                We offer several Loan Account options, which allows you to take out even more money than a Business Account would.
                Our loan packages are offered at competitive interest rates!
            </p>
        </div>
    </div>
");
            EndContext();
            BeginContext(629, 59, true);
            WriteLiteral("    <div class=\"form-horizontal\">\r\n        <hr />\r\n        ");
            EndContext();
            BeginContext(689, 64, false);
#line 23 "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\Banking\LoanAccount.cshtml"
   Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(753, 12, true);
            WriteLiteral("\r\n\r\n        ");
            EndContext();
            BeginContext(765, 33, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6c89bf3820b94247853efe965163d08a", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 25 "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\Banking\LoanAccount.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.userID);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(798, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(808, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "d172f8b7bb144d28ab4b0482d8a9f058", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 26 "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\Banking\LoanAccount.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.dateCreated);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(846, 10, true);
            WriteLiteral("\r\n        ");
            EndContext();
            BeginContext(856, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b2fdecf0bb6540cbba8732a3bee07b13", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 27 "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\Banking\LoanAccount.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.accountType);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("hidden", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(894, 622, true);
            WriteLiteral(@"

        <label class=""control-label"">What Type of Loan Would You Like to Take Out</label> <br />
        <input type=""radio"" value=""1"" name=""accountChoice"" /> $20000 with a 2.5% Annual Rate <br />
        <input type=""radio"" value=""2"" name=""accountChoice"" /> $50000 with a 5.5% Annual Rate <br />
        <input type=""radio"" value=""3"" name=""accountChoice"" /> $100000 with a 11% Annual Rate <br />
        <span class=""text-danger""></span>

        <br />

        <div class=""form-group"">
            <input type=""submit"" value=""Create"" class=""btn btn-default"" />
            <button class=""btn btn-default"">");
            EndContext();
            BeginContext(1517, 84, false);
#line 39 "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\Banking\LoanAccount.cshtml"
                                       Write(Html.ActionLink("Main Menu", "MainMenu", "MainMenu", new { userID = @Model.userID }));

#line default
#line hidden
            EndContext();
            BeginContext(1601, 39, true);
            WriteLiteral("</button>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 42 "C:\Users\PhoenixxKing\source\repos\NetBankDB\Views\Banking\LoanAccount.cshtml"
}

#line default
#line hidden
            BeginContext(1643, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NetBankDB.Models.Accounts> Html { get; private set; }
    }
}
#pragma warning restore 1591
