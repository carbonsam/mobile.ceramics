using System.Collections.Generic;
using Books1.Shared.Models;
using System.Threading.Tasks;

namespace Books1.Shared.Services
{
    public interface IOpenLibraryApiClient
    {
        Task<Author> FindAuthorAsync(string name);

        Task<IEnumerable<Work>> GetAuthorWorksAsync(string key);
    }
}
