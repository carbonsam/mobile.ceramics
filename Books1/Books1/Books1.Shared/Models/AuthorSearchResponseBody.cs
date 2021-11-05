using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Books1.Shared.Models
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class AuthorSearchResponseBody
    {
        public IEnumerable<Author> Docs { get; set; }
    }
}
