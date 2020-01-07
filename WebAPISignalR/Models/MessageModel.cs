using System.Collections.Generic;

namespace WebAPISignalR.Models
{
	public class MessageModel
	{
		public string Message { get; set; }

		/// <summary>
		/// 設立static以保存內容
		/// </summary>
		public static List<MessageModel> Messages { get; set; } = new List<MessageModel>
		{
			new MessageModel {Message="預設的內容" }
		};

		public static void Add(string message)
		{
			Messages.Add(new MessageModel { Message = message });
		}
	}
}