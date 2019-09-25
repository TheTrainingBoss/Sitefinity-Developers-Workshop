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

namespace SFDevWorkshop.ResourcePackages.Bootstrap4.MVC.Views.VideoGallery
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
    
    #line 3 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
    using Telerik.Sitefinity;
    
    #line default
    #line hidden
    
    #line 4 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
    using Telerik.Sitefinity.Frontend.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 5 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
    using Telerik.Sitefinity.Web.DataResolving;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/MVC/Views/VideoGallery/Detail.Default.cshtml")]
    public partial class Detail_Default : System.Web.Mvc.WebViewPage<Telerik.Sitefinity.Frontend.Media.Mvc.Models.VideoGallery.VideoDetailsViewModel>
    {
        public Detail_Default()
        {
        }
        public override void Execute()
        {
WriteLiteral("\n<div");

WriteAttribute("class", Tuple.Create(" class=\"", 213), Tuple.Create("\"", 236)
            
            #line 7 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
, Tuple.Create(Tuple.Create("", 221), Tuple.Create<System.Object, System.Int32>(Model.CssClass
            
            #line default
            #line hidden
, 221), false)
);

WriteLiteral(" ");

            
            #line 7 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                        Write(Html.InlineEditingAttributes(Model.ProviderName, Model.ContentType.FullName, (Guid)Model.Item.Fields.Id));

            
            #line default
            #line hidden
WriteLiteral(">\n    <figure");

WriteAttribute("aria-labelledby", Tuple.Create(" aria-labelledby=\"", 356), Tuple.Create("\"", 402)
            
            #line 8 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
, Tuple.Create(Tuple.Create("", 374), Tuple.Create<System.Object, System.Int32>(Html.UniqueId("VideoTitle")
            
            #line default
            #line hidden
, 374), false)
);

WriteLiteral(">\n        <figcaption");

WriteLiteral(" class=\"h2\"");

WriteAttribute("id", Tuple.Create("  id=\"", 435), Tuple.Create("\"", 469)
            
            #line 9 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
, Tuple.Create(Tuple.Create("", 441), Tuple.Create<System.Object, System.Int32>(Html.UniqueId("VideoTitle")
            
            #line default
            #line hidden
, 441), false)
);

WriteLiteral(" ");

            
            #line 9 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                                                             Write(Html.InlineEditingFieldAttributes("Title", "ShortText"));

            
            #line default
            #line hidden
WriteLiteral(">");

            
            #line 9 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                                                                                                                      Write(Model.Item.Fields.Title);

            
            #line default
            #line hidden
WriteLiteral("</figcaption>\n        <div");

WriteLiteral(" class=\"text-muted\"");

WriteLiteral(">\n            <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">");

            
            #line 11 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                             Write(Html.Resource("VideoTakenOn"));

            
            #line default
            #line hidden
WriteLiteral(" </span>\n");

WriteLiteral("            ");

            
            #line 12 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
       Write(Model.Item.GetDateTime("PublicationDate", "MMM d, yyyy, HH:mm tt"));

            
            #line default
            #line hidden
WriteLiteral("\n");

WriteLiteral("            ");

            
            #line 13 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
       Write(Html.Resource("By"));

            
            #line default
            #line hidden
WriteLiteral("\n");

WriteLiteral("            ");

            
            #line 14 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
       Write(DataResolver.Resolve(@Model.Item.DataItem, "Author", null));

            
            #line default
            #line hidden
WriteLiteral("\n        </div>\n        <p ");

            
            #line 16 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
      Write(Html.InlineEditingFieldAttributes("Description", "LongText"));

            
            #line default
            #line hidden
WriteLiteral(" id=\'");

            
            #line 16 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                                                                        Write(Html.UniqueId("VideoInfo"));

            
            #line default
            #line hidden
WriteLiteral("\'>");

            
            #line 16 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                                                                                                     Write(Html.HtmlSanitize((string)Model.Item.Fields.Description));

            
            #line default
            #line hidden
WriteLiteral("</p>        \n        <video");

WriteAttribute("src", Tuple.Create(" src=\"", 1062), Tuple.Create("\"", 1093)
            
            #line 17 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
, Tuple.Create(Tuple.Create("", 1068), Tuple.Create<System.Object, System.Int32>(Html.Raw(Model.MediaUrl)
            
            #line default
            #line hidden
, 1068), false)
);

WriteLiteral(" controls=\"controls\"");

WriteAttribute("width", Tuple.Create(" width=\"", 1114), Tuple.Create("\"", 1134)
            
            #line 17 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
, Tuple.Create(Tuple.Create("", 1122), Tuple.Create<System.Object, System.Int32>(Model.Width
            
            #line default
            #line hidden
, 1122), false)
);

WriteAttribute("height", Tuple.Create(" height=\"", 1135), Tuple.Create("\"", 1157)
            
            #line 17 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                , Tuple.Create(Tuple.Create("", 1144), Tuple.Create<System.Object, System.Int32>(Model.Height
            
            #line default
            #line hidden
, 1144), false)
);

WriteAttribute("aria-labelledby", Tuple.Create(" aria-labelledby=\'", 1158), Tuple.Create("\'", 1204)
            
            #line 17 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                                                , Tuple.Create(Tuple.Create("", 1176), Tuple.Create<System.Object, System.Int32>(Html.UniqueId("VideoTitle")
            
            #line default
            #line hidden
, 1176), false)
);

