using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(WebAPISignalR.Startup))]
namespace WebAPISignalR
{
	/// <summary>
	/// 初始
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// 設定 SignalR 允許 Cors 跨域
		/// </summary>
		/// <param name="app"></param>
		public void Configuration(IAppBuilder app)
		{
			var hubConfiguration = new HubConfiguration();
			app.Map("/signalr", map =>
			{
				map.UseCors(CorsOptions.AllowAll);

				hubConfiguration.EnableJSONP = true;
				map.RunSignalR(hubConfiguration);
			});
			app.MapSignalR(hubConfiguration);
		}
	}
}