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

namespace SFDevWorkshop.ResourcePackages.Bootstrap4.MVC.Views.Layouts
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    
    #line 1 "..\..MVC\Views\Layouts\default.cshtml"
    using System.Web.Mvc;
    
    #line default
    #line hidden
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 2 "..\..MVC\Views\Layouts\default.cshtml"
    using Telerik.Sitefinity.Frontend.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 3 "..\..MVC\Views\Layouts\default.cshtml"
    using Telerik.Sitefinity.Modules.Pages;
    
    #line default
    #line hidden
    
    #line 5 "..\..MVC\Views\Layouts\default.cshtml"
    using Telerik.Sitefinity.Services;
    
    #line default
    #line hidden
    
    #line 4 "..\..MVC\Views\Layouts\default.cshtml"
    using Telerik.Sitefinity.UI.MVC;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/MVC/Views/Layouts/default.cshtml")]
    public partial class @default : System.Web.Mvc.WebViewPage<dynamic>
    {
        public @default()
        {
        }
        public override void Execute()
        {
WriteLiteral("\n<!DOCTYPE html>\n<html ");

            
            #line 8 "..\..MVC\Views\Layouts\default.cshtml"
 Write(Html.RenderLangAttribute());

            
            #line default
            #line hidden
WriteLiteral(">\n<head>\n    <meta");

WriteLiteral(" charset=\"utf-8\"");

WriteLiteral(" />\n    <title></title>\n\n");

WriteLiteral("    ");

            
            #line 13 "..\..MVC\Views\Layouts\default.cshtml"
Write(Html.Section("head"));

            
            #line default
            #line hidden
WriteLiteral("\n");

WriteLiteral("    ");

            
            #line 14 "..\..MVC\Views\Layouts\default.cshtml"
Write(Html.StyleSheet(Url.WidgetContent("~/ResourcePackages/Bootstrap4/assets/dist/css/main.min.css"), "head", true));

            
            #line default
            #line hidden
WriteLiteral("\n</head>\n\n<body>\n");

WriteLiteral("    ");

            
            #line 18 "..\..MVC\Views\Layouts\default.cshtml"
Write(Html.Section("top"));

            
            #line default
            #line hidden
WriteLiteral("\n\n    <div>\n");

WriteLiteral("        ");

            
            #line 21 "..\..MVC\Views\Layouts\default.cshtml"
   Write(Html.SfPlaceHolder("Contentplaceholder1"));

            
            #line default
            #line hidden
WriteLiteral("\n    </div>\n\n    ");

WriteLiteral("\n");

WriteLiteral("    ");

            
            #line 25 "..\..MVC\Views\Layouts\default.cshtml"
Write(Html.Section("inline-editing"));

            
            #line default
            #line hidden
WriteLiteral("\n");

            
            #line 26 "..\..MVC\Views\Layouts\default.cshtml"
    
            
            #line default
            #line hidden
            
            #line 26 "..\..MVC\Views\Layouts\default.cshtml"
     if (Html.ShouldRenderInlineEditing())
    {
        
            
            #line default
            #line hidden
            
            #line 28 "..\..MVC\Views\Layouts\default.cshtml"
   Write(Html.Script(ScriptRef.MicrosoftAjax, "inline-editing", true));

            
            #line default
            #line hidden
            
            #line 28 "..\..MVC\Views\Layouts\default.cshtml"
                                                                     
        
            
            #line default
            #line hidden
            
            #line 29 "..\..MVC\Views\Layouts\default.cshtml"
   Write(Html.Script(ScriptRef.MicrosoftAjaxCore, "inline-editing", true));

            
            #line default
            #line hidden
            
            #line 29 "..\..MVC\Views\Layouts\default.cshtml"
                                                                         
        
            
            #line default
            #line hidden
            
            #line 30 "..\..MVC\Views\Layouts\default.cshtml"
   Write(Html.Script(ScriptRef.JQuery, "inline-editing", true));

            
            #line default
            #line hidden
            
            #line 30 "..\..MVC\Views\Layouts\default.cshtml"
                                                              

        
            
            #line default
            #line hidden
            
            #line 32 "..\..MVC\Views\Layouts\default.cshtml"
   Write(Html.Script(Url.EmbeddedResource("Telerik.Sitefinity.Resources.Reference", "Telerik.Sitefinity.Resources.Scripts.jquery.ba-outside-events.min.js"), "inline-editing", true));

            
            #line default
            #line hidden
            
            #line 32 "..\..MVC\Views\Layouts\default.cshtml"
                                                                                                                                                                                    
        
            
            #line default
            #line hidden
            
            #line 33 "..\..MVC\Views\Layouts\default.cshtml"
   Write(Html.Script(ScriptRef.KendoAll, "inline-editing", true));

            
            #line default
            #line hidden
            
            #line 33 "..\..MVC\Views\Layouts\default.cshtml"
                                                                
        
            
            #line default
            #line hidden
            
            #line 34 "..\..MVC\Views\Layouts\default.cshtml"
   Write(Html.Script(ScriptRef.KendoTimezones, "inline-editing", true));

            
            #line default
            #line hidden
            
            #line 34 "..\..MVC\Views\Layouts\default.cshtml"
                                                                      
        
            
            #line default
            #line hidden
            
            #line 35 "..\..MVC\Views\Layouts\default.cshtml"
   Write(Html.Script(Url.EmbeddedResource("Telerik.Sitefinity.Resources.Reference", "Telerik.Sitefinity.Resources.Scripts.RequireJS.require.min.js"), "inline-editing", true));

            
            #line default
            #line hidden
            
            #line 35 "..\..MVC\Views\Layouts\default.cshtml"
                                                                                                                                                                             
        
            
            #line default
            #line hidden
            
            #line 36 "..\..MVC\Views\Layouts\default.cshtml"
   Write(Html.InlineEditingManager(false));

            
            #line default
            #line hidden
            
            #line 36 "..\..MVC\Views\Layouts\default.cshtml"
                                         
    }

            
            #line default
            #line hidden
WriteLiteral("    ");

            
            #line 38 "..\..MVC\Views\Layouts\default.cshtml"
Write(Html.Section("bottom"));

            
            #line default
            #line hidden
WriteLiteral("\n</body>\n</html>\n");

        }
    }
}
#pragma warning restore 1591
