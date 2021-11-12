using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using FluentAssertions;
using QuotesApp2.Shared.Services;
using Xunit;

namespace QuotesApp2.Shared.Test.Services
{
    public class QuotesApiClientTest
    {
        private readonly TestRequestHandler testRequestHandler = new TestRequestHandler();
        private readonly HttpClient httpClient;
        
        public QuotesApiClientTest()
        {
            httpClient = new HttpClient(testRequestHandler) { BaseAddress = new Uri("https://localhost") };
        }
        
        [Fact]
        public async void GetQuoteOfTheDay_ExpectSuccess()
        {
            HttpRequestMessage? sentRequest = null;
            var client = new QuotesApiClient(httpClient);
            testRequestHandler.SendBehavior = request =>
            {
                sentRequest = request;
                return TestUtilities.GetHttpResponseMessage("QuoteOfTheDaySuccessResponse.json", HttpStatusCode.OK);
            };

            var result = await client.GetQuoteOfTheDay();
            
            result.Should().NotBeNull();
        }

        [Fact]
        public async void GetQuoteOfTheDay_NullSerialization_ExpectExceptionThrown()
        {
            HttpRequestMessage? sentRequest = null;
            var client = new QuotesApiClient(httpClient);
            testRequestHandler.SendBehavior = request =>
            {
                sentRequest = request;
                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(string.Empty) };
            };

            Func<Task> result = async () => await client.GetQuoteOfTheDay();

            await result.Should().ThrowAsync<SerializationException>().WithMessage("Unable to deserialize response from Quotes API**");
        }

        [Fact]
        public async void GetQuoteOfTheDayCategories_ExpectSuccess()
        {
            HttpRequestMessage? sentRequest = null;
            var client = new QuotesApiClient(httpClient);
            testRequestHandler.SendBehavior = request =>
            {
                sentRequest = request;
                return TestUtilities.GetHttpResponseMessage("QuoteOfTheDayCategoriesSuccessResponse.json", HttpStatusCode.OK);
            };

            var result = await client.GetQuoteOfTheDay();
            
            result.Should().NotBeNull();
        }

        [Fact]
        public async void GetQuoteOfTheDayCategories_NullSerialization_ExpectExceptionThrown()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async void GetQuotesFromCategory_ExpectSuccess()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public async void GetQuotesFromCategory_NullSerialization_ExpectExceptionThrown()
        {
            throw new NotImplementedException();
        }
    }
}
