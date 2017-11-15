using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrungTamYenMy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "Tin tuc moi",
              url: "tin-moi/{Id}",
              defaults: new { controller = "TinTuc", action = "TinTucMoiPartial", id = UrlParameter.Optional },
              namespaces: new[] { "TrungTamYenMy.Controllers" }
          );

            routes.MapRoute(
             name: "Lop hoc",
            url: "lop-hoc/{metatitle}-{id}",
             defaults: new { controller = "LopHoc", action = "ChiTietLopHoc", id = UrlParameter.Optional },
             namespaces: new[] { "TrungTamYenMy.Controllers" }
         );

            routes.MapRoute(
             name: "Khoi hoc",
            url: "khoi-hoc/{metatitle}-{id}",
             defaults: new { controller = "LopHoc", action = "KhoiHoc", id = UrlParameter.Optional },
             namespaces: new[] { "TrungTamYenMy.Controllers" }
         );

            routes.MapRoute(
             name: "Tim kiem",
            url: "tim-kiem",
             defaults: new { controller = "LopHoc", action = "TimKiem", id = UrlParameter.Optional },
             namespaces: new[] { "TrungTamYenMy.Controllers" }
         );

            routes.MapRoute(
                 //name: "Default",
                 //url: "{controller}/{action}/{id}",
                 //defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                 name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces:
            new[] { "TrungTamYenMy.Controllers" }
            );

        }
    }
}
