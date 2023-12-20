namespace OnlineCaterer.Application.Exceptions
{
	public class NotFoundException : ApplicationException
	{
		public NotFoundException() : base("The record not found!")
		{
		}

		public NotFoundException(string message) : base(message)
		{
		}
	}
}
