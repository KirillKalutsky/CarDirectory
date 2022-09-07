using Newtonsoft.Json;

namespace CarDirectory.Models.Dto
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class StatisticsDto
    {
        public DateTime? FirstNoteCreate { get; set; }
        public int TotalItemCount { get; set; }
        public DateTime? LastNoteCreate { get; set; }
    }
}
