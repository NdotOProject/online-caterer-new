using System.Net;

namespace OnlineCaterer.Application.Models.Api.Error
{
	public class ErrorInfo
	{
		public ErrorInfo(
			HttpStatusCode statusCode, string message)
		{
			StatusCode = statusCode;
			Message = message;
		}

		public HttpStatusCode StatusCode { get; }
		public string Message { get; }
	}
}
