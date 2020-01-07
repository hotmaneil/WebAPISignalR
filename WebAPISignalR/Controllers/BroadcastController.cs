using Microsoft.AspNet.SignalR;
using System.Web.Http;
using System.Web.Http.Cors;
using WebAPISignalR.HubClass;
using WebAPISignalR.Models;

namespace WebAPISignalR.Controllers
{
	/// <summary>
	/// 廣播 ApiController
	/// https://localhost:44369/
	/// </summary>
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api/Broadcast")]
	public class BroadcastController : ApiController
    {
		IHubContext hub = GlobalHost.ConnectionManager.GetHubContext<BroadcastHub>();
		
		[HttpPost]
		[Route("Get")]
		public IHttpActionResult Get(MsgModel model)
		{
			MessageModel.Add(model.message);

			//新增完成去觸發signlar，以通知client更新
			hub.Clients.All.ReceiveMsg(MessageModel.Messages);
			return Ok();
		}
	}
}
