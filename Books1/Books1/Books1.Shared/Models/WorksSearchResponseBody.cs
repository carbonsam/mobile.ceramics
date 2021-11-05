using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Books1.Shared.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class WorksSearchResponseBody
    {
        public int Size { get; set; }

        public IEnumerable<Work> Entries { get; set; }
    }
}
