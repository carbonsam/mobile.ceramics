using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Books1.Shared.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Author
    {
        public string Key { get; set; }

        public string Name { get; set; }

        // TODO: Convert to DateTime
        public string BirthDate { get; set; }

        // TODO: Convert to DateTime
        public string DeathDate { get; set; }
        
        public int WorkCount { get; set; }
        
        // TODO: Add author picture
    }
}
