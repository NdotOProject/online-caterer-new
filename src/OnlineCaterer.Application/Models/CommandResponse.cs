using Newtonsoft.Json;

namespace OnlineCaterer.Application.Models
{
    public class CommandResponse<TData>
    {
        public bool Success { get; set; } = false;
        public string? Message { get; set; }
        public ICollection<string>? Errors { get; set; }

        public TData? Data { get; set; }
        public List<object>? Includes { get; set; }

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
