using Dapper;

namespace DataModel.Entities
{
	public class Poll
	{
		[Key]
		public int PollID { get; set; }

		public string Question { get; set; }

		public bool Active { get; set; }
	}
}