WriteAttribute("aria-describedby", Tuple.Create(" aria-describedby=\'", 1205), Tuple.Create("\'", 1251)
            
            #line 17 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                                                                                                , Tuple.Create(Tuple.Create("", 1224), Tuple.Create<System.Object, System.Int32>(Html.UniqueId("VideoInfo")
            
            #line default
            #line hidden
, 1224), false)
);

WriteLiteral("></video>\n    </figure>\n");

            
            #line 19 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
    
            
            #line default
            #line hidden
            
            #line 19 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
     if (ViewBag.ItemIndex != null)
    {

            
            #line default
            #line hidden
WriteLiteral("        <nav");

WriteLiteral(" role=\"navigation\"");

WriteAttribute("aria-label", Tuple.Create(" aria-label=\"", 1348), Tuple.Create("\"", 1396)
            
            #line 21 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
, Tuple.Create(Tuple.Create("", 1361), Tuple.Create<System.Object, System.Int32>(Html.Resource("PreviousNextVideo")
            
            #line default
            #line hidden
, 1361), false)
);

WriteLiteral(" class=\"text-center clearfix\"");

WriteLiteral(">\n");

            
            #line 22 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
            
            
            #line default
            #line hidden
            
            #line 22 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
              
                var previousItemIndex = ViewBag.ItemIndex == 1 ? Model.TotalItemsCount : ViewBag.ItemIndex - 1;
                var nextItemIndex = ViewBag.ItemIndex == Model.TotalItemsCount ? 1 : ViewBag.ItemIndex + 1;
            
            
            #line default
            #line hidden
WriteLiteral("\n\n");

            
            #line 27 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
            
            
            #line default
            #line hidden
            
            #line 27 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
             if (Model.PreviousItem != null) 
            {

            
            #line default
            #line hidden
WriteLiteral("                <a");

WriteLiteral(" class=\"sf-Gallery-prev--simple\"");

WriteAttribute("aria-label", Tuple.Create(" aria-label=\"", 1788), Tuple.Create("\"", 1836)
            
            #line 29 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
, Tuple.Create(Tuple.Create("", 1801), Tuple.Create<System.Object, System.Int32>(Html.Resource("GoToPreviousVideo")
            
            #line default
            #line hidden
, 1801), false)
);

WriteAttribute("href", Tuple.Create(" href=\"", 1837), Tuple.Create("\"", 1986)
            
            #line 29 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                          , Tuple.Create(Tuple.Create("", 1844), Tuple.Create<System.Object, System.Int32>(HyperLinkHelpers.GetDetailPageUrl(Model.PreviousItem, ViewBag.DetailsPageId, ViewBag.OpenInSamePage, ViewBag.UrlKeyPrefix, previousItemIndex)
            
            #line default
            #line hidden
, 1844), false)
);

WriteLiteral(">\n");

WriteLiteral("                    ");

            
            #line 30 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
               Write(Html.Resource("PreviousVideo"));

            
            #line default
            #line hidden
WriteLiteral("\n                </a>\n");

            
            #line 32 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("\n");

            
            #line 34 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
            
            
            #line default
            #line hidden
            
            #line 34 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
             if (Model.PreviousItem != null || Model.NextItem != null)
            {
                
            
            #line default
            #line hidden
            
            #line 36 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
           Write(Html.HtmlSanitize((string)string.Format(Html.Resource("IndexOfTotal"), ViewBag.ItemIndex, Model.TotalItemsCount)));

            
            #line default
            #line hidden
            
            #line 36 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                                                                                                                                  ;
            }

            
            #line default
            #line hidden
WriteLiteral("\n");

            
            #line 39 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
            
            
            #line default
            #line hidden
            
            #line 39 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
             if (Model.NextItem != null) 
            {

            
            #line default
            #line hidden
WriteLiteral("                <a");

WriteLiteral(" class=\"sf-Gallery-next--simple\"");

WriteAttribute("aria-label", Tuple.Create(" aria-label=\"", 2415), Tuple.Create("\"", 2459)
            
            #line 41 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
, Tuple.Create(Tuple.Create("", 2428), Tuple.Create<System.Object, System.Int32>(Html.Resource("GoToNextVideo")
            
            #line default
            #line hidden
, 2428), false)
);

WriteAttribute("href", Tuple.Create(" href=\"", 2460), Tuple.Create("\"", 2601)
            
            #line 41 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                      , Tuple.Create(Tuple.Create("", 2467), Tuple.Create<System.Object, System.Int32>(HyperLinkHelpers.GetDetailPageUrl(Model.NextItem, ViewBag.DetailsPageId, ViewBag.OpenInSamePage, ViewBag.UrlKeyPrefix, nextItemIndex)
            
            #line default
            #line hidden
, 2467), false)
);

WriteLiteral(">\n");

WriteLiteral("                    ");

            
            #line 42 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
               Write(Html.Resource("NextVideo"));

            
            #line default
            #line hidden
WriteLiteral("\n                </a>\n");

            
            #line 44 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
            }

            
            #line default
            #line hidden
WriteLiteral("        </nav>\n");

            
            #line 46 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"

        
            
            #line default
            #line hidden
            
            #line 47 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
   Write(Html.ActionLink(Html.Resource("BackToAllVideos"), "Index"));

            
            #line default
            #line hidden
            
            #line 47 "..\..MVC\Views\VideoGallery\Detail.Default.cshtml"
                                                                   
    }

            
            #line default
            #line hidden
WriteLiteral("</div>");

        }
    }
}
#pragma warning restore 1591
