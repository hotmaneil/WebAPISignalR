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
		
		/// <summary>
		/// 取得廣播訊息
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("Get")]
		public IHttpActionResult Get(MessageModel model)
		{
			MessageListModel.AddMessage(model.Message);

			//新增完成去觸發signlar，以通知client更新
			hub.Clients.All.ReceiveMsg(MessageListModel.Messages);
			return Ok();
		}

		/// <summary>
		/// 顯示單一訊息
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("ShowSingleMessage")]
		public IHttpActionResult ShowSingleMessage(MessageModel model)
		{
			hub.Clients.All.SingleMessage(model.Message);
			return Ok();
		}
	}
}
