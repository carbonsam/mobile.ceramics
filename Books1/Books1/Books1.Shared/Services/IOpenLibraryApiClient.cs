using System.Collections.Generic;
using Books1.Shared.Models;
using System.Threading.Tasks;

namespace Books1.Shared.Services
{
    public interface IOpenLibraryApiClient
    {
        public Task<Author> FindAuthorAsync(string name);

        public Task<IEnumerable<Work>> GetAuthorWorksAsync(Author author);
    }
}
