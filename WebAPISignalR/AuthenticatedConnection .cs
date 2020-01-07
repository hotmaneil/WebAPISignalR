using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPISignalR
{
	public class AuthenticatedConnection: PersistentConnection
	{
		protected override bool AuthorizeRequest(IRequest request)
		{
			//return request.User.Identity.IsAuthenticated;

			return true;
		}
	}
}