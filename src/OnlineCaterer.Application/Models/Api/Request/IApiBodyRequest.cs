namespace OnlineCaterer.Application.Models.Api.Request
{
	public interface IApiBodyRequest<TBody> : IApiRequest
		where TBody : class, IRequestBody
	{
		public TBody Body { get; set; }
	}
}
