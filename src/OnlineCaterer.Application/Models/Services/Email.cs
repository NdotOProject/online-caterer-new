namespace OnlineCaterer.Application.Models.Services
{
	public class Email
	{
		public string To { get; }
		public string Subject { get; }
		public string Body { get; }

		public Email(string to, string subject, string body)
		{
			To = to;
			Subject = subject;
			Body = body;
		}

	}
}
