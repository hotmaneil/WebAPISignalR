using Microsoft.AspNet.SignalR;
using WebAPISignalR.Models;

namespace WebAPISignalR.HubClass
{
	public class BroadcastHub:Hub
	{
		public void ReceiveMsg()
		{
			Clients.All.ReceiveMsg(MessageModel.Messages);
		}
	}
}