namespace OnlineCaterer.Application.Models.Api.Response
{
	public class DataResponse<TPayload> : VoidResponse
	{
		public TPayload? Payload { get; set; }

		public List<object>? Includes { get; set; }

		public void Include<TKey, TValue>(IDictionary<TKey, TValue> dict)
		{
			Includes ??= new();
			foreach (TValue val in dict.Values)
			{
				if (val != null)
				{
					Includes.Add(val);
				}
			}
		}

		public void Include<TElement>(IEnumerable<TElement> value)
		{
			Includes ??= new();
			foreach (TElement val in value)
			{
				if (val != null)
				{
					Includes.Add(val);
				}
			}
		}

		public void Include(object value)
		{
			Includes ??= new();
			Includes.Add(value);
		}
	}
}
