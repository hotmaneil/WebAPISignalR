using Microsoft.AspNet.SignalR;
using WebAPISignalR.Models;

namespace WebAPISignalR.HubClass
{
	/// <summary>
	/// 廣播 Hub
	/// </summary>
	public class BroadcastHub:Hub
	{
		/// <summary>
		/// 接收訊息
		/// </summary>
		public void ReceiveMsg()
		{
			Clients.All.ReceiveMsg(MessageListModel.Messages);
		}
	}
}