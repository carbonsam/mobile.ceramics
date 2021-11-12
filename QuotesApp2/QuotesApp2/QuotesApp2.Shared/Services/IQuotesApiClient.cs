using System.Threading.Tasks;
using QuotesApp2.Shared.Models;

namespace QuotesApp2.Shared.Services
{
    public interface IQuotesApiClient
    {
        public Task<Quote> GetQuoteOfTheDay();
    }
}
