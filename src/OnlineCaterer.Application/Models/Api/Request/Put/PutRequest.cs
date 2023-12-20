namespace OnlineCaterer.Application.Models.Api.Request.Put
{
	public abstract class PutRequest<TBody>
		where TBody : class
	{
		public TBody Body { get; set; } = null!;
	}
}
