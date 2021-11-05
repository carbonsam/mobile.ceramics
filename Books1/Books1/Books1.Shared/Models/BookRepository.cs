using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Books1.Shared.Services;

namespace Books1.Shared.Models
{
    public class BookRepository : IBookRepository, INotifyPropertyChanged
    {
        private readonly IOpenLibraryApiClient openLibraryApiClient;
        public event PropertyChangedEventHandler? PropertyChanged;

        public BookRepositoryLoadingState LoadingState { get; private set; } = BookRepositoryLoadingState.Done;

        public Author CurrentAuthor { get; private set; } = new Author();

        public List<Work> AuthorWorks { get; private set; } = new List<Work>();

        public BookRepository(IOpenLibraryApiClient openLibraryApiClient)
        {
            this.openLibraryApiClient = openLibraryApiClient;
        }

        public async Task GetAuthorWorks(string name)
        {
            LoadingState = BookRepositoryLoadingState.Busy;

            try
            {
                CurrentAuthor = await openLibraryApiClient.FindAuthorAsync(name);
                
                var works = await openLibraryApiClient.GetAuthorWorksAsync(CurrentAuthor);
                AuthorWorks.Clear();
                foreach (var item in works)
                {
                    AuthorWorks.Add(item);
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AuthorWorks)));
            }
            catch (Exception e)
            {
                LoadingState = BookRepositoryLoadingState.Error;
            }

            LoadingState = BookRepositoryLoadingState.Done;
        }
    }
}
