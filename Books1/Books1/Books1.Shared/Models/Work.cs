using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Books1.Shared.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Work
    {
        public string Key { get; set; }

        public string Title { get; set; }
        
        // TODO: Add book cover
    }
}
