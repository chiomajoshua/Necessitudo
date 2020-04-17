using Flurl.Http;
using Necessitudo.Engine.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Necessitudo.Engine
{
    public class BaseEngine
    {
		public HttpClientUtil httpClientUtil = new HttpClientUtil();
		public string HandleHttpError(FlurlHttpException ex)
		{
			string errorMessage;
			if (ex.InnerException?.GetType() == typeof(TaskCanceledException))
			{
				errorMessage = "We can't complete this action because there was a timeout.";
			}
			else if (ex.Call.Response == null)
			{

				errorMessage = "Oops something went wrong. " + ex;

			}
			else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.BadRequest)
			{
				var msg = ex.GetResponseStringAsync().Result;
				var response = ex.GetResponseJsonAsync<Dictionary<string, object>>().Result;
				if (response.ContainsKey("error"))
				{
					errorMessage = response["error"] as string;
				}
				else
				{
					errorMessage = ex.GetResponseStringAsync().Result;
				}
			}
			else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.Forbidden)
			{
				errorMessage = "Oops. You are not permitted to access this resource.";

			}
			else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.GatewayTimeout)
			{
				errorMessage = "This resource is on a very old slow server with 10kb connection.";

			}
			else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
			{

				errorMessage = "Oops. Something went wrong. Please try again.";

			}
			else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
			{
				errorMessage = "You do not have the required access to this resource.";
			}
			else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
			{
				errorMessage = "We can't find the resource you are looking for.";

			}
			else if (ex.Call.Response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
			{
				errorMessage = "We are sorry. The server is currently unavailable. Please try again later.";
			}
			else
			{
				errorMessage = ex.GetResponseStringAsync().Result;
			}
			return errorMessage;
		}
	}
}
