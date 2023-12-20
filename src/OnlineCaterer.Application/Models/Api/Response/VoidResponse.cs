using Newtonsoft.Json;
using OnlineCaterer.Application.Models.Api.Error;

namespace OnlineCaterer.Application.Models.Api.Response
{
	public class VoidResponse
	{
		// fields
		private readonly HashSet<ErrorInfo> _errors = new();

		// can modify props
		public object? Id { get; set; }
		public string? Message { get; set; }

		// read only props
		public bool Success => _errors.Count == 0;
		public ICollection<ErrorInfo>? Errors => _errors;

		// methods
		public void AddError(ErrorInfo error)
		{
			_errors.Add(error);
		}

		public void AddErrors(IEnumerable<ErrorInfo> errors)
		{
			foreach (var error in errors)
			{
				AddError(error);
			}
		}

		public string ToJson()
		{
			return JsonConvert.SerializeObject(
				value: this,
				settings: new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore,
				}
			);
		}
	}
}
