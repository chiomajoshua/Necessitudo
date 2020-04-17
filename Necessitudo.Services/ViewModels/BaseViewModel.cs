using Necessitudo.Contract;
using System;

namespace Necessitudo.Services.ViewModels
{
	public class BaseViewModel
    {
		public String GetNetworkErrorMessage(AggregateException ex)
		{
			if (ex.InnerException != null && (ex.InnerException as NetworkErrorException) != null)
			{
				var networkException = ex.InnerException as NetworkErrorException;
				return (networkException.Message == null) ? "Unknown Error" : networkException.Message;
			}
			else return string.Empty;
		}
	}
}