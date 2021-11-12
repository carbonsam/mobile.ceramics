using Newtonsoft.Json;

namespace QuotesApp2.Shared.Models
{
    public class Quote
    {
        public string Id { get; set; }

        public string Author { get; set; }

        [JsonProperty("quote")]
        public string Content { get; set; }
        
        public string Image { get; set; }
        
        public int Length { get; set; }
    }
}
