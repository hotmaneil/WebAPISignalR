using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPISignalR
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			var domainname = ConfigurationManager.AppSettings["domainname"] + ",http://localhost:8080/";
			var corsAttr = new EnableCorsAttribute(domainname, "*", "*");
			config.EnableCors();

			// Web API 設定和服務

			// Web API 路由
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}
}
