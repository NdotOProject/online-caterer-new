using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OnlineCaterer.Application.Models.Api.Error;
using System.Reflection;

namespace OnlineCaterer.Application.Models.Api.Response
{
	public class ShouldSerializeContractResolver : DefaultContractResolver
	{
		public static readonly ShouldSerializeContractResolver Instance = new();

		protected override JsonProperty CreateProperty(
			MemberInfo member, MemberSerialization memberSerialization)
		{
			JsonProperty property = base.CreateProperty(member, memberSerialization);

			if (property.PropertyName == "Errors")
			{
				property.ShouldSerialize =
					instance =>
					{
						VoidResponse response = (VoidResponse)instance;
						return !response.Success;
					};
			}

			return property;
		}
	}

	public class VoidResponse
	{
		public object? Id { get; set; }
		public string? Message { get; set; }

		public bool Success => Errors.Count == 0;
		public ICollection<ErrorInfo> Errors { get; } = new HashSet<ErrorInfo>();

		public void AddError(ErrorInfo error)
		{
			Errors.Add(error);
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
					Formatting = Formatting.Indented,
					NullValueHandling = NullValueHandling.Ignore,
					DefaultValueHandling = DefaultValueHandling.Ignore,
					ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
					ContractResolver = ShouldSerializeContractResolver.Instance
				}
			);
		}
	}
}
