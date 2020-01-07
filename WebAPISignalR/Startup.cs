using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(WebAPISignalR.Startup))]
namespace WebAPISignalR
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var hubConfiguration = new HubConfiguration();
			app.Map("/signalr", map =>
			{
				map.UseCors(CorsOptions.AllowAll);

				//var connectionConfiguration = new ConnectionConfiguration
				//{
				//	EnableJSONP = true
				//};
				//map.RunSignalR<AuthenticatedConnection>(connectionConfiguration);

				//var hubConfiguration = new HubConfiguration { EnableJSONP = true };

				hubConfiguration.EnableJSONP = true;
				map.RunSignalR(hubConfiguration);
			});
			app.MapSignalR(hubConfiguration);
		}
	}
}