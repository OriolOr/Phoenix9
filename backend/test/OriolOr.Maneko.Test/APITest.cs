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
        public async void APITest_GetCurrentBalance_400BadRequest()
        {
            var response = await client.GetAsync("https://localhost:7171/Account/GetCurrentBalance");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void APITest_GetYearData_400BadRequest()
        {
            var response = await client.GetAsync("https://localhost:7171/Account/GetYearData");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void APITest_LogInUser_400BadRequest()
        {
            var httpContent = new StringContent("", Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7171/LoginCredentials", httpContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async void APITest_SigInUser_400BadRequest()
        {
            var httpContent = new StringContent("{'password' : '1234'}", Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7171/SignInUser", httpContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}