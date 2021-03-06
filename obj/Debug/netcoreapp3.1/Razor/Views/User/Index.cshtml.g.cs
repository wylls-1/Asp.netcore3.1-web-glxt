#pragma checksum "D:\code\c++\data\WebHomework\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bd4e5589ac09c6549ef9166859ae772035bb12a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
#line 1 "D:\code\c++\data\WebHomework\Views\_ViewImports.cshtml"
using WebHomework;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\code\c++\data\WebHomework\Views\_ViewImports.cshtml"
using WebHomework.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd4e5589ac09c6549ef9166859ae772035bb12a3", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0513c8cd19dec1f136246739c5e79fbed96061ee", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Employee>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""tab-pane active"">
    <table class=""table table-hover "">
        <caption>个人信息</caption>
        <thead>
            <tr>
                <th>工号</th>
                <th>姓名</th>
                <th>工作状态</th>
                <th>入职时间</th>
                <th>工作岗位</th>
                <th>职务</th>
                <th>部门编号</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>");
#nullable restore
#line 22 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
               Write(Model.EmpId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
               Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 24 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
               Write(Model.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
               Write(Model.WorkStart);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
               Write(Model.Job);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 27 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
               Write(Model.Position);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
               Write(Model.DepId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
            </tr>
        </tbody>

    </table>


    <div class=""form-group"">
        <label>申请离职理由：</label>
        <input type=""text"" class=""col-auto input-group"" id=""lz"" placeholder=""工资太少"">
        <button onclick=""btnOn1()"" class=""btn btn-primary"" id=""btn1"" disabled=""disabled"">申请</button>
    </div>
    <div class=""form-group"">
        <label>申请退休理由：</label>
        <input type=""text"" class=""col-auto input-group"" id=""tx"" placeholder=""工资太少"">
        <button onclick=""btnOn2()"" class=""btn btn-primary""id=""btn2"" disabled=""disabled"">申请</button>
    </div>
    <div class=""form-group"">
        <label>申请调动部门：</label>
        <input type=""text"" class=""col-auto input-group"" id=""ddbm"" placeholder=""001"">
        <button onclick=""btnOn3()"" class=""btn btn-primary""id=""btn3"" disabled=""disabled"">申请</button>
    </div>
</div>

<script type=""text/javascript"">
    window.onload = function () {
        this.document.getElementById(""loginIndex"").text = """);
#nullable restore
#line 54 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
                                                      Write(Model.EmpId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""";
        $('#btn1').attr(""disabled"", false);
        $('#btn2').attr(""disabled"", false);
        $('#btn3').attr(""disabled"", false);
    }
    function btnOn1() {
          $.ajax({
            url: ""/user/departure"",
            data: { ""name1"":document.getElementById(""lz"").value,""id"":""");
#nullable restore
#line 62 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
                                                                 Write(Model.EmpId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" },
            type: ""post"",
            dataType: ""text"",
            success: function (res) {
                if (res == ""ok"") {
                    alert(""申请成功，请等待管理员批准！"");
                    document.getElementById('btn1').disabled = ""disabled"";
                }
                else if (res == ""4"") {
                    alert(""你已经离职！"");
                }
                else if (res == ""6"") {
                    alert(""你已经退休！"");
                }
            }
        });
    }
    function btnOn2() {
        $.ajax({
            url: ""/user/retired"",
            data: { ""name2"":document.getElementById(""tx"").value,""id"":""");
#nullable restore
#line 82 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
                                                                 Write(Model.EmpId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" },
            type: ""post"",
            dataType: ""text"",
            success: function (res) {
                if (res == ""ok"") {
                    alert(""申请成功，请等待管理员批准！"");
                    document.getElementById(""btn2"").disabled = true; 
                }
                else if (res == ""4"") {
                    alert(""你已经离职！"");
                }
                else if (res == ""6"") {
                    alert(""你已经退休！"");
                }
            }
        });
    }
    function btnOn3() {
        $.ajax({
            url: ""/user/move"",
            data: { ""name3"":document.getElementById(""ddbm"").value,""id"":""");
#nullable restore
#line 102 "D:\code\c++\data\WebHomework\Views\User\Index.cshtml"
                                                                   Write(Model.EmpId);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""" },
            type: ""post"",
            dataType: ""text"",
            success: function (res) {
                if (res == ""ok"") {
                    alert(""申请成功，请等待管理员批准！"");
                    document.getElementById(""btn3"").disabled = true; 
                }
                else if (res == ""4"") {
                    alert(""你已经离职！"");
                }
                else if (res == ""6"") {
                    alert(""你已经退休！"");
                }
                else {
                    alert(""申请失败，部门输入有误！"");
                }
            }
        });
        }
</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Employee> Html { get; private set; }
    }
}
#pragma warning restore 1591
