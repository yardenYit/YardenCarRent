using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace _03_Website
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
           
            // Web API routes
            config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute(
        //     name: "CarFleetApi",
        //     routeTemplate: "api/{controller}/{action}/{carFleetID}"
        //);

            config.Routes.MapHttpRoute(
               name: "ActionApi",
               routeTemplate: "api/{controller}/{action}"
               //defaults: new { id = RouteParameter.Optional }
           );

            config.Routes.MapHttpRoute(
               name: "CheckUserApi",
               routeTemplate: "api/{controller}/{action}/{userName}"
          );



            config.Routes.MapHttpRoute(
                 name: "AddUserApi",
                 routeTemplate: "api/{controller}/{action}/{userName}/{password}/{firstName}/{lastName}/{identityNumber}/{email}/{birthDate}/{roleId}"
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
          
           
        }
    }
}
