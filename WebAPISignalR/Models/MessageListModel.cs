using System.Collections.Generic;

namespace WebAPISignalR.Models
{
	/// <summary>
	/// 訊息列表模型
	/// </summary>
	public static class MessageListModel
	{
		/// <summary>
		/// 設立static以保存內容
		/// </summary>
		public static List<MessageModel> Messages { get; set; } = new List<MessageModel>()
		{
			new MessageModel {Message="預設的內容" }
		};

		/// <summary>
		/// 加入訊息
		/// </summary>
		/// <param name="message"></param>
		public static void AddMessage(string message)
		{
			Messages.Add(new MessageModel { Message = message });
		}
	}
}