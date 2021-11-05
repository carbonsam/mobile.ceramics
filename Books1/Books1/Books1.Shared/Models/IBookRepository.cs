using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Books1.Shared.Models
{
    public interface IBookRepository
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public BookRepositoryLoadingState LoadingState { get; }

        public Author CurrentAuthor { get; }

        public List<Work> AuthorWorks { get; }

        public Task GetAuthorWorks(string name);
    }
}
