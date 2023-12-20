namespace OnlineCaterer.Application.Models.Api.Request.Post
{
	public abstract class PostRequest<TBody>
		where TBody : class
	{
		public TBody Body { get; set; } = null!;
	}
}
