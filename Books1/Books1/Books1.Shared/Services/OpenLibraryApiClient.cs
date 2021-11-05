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

            var author = response.Data.Docs.FirstOrDefault();

            if (author == null)
            {
                throw new HttpRequestException($"No author found ({response.StatusCode}).");
            }

            return author;
        }

        public async Task<IEnumerable<Work>> GetAuthorWorksAsync(Author author)
        {
            var request = new RestRequest($"authors/{author.Key}/works.json", DataFormat.Json);
            request.AddQueryParameter("limit", "500");

            var response = await restClient.ExecuteAsync<WorksSearchResponseBody>(request);

            if (!response.IsSuccessful)
            {
                throw new HttpRequestException($"Could not complete the request ({response.StatusCode}).");
            }

            var works = response.Data.Entries;

            if (works == null)
            {
                throw new HttpRequestException($"No works found for {author.Name} ({response.StatusCode}).");
            }

            return works;
        }
    }
}
