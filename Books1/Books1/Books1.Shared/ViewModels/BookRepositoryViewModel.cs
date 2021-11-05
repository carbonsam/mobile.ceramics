using System.Collections.Generic;
using System.ComponentModel;
using Books1.Shared.Models;
using PropertyChanged;

namespace Books1.Shared.ViewModels
{
    public class BookRepositoryViewModel : INotifyPropertyChanged
    {
        private readonly IBookRepository bookRepository;

        public event PropertyChangedEventHandler? PropertyChanged;

        public BookRepositoryLoadingState LoadingState => bookRepository.LoadingState;

        public Author CurrentAuthor => bookRepository.CurrentAuthor;

        public List<Work> AuthorWorks => bookRepository.AuthorWorks;

        [DependsOn(nameof(CurrentAuthor))]
        public string AuthorImageSource => $"https://covers.openlibrary.org/a/olid/{CurrentAuthor.Key}-M.jpg";

        public string AuthorSearchTerm { get; set; } = string.Empty;

        public BookRepositoryViewModel(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
            this.bookRepository.PropertyChanged += (sender, args) => PropertyChanged?.Invoke(this, args);
        }

        public void GetAuthorWorks()
        {
            bookRepository.GetAuthorWorks(AuthorSearchTerm);
        }
    }
}
