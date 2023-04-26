using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using OriolOr.Maneko.API;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace OriolOr.Maneko.Test
{
    public class APITest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient client;
        private readonly string uri; 


        public APITest(WebApplicationFactory<Program> factory)
        {
            client = factory.CreateClient();
        }

        [Fact]
        public async void SigInUser()
        {
            var httpContent = new StringContent("aaaaa;", Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7171/LoginCredentials", httpContent);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}