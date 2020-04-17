using System;

namespace Necessitudo.Contract
{
	public class NetworkErrorException : Exception
	{
		private readonly string _message;

		public override string Message
		{
			get
			{
				return _message;
			}
		}

		public NetworkErrorException(string message)
		{
			this._message = message;
		}
	}
}