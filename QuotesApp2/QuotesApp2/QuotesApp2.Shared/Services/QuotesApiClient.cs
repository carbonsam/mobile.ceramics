using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using QuotesApp2.Shared.Models;

namespace QuotesApp2.Shared.Services
{
    public class QuotesApiClient : IQuotesApiClient
    {
        private readonly HttpClient httpClient;

        public QuotesApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        
        public async Task<Quote> GetQuoteOfTheDay()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "qod");

            var response = await httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            var deserializedResponse = JsonConvert.DeserializeObject<QuoteOfTheDayResponseBody>(responseContent);

            if (deserializedResponse == null)
            {
                throw new SerializationException($"Unable to deserialize response from Quotes API. Content: {responseContent}");
            }

            return deserializedResponse.QuoteContents.Quotes.FirstOrDefault();
        }
    }
}
