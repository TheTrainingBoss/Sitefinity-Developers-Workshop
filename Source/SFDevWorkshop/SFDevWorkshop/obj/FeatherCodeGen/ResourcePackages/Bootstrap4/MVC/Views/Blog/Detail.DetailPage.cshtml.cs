#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SFDevWorkshop.ResourcePackages.Bootstrap4.MVC.Views.Blog
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 3 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
    using Telerik.Sitefinity;
    
    #line default
    #line hidden
    
    #line 4 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
    using Telerik.Sitefinity.Frontend.Blogs.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 5 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
    using Telerik.Sitefinity.Frontend.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 6 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
    using Telerik.Sitefinity.Web.DataResolving;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/MVC/Views/Blog/Detail.DetailPage.cshtml")]
    public partial class Detail_DetailPage : System.Web.Mvc.WebViewPage<Telerik.Sitefinity.Frontend.Blogs.Mvc.Models.Blog.BlogDetailsViewModel>
    {
        public Detail_DetailPage()
        {
        }
        public override void Execute()
        {
WriteLiteral("\n<div");

WriteAttribute("class", Tuple.Create(" class=\"", 258), Tuple.Create("\"", 281)
            
            #line 8 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
, Tuple.Create(Tuple.Create("", 266), Tuple.Create<System.Object, System.Int32>(Model.CssClass
            
            #line default
            #line hidden
, 266), false)
);

WriteLiteral(" ");

            
            #line 8 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
                        Write(Html.InlineEditingAttributes(Model.ProviderName, Model.ContentType.FullName, (Guid)Model.Item.Fields.Id));

            
            #line default
            #line hidden
WriteLiteral(">\n    <h3>\n        <span ");

            
            #line 10 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
         Write(Html.InlineEditingFieldAttributes("Title", "ShortText"));

            
            #line default
            #line hidden
WriteLiteral(">");

            
            #line 10 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
                                                                  Write(Model.Item.Fields.Title);

            
            #line default
            #line hidden
WriteLiteral("</span>\n    </h3>\n\n    <p");

WriteLiteral(" class=\"text-muted\"");

WriteLiteral(">");

            
            #line 13 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
                     Write(string.Format(Html.Resource("PostsCount"), Model.PostsCount));

            
            #line default
            #line hidden
WriteLiteral("</p>\n");

            
            #line 14 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
    
            
            #line default
            #line hidden
            
            #line 14 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
      
        var lastPostDate = Model.Item.GetLastPostDate();
        if (lastPostDate!=null && lastPostDate.HasValue)
        {

            
            #line default
            #line hidden
WriteLiteral("            <p");

WriteLiteral(" class=\"text-muted\"");

WriteLiteral(">");

            
            #line 18 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
                             Write(Html.Resource("LastPost"));

            
            #line default
            #line hidden
WriteLiteral(" : ");

            
            #line 18 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
                                                          Write(lastPostDate.Value.ToShortDateString());

            
            #line default
            #line hidden
WriteLiteral(" </p>\n");

            
            #line 19 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
        }
    
            
            #line default
            #line hidden
WriteLiteral("\n\n    <div ");

            
            #line 22 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
    Write(Html.InlineEditingFieldAttributes("Description", "LongText"));

            
            #line default
            #line hidden
WriteLiteral(">");

            
            #line 22 "..\..MVC\Views\Blog\Detail.DetailPage.cshtml"
                                                                  Write(Html.HtmlSanitize((string)Model.Item.Fields.Description));

            
            #line default
            #line hidden
WriteLiteral("</div>\n</div>");

        }
    }
}
#pragma warning restore 1591
