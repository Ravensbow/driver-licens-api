using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace api
{
    public static class WebApiConfig
    {
        public static MySqlConnection conn()
        {
            string conn_string = "Server=den1.mysql6.gear.host; Port=3306; Database=prawko; Uid=prawko; Pwd=placek.121";

            MySqlConnection conn = new MySqlConnection(conn_string);

            return conn;
        }
        public static void Register(HttpConfiguration config)
        {
            // Konfiguracja i usługi składnika Web API

            // Trasy składnika Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
