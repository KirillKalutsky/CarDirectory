
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CarDirectory.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class ApiResponse
    {
        public object Data { get; set; }
        public int StatusCode { get; set; }
        public string Error { get; set; }
    }

}
