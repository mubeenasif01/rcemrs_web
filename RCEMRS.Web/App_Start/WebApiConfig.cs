using RCEMRS.Web.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RCEMRS.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.SuppressHostPrincipal();
            
            //Enable Cross-Origin Requesst 
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

           // config.Filters.Add(new BasicAuthFilterAttribute());
            config.Filters.Add(new MyAuthenticateFilter());

            config.Filters.Add(new AuthorizeAttribute());
            // Web API routes
            config.MapHttpAttributeRoutes();
            

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
