using Microsoft.AspNet.SignalR;
using ServiceImpletment;
using ServiceInterface;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Http.Results;
using ViewModel;
using WebAPISignalR.HubClass;

namespace WebAPISignalR.Controllers
{
	/// <summary>
	/// 投票 ApiController
	/// </summary>
	[EnableCors(origins: "*", headers: "*", methods: "*")]
	[RoutePrefix("api/Poll")]
	public class PollController : ApiController
    {
		private readonly IPollManager _pollManager;
		IHubContext hub = GlobalHost.ConnectionManager.GetHubContext<PollHub>();

		/// <summary>
		/// 投票 ApiController
		/// </summary>
		public PollController()
		{
			_pollManager =new PollManager();
		}

		/// <summary>
		/// 取得投票結果列表
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("GetVoteResults")]
		[ResponseType(typeof(List<VoteResultViewModel>))]
		public IHttpActionResult GetVoteResults(int id)
		{
			var dataList = _pollManager.GetPollVoteResults(id);
			return new ResponseMessageResult(Request.CreateResponse(HttpStatusCode.OK, dataList));
		}

		/// <summary>
		/// 加入投票
		/// </summary>
		/// <param name="poll"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("AddPoll")]
		public IHttpActionResult AddPoll(AddPollViewModel poll)
		{
			var result = _pollManager.AddPoll(poll);
			hub.Clients.All.GetVoteResults();
			return new ResponseMessageResult(Request.CreateResponse(HttpStatusCode.OK, result));
		}
	}
}
