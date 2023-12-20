using System.Net;

namespace OnlineCaterer.Application.Models.Api.Error
{
	public class ErrorList
	{
		private readonly ICollection<ErrorInfo> _value;
		private Reader? _reader;

		public ErrorList()
		{
			_value = new List<ErrorInfo>();
		}

		public void Add(HttpStatusCode httpStatus, string errorMessage)
		{
			_value.Add(new ErrorInfo(httpStatus, errorMessage));
		}

		public Reader GetReader()
		{
			_reader ??= new(this);
			return _reader;
		}

		public class Reader
		{
			private readonly ICollection<ErrorInfo> _errors;
			public Reader(ErrorList errorList)
			{
				_errors = errorList._value;
			}

			public ICollection<string> GetMessages()
			{
				var messages = new HashSet<string>();
				foreach (var val in _errors)
				{
					messages.Add(val.Message);
				}
				return messages;
			}

			public ErrorInfo GetError(int index)
				=> _errors.ElementAt(index);

			public ICollection<ErrorInfo> GetErrors() => _errors;
		}
	}
}
