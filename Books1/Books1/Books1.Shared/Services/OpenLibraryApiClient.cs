using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Books1.Shared.Models;
using RestSharp;

namespace Books1.Shared.Services
{
    public class OpenLibraryApiClient : IOpenLibraryApiClient
    {
        private readonly IRestClient restClient;
        
        public OpenLibraryApiClient()
        {
            restClient = new RestClient("https://openlibrary.org");
        }
        
        public async Task<Author> FindAuthorAsync(string name)
        {
            var request = new RestRequest("search/authors.json", DataFormat.Json);
            request.AddQueryParameter("q", name);
            
            var response = await restClient.ExecuteAsync<AuthorSearchResponseBody>(request);

            if (!response.IsSuccessful)
            {
                throw new HttpRequestException($"Could not complete the request ({response.StatusCode}).");
            }
            
            return response.Data.Docs.FirstOrDefault();
        }

        public Task<IEnumerable<Work>> GetAuthorWorksAsync(string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
